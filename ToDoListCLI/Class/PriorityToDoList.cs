using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListCLI.Class
{
    [Obsolete]
    internal class PriorityToDoList
    {
        public int IdPriority { get; set; }
        public string PriorityTask { get; set; }

        public PriorityToDoList(int idPriority, string priorityTask)
        {
            IdPriority = idPriority;
            PriorityTask = priorityTask;
        }
    }
}
