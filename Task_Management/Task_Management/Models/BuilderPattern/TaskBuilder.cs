using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Enums;
using Task_Management.interfaces;

namespace Task_Management.Models.BuilderPattern
{
    public class TaskBuilder
    {
        DateTime? creationDate = null;
        string? title = null;
        string? description = null;
        User? assignee = null;
        User? reporter = null;
        Priority? priority = null;
        int? estimationTime = null;
        int? loggedTime = 0;
        List<Task>? tasks ;

        public TaskBuilder(DateTime _creationDate, string _title, User _assignee,int _estimationTime)
        {
            creationDate = _creationDate;
            title = _title;
            assignee = _assignee;
            estimationTime = _estimationTime;
            loggedTime = 0;
        }
        public void AddDescription(string des) { description = des; }
        public void AddReporter(string name, string email, Role role)
        {

            reporter = new User()
            {
                name = name,
                email = email,
                role = role
            };


        }
        
        public void AddPriority(Priority pr) { priority = pr; }
       
        public void AddeLoggedTime(int log) { loggedTime = log; }
        public void AddSubTasks(Task task) {
            if (tasks == null) 
                tasks = new List<Task>();
            tasks.Add(task);
        }
        public Task Build()
        {

            if ( estimationTime == null)
            {

                throw new Exception("Can't build task");
            }
            
            return new Task()
            {
                CreationDate = (DateTime)creationDate,
                Title = title,
                Description = description,
                Assignee = assignee,
                Reporter = reporter,
                Priority = (Priority)priority,
                Tasks = tasks,
                EstimationTime = (int)estimationTime,
                LoggedTime = (int)loggedTime
                
            };

        }
    }


}
