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
    }
}