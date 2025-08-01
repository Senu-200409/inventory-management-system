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


            _connectionString = string.Format("Data Source=SENU_RY; " +
              "Initial Catalog=inventory_db;" +
              "Integrated Security=True; " +
              "MultipleActiveResultSets=true;" +
              "Max Pool Size=600;");

        }

        public SqlConnection GetOpenConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public SqlDataReader ReadTable(string query)
        {
            SqlConnection connection = GetOpenConnection();
            SqlCommand command = new SqlCommand(query, connection);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public bool AddEditDel(string query)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                int affectedRows = command.ExecuteNonQuery();
                return affectedRows > 0;
            }
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

        internal bool AddEditDel(object query)
        {
            throw new NotImplementedException();
        }
    }
}
