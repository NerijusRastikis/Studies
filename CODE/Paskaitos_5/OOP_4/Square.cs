using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    internal class Square : GeometricShape
    {
        public Square(int a, int b, string name) : base(a, b, name)
        {
        }

        public override double GetArea()
        {
            return A * B;
        }

        public override double GetPerimeter()
        {
            return (A + B) * 2;
        }
    }
}
