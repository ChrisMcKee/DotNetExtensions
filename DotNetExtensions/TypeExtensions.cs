using System;
using System.Text;

namespace DotNetExtensions
{
    public static class TypeExtensions
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
    }
}