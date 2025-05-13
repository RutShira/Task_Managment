using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Enums;
using Task_Management.interfaces;
using Task_Management.Models.MomentoPattern;
using Task_Management.Models.StatePattern;


namespace Task_Management.Models
{
    public class Task:ITask
    {
        private readonly Stack<TaskHistory> hisrory = new Stack<TaskHistory>();
       
       // public  TaskCaretaker history { get; } = new TaskCaretaker();
        public DateTime CreationDate { get;  set; }
        public string Title { get;  set; }
        public string Description { get;  set; }

        private User _assignee;
        public User Assignee { get { return _assignee; } set {  Save(); _assignee = value; } }

        private User _reporter;
        public User Reporter { get { return _reporter; } set {  Save(); _reporter = value; } }

        private Priority _priority;
        public Priority Priority { get{ return _priority; } set { Save(); _priority = value;  } }

        private IState _status;
        public IState Status { get { return _status; } set {  _status = value; Emit($"Task status changed to: {Status}"); } }
        public List<Task>? Tasks { get; set; }
        public List<INotification>? Notifications { get; set; }

        //Observer Pattern
        public void Attach(INotification subscriber)
        {
            if(Notifications==null)
                Notifications=new List<INotification>();
            Notifications.Add(subscriber);
        }
        public void Detach(INotification subscriber)
        {
            Notifications?.Remove(subscriber);
        }
        public void Emit(string message)
        {
            if(Notifications!=null)
            foreach (INotification _notification in Notifications)
            {
                if(_notification!=null)
                _notification.GetMessage(message);
            }
        }



        //Composite Pattern


        private int _estimationTime;
        public int EstimationTime
        {
            set { Save(); _estimationTime = value;  } 
            get
            { 
                return GetEstimatedTime();
                
            }
            
        }

        private int GetEstimatedTime()
        {
            if (Tasks != null) { 
                int totalEstimatedTime = _estimationTime;
            foreach (var task in Tasks)
            {
                totalEstimatedTime += task.GetEstimatedTime();
            }
            return totalEstimatedTime;
        }
            return _estimationTime;
        
        }

        
        
        private int _loggedTime;
        public int LoggedTime {
            set{
                
                _loggedTime += value;
            }
            get {
                return GetLoggedTime(); 
            } 
        }

        private int GetLoggedTime()
        {
            if (Tasks != null)
            {
                int totalLoggedTime = _loggedTime;

                foreach (var task in Tasks)
                {
                    totalLoggedTime += task.GetLoggedTime();
                }
                return totalLoggedTime;
               
            }
            return _loggedTime;
        }
        //State Pattern
        public Task()
        {
            Status = new ToDo(this);
        }

        public void ChangeState(int logTime)
        {
            Status.ChangeState();
            LoggedTime = logTime;
        }
        public void UpdateState(IState nextState)
        {
            Save();
            Status = nextState;
            if (Tasks != null) {
                Tasks.ForEach(task =>
                {
                    task.UpdateState(nextState) ;
                }); 
            }
        }

        //Memento Pattern

        private void Save()
        {
            hisrory.Push(this.SaveToHistory());
        }

        public void Undo()
        {
            if (hisrory.Count != 0)
            {
                TaskHistory memento = hisrory.Pop();
                RestoreFromHistory(memento);

            }
        }
        public void DisplayHistory()
        {
            if (hisrory.Count>0)
            foreach (var memento in hisrory)
            {
                Console.WriteLine($"Status: {memento.Status}, Assignee: {memento.Assignee}, Reporter{memento.Reporter}, Priority: {memento.Priority},LoggedTine{memento.LoggedTime}, EstimationTime{memento.EstimationTime} ");
            }
        }
        private TaskHistory SaveToHistory()
        {
            return new TaskHistory(Status, Assignee,Reporter, Priority,LoggedTime,EstimationTime,Tasks);
        }
        private void RestoreFromHistory(TaskHistory momento)
        {
            Status = momento.Status;
            Assignee = momento.Assignee;
            hisrory.Pop();
            Priority = momento.Priority;
            hisrory.Pop();
            Reporter = momento.Reporter;
            hisrory.Pop();
            LoggedTime= momento.LoggedTime;
            EstimationTime = momento.EstimationTime;
            hisrory.Pop();
            Tasks = momento.Tasks;
           

        }

      

    }
}
