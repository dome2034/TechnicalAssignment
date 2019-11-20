using System;
using System.Globalization;

namespace TechnicalAssignment.Utils
{
    public static class Extension
    {
        private static DateTime _default = new DateTime(1970, 1, 1, 0, 0, 0);
        public static readonly string DATE_FORMAT = "dd/MM/yyyy HH:MM";

        public static long ToUnixTimestamp(this string datetimeString)
        {
            DateTime datetime = DateTime.ParseExact(datetimeString, DATE_FORMAT, CultureInfo.InvariantCulture);
            return ToUnixTimestamp(datetime);
        }

        public static long ToUnixTimestamp(this DateTime dt)
        {
            return (dt.Ticks - _default.Ticks) / 10000000;
        }

        public static DateTime FromUnixTimestamp(this long timestamp)
        {
            return _default.AddSeconds(timestamp);
        }

        public static T AsEnum<T>(this string enumString)
        {
            return (T)Enum.Parse(typeof(T), enumString, true);
        }
    }
}