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
    }
}