using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    internal class Circle : Shape
    {
        public override string Draw()
        {
            return $"The circle's radius is actually 2 :)";
        }
    }
}
