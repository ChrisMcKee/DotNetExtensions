using System;
using System.Collections.Generic;

namespace Tests.MockObjects
{
    public class Person
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public bool Deleted { get; set; }
        public Sex Sex { get; set; }
        public Guid Guid { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }

        public static List<string> PublicPropertiesAsStrings()
        {
            return new List<string>
                       {
                           "DateOfBirth",
                           "DateOfDeath",
                           "Deleted",
                           "Guid",
                           "Height",
                           "Name",
                           "Sex"
                       };
        }
    }
}
