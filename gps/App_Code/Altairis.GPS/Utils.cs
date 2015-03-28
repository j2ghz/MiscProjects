/*****************************************************************************
 * Altairis TrackGPS sample application for Microsoft .NET Framework 3.5     *
 * Copyright (c) Michal Altair Valášek - Altairis, s. r. o., 2007            *
 *               http://www.rider.cz/    http://www.altairis.cz/             *
 * This code is licensed under terms of Microsoft Public License (Ms-PL)     *
 *****************************************************************************/

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Altairis.GPS {

    /// <summary>
    /// This class contains general helper methods for working with GPS data.
    /// </summary>
    public static class Utils {

        // Multipliers for conversions of international knots to more user friendly units
        public const decimal KnotsToMPH = 1.150779M;    // miles per hour (MPH)
        public const decimal KnotsToKMH = 1.852000M;    // kilometers per hour (km/h)
        public const decimal KnotsToMPS = 0.514444M;    // meters per second (m/s)

        /// <summary>
        /// Validate checksum on NMEA sentence
        /// </summary>
        /// <param name="sentence">NMEA sentence to validate checksum of</param>
        /// <returns>Returns <c>true</c> if checksum is valid, <c>false</c> if checksum is invalid, missing or cannot be computed.</returns>
        public static bool ValidateNmeaChecksum(string sentence) {
            if (!sentence.StartsWith("$")) return false; // sentence must begin with $
            if (sentence.IndexOf('*') == -1 || sentence.EndsWith("*")) return false; // sentence must contain *

            // Compute checksum
            int checksum = 0;
            for (int i = 0; i < sentence.Length; i++) {
                if (sentence[i] == '$') continue;
                if (sentence[i] == '*') break;
                if (checksum == 0) checksum = Convert.ToByte(sentence[i]);
                else checksum ^= Convert.ToByte(sentence[i]);
            }

            // Compare with received checksum
            return sentence.Substring(sentence.IndexOf('*') + 1).Equals(checksum.ToString("X2"), StringComparison.Ordinal);
        }

        internal static decimal SmartParseDecimal(string s) {
            if (string.IsNullOrEmpty(s)) return 0;
            decimal d = 0; decimal.TryParse(s, NumberStyles.Number, NumberFormatInfo.InvariantInfo, out d);
            return d;
        }

        internal static decimal SmartParseDegrees(string s) {
            if (s == null) throw new ArgumentNullException("s");
            if (string.IsNullOrEmpty(s)) throw new ArgumentException("Value cannot be null or empty string.", "s");
            if (!Regex.IsMatch(s, @"^[0-9]{5}(\.[0-9]+)?$")) throw new FormatException();

            decimal d = decimal.Parse(s.Substring(0, 3));
            decimal m = decimal.Parse(s.Substring(3), NumberStyles.Number, NumberFormatInfo.InvariantInfo);
            d += m / 60.0M;
            return d;
        }

    }
}