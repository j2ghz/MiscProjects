/*****************************************************************************
 * Altairis TrackGPS sample application for Microsoft .NET Framework 3.5     *
 * Copyright (c) Michal Altair Valášek - Altairis, s. r. o., 2007            *
 *               http://www.rider.cz/    http://www.altairis.cz/             *
 * This code is licensed under terms of Microsoft Public License (Ms-PL)     *
 *****************************************************************************/

using System;
using System.Globalization;

namespace Altairis.GPS {

    /// <summary>
    /// This class represents one item (record) of NMEA track log.
    /// </summary>
    public class TrackPoint {
        // Helper constants
        private const int EarthRadius = 6378137;                                                    // Semi-major axis of WGS84 reference ellipsoid (in meters)
        private static readonly double DegToRad = Math.PI / 180.0;                                  // Multiplier to convert degrees to radians
        private static readonly string[] TimeFormats = { "ddMMyyHHmmss", "ddMMyyHHmmss\\.fff" };    // Date/time formats recognized in logs

        // Simple properties - self descripting
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Speed { get; set; }
        public decimal Bearing { get; set; }
        public decimal MagneticVariation { get; set; }
        public DateTime Time { get; set; }
        public bool Fix { get; set; }

        /// <summary>
        /// Computes approximate distance of two TrackPoints using the Haversine formula and WGS84 reference ellipsoid.
        /// </summary>
        /// <param name="other">Second track point.</param>
        /// <returns>Computed aerial distance in meters.</returns>
        public int DistanceTo(TrackPoint other) {
            if (other == null) throw new ArgumentNullException("other");
            if (this.SameLocationAs(other)) return 0;

            // Details about mathematical origin of the following algorithm may be found
            // for example at http://mathforum.org/library/drmath/view/51879.html
            double dLat = (double)(other.Latitude - this.Latitude) * DegToRad;
            double dLon = (double)(other.Longitude - this.Longitude) * DegToRad;
            double a = Math.Pow(Math.Sin(dLat / 2), 2) + Math.Cos((double)this.Latitude * DegToRad) * Math.Cos((double)other.Latitude * DegToRad) * Math.Pow(Math.Sin(dLon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return (int)Math.Round(Math.Abs(EarthRadius * c));
        }

        /// <summary>
        /// Checks if two TrackPoints have the same location (Lat, Lon).
        /// </summary>
        /// <param name="other">Second track point.</param>
        /// <returns>Returts <c>true</c> if location is the same, <c>false</c> otherwise.</returns>
        public bool SameLocationAs(TrackPoint other) {
            if (other == null) return false;
            return this.Latitude == other.Latitude && this.Longitude == other.Longitude;
        }

        /// <summary>
        /// Parses RMC sentence into TrackPoint class.
        /// </summary>
        /// <param name="sentence">String containing GPRMC sentence (including $ and checksum).</param>
        /// <returns>Parsed instance of TrackPoint class.</returns>
        public static TrackPoint FromRMC(string sentence) {
            // Validate arguments
            if (sentence == null) throw new ArgumentNullException("sentence");
            if (string.IsNullOrEmpty(sentence)) throw new ArgumentException("Value cannot be null or empty string.", "sentence");
            if (!Utils.ValidateNmeaChecksum(sentence)) throw new FormatException("Invalid NMEA sentence checksum.");

            // Remove checksum and split
            sentence = sentence.Remove(sentence.IndexOf('*'));  // Remove checksum
            string[] words = sentence.Split(',');               // Split to words
            if (words.Length < 12) throw new FormatException(string.Format("Invalid number of words in NMEA sentence. Expecting at least 10 words, present {0}.", words.Length));
            if (!words[0].Equals("$GPRMC")) throw new FormatException("RMC sentence must begin with '$GPRMC'.");

            // Prepare track point
            TrackPoint tp = new TrackPoint();

            // Get date and time
            if (string.IsNullOrEmpty(words[1]) || string.IsNullOrEmpty(words[9])) return null;
            DateTime dt;
            if (!DateTime.TryParseExact(words[9] + words[1], TimeFormats, null, DateTimeStyles.None, out dt)) return null;
            tp.Time = DateTime.SpecifyKind(dt, DateTimeKind.Utc);

            // Get fix
            tp.Fix = words[2].Equals("A");

            // Get latitude
            if (string.IsNullOrEmpty(words[3]) || string.IsNullOrEmpty(words[4])) return null;
            tp.Latitude = Utils.SmartParseDegrees("0" + words[3]);
            if (words[4].Equals("S")) tp.Latitude = -tp.Latitude;   // Set negative value for southern hemisphere

            // Get longitude
            if (string.IsNullOrEmpty(words[5]) || string.IsNullOrEmpty(words[6])) return null;
            tp.Longitude = Utils.SmartParseDegrees(words[5]);
            if (words[6].Equals("W")) tp.Longitude = -tp.Longitude; // Set negative value for western hemisphere

            // Get speed in knots
            tp.Speed = Utils.SmartParseDecimal(words[7]);

            // Get bearing
            tp.Bearing = Utils.SmartParseDecimal(words[8]);

            // Get magnetic variation
            if (words.Length > 10 && !string.IsNullOrEmpty(words[10]) && !string.IsNullOrEmpty(words[11])) {
                tp.MagneticVariation = Utils.SmartParseDecimal(words[10]);
                if (words[11].Equals("W")) tp.MagneticVariation = -tp.MagneticVariation;
            }

            return tp;
        }

        /// <summary>
        /// Implements comparsion of two TrackPoints based on time measured.
        /// </summary>
        /// <param name="x">First TrackPoint.</param>
        /// <param name="y">Second TrackPoint.</param>
        /// <returns>See System.Comparsion&lt;T&gt; delegate.</returns>
        public static int CompareByTime(TrackPoint x, TrackPoint y) {
            if (x == null) {
                if (y == null) return 0;
                else return -1;
            }
            else {
                if (y == null) return 1;
                else return x.Time.CompareTo(y.Time);
            }
        }

    }
}