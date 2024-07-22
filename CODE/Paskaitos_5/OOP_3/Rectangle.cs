using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    internal class Rectangle : Shape
    {
        public override string Draw()
        {
            return "The rectangle actually has two different length sides: 1 and 2";
        }
    }
}
