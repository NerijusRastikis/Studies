using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    internal class Rectangle
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int CalcArea()
        {
            return Height * Width;
        }
        public int CalcPerimeter()
        {
            return (Height + Width) * 2;
        }
    }
}
