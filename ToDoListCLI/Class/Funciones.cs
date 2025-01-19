using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListCLI.Class
{
    public static class Funciones
    {
        public static string ConverNum(bool convert)
        {
            if (convert)
                return "";
            else
                return "Ingrese numero valido o numero fuera de rango.";
        }
        public static string GetStatus(int x)
        {
            string strPriority;
            if (x == 1)
                return strPriority = "Pendinte";
            if (x == 2)
                return strPriority = "En Proceso";
            if (x == 3)
                return strPriority = "Completo";
            else
                return strPriority = "Pendiente";
        }
        public static string GetPriority(int x)
        {
            string strPriority;
            if (x == 1)
                return strPriority = "Baja";
            if (x == 2)
                return strPriority = "Media";
            if (x == 3)
                return strPriority = "Alta";
            else
                return strPriority = "Baja";

        }

        public static void ShowStatus()
        {
            Console.WriteLine("Nivle de estatus.");
            Console.WriteLine("1. Pendiente");
            Console.WriteLine("2. En proceso");
            Console.WriteLine("3. Completado");
        }
        public static void ShowPriority()
        {
            Console.WriteLine("Nivle de prioridad.");
            Console.WriteLine("1. Bajo");
            Console.WriteLine("2. Medio");
            Console.WriteLine("3. Alto");
        }
        public static void FormatMessageTask(List<TasksToDoList> tasks)
        {
            
        }



    }
}
