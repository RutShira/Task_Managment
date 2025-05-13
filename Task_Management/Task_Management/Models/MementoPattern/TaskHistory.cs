using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Enums;
using Task_Management.interfaces;

namespace Task_Management.Models.MomentoPattern
{
    public class TaskHistory
    {
        public IState Status { get; }
        public User Assignee { get; }
        public Priority Priority { get; }
        public int LoggedTime {  get; }
        public int EstimationTime {  get; }
        public User Reporter {  get; }
        public List<Task>? Tasks { get; }

        public TaskHistory(IState status, User assignee, User reporter, Priority priority, int loggedTime, int estimationTime, List<Task>? tasks)
        {
            Status = status;
            Assignee = assignee;
            Reporter = reporter;
            Priority = priority;
            LoggedTime = loggedTime;
            EstimationTime = estimationTime;
            Tasks = tasks;


        }
       
    }
}
