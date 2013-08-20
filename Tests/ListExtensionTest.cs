using System.Collections.Generic;
using DotNetExtensions;
using NUnit.Framework;
// ReSharper disable InconsistentNaming
namespace Tests
{
    [TestFixture]
    public class ListExtensionTest
    {
        [Test]
        public void Shuffle_WorksFine()
        {
            //arrange
            var list1 = new List<int>
                            {
                                1,2,3,4,5,6,7,8,9,0,11,12,13,14,15,16
                            };
            var list2 = new List<int>
                            {
                                1,2,3,4,5,6,7,8,9,0,11,12,13,14,15,16
                            };
            //assume
            CollectionAssert.AreEqual(list1,list2);

            //act
            list1.Shuffle();
            list2.Shuffle();

            //assert
            CollectionAssert.AreEqual(list1, list2);
        }

        [Test]
        public void Shuffle_MaintainsEquivalency()
        {
            //arrange
            var list1 = new List<int>
                            {
                                1,2,3,4,5,6,7,8,9,0,11,12,13,14,15,16
                            };
            var list2 = new List<int>
                            {
                                1,2,3,4,5,6,7,8,9,0,11,12,13,14,15,16
                            };
            //assume
            CollectionAssert.AreEqual(list1, list2);

            //act
            list1.Shuffle();
            list2.Shuffle();

            //assert
            CollectionAssert.AreEquivalent(list1, list2);
        }
    }
}