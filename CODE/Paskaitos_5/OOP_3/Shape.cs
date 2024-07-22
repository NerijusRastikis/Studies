using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    internal class Shape
    {
        public virtual string Draw()
        {
            int sideLength = 1;
            int radius = 1;
            return $"Basic figure square's side length is {sideLength}. Basic figure circle's radius is {radius}.";
        }
    }
}
