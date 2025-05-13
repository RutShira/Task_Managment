using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task_Management.Models.ChainOfResponsPattern
{
    public class BaseHandler
    {

        private BaseHandler _next;

        public void SetNext(BaseHandler next)
        {
            _next = next;
        }

        public virtual bool Handle(Task task, User user)
        {
            if (_next != null)
            {
                return _next.Handle(task, user);
            }
            Console.WriteLine($"the user{user.email} can't acsset to task");
            return false;
        }

    }
}
