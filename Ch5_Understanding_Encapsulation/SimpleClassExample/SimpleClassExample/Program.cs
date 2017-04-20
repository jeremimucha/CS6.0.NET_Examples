using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Fun with Class Types ****\n");
            Car myCar = new Car();
            myCar.petName = "Henry";
            myCar.currSpeed = 10;

            // Speed up the car a few times and print the new state
            for( int i=0; i<=10; ++i )
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }

            Motorcycle c = new Motorcycle(5);
            c.SetDriverName("Tiny");
            c.PopAWheely();
            Console.WriteLine("Rider name is {0}", c.driverName);

            Console.WriteLine("\n-> SavingsAccount class:\n");
            SavingsAccount sa1 = new SavingsAccount(3000);
            sa1.PrintInterestRate();
            SavingsAccount.SetInterestRate(0.08);
            SavingsAccount sa2 = new SavingsAccount(4000);
            sa2.PrintInterestRate();


            Console.ReadLine();
        }
    }
}
