using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DotNetExtensions
{
    public static class ObjectExtensions
    {
        public static string GetFriendlyName(this Type type)
        {
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
            return type.Name;
        }

        public static string GetFriendlyTypeName(this object obj)
        {
            Type type = obj.GetType();
            if (type.IsGenericType && type.Name.IndexOf('`') >= 0)
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

            return type.Name;
        }

        public static bool In<T>(this T source, params T[] list)
        {
            // ReSharper disable CompareNonConstrainedGenericWithNull
            if (source == null) throw new ArgumentNullException("source");
            // ReSharper restore CompareNonConstrainedGenericWithNull
            return list.Contains(source);
        }

        public static T[] InArray<T>(this T obj)
        {
            return new T[] { obj };
        }

        public static List<T> InList<T>(this T obj)
        {
            return new List<T> { obj };
        }

        public static bool NotNullAndIn<T>(this T source, params T[] list)
        {
            // ReSharper disable CompareNonConstrainedGenericWithNull
            return source != null && source.In(list);
            // ReSharper restore CompareNonConstrainedGenericWithNull
        }

        public static Dictionary<string, object> ReflectToDictionary<T>(this T source)
        {
            var properties = typeof(T).GetProperties();
            return properties.ToDictionary(propertyInfo => propertyInfo.Name, propertyInfo => propertyInfo.GetValue(source, null));
        }

        public static byte ToByte(this object obj)
        {
            return Convert.ToByte(obj);
        }

        /// <summary>
        /// Trims a string if it is not null.
        /// If null then null is returned.
        /// Cleans calling code.
        /// </summary>
        /// <param name="object"></param>
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

        public static string ToXml<T>(this T t)
        {
            var serializer = new XmlSerializer(typeof(T));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();
            using (var stringWriter = new StringWriter(sb))
            {
                serializer.Serialize(stringWriter, t, namespaces);
            }

            return sb.ToString();
        }
    }
}