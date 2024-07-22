using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    internal class SavingsAccount : BankAccount
    {
        private double interestRate;
        public double CalculateInterest()
        {
            interestRate = 0.5;
            return balance * interestRate;
        }
    }
}
