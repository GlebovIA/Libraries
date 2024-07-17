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
                Connection = new SqlConnection($"server=HOME-PC\\MSSERVER;database=Libraries;user={login};pwd={pwd}");
                return Connection;
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
                if (Connection.State == System.Data.ConnectionState.Open) Connection.Close();
                Connection.Open();
                return Connection;
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
