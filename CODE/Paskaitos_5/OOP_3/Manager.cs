using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    internal class Manager : Employee
    {
        public override void Greeting()
        {
            Console.WriteLine("Greetings, manager!");
        }
    }
}
