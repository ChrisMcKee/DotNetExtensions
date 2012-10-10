using System;

namespace DotNetExtensions
{
    public static class TimeSpanExtensions
    {
        public static TimeSpan Seconds(this int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan Days(this int days)
        {
            return TimeSpan.FromDays(days);
        }

        public static TimeSpan Minutes(this int minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }

        public static TimeSpan Years(this int years)
        {
            double yearsInHours = 8765.81*years;
            return TimeSpan.FromHours(yearsInHours);
        }

        public static DateTime YearsAgo(this int years)
        {
            var dt = DateTime.UtcNow;
            return new DateTime(dt.Year - years, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }

        public static TimeSpan Milliseconds(this int milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds);
        }

        public static int SecondsAsMilliseconds(this int seconds)
        {
            return Convert.ToInt32(TimeSpan.FromSeconds(seconds).TotalMilliseconds);
        }
    }
}