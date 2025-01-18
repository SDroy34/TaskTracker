using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListCLI.Class
{
    public class interfaceClass
    {
        public void RunView()
        {
            ShowMenu();
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
    }
}
