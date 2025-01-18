using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListCLI.Class
{
    [Obsolete]
    internal class StateToDoList
    {
        public int IdState { get; set; }
        public string StateTask { get; set; }

        public StateToDoList(int idState, string stateTask)
        {

            IdState = idState;
            StateTask = stateTask;
        }
    }
}
