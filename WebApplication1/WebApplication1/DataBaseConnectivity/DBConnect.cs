using System;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication1.Database_Layer
{
    internal class DBconnect : IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public DBconnect()
        {
            //_connectionString = string.Format("Data Source=ito-test020; " +
            //  "Initial Catalog=NOC-OPS;" +
            //  "User id=sa;" +
            //  "Password=admin@123; MultipleActiveResultSets=true;Max Pool Size=600;");


            _connectionString = "Data Source=Senu_RY; Initial Catalog=inventory_db; Integrated Security=True; MultipleActiveResultSets=True;";
        }

        public SqlConnection GetOpenConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public SqlDataReader ReadTable(string readStr)
        {
            SqlConnection connection = GetOpenConnection();
            var command = new SqlCommand(readStr, connection);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public bool AddEditDel(string AddEditDelStr)
        {
            SqlConnection connection = GetOpenConnection();
            var command = new SqlCommand(AddEditDelStr, connection);
            int affectedRows = command.ExecuteNonQuery();
            connection.Close(); // Close the connection after executing the query
            return affectedRows > 0;
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

        internal void ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }
    }
}
