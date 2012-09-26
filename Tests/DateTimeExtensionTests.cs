using System;
using DotNetExtensions;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Tests
{
    [TestFixture]
    public class DateTimeExtensionTests
    {
        [Test]
        public void CurrentTime()
        {
            DateTimeExtensions.CurrentTime = () => new DateTime(2000,1,1);

            Assert.That(DateTimeExtensions.CurrentTime(),Is.EqualTo(new DateTime(2000,1,1)));
        }

        [Test]
        public void CurrentTime_AffectsWithin()
        {
            DateTimeExtensions.CurrentTime = () => new DateTime(2000, 1, 1);

            var dt = new DateTime(2000, 1, 2);

            Assert.That(dt.Within(2.Days()),Is.True);
        }
    }
}
