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
        public DateTime TaskLimitTime { get; set; }
        public DateTime TaskCreation { get; set; }
        public DateTime TaskUpdate { get; set; }
        public string? StrState { get; set; }
        public string? StrPriority { get; set; }
        public int IdFkState { get; set; }
        public int IdFkPriority { get; set; }


        public TasksToDoList(int idTask, string taskName, DateTime taskLimitTime, DateTime taskCreation, DateTime taskUpdate, string strState, string strPriority, int idFkState, int idFkPriority)
        {
            IdTask = idTask;
            TaskName = taskName;
            TaskLimitTime = taskLimitTime;
            TaskCreation = taskCreation;
            TaskUpdate = taskUpdate;
            StrState = strState;
            StrPriority = strPriority;
            IdFkState = idFkState;
            IdFkPriority = idFkPriority;

        }
        public TasksToDoList(int idTask, string taskName, DateTime taskLimitTime, DateTime taskCreation, DateTime taskUpdate, int idFkState, int idFkPriority)
        {
            IdTask = idTask;
            TaskName = taskName;
            TaskLimitTime = taskLimitTime;
            TaskCreation = taskCreation;
            TaskUpdate = taskUpdate;
            IdFkState = idFkState;
            IdFkPriority = idFkPriority;

        }
        public TasksToDoList(string taskName, DateTime taskLimitTime, DateTime taskCreation, DateTime taskUpdate, int idFkState, int idFkPriority)
        {
            TaskName = taskName;
            TaskLimitTime = taskLimitTime;
            TaskCreation = taskCreation;
            TaskUpdate = taskUpdate;
            IdFkState = idFkState;
            IdFkPriority = idFkPriority;

        }
    }
}
