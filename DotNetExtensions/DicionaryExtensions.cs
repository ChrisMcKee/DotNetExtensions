using System.Collections.Generic;

namespace DotNetExtensions
{
    public static class DicionaryExtensions
    {
        public static Dictionary<string, string> ToStringString<T>(this Dictionary<string,T> dictionary)
        {
            var stringStringDictionary = new Dictionary<string, string>();
            foreach (var entry in dictionary)
            {
                stringStringDictionary.Add(entry.Key,entry.Value.ToStringOrNull());
            }
            return stringStringDictionary;
        }
    }
}
