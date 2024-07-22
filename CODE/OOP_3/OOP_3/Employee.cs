using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    internal class Employee
    {
        public double Salary { get; set; } = 1200.00;
        public virtual double GetSalary()
        {
            return Salary;
        }
    }
}
