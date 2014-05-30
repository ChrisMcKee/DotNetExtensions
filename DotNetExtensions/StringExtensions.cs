using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNetExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        ///  Allows for more succinct coalescing on empty strings e.g. <br/>
        ///  var city = string.IsNullOrWhiteSpace(Address.City) ? "No City" : Address.City;<br/>
        ///  vs <br/>
        ///  var city = Address.City.CoalesceNullOrWhiteSpace("No City");
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static string CoalesceNullOrWhiteSpace(this string s1, string s2)
        {
            return string.IsNullOrWhiteSpace(s1) ? s2 : s1;
        }

        public static bool ToBool(this string str)
        {
            int i;
            if (int.TryParse(str,out i))
            {
                return Convert.ToBoolean(i);
            }
            if (str.Length == 1)
            {
                if (str.ToLower() == "f")
                {
                    return false;
                }
                if (str.ToLower() == "t")
                {
                    return true;
                }
            }
            return Convert.ToBoolean(str);
        }
        public static double ToDouble(this string str)
        {
            return Convert.ToDouble(str);
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

        public static Guid ToGuid(this string s)
        {
            return Guid.Parse(s);
        }

        public static long ToLong(this string str)
        {
            if (str != null && str.Contains("."))
            {
                str = str.Split(new[]
                                    {
                                        '.'
                                    })[0];
            }
            return Convert.ToInt64(str);
        }

        public static string FullStopBeforeCapital(this string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            var newText = new StringBuilder(s.Length * 2);
            newText.Append(s[0]);

            for (int i = 1; i < s.Length; i++)
            {
                if (char.IsUpper(s[i]) && (s[i - 1] != ' ' && s[i - 1] != '.'))
                    newText.Append('.');

                newText.Append(s[i]);
            }
            return newText.ToString();
        }


        public static string Replace(this string source, string oldString, string newString, StringComparison comp)
        {
            int index = source.IndexOf(oldString, comp);

            // Determine if we found a match
            bool matchFound = index >= 0;

            if (matchFound)
            {
                // Remove the old text
                source = source.Remove(index, oldString.Length);

                // Add the replacemenet text
                source = source.Insert(index, newString);
            }

            return source;
        }

        public static String TitleCase(this string s)
        {
            if (s == null) return s;

            String[] words = s.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 0) continue;

                Char firstChar = Char.ToUpper(words[i][0]);
                String rest = "";
                if (words[i].Length > 1)
                {
                    rest = words[i].Substring(1).ToLower();
                }
                words[i] = firstChar + rest;
            }
            return String.Join(" ", words);
        }

        public static Stream ToStream(this string str)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static string FormatWith(this string format, params object[] args)
        {
            try
            {
                if (format == null)
                    throw new ArgumentNullException("format");

                return string.Format(format, args);
            }
            catch
            {
                return format;
            }
        }

        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static bool IsNullOrWhitespace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static bool IsTrimmed(this string str)
        {
            return str.Trim().Equals(str);
        }

        public static bool IsNotNullOrEmpty(this string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        public static bool IsNotNullOrWhiteSpace(this string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        [Obsolete("Use TrimOrDefault")]
        public static string TrimOrNull(this string input)
        {
            return TrimOrDefault(input);
        }

        public static string TrimOrDefault(this string input)
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
            if (str == null)
            {
                return null;
            }
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

        public static bool In(this string str, StringComparison strComparison, params string[] list)
        {
            if (list == null)
            {
                return false;
            }
            if (str == null && list.Contains(null))
            {
                return true;
            }
            if (str == null)
            {
                return false;
            }
            return list.Any(listItem => str.Equals(listItem, strComparison));
        }

        public static string TryRemoveSpaces(this string str)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    str = str.Replace(" ", "");
                }
            }
            // ReSharper disable EmptyGeneralCatchClause - method name implies errors will be swallowed
            catch { }
            // ReSharper restore EmptyGeneralCatchClause
            return str;
        }

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

    }
}