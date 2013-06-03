using System;
using System.Linq;
using NUnit.Framework;
using DotNetExtensions;
// ReSharper disable InconsistentNaming

namespace Tests
{
    [TestFixture]
    public class LinqExtensionsTests
    {
        Tuple<int,string> one = Tuple.Create(1, "one");
        Tuple<int,string> two  = Tuple.Create(2, "two");
        Tuple<int,string> three = Tuple.Create(3, "three");


        [Test]
        public void OrderBy_WorksFine()
        {
            var tuples = new[]
                             {
                                 three,
                                 two,
                                 one
                             };

            var result = tuples.OrderBy("Item1").ToList();

            for (int i = 1; i <=3; i++)
            {
                Assert.That(result[i-1].Item1,Is.EqualTo(i));
                
            }
        }

    }
}