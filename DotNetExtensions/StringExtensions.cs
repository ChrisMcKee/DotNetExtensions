using System;
using System.Text.RegularExpressions;

namespace DotNetExtensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string str, int defaultVal)
        {
            if (str != null && str.Contains("."))
            {
                str = str.Split(new[]
                                    {
                                        '.'
                                    })[0];
            }
            int result;
            if (!int.TryParse(str, out result))
            {
                result = defaultVal;
            }
            return result;
        }

        public static string FormatWith(this string format, params object[] args)
        {
            if (format == null)
                throw new ArgumentNullException("format");

            return string.Format(format, args);
        }

        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static bool IsNotNullOrEmpty(this string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        public static int ToInt(this string str)
        {
            if (str != null && str.Contains("."))
            {
                str = str.Split(new[]
                                    {
                                        '.'
                                    })[0];
            }
            return Convert.ToInt32(str);
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