namespace Tests
{
    using System;
    using DotNetExtensions;
    using NUnit.Framework;

    [TestFixture]
    public class UriExtensionTests
    {

        [TestCase("http://foo.bar?",0)]
        [TestCase("http://foo.bar#baz", 0)]
        [TestCase("http://foo.bar?a=b", 1)]
        [TestCase("http://foo.bar?a=b&", 1)]
        [TestCase("http://foo.bar?a=b&c=d", 2)]
        [TestCase("http://foo.bar?a=b&c", 2)]
        public void QueryStringToDictionary_KeyCountCorrect(string url, int actualKeyCount)
        {
            //arrange
            Uri uri = new Uri(url);

            //act
            var dictionary =  uri.QueryStringToDictionary();

            //assert
            Assert.That(dictionary.Keys.Count,Is.EqualTo(actualKeyCount));
        }

        [TestCase("http://foo.bar?a=b", "a","b")]
        [TestCase("http://foo.bar?a=b&", "a","b")]
        [TestCase("http://foo.bar?a=b&c=d", "c","d")]
        [TestCase("http://foo.bar?a=b&c", "c","")]
        public void QueryStringToDictionary_KeyCountCorrect(string url, string key,string expectedValue)
        {
            //arrange
            Uri uri = new Uri(url);

            //act
            var actualValue = uri.QueryStringToDictionary()[key];

            //assert
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
