namespace Tests
{
    using System;
    using DotNetExtensions;
    using NUnit.Framework;

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