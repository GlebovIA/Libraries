using Libraries.Classes.Common;
using Microsoft.Data.SqlClient;
using System;
using System.Windows;

namespace Libraries.Classes.Db
{
    public class DbConnection
    {
        private static SqlConnection Connection { get; set; }
        public static SqlConnection CreateConnection(string login, string pwd)
        {
            try
            {
                if (login != "" & pwd != "")
                {
                    Connection = new SqlConnection($"server=HOME-PC\\MSSERVER;database=Libraries;user={login};pwd={Hasher.GetHash(pwd)}");
                    return Connection;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                MessageBox.Show("Не удалось выполнить подключение к базе данных!");
                return null;
            }
        }
        public static void Disconnect()
        {
            Connection.Dispose();
        }
        public static SqlConnection OpenConnection()
        {
            try
            {
                if (Connection != null)
                {
                    Connection.OpenAsync();
                    return Connection;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static void CloseConnection()
        {
            Connection.Close();
            SqlConnection.ClearPool(Connection);
        }
        public static SqlDataReader Query(string sql)
        {
            return new SqlCommand(sql, Connection).ExecuteReader();
        }
    }
}
