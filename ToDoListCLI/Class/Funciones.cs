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
                return "Ingrese un numero valido";
        }
        public static string GetStatus(int x)
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




    }
}
