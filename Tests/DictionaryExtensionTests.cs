using System.Linq;
using DotNetExtensions;
using NUnit.Framework;
using Tests.MockObjects;
// ReSharper disable InconsistentNaming
namespace Tests
{
    [TestFixture]
    public class DictionaryExtensionTests
    {
        [Test]
        public void ToStringString_ProducesExpectedKeys()
        {
            //arrange
            var person = PersonFactory.Build();

            //act
            var dictionary = person.ReflectToDictionary().ToStringString();
            
            //assert
            CollectionAssert.AreEquivalent(dictionary.Keys.ToList(),Person.PublicPropertiesAsStrings());
        }
    }
}