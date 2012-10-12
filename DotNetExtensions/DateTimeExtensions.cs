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
            return new DateTime(newYear,newMonth ,newDay, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
        }
    }
}