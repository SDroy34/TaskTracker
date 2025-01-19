using K4os.Compression.LZ4.Encoders;
using K4os.Compression.LZ4.Streams;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace ToDoListCLI.Class
{
    public class interfaceClass
    {
        public void RunView()
        {
            bool Salir = true;
            do
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
                        case 2:
                            Add(db);
                            break;
                        case 3:
                            ShowTasks(db);
                            EditTask(db);
                            break;
                        case 4:
                            ShowTasks(db);
                            EditState(db);
                            break;
                        case 5:
                            ShowTasks(db);
                            EditPriority(db);
                            break;
                        case 6:
                            ShowTasks(db);
                            DeleteTask(db);
                            break;
                        case 7:
                            Salir = false;
                            break;
                        case 0:
                        case 8:
                            Console.WriteLine("Fuera de rango");
                            break;
                        default:
                            break;
                    }
                    db.Cerrar();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            } while (Salir);
        }
        private void ShowMenu()
        {
            Console.WriteLine("Elije una opcion");
            Console.WriteLine("1.- Mostrar tareas");
            Console.WriteLine("2.- Crear tarea");
            Console.WriteLine("3.- Modificar una tarea");
            Console.WriteLine("4.- Cambiar estado de una tarea");
            Console.WriteLine("5.- Cambiar prioridad de una tarea");
            Console.WriteLine("6.- Eliminar tarea");
            Console.WriteLine("7.- Salir");
        }
        private void ShowTasks(DbToDoList db)
        {
            List<TasksToDoList> tasks = db.GetAllTasks();
            foreach (var task in tasks)
                #region
                Console.WriteLine($"{task.IdTask}.- {task.TaskName}\n Fecha limite: {task.TaskLimitTime} \n Fecha creacion: {task.TaskCreation} \n Ultima actalizacion: {task.TaskUpdate} \n Prioridad: {task.StrPriority}  \n Estado: {task.StrState}");
            #endregion
        }
        private void Add(DbToDoList dbToDoList)
        {
            bool convert = false;
            bool band = true;
            int idPriority;
            int idStatus = 1;

            Console.Clear();
            Console.Write("Nombre de tarea: ");
            string taskName = Console.ReadLine();
            Console.Write("Tiempo limite de la tarea (AAAA-MM-DD HH:MM:SS): ");
            DateTime taskLimitTime = DateTime.Parse(Console.ReadLine());
            DateTime taskCreation = DateTime.Now;
            DateTime taskUpdate = DateTime.Now;
            do
            {
                Funciones.ShowPriority();
                Console.Write("Elije el nivel de prioridad: ");
                convert = int.TryParse(Console.ReadLine(), out idPriority);
                if (convert == false || idPriority >= 4 || idPriority < 1)
                {
                    band = true;
                    do
                    {
                        Console.Write("Ingresa otro numero: ");
                        convert = int.TryParse(Console.ReadLine(), out idPriority);
                        if (convert == false || idPriority >= 4 || idPriority < 1)
                        {
                            band = true;
                            Console.WriteLine("Es un numero fuera de rango o no es un numero.");
                        }
                        else
                        {
                            band = false;
                        }

                    } while (band == true);

                }
            } while (band == true);
            var addTask = new TasksToDoList(taskName, taskLimitTime, taskCreation, taskUpdate, idStatus, idPriority);
            dbToDoList.AddTask(addTask);
        }
        private void EditTask(DbToDoList dbToDoList)
        {
            bool convert = false, band = false;
            int idTask;
            Console.Write("Selecciona una tarea: ");
            convert = int.TryParse(Console.ReadLine(), out idTask);
            if (convert == false)
            {
                Console.WriteLine(Funciones.ConverNum(convert));
                do
                {
                    Console.Write("Ingresa un numero: ");
                    convert = int.TryParse(Console.ReadLine(), out idTask);
                    if (convert == false)
                    {
                        Console.WriteLine(Funciones.ConverNum(convert));
                        band = false;
                    }
                    band = true;

                } while (band);
            }
            TasksToDoList task = dbToDoList.GetTask(idTask);
            if (task != null && convert == true)
            {
                Console.Write("Describe la tarea: ");
                string taskDec = Console.ReadLine();
                task.TaskName = taskDec;
                DateTime taskUpdate = DateTime.Now;
                dbToDoList.EditTask(taskDec, taskUpdate);
            }
            else
                Console.WriteLine("La tarea no existe.");
        }
        private void EditState(DbToDoList dbToDoList)
        {
            bool conver = false, band = true;
            int idTask, idStatus;
            Console.Write("Selciona una tarea: ");
            conver = int.TryParse(Console.ReadLine(), out idTask);
            if (conver == false)
            {
                do
                {
                    Console.WriteLine("Lo que ingresaste no es un nuemro.");
                    Console.WriteLine("Elije de nuevo una tarea");
                    conver = int.TryParse(Console.ReadLine(), out idTask);
                    if (conver == false)
                        band = true;
                    else
                        band = false;
                } while (band);
            }
            TasksToDoList task = dbToDoList.GetTask(idTask);
            if (task != null)
            {
                Funciones.ShowStatus();
                Console.Write("Ingresa el estatus: ");
                conver = int.TryParse(Console.ReadLine(), out idStatus);
                if (conver == false || idStatus >= 4 || idStatus < 1)
                {
                    do
                    {
                        Console.WriteLine("El valor no es valido o fuera de rango");
                        Console.Write("Vuleve a ingreasar el estatus: ");
                        conver = int.TryParse(Console.ReadLine(), out idStatus);
                        if (conver == false || idStatus >= 4 || idStatus < 1)
                        {
                            band = true;
                        }
                        else
                            band = false;
                    } while (band);
                }
                band = false;
                DateTime taskUpdate = DateTime.Now;
                dbToDoList.EditStatus(idStatus, taskUpdate);
            }
        }
        private void EditPriority(DbToDoList dbToDoList)
        {
            bool conver = false, band = true;
            int idTask, idPriority;
            Console.Write("Selciona una tarea: ");
            conver = int.TryParse(Console.ReadLine(), out idTask);
            if (conver == false)
            {
                do
                {
                    Console.WriteLine("Lo que ingresaste no es un nuemro.");
                    Console.Write("Elije de nuevo una tarea: ");
                    conver = int.TryParse(Console.ReadLine(), out idTask);
                    if (conver == false)
                        band = true;
                    else
                        band = false;
                } while (band);
            }
            TasksToDoList task = dbToDoList.GetTask(idTask);
            if (task != null)
            {
                Funciones.ShowPriority();
                Console.Write("Ingresa el nivel de prioridad: ");
                conver = int.TryParse(Console.ReadLine(), out idPriority);
                if (conver == false || idPriority >= 4 || idPriority < 1)
                {
                    do
                    {
                        Console.WriteLine("El valor no es valido o fuera de rango");
                        Console.Write("Vuleve a ingreasar el nivel de prioridad: ");
                        conver = int.TryParse(Console.ReadLine(), out idPriority);
                        if (conver == false || idPriority >= 4 || idPriority < 1)
                        {
                            band = true;
                        }
                        else
                            band = false;
                    } while (band);
                }
                band = false;
                DateTime taskUpdate = DateTime.Now;
                dbToDoList.EditPriority(idPriority, taskUpdate);
            }
        }
        private void DeleteTask(DbToDoList dbToDoList)
        {
            bool conver = false, band = false;
            int idTask;
            do
            {
                Console.WriteLine("Escribe el id de la tarea: ");
                conver = int.TryParse(Console.ReadLine(), out idTask);
                if (conver == false)
                {
                    Console.WriteLine(Funciones.ConverNum(conver));
                    band = false;
                }
                else band = true;
            } while (band);
            dbToDoList.DeleteTask(idTask);
        }
    }
}
