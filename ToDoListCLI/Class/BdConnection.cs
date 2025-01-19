using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ToDoListCLI.Class
{
    public abstract class BdConnection
    {
        private string _connectionString;
        protected SqliteConnection connection;

        //public BdConnection(string server, string db, string user, string port)
        public BdConnection(string paht)
        {
            //_connectionString = $"server={server}:{port};uid={user};database={db}";
            _connectionString = $@"DataSource={paht}";


        }
        public void Abrir()
        {
            connection = new SqliteConnection(_connectionString);
            connection.Open();
        }
        public void Cerrar()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

    }
}
