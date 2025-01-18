using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListCLI.Class
{
    public abstract class BdConnection
    {
        private string _connectionString;
        protected MySqlConnection connection;

        public BdConnection(string server, string db, string user, string port)
        {
            //_connectionString = $"server={server}:{port};uid={user};database={db}";
             _connectionString = $"server={server};port={port};database={db};user={user};";


        }
        public void Abrir()
        {
            connection = new MySqlConnection(_connectionString);
            connection.Open();
        }
        public void Cerrar()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

    }
}
