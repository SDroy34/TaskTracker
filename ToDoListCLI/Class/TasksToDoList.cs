using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListCLI.Class
{
    public class TasksToDoList
    {
        public int IdTask { get; set; }
        public string TaskName { get; set; }
        public DateTime TaskLimitTime {  get; set; }
        public DateTime TaskCreation { get; set; }
        public DateTime TaskUpdate { get; set; }
        public string StrState { get; set; }
        public string StrPriority { get; set; }

        

        public TasksToDoList(int idTask, string taskName, DateTime taskLimitTime, DateTime taskCreation, DateTime taskUpdate, string strState, string idFkPriority)
        {
            IdTask = idTask;
            TaskName = taskName;
            TaskLimitTime = taskLimitTime;
            TaskCreation = taskCreation;
            TaskUpdate = taskUpdate;
            StrState = strState;
            StrPriority = idFkPriority;
            
        }
    }
}
