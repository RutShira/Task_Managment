using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.interfaces;

namespace Task_Management.Models.StatePattern
{
    public class Done : IState
    {
        private Task _task { get; set; }
        public Done(Task task)
        {
            _task = task;
        }

        public void ChangeState()
        {
            Console.WriteLine("The task succes");
        }
    }
}
