using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    internal class Circle
    {
        public double Radius { get; set; }
        public double CircleArea()
        {
        return Math.PI * Math.Pow(Radius, 2); 
        }
        public double CirclePerimeter()
        {
            return 2 * (Math.PI * Radius);
        }
    }
}
