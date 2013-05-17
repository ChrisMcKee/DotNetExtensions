using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotNetExtensions
{
    public static class DictionaryExtensions
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

        public static void Add(this IDictionary thisDictionary, IDictionary thatDictionary)
        {
            foreach (var key in thatDictionary.Keys)
            {
                thisDictionary.Add(key, thatDictionary[key]);
            }
        }

        public static TValue TryGetNoneNullValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue @default) where TValue : class
        {
            TValue value;
            if (dictionary.TryGetValue(key, out value))
            {
                return value ?? @default;
            }
            return @default;
        }

        public static void ForEach<T1, T2>(this Dictionary<T1, T2> dictionary, Action<T1, T2> func)
        {
            var keys = dictionary.Select(x => x.Key).ToList();
            foreach (var key in keys)
            {
                func(key, dictionary[key]);
            }
        }
    }
}
