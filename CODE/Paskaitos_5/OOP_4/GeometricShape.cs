using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    public abstract class GeometricShape
    {
        public GeometricShape(int a, int b, string name)
        {
            A = a;
            B = b;
            Name = name;
        }
        public int A { get; set; }
        public int B { get; set; }
        public string Name { get; set; }
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
}
