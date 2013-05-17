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
            var enumerable1 = enumerable as T[] ?? enumerable.ToArray(); //prevent multiple enumerations
            if (enumerable1.NullOrEmpty())
            {
                return default(T);
            }
            var list = enumerable1.ToList();
            int index = Rand.Next(list.Count());
            return list[index];
        }

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> enumeration)
        {
            return enumeration ?? Enumerable.Empty<T>();
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

        public static bool NotNullAndAny<T>(this IEnumerable<T> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }

        //allow for cleaner looking and more expressive guards
        public static bool NotNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }

        public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
        {
            foreach (var value in values)
            {
                action(value);
            }
        }

        public static string SelectFirstNotNullOrEmpty<T>(this IEnumerable<T> enumerable, Func<T, string> func)
        {
            return enumerable.Select(func).First(x => x.IsNotNullOrEmpty());
        }

        public static string TrySelectFirstNotNullOrEmpty<T>(this IEnumerable<T> enumerable, Func<T, String> func)
        {
            var enumerable1 = enumerable as T[] ?? enumerable.ToArray();
            string value = enumerable1.Select(func).FirstOrDefault(x => x.IsNotNullOrEmpty());
            if (value == null)
            {
                return enumerable1.Select(func).FirstOrDefault(x => x != null);
            }
            return value;
        }

        public static List<TOutput> ConvertAll<T, TOutput>(this IEnumerable<T> enumerable, Converter<T, TOutput> converter)
        {
            return enumerable.ToList().ConvertAll(converter);
        }

        public static IList<T> RandomSlice<T>(this IList<T> list, int min = 0)
        {
            int lower = Math.Max(0, min);
            lower = Math.Min(lower, list.Count());
            int size = Rand.Next(lower, list.Count() + 1);
            IList<T> result = new List<T>();
            var indexes = new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                indexes.Add(i);
            }

            for (int i = 0; i < size; i++)
            {
                int index = indexes.Random();
                result.Add(list[index]);
                indexes.Remove(index);
            }
            return result;
        }

    }
}