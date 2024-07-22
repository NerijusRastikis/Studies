using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    internal class CheckingAccount : BankAccount
    {
        private double overdraftLimit = 2000;
        public double Withdraw(double withdrawSum)
        {
            if (overdraftLimit !> withdrawSum)
            {
                return balance = balance - withdrawSum;
            }
            else
            {
                return balance;
            }
        }
    }
}
