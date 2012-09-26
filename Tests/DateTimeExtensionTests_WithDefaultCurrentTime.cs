using System;
using DotNetExtensions;
using NUnit.Framework;
// ReSharper disable InconsistentNaming
namespace Tests
{
    [TestFixture]
    public class DateTimeExtensionTests_WithDefaultCurrentTime
    {
        [Test]
        public void Within_WhenBehind_WhenInFutureAndWithin()
        {
            Assert.That(DateTime.UtcNow.Subtract(1.Seconds()).Within(2.Seconds()), Is.True);
        }

        [Test]
        public void Within_WhenInFutureAndWithIn()
        {
            Assert.That(DateTime.UtcNow.Add(1.Seconds()).Within(2.Seconds()), Is.True);
        }
    }
}