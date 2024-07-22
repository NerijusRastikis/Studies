using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pirma
{
    internal class Person
    {
        public Person(int height)
        {
            Height = height;
        }
        public Person(string name, int age, int height) : this(height)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age} {Height}";
        }
    }
}
