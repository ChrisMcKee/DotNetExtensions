using System;
using System.Collections.Generic;

namespace DotNetExtensions
{
    public static class ListExtensions
    {
        public static IList<T> Add<T>(this IList<T> list,params T[] ts)
        {
            foreach (var t in ts)
            {
                list.Add(t);
            }
            return list;
        }

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            var rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}