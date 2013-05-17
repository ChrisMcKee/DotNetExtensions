using System;

namespace DotNetExtensions
{
    public static class DateTimeExtensions
    {
        public static Func<DateTime> CurrentTime = () => DateTime.UtcNow;

        public static bool Within(this DateTime datetime, TimeSpan timeSpan)
        {
            DateTime upper = datetime.Add(timeSpan);
            DateTime lower = datetime.Subtract(timeSpan);
            DateTime currentTime = CurrentTime();
            return currentTime > lower && currentTime < upper;
        }

        public static DateTime CalendarMonthsAgo(this int months)
        {
            var dt = CurrentTime();
            int monthsBack = months % 12;
            int yearsBack = (months - monthsBack) / 12;
            int month = dt.Month;
            if (dt.Month <= monthsBack)
            {
                yearsBack++;
                monthsBack -= dt.Month;
                month = 12;
            }
            int newYear = dt.Year - yearsBack;
            int newMonth = month - monthsBack;
            int newDay = Math.Min(DateTime.DaysInMonth(newYear, newMonth), dt.Day);
            return new DateTime(newYear, newMonth, newDay, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }


        public static DateTime UtcFromMillisecondsSinceEpoch(string value)
        {
            var millisconds = Convert.ToDouble(value.Split('+')[0]);
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddMilliseconds(millisconds);
            return dateTime;
        }

        public static DateTime FloorMilliseconds(this DateTime dt)
        {
            return dt.AddTicks(-(dt.Ticks % TimeSpan.TicksPerSecond));
        }

        /// <summary>
        ///   Convert a long into a DateTime
        /// </summary>
        public static DateTime FromUnixTimestamp(this Int64 self)
        {
            var ret = new DateTime(1970, 1, 1);
            return ret.AddMilliseconds(self);
        }

        public static int MonthsSince(DateTime date)
        {
            var days = DateTime.UtcNow.Subtract(date).TotalDays;
            const double averageDaysInMonths = 365.25 / 12;
            return Convert.ToInt32(days / averageDaysInMonths);
        }

        public static bool Within(this DateTime @this, DateTime @that, TimeSpan timeSpan)
        {
            var difference = @this.Subtract(@that);
            return difference < timeSpan;
        }

        public static DateTime FloorTime(this DateTime utcTime)
        {
            return new DateTime(utcTime.Year, utcTime.Month, utcTime.Day);
        }
    }
}