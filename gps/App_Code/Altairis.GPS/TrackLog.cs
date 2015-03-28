/*****************************************************************************
 * Altairis TrackGPS sample application for Microsoft .NET Framework 3.5     *
 * Copyright (c) Michal Altair Valášek - Altairis, s. r. o., 2007            *
 *               http://www.rider.cz/    http://www.altairis.cz/             *
 * This code is licensed under terms of Microsoft Public License (Ms-PL)     *
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Altairis.GPS {

    public enum TrackLogCompressionMethod { None, GZip, Deflate, Auto }

    /// <summary>
    /// This class represents record of one trip, obtained by parsing one or more NMEA log files.
    /// </summary>
    public class TrackLog {
        private static readonly byte[] GZipSignature = { 0x1f, 0x8b, 0x08 };    // First three bytes of GZIP stream (used to detect compression method)

        private List<TrackPoint> points, markers;
        private int totalDistance;

        /// <summary>
        /// Initialize instance of <c>GpsTrackLog</c> class.
        /// </summary>
        public TrackLog() {
            this.ConvertFromUTC = true;
            this.IgnoreNoFix = false;
            this.MarkerInterval = TimeSpan.FromMinutes(60);
            this.PointDistance = 50;
            this.MinimalDistanceForLengthComputation = 5;
            this.points = new List<TrackPoint>();
            this.markers = new List<TrackPoint>();
            this.totalDistance = 0;
        }

        /// <summary>
        /// Clears list of points.
        /// </summary>
        public void Clear() {
            this.points.Clear();
            this.markers.Clear();
        }

        /// <summary>
        /// Imports track points from uncompressed log file.
        /// </summary>
        /// <param name="fileName">Name of file to import from.</param>
        public void Import(string fileName) {
            this.Import(fileName, TrackLogCompressionMethod.None);
        }

        /// <summary>
        /// Imports track points from log file.
        /// </summary>
        /// <param name="fileName">Name of file to import from.</param>
        /// <param name="compression">Used compression method.</param>
        public void Import(string fileName, TrackLogCompressionMethod compression) {
            // Validate arguments
            if (fileName == null) throw new ArgumentNullException("fileName");
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentException("Value cannot be null or empty string.", "fileName");

            // Read from file stream
            using (Stream stream = File.OpenRead(fileName)) this.Import(stream, compression);
        }

        /// <summary>
        /// Imports track points uncompressed from stream.
        /// </summary>
        /// <param name="stream">Stream to import from.</param>
        public void Import(Stream stream) {
            this.Import(stream, TrackLogCompressionMethod.None);
        }

        /// <summary>
        /// Imports track points from stream.
        /// </summary>
        /// <param name="stream">Stream to import from.</param>
        /// <param name="compression">Used compression method.</param>
        public void Import(Stream stream, TrackLogCompressionMethod compression) {
            // Validate arguments
            if (stream == null) throw new ArgumentNullException("stream");

            // Autodetect compression
            if (compression == TrackLogCompressionMethod.Auto) {
                // Read signature (first three bytes)
                byte[] sig = new byte[3];
                stream.Read(sig, 0, 3);
                stream.Seek(0, SeekOrigin.Begin);

                // Compare signature with master
                for (int i = 0; i < 2; i++) {
                    if (!sig[i].Equals(GZipSignature[i])) {
                        compression = TrackLogCompressionMethod.None;
                        break;
                    }
                    if (compression == TrackLogCompressionMethod.Auto) compression = TrackLogCompressionMethod.GZip;
                }
            }

            // Decompress and read
            switch (compression) {
                case TrackLogCompressionMethod.GZip:
                    using (GZipStream dc = new GZipStream(stream, CompressionMode.Decompress))
                    using (TextReader reader = new StreamReader(dc)) {
                        this.Import(reader);
                    }
                    break;
                case TrackLogCompressionMethod.Deflate:
                    using (DeflateStream dc = new DeflateStream(stream, CompressionMode.Decompress))
                    using (TextReader reader = new StreamReader(dc)) {
                        this.Import(reader);
                    }
                    break;
                default:
                    using (TextReader reader = new StreamReader(stream)) this.Import(reader);
                    break;
            }
        }

        /// <summary>
        /// Imports track points from text reader.
        /// </summary>
        /// <param name="reader">Reader to import from.</param>
        public void Import(TextReader reader) {
            TrackPoint currentPoint = null;
            TrackPoint lastDistancePoint = null;
            while (reader.Peek() > -1) {
                string sentence = reader.ReadLine();
                if (!sentence.StartsWith("$GPRMC,")) continue;                                  // Ignore sentences other than GPRMC

                // Read trackpoint from log
                currentPoint = TrackPoint.FromRMC(sentence);
                if (currentPoint == null) continue;                                             // Error while reading track point
                if (this.IgnoreNoFix && !currentPoint.Fix) continue;                            // Ignore no-fix points if requested
                if (this.ConvertFromUTC) currentPoint.Time = currentPoint.Time.ToLocalTime();   // Convert to local time if requested

                // Add to points, if first or distance greater than set minimum
                if (points.Count == 0 || points.Last().DistanceTo(currentPoint) >= this.PointDistance) points.Add(currentPoint);

                // Add to markers if first or time is greater than set minimum
                if (markers.Count == 0 || currentPoint.Time.Subtract(markers.Last().Time) >= this.MarkerInterval) markers.Add(currentPoint);

                // Compute total distance of trip
                if (lastDistancePoint == null) {
                    lastDistancePoint = currentPoint;
                }
                else {
                    int lastDistance = lastDistancePoint.DistanceTo(currentPoint);
                    if (lastDistance > this.MinimalDistanceForLengthComputation) {
                        this.totalDistance += lastDistance;
                        lastDistancePoint = currentPoint;
                    }
                }
            }

            // Add last point to markers and points, if not already there
            if (currentPoint != null) {
                if (!points.Last().SameLocationAs(currentPoint)) points.Add(currentPoint);
                if (!markers.Last().SameLocationAs(currentPoint)) markers.Add(currentPoint);
            }
        }

        /// <summary>
        /// Total time of the trip
        /// </summary>
        public TimeSpan TotalTime {
            get {
                return this.Points.Last().Time.Subtract(this.Points.First().Time);
            }
        }

        /// <summary>
        /// Gets total distance of trip in meters
        /// </summary>
        public int TotalDistance {
            get { return this.totalDistance; }
        }

        /// <summary>
        /// Gets or sets if time used in NMEA log is in UTC (usually true).
        /// </summary>
        public bool ConvertFromUTC { get; set; }

        /// <summary>
        /// Gets or sets if when importing, ignore records with no fix.
        /// </summary>
        public bool IgnoreNoFix { get; set; }

        /// <summary>
        /// Gets or sets interval in which the markers are placed on map.
        /// </summary>
        public TimeSpan MarkerInterval { get; set; }

        /// <summary>
        /// Gets or sets distance in meters in which trace points are placed on map.
        /// </summary>
        public int PointDistance { get; set; }

        /// <summary>
        /// Gets or sets minimal distance used for length computation. 
        /// This is to mitigate limited precision of GPS.
        /// </summary>
        public int MinimalDistanceForLengthComputation { get; set; }

        /// <summary>
        /// Gets array of track points sorted by time.
        /// </summary>
        public TrackPoint[] Points {
            get {
                TrackPoint[] r = this.points.ToArray();
                Array.Sort(r, TrackPoint.CompareByTime);
                return r;
            }
        }

        /// <summary>
        /// Gets unsorted array of marker points.
        /// </summary>
        public TrackPoint[] Markers {
            get {
                TrackPoint[] r = this.markers.ToArray();
                Array.Sort(r, TrackPoint.CompareByTime);
                return r;
            }
        }

    }
}