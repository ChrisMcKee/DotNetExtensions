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
    }
}
