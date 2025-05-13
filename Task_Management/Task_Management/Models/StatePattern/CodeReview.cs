using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Enums;
using Task_Management.interfaces;

namespace Task_Management.Models.StatePattern
{
    public class CodeReview : IState
    {
        private Task _task { get; set; }
        public CodeReview(Task task) 
        {
            _task = task;
        }

        public void ChangeState()
        {
            _task.UpdateState(new QA(_task));
        }

    }
}
