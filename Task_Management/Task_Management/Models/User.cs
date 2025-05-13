using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Enums;
using Task_Management.interfaces;

namespace Task_Management.Models
{
    public class User:INotification
    {
        public string name;
        public string email;
        public Role role;

        void INotification.GetMessage(string message)
        {
            Console.WriteLine($"{name} received notification: {message}");
        }
    }
}
