using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListCLI.Class
{
    internal class DbToDoList : BdConnection
    {
        public DbToDoList(string server, string db, string user, string port) : base(server, db, user, port)
        {

        }
        public List<TasksToDoList> GetAllTasks()
        {
            Abrir();
            string strState, strPriority;
            var allTask = new List<TasksToDoList>();
            string query = "SELECT * FROM todolist.tasks; ";
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                int idTask = mySqlDataReader.GetInt32(0);
                string taskName = mySqlDataReader.GetString(1);
                DateTime taskLimitTime = mySqlDataReader.GetDateTime(2);
                DateTime taskCreation = mySqlDataReader.GetDateTime(3);
                DateTime taskUpdate = mySqlDataReader.GetDateTime(4);
                int idFkState = mySqlDataReader.GetInt32(5);
                int idFkPriority = mySqlDataReader.GetInt32(6);
                strState = Funciones.GetStatus(idFkState);
                strPriority = Funciones.GetPriority(idFkPriority);


                allTask.Add(new TasksToDoList(idTask, taskName, taskLimitTime, taskCreation, taskUpdate, strState, strPriority));

            }
            Cerrar();
            return allTask;
        }
    }
}
