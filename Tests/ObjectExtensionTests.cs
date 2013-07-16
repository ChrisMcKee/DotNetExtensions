using System;
using DotNetExtensions;
using NUnit.Framework;
using Tests.MockObjects;

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
        public void IsNull_1NullObjectDeep_IsTrue()
        {
            var person = new Person();

            bool isNull = person.IsNull(x => x.Contact);
        
            Assert.That(isNull,Is.True);
        }

        [Test]
        public void IsNull_2NullObjectsDeep_IsTrue()
        {
            var person = new Person();

            bool isNull = person.IsNull(x => x.Contact.Address);

            Assert.That(isNull, Is.True);
        }

        [Test]
        public void IsNull_2NotNullObjectsDeep_IsFalse()
        {
            var person = new Person()
                             {
                                 Contact = new Contact
                                               {
                                                   Address = new Address()
                                               }
                             };

            bool isNull = person.IsNull(x => x.Contact.Address);

            Assert.That(isNull, Is.False);
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