using Microsoft.VisualBasic;
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


                allTask.Add(new TasksToDoList(idTask, taskName, taskLimitTime, taskCreation, taskUpdate, strState, strPriority, idFkState, idFkPriority));

            }
            Cerrar();
            return allTask;
        }
        public void AddTask(TasksToDoList addTask)
        {
            Abrir();
            string query = "INSERT INTO tasks(TaskName, taskLimitTime, taskCreation, taskUpdate, idFkState, idFkPriority) " +
                "VALUES(@TaskName, @taskLimitTime, @taskCreation, @taskUpdate, @idFkState, @idFkPriority);";
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            mySqlCommand.Parameters.AddWithValue("@TaskName", addTask.TaskName);
            mySqlCommand.Parameters.AddWithValue("@taskLimitTime", addTask.TaskLimitTime);
            mySqlCommand.Parameters.AddWithValue("@taskCreation", addTask.TaskCreation);
            mySqlCommand.Parameters.AddWithValue("@taskUpdate", addTask.TaskUpdate);
            mySqlCommand.Parameters.AddWithValue("@idFkState", addTask.IdFkState);
            mySqlCommand.Parameters.AddWithValue("@idFkPriority", addTask.IdFkPriority);
            mySqlCommand.ExecuteNonQuery();
            Cerrar();
        }
        public void EditTask(string task, DateTime taskUpdate)
        {
            Abrir();
            string query = "UPDATE todolist.tasks SET TaskName = @TaskName, taskUpdate = @taskUpdate ";
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            mySqlCommand.Parameters.AddWithValue("@TaskName", task);
            mySqlCommand.Parameters.AddWithValue("@taskUpdate", taskUpdate);
            mySqlCommand.ExecuteNonQuery();
            Cerrar();
        }
        public void EditStatus(int idState, DateTime taskUpdate)
        {
            Abrir();
            string query = "UPDATE todolist.tasks SET idFkState = @idFkState, taskUpdate = @taskUpdate ";
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            mySqlCommand.Parameters.AddWithValue("@idFkState", idState);
            mySqlCommand.Parameters.AddWithValue("@taskUpdate", taskUpdate);
            mySqlCommand.ExecuteNonQuery();
            Cerrar();
        }
        public void EditPriority(int idPriority, DateTime taskUpdate)
        {
            Abrir();
            string query = "UPDATE todolist.tasks SET idFkPriority = @idFkPriority, taskUpdate = @taskUpdate ";
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            mySqlCommand.Parameters.AddWithValue("@idFkPriority", idPriority);
            mySqlCommand.Parameters.AddWithValue("@taskUpdate", taskUpdate);
            mySqlCommand.ExecuteNonQuery();
            Cerrar();
        }
        public TasksToDoList GetTask(int id)
        {
            string strState, strPriority;
            Abrir();
            TasksToDoList tasks = null;
            string query = "SELECT * FROM todolist.tasks " +
                "WHERE idTask = @idTask;";
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            mySqlCommand.Parameters.AddWithValue("@idTask", id);
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
                tasks = new TasksToDoList(idTask, taskName, taskLimitTime, taskCreation, taskUpdate, strState, strPriority, idFkState, idFkPriority);
            }
            Cerrar();
            return tasks;

        }


        public void DeleteTask(int idTask)
        {
            Abrir();
            string query = "DELETE FROM todolist.tasks " +
                "WHERE idTask = @idTask;";
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            mySqlCommand.Parameters.AddWithValue("@idTask", idTask);
            mySqlCommand.ExecuteNonQuery();
            Cerrar();
        }
    }
}
