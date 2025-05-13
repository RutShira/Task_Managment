using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Enums;

namespace Task_Management.interfaces
{
    public interface ITask
    {
        int LoggedTime { get; set; }
        int EstimationTime { get; }
    }
}
