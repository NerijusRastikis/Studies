using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    internal class BankAccount
    {
        protected double balance;
        protected void PrintBalance()
        {
            balance = 0;
            Console.WriteLine(balance);
        }
    }
}
