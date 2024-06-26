namespace Libraries.Classes.Db
{
    public class DbConnection
    {
        private static SqlConnection Connection { get; set; }
        public static SqlConnection CreateConnection(string login, string pwd)
        {
            Connection = new SqlConnection($"server=HOME-PC\\MSSERVER;database=Libraries;user={login};pwd={pwd}");
            return Connection;
        }
        public static SqlConnection OpenConnection()
        {
            Connection.Open();
            return Connection;
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
