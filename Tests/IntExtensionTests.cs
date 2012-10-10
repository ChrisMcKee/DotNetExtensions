using System;
using DotNetExtensions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class IntExtensionTests
    {
        [Test]
        public void YearsAgo()
        {
            DateTime dt = 20.YearsAgo();

            Assert.That(dt.Year, Is.EqualTo(DateTime.UtcNow.Year - 20));
        }
    }
}
