using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    internal class Person
    {
        protected string name = "Thomas";
        protected int age = 34;
        protected void PrintInfo()
        {
            Console.WriteLine($"{name} is {age} years old.");
        }
    }
}
