using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetExtensions
{
    public static class ObjectExtensions
    {
        public static string GetFriendlyTypeName(this object obj)
        {
            Type type = obj.GetType();
            if (type.IsGenericType)
            {
                var sb = new StringBuilder();
                sb.Append(type.Name.Remove(type.Name.IndexOf('`')));
                sb.Append("<");
                Type[] arguments = type.GetGenericArguments();
                for (int i = 0; i < arguments.Length; i++)
                {
                    sb.Append(arguments[i].GetFriendlyName());
                    if (i + 1 < arguments.Length)
                    {
                        sb.Append(", ");
                    }
                }
                sb.Append(">");
                return sb.ToString();
            }
        }

        public static bool In<T>(this T source, params T[] list)
        {
            // ReSharper disable CompareNonConstrainedGenericWithNull
            if (source == null) throw new ArgumentNullException("source");
            // ReSharper restore CompareNonConstrainedGenericWithNull
            return list.Contains(source);
        }

        public static List<T> InList<T>(this T obj)
        {
            return new List<T> { obj };
        }

        public static bool NotNullAndIn<T>(this T source, params T[] list)
        {
            if (source == null)
            {
                return false;
            }
            return source.In(list);
        }

        public static Dictionary<string, object> ReflectToDictionary<T>(this T source)
        {
            var dictionary = new Dictionary<string, object>();
            var properties = typeof(T).GetProperties();
            foreach (var propertyInfo in properties)
            {
                dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(source, null));
            }
            return dictionary;
        }

        /// <summary>
        /// Trims a string if it is not null.
        /// If null then null is returned.
        /// Cleans calling code.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>null or trimmed string</returns>
        public static string ToStringOrNull(this object @object)
        {
            string @string = null;
            if (@object != null)
            {
                @string = @object.ToString();
            }
            return @string;
        }
    }
}