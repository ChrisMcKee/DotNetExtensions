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
        public void ToString(object obj, string result)
        {
            Assert.That(obj.ToStringOrNull(), Is.EqualTo(result));
        }

        [TestCase("dan","Dan")]
        [TestCase("hElLo", "Hello")]
        [TestCase(null,null)]
        [TestCase("Title","Title")]
        public void TitleCase(string input, string expectedOutput)
        {
            Assert.That(input.TitleCase(),Is.EqualTo(expectedOutput));
        }

        [TestCase("a b", "ab")]
        [TestCase("a  b", "ab")]
        [TestCase(null, null)]
        [TestCase("       a    b  ", "ab")]
        [TestCase("          ", "")]
        public void TryRemoveSpaces(string input, string expectedOutput)
        {
            Assert.That(input.TryRemoveSpaces(), Is.EqualTo(expectedOutput));
        }


        [TestCase("a", true)]
        [TestCase("a a", true)]
        [TestCase("a ", false)]
        [TestCase(" a", false)]
        [TestCase(" ", false)]
        [TestCase("", true)]
        public void IsTrimmed(string str,bool trimmed)
        {
            Assert.That(str.IsTrimmed(),Is.EqualTo(trimmed));
        }

        [TestCase("a", true, true, new []{"a"})]
        [TestCase("a", true, false, new[] { "A" })]
        [TestCase("a", false, true, new[] { "A" })]
        [TestCase(null, false, true, new[] { "A", null })]
        [TestCase(null, true, true, new[] { "A", null })]
        [TestCase(null, true, false, null)]
        public void In(string str, bool caseSensitive, bool expected, string[] list)
        {
            Assert.That(str.In(caseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase,list),
                Is.EqualTo(expected));
        }
    }
}
