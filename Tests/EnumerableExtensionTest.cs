 // ReSharper disable PossibleInvalidOperationException
// ReSharper disable InconsistentNaming

namespace Tests
{
    using System;
    using System.Collections.Generic;
    using DotNetExtensions;
    using MockObjects;
    using NUnit.Framework;

    [TestFixture]
    public class EnumerableExtensionTest
    {
        private readonly List<string> nullList = null;
        private readonly List<string> emptyList = new List<string>();

        private readonly List<string> populatedList = new List<string>
        {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g"
        };

        [Test]
        public void EmptyIfNull_WhenNull_ReturnsEmptyList()
        {
            CollectionAssert.AreEquivalent(nullList.EmptyIfNull(), emptyList);
        }

        [Test]
        public void NotNullAndContains_WhenNotNullAndDoesNotContains_ReturnsFalse()
        {
            var list = new List<string>()
            {
                "foo",
                "bar"
            };
            Assert.That(list.NotNullAndContains("baz"), Is.False);
        }

        [Test]
        public void NotNullAndContains_WhenNull_ReturnsFalse()
        {
            List<string> iAmNull = null;
            Assert.That(iAmNull.NotNullAndContains("foo"), Is.False);
        }

        [Test]
        public void NotNullNullAndContains_WhenNotNullAndContains_ReturnsTrue()
        {
            var list = new List<string>()
            {
                "foo",
                "bar"
            };
            Assert.That(list.NotNullAndContains("bar"), Is.True);
        }

        [Test]
        public void NullOrEmpty_WhenEmpty_ReturnsTrue()
        {
            Assert.That(emptyList.NullOrEmpty(), Is.True);
        }

        [Test]
        public void NullOrEmpty_WhenNull_ReturnsFalse()
        {
            Assert.That(nullList.NullOrEmpty(), Is.True);
        }

        [Test]
        public void OrderRandomly_KeepsListEquivalent()
        {
            CollectionAssert.AreEquivalent(populatedList.OrderRandomly(), populatedList);
        }

        [Test]
        public void Random_ReturnsRandomEntry()
        {
            CollectionAssert.Contains(populatedList, populatedList.Random());
        }

        [Test]
        public void TrySelectFirstNoneDefaultValue_ReturnsExpectedDateTime()
        {
            //arrange
            var expected = new DateTime(2016, 4, 1);
            var list = new[]
            {
                default(DateTime),
                expected
            };

            //act
            var actual = list.TrySelectFirstNoneDefaultValue(x => x);

            //assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TrySelectFirstNotNullOrEmpty_WithDates()
        {
            //arrange
            DateTime dt = DateTime.UtcNow;
            var person1 = new Person
            {
                DateOfDeath = dt
            };
            var person2 = new Person();

            //act
            var randoms = new List<Person>
            {
                person1,
                person2
            }.Shuffle();

            //assert
            Assert.That(randoms.TrySelectFirstNotNullOrEmpty(x => x.DateOfDeath).Value, Is.EqualTo(dt));
        }
    }
}