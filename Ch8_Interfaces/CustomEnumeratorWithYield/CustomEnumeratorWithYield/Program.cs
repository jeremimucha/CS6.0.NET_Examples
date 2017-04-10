using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumeratorWithYield
{
    class Program
    {
        static void Main(string[] args)
        {
            Garage g = new Garage();

            foreach(Car c in g )
            {
                Console.WriteLine("Car {0} is going {1}",
                    c.PetName, c.CurrentSpeed);
            }
            Console.WriteLine("\nIn reverse:");
            foreach(Car c in g.GetTheCars(true) )
            {
                Console.WriteLine("Car {0} is going {1}",
                    c.PetName, c.CurrentSpeed);
            }
        }
    }
}
