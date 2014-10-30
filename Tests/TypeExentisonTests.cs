namespace Tests
{
    using DotNetExtensions;
    using NUnit.Framework;
    using Stubs;

    [TestFixture]
    public class TypeExentisonTests
    {
        [Test]
        public void HasInterface_WhenHasInterface_ReturnsTrue()
        {
            bool actual = typeof (Foo).HasInterface<IFoo>();

            Assert.That(actual,Is.True);
        }

        [Test]
        public void IsDefaultCtor_WhenHasDefaultCtor_ReturnsTrue()
        {
            bool actual = typeof (Foo).IsDefaultCtor();

            Assert.That(actual, Is.True);
        }

        [Test]
        public void IsDefaultCtor_WhenNotDefaultCtor_ReturnsFalse()
        {
            bool actual = typeof(Bar).IsDefaultCtor();

            Assert.That(actual, Is.False);
        }

        [Test]
        public void HasInterface_WhenDoesNotHaveInterface_ReturnsFalse()
        {
            bool actual = typeof(Foo).HasInterface<IBar>();

            Assert.That(actual, Is.False);
        }


        [Test]
        public void IsPublicNonDefaultCtor_ReturnsTrue()
        {
            bool actual = typeof(Bar).IsPublicNonDefaultCtor();

            Assert.That(actual, Is.True);
        }

        [Test]
        public void IsPublicNonDefaultCtor_ReturnsFalse()
        {
            bool actual = typeof(Foo).IsPublicNonDefaultCtor();

            Assert.That(actual, Is.False);
        }
    }
}