using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    internal class Dog : Animal
    {
        public sealed override void MakeSound()
        {
            Console.WriteLine("Woof woof");
        }
    }
}
