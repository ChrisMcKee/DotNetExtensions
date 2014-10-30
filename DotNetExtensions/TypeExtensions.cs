using System;
using System.Text;

namespace DotNetExtensions
{
    using System.Linq;

    public static class TypeExtensions
    {
        public static bool IsPublicNonDefaultCtor(this Type type)
        {
            var ctors = type.GetConstructors().Where(x => x.GetParameters().Any());
            return ctors.Any();
        }

        public static bool IsDefaultCtor(this Type type)
        {
            var ctors = type.GetConstructors();
            return ctors.Any(x => !x.GetParameters().Any());
        }

        public static bool HasInterface<T>(this Type type)
        {
            return type.GetInterfaces().Any(x => x == typeof(T));
        }

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
    }
}