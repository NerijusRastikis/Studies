using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    internal class Circle : Shape
    {
        Circle(double radius)
        {
            Radius = radius;
        }
        public double Radius { get; set; }
        public sealed override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
