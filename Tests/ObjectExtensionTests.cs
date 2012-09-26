using System;
using DotNetExtensions;
using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Tests
{
    [TestFixture]
    public class ObjectExtensionTests
    {
        [TestCase("d", false)]
        [TestCase(null, false)]
        [TestCase("a", true)]
        public void NotNullAndIn(string val, bool result)
        {
            Assert.That(val.NotNullAndIn("a", "b", "c"), Is.EqualTo(result));
        }

        [Test]
        public void In_WhenFalse()
        {
            Assert.That("d".In("a", "b", "c"), Is.False);
        }

        [Test]
        public void In_WhenNull_Throws()
        {
            Assert.Throws(Is.InstanceOf<Exception>(),
                          () => ((string) null).In("a", "b", "c"));
        }

        [Test]
        public void In_WhenTrue()
        {
            Assert.That("a".In("a", "b", "c"), Is.True);
        }
    }
}