using System;
using System.Collections.Generic;
using DotNetExtensions;
using NUnit.Framework;
using Tests.MockObjects;
// ReSharper disable PossibleInvalidOperationException
// ReSharper disable InconsistentNaming
namespace Tests
{
    [TestFixture]
    public class EnumerableExtensionTest
    {
        readonly List<string> nullList = null;
        private readonly List<string> emptyList = new List<string>();

        private List<string> populatedList = new List<string>
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
        public void NullOrEmpty_WhenEmpty_ReturnsTrue()
        {
            Assert.That(emptyList.NullOrEmpty(), Is.True);
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
            Assert.That(randoms.TrySelectFirstNotNullOrEmpty(x=>x.DateOfDeath).Value,Is.EqualTo(dt));

        }
        [Test]
        public void NullOrEmpty_WhenNull_ReturnsFalse()
        {
            Assert.That(nullList.NullOrEmpty(), Is.True);
        }
        
        [Test]
        public void EmptyIfNull_WhenNull_ReturnsEmptyList()
        {
            CollectionAssert.AreEquivalent(nullList.EmptyIfNull(), emptyList);
        }

        [Test]
        public void Random_ReturnsRandomEntry()
        {
            CollectionAssert.Contains(populatedList,populatedList.Random());
        }

        [Test]
        public void OrderRandomly_KeepsListEquivalent()
        {
            CollectionAssert.AreEquivalent(populatedList.OrderRandomly(), populatedList);
        }
    }
}