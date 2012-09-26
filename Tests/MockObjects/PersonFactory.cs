using System;
using DotNetExtensions;

namespace Tests.MockObjects
{
    public static class PersonFactory
    {
        public static Person Build()
        {
            return new Person
                       {
                           DateOfBirth = DateTime.UtcNow.Subtract(20.Years()),
                           DateOfDeath = null,
                           Deleted = false,
                           Guid = Guid.NewGuid(),
                           Height = 175,
                           Name = "Foo Bar",
                           Sex = Sex.Male
                       };

        }
    }
}
