using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class SavingsAccount
    {
        public double currBalance;
        public static double currInterestRate;

        public SavingsAccount(double balance)
        {
            currBalance = balance;
        }

        static SavingsAccount()
        {
            Console.WriteLine("In static ctor!");
            currInterestRate = 0.04;
        }

        public static void SetInterestRate(double rate)
        { currInterestRate = rate; }
        
        public void PrintInterestRate()
        {
            Console.WriteLine("Interest rate is {0}", currInterestRate);
        }
    }
}
