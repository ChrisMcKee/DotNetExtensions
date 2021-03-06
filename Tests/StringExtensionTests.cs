﻿using System;
using DotNetExtensions;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Tests
{
	[TestFixture]
    public class StringExtensionTests
    {
        [Test]
        public void SplitCamelCase()
        {
            string @string = "ATest";

            string result  = @string.SplitCamelCase();

            Assert.That(result,Is.EqualTo("A Test"));
        }

        [TestCase("abc", 1, "a")]
        [TestCase("abc", 2, "ab")]
        [TestCase("abc", 3, "abc")]
        [TestCase("abc", 4, "abc")]
        [TestCase("abc", -1, "")]
        [TestCase("abc", 0, "")]
        [TestCase(null, 1, "")]
        public void SafeSubString(string subject,int arg,string expected)
        {
			//act
            string actual = subject.SafeSubstring(arg);

			//assert
			Assert.That(actual,Is.EqualTo(expected));
        }

        [TestCase("abcd", 1,1, "b")]
        [TestCase("abcd", 1, 10, "bcd")]
        [TestCase("abcd", 5, 1, "")]
        [TestCase(null, 5, 4, "")]
        public void SafeSubString(string subject, int start,int length, string expected)
        {
            //act
            string actual = subject.SafeSubstring(start,length);

            //assert
            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void SplitCamelCase_DoesNotBreakAcronym()
        {
            string @string = "NASAIsAwesome";

            string result = @string.SplitCamelCase();

            Assert.That(result, Is.EqualTo("NASA Is Awesome"));
        }


        [TestCase("t", true)]
        [TestCase("T", true)]
        [TestCase("1", true)]
        [TestCase("true",true)]
        [TestCase("TrUe", true)]
        [TestCase("f", false)]
        [TestCase("F", false)]
        [TestCase("0", false)]
        [TestCase("false", false)]
        [TestCase("FaLsE", false)]
        public void ToBool_WorksFine(string str, bool expected)
        {
            Assert.That(str.ToBool(), Is.EqualTo(expected));
        }

        [TestCase("2",2)]
        [TestCase("2.4", 2)]
        [TestCase("2.9", 2)]
        public void ToInt_WorksFine(string str, int @int)
        {
            Assert.That(str.ToInt(),Is.EqualTo(@int));
        }

        [TestCase("2", 2)]
        [TestCase("2.4", 2.4)]
        [TestCase("2.9", 2.9)]
        public void ToDouble_WorksFine(string str, double @double)
        {
            Assert.That(str.ToDouble(), Is.EqualTo(@double));
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
        [TestCase("Title", "Title")]
        [TestCase("aN example Title", "An Example Title")]
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


        [TestCase("a", "a")]
        [TestCase("a ", "a")]
        [TestCase(" a ","a")]
        [TestCase(null,null)]
        public void TrimOrDefault(string str, string expected)
        {
            Assert.That(str.TrimOrNull(),Is.EqualTo(expected));
        }
    }
}
