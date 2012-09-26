using System;
using System.Collections.Generic;
using DotNetExtensions;
using NUnit.Framework;
using Tests.MockObjects;
// ReSharper disable InconsistentNaming
namespace Tests
{
    [TestFixture]
    public class ObjectExtensionTests_ReflectToDict
    {
        private Dictionary<string, object> dictionary;
        private Person person;
        public ObjectExtensionTests_ReflectToDict()
        {
            person = PersonFactory.Build();

            dictionary = person.ReflectToDictionary();
        }

        [Test]
        public void ReflectToDict_HandlesGuid()
        {
            Assert.That(dictionary["Guid"], Is.EqualTo(person.Guid));
        }

        [Test]
        public void ReflectToDict_HandlesInt()
        {
            Assert.That(dictionary["Height"], Is.EqualTo(person.Height));
        }

        [Test]
        public void ReflectToDict_HandlesBool()
        {
            Assert.That(dictionary["Deleted"], Is.EqualTo(person.Deleted));
        }


        [Test]
        public void ReflectToDict_HandlesString()
        {
            Assert.That(dictionary["Name"], Is.EqualTo(person.Name));
        }
    }
}
