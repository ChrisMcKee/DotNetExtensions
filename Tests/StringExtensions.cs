using System;
using DotNetExtensions;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Tests
{
    public class StringExtensionTests
    {
        [Test]
        public void SplitCamelCase()
        {
            string @string = "ATest";

            string result  = @string.SplitCamelCase();

            Assert.That(result,Is.EqualTo("A Test"));
        }

        [Test]
        public void SplitCamelCase_DoesNotBreakAcronym()
        {
            string @string = "NASAIsAwesome";

            string result = @string.SplitCamelCase();

            Assert.That(result, Is.EqualTo("NASA Is Awesome"));
        }

        [TestCase("2",2)]
        [TestCase("2.4", 2)]
        [TestCase("2.9", 2)]
        public void ToInt_WorksFine(string str, int @int)
        {
            Assert.That(str.ToInt(),Is.EqualTo(@int));
        }

        [TestCase("2", 6,2)]
        [TestCase("2.4",6, 2)]
        [TestCase("2.9",6, 2)]
        [TestCase("2.9", 6, 2)]
        [TestCase("a", 6, 6)]
        [TestCase(null, 6, 6)]
        public void ToInt_WithDefault_WorksFine(string str,int @default, int @int)
        {
            Assert.That(str.ToInt(@default), Is.EqualTo(@int));
        }

        [TestCase("a", "a")]
        [TestCase(null, null)]
        public void ToString(object obj,string result)
        {
            Assert.That(obj.ToStringOrNull(),Is.EqualTo(result));
        }
    }
}
