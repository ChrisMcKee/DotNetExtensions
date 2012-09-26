using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetExtensions
{
    public static class EnumerableExtensions
    {
        private static readonly Random Rand = new Random();

        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            var enumerable1 = enumerable as T[] ?? enumerable.ToArray();//prevent multiple enumerations
            if (enumerable1.NullOrEmpty())
            {
                return default(T);
            }
            var list = enumerable1.ToList();
            var index = Rand.Next(list.Count());
            return list[index];
        }

        public static bool NullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }

        public static IEnumerable<T> OrderRandomly<T>(this IEnumerable<T> source)
        {
            var rnd = new Random();
            return source.OrderBy(x => rnd.Next());
        }

    }
}