using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetExtensions
{
    public static class UriExtensions
    {
        public static Dictionary<string, string> QueryStringToDictionary(this Uri uri)
        {
            string query = uri.Query;
            var keys = new Dictionary<string, string>();
            if (query.Length > 1)
            {
                string trimmedQuery = query.Substring(1, uri.Query.Length - 1);
                var pairs = trimmedQuery.Split('&');
                var noneEmptyPairs = pairs.Where(x => !string.IsNullOrWhiteSpace(x));
                var splitPairs = noneEmptyPairs.Select(pair => pair.Split('='));
                keys = splitPairs
                    .ToDictionary(a => a[0], a => a.Length > 1 ? a[1] : "");
            }
            return keys;
        }
    }
}
