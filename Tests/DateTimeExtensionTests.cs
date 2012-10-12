using System;
using DotNetExtensions;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Tests
{
    [TestFixture]
    public class DateTimeExtensionTests_WithModifiedCurrentTime
    {
        [Test]
        public void CurrentTime()
        {
            DateTimeExtensions.CurrentTime = () => new DateTime(2000, 1, 1);

            Assert.That(DateTimeExtensions.CurrentTime(), Is.EqualTo(new DateTime(2000, 1, 1)));
        }

        [Test]
        public void CurrentTime_AffectsWithin()
        {
            DateTimeExtensions.CurrentTime = () => new DateTime(2000, 1, 1);

            var dt = new DateTime(2000, 1, 2);

            Assert.That(dt.Within(2.Days()), Is.True);
        }

        [Test]
        public void CalendarMonthsAgo_Simple()
        {
            DateTimeExtensions.CurrentTime = () => new DateTime(2012,10,1);

            var result = 1.CalendarMonthsAgo();

            Assert.That(result,Is.EqualTo(new DateTime(2012,9,1)));
        }

        [Test]
        public void CalendarMonthsAgo_RollOverYear()
        {
            DateTimeExtensions.CurrentTime = () => new DateTime(2012, 10, 1);

            var result = 10.CalendarMonthsAgo();

            Assert.That(result, Is.EqualTo(new DateTime(2011, 12, 1)));
        }

        [Test]
        public void CalendarMonthsAgo_No31stInPreviousMonth()
        {
            DateTimeExtensions.CurrentTime = () => new DateTime(2012, 10, 31);

            var result = 1.CalendarMonthsAgo();

            Assert.That(result, Is.EqualTo(new DateTime(2012, 9, 30)));
        }

        [Test]
        public void CalendarMonthsAgo_LeapYEar()
        {
            DateTimeExtensions.CurrentTime = () => new DateTime(2012, 2, 29);

            var result = 36.CalendarMonthsAgo();

            Assert.That(result, Is.EqualTo(new DateTime(2009, 2, 28)));
        }
    }
}