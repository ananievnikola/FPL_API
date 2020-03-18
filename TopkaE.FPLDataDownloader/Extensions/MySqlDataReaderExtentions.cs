using MySql.Data.MySqlClient;
using System;

namespace TopkaE.FPLDataDownloader.Extensions
{
    public static class MySqlDataReaderExtentions
    {
        public static int? SaveReadInt32(this MySqlDataReader reader, string name)
        {
            return Convert.IsDBNull(reader[name]) ? null : (int?)reader[name];
        }

        public static long? SaveReadInt64(this MySqlDataReader reader, string name)
        {
            return Convert.IsDBNull(reader[name]) ? null : (long?)reader[name];
        }

        public static byte? SaveReadByte(this MySqlDataReader reader, string name)
        {
            return Convert.IsDBNull(reader[name]) ? null : (byte?)reader[name];
        }

        public static sbyte? SaveReadSByte(this MySqlDataReader reader, string name)
        {
            return Convert.IsDBNull(reader[name]) ? null : (sbyte?)reader[name];
        }

        public static short? SaveReadShort(this MySqlDataReader reader, string name)
        {
            return Convert.IsDBNull(reader[name]) ? null : (short?)reader[name];
        }

        public static DateTime? SaveReadDateTime(this MySqlDataReader reader, string name)
        {
            return Convert.IsDBNull(reader[name]) ? null : (DateTime?)reader[name];
        }

        
    }
}
