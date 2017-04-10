using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** GC Basics *****");

            // Create a new Car object on the managed heap
            // We are returned a reference to this object
            Car refToCar = new Car("Zippy", 50);

            // The C# dot (.) operator is used to invoke
            // members on the object using the reference
            // variable
            Console.WriteLine(refToCar.ToString());

            Console.ReadLine();
        }
    }
}
