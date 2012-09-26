using System.Text.RegularExpressions;

namespace DotNetExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Trims a string if it is not null.
        /// If null then null is returned.
        /// Cleans calling code.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>null or trimmed string</returns>
        public static string ToStringOrNull(this string input)
        {
            string @string = null;
            if (input != null)
            {
                @string = input.Trim();
            }
            return @string;
        }

        public static string SplitCamelCase(this string str)
        {
            return Regex.Replace(
                Regex.Replace(
                    str,
                    @"(\P{Ll})(\P{Ll}\p{Ll})",
                    "$1 $2"
                ),
                @"(\p{Ll})(\P{Ll})",
                "$1 $2"
            );
        }
    }
}