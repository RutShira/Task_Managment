using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Enums;
using Task_Management.Models.StatePattern;

namespace Task_Management.Models.ChainOfResponsPattern
{
    public class UserQA : BaseHandler
    {
        public override bool Handle(Task task, User user)
        {
            if (user.role == Role.QA)
            {
                if (task == null) return false;
                if (task.Status.GetType() != typeof(InProgress))
                {
                    int loggedTime = 0;
                    //do samsing...+ timer
                    Console.WriteLine($"{task.Assignee.name} QA have acssect {task.Status.GetType()} ");
                    loggedTime = 3;//=timer
                    task.ChangeState(loggedTime);
                    Console.WriteLine($"{task.Assignee.name} QA have acssect {task.Status.GetType()} ");
                    return true;
                }
                Console.WriteLine("No have acssect ");
                return false;

            }
            return base.Handle(task, user);

        }
    }
}
