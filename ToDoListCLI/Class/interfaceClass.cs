using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListCLI.Class
{
    public class interfaceClass
    {
        public void RunView()
        {
            try
            {

                bool convert = false;
                int opc;
                var db = new DbToDoList("127.0.0.1", "todolist", "root", "3306");
                db.Abrir();
                ShowMenu();
                Console.Write("Seleciona: ");
                convert = int.TryParse(Console.ReadLine(), out opc);
                Console.WriteLine(Funciones.ConverNum(convert));
                switch (opc)
                {
                    case 1:
                        //Mostrar tareas
                        ShowTasks(db);
                        break;
                    default:
                        break;
                }
                db.Cerrar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void ShowMenu()
        {
            Console.WriteLine("Elije una opcion");
            Console.WriteLine("1.- Mostrar tareas");
            Console.WriteLine("2.- Crear tarea");
            Console.WriteLine("3.- Modificar una tarea");
            Console.WriteLine("4.- Cambiar estado de una tarea");
            Console.WriteLine("5.- Cambiar prioridad de una tarea");
            Console.WriteLine("6.- Salir");
        }
        private void ShowTasks(DbToDoList db)
        {
            List<TasksToDoList> tasks = db.GetAllTasks();
            foreach (var task in tasks)
                Console.WriteLine($"{task.IdTask}.- {task.TaskName}; Tiempo limite: {task.TaskLimitTime}; Fecha creacion: {task.TaskCreation}; Ultmia modificacion: {task.TaskUpdate}; Estado: {task.StrState}; Prioridad: {task.StrPriority};");
        }
    }
}
