using System;
using System.Data.SqlClient;

namespace DotNetExtensions
{
    public static class SqlDataReaderExtensions
    {
        public static DateTime GetDateTime(this SqlDataReader reader, string column)
        {
            int ordinal = reader.GetOrdinal(column);
            return reader.GetDateTime(ordinal);
        }

        public static string GetString(this SqlDataReader reader, string column)
        {
            int ordinal = reader.GetOrdinal(column);
            return reader.GetString(ordinal);
        }

        public static int GetInt32(this SqlDataReader reader, string column)
        {
            int ordinal = reader.GetOrdinal(column);
            return reader.GetInt32(ordinal);
        }

        public static int? GetNullableInt32(this SqlDataReader reader, string column)
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
            return reader.GetInt32(ordinal);
        }

        public static decimal? GetNullableDecimal(this SqlDataReader reader, string column)
        {
            int ordinal = reader.GetOrdinal(column);

            if (reader.IsDBNull(ordinal))
            {
                return null;
            }
            return reader.GetDecimal(ordinal);
        }
    }
}