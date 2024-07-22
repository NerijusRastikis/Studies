using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    internal class Developer : Employee
    {
        public sealed override double GetSalary()
        {
            return 1500.00;
        }
    }
}
