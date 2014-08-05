using System;
using System.Data;

namespace DotNetExtensions
{
    public static class SqlDataReaderExtensions
    {

        public static DateTime GetDateTime(this IDataReader reader, string name)
        {
            return reader.GetDateTime(reader.GetOrdinal(name));
        }

        public static string GetString(this IDataReader reader, string name)
        {
            return reader.GetString(reader.GetOrdinal(name));
        }

        public static decimal? GetNullableDecimal(this IDataReader reader, string name)
        {
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? (decimal?)null : reader.GetDecimal(name);
        }

        public static int GetInt32(this IDataReader reader, string name)
        {
            return reader.GetInt32(reader.GetOrdinal(name));
        }

        public static DateTime? GetNullableDateTime(this IDataReader reader, int ordinal)
        {
            bool isNull = reader.IsDBNull(ordinal);
            return isNull ? (DateTime?)null : reader.GetDateTime(ordinal);
        }

        public static DateTime? GetNullableDateTime(this IDataReader reader, string name)
        {
            var ordinal = reader.GetOrdinal(name);
            bool isNull = reader.IsDBNull(ordinal);
            return isNull ? (DateTime?)null : reader.GetDateTime(name);
        }

        public static decimal GetDecimal(this IDataReader reader, string name)
        {
            int ordinal = reader.GetOrdinal(name);
            var type = reader.GetFieldType(ordinal);
            if (type == typeof(string))
            {
                var str = reader.GetString(ordinal);
                decimal result;
                if (decimal.TryParse(str, out result))
                {
                    return result;
                }
                throw new Exception("Could not parse {0} into decimal".FormatWith(str));
            }
            return reader.GetDecimal(reader.GetOrdinal(name));
        }


        public static int? GetNullableInt32(this IDataReader reader, string column)
        {
            int ordinal = reader.GetOrdinal(column);

            if (reader.IsDBNull(ordinal))
            {
                return null;
            }
            var type = reader.GetFieldType(ordinal);
            if (type == typeof(decimal))
            {
                var @decimal = reader.GetDecimal(ordinal);
                return Convert.ToInt32(@decimal);
            }
            if (type == typeof(string))
            {
                var str = reader.GetString(ordinal);
                int result;
                if (int.TryParse(str, out result))
                {
                    return result;
                }
                else
                {
                    throw new Exception("Could not parse {0} into int".FormatWith(str));
                }
            }
            return reader.GetInt32(ordinal);
        }
    }
}