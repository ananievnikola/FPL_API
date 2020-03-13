using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopkaE.FPLDataDownloader.Extensions
{
    public static class MySqlDataReaderExtentions
    {
        public static int? SaveReadInt32(this MySqlDataReader reader, string name)
        {
            return Convert.IsDBNull(reader[name]) ? null : (int?)reader[name];
        }

        public static DateTime? SaveReadDateTime(this MySqlDataReader reader, string name)
        {
            return Convert.IsDBNull(reader[name]) ? null : (DateTime?)reader[name];
        }

        public static long? SaveReadInt64(this MySqlDataReader reader, string name)
        {
            return Convert.IsDBNull(reader[name]) ? null : (long?)reader[name];
        }
    }
}
