using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    internal class Triangle : GeometricShape
    {
        public Triangle(int a, int b, string name) : base(a, b, name)
        {
        }

        public override double GetArea()
        {
            return (A * B) / 2;
        }

        public override double GetPerimeter()
        {
            return A + (A - B);
        }
    }
}
