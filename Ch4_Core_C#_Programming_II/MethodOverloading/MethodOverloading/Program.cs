using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            // Calls int version of Add()
            Console.WriteLine(Add(10, 10));

            // Calls double version of Add()
            Console.WriteLine(Add(3.14, 3.14));

            // Calls long version of Add()
            Console.WriteLine(Add(900000000000, 900000000000));

            Console.ReadLine();
        }

        // Overloaded Add() method
        static int Add(int x, int y)
        { return x + y; }

        static double Add(double x, double y)
        { return x + y; }

        static long Add(long x, long y)
        { return x + y; }
    }
}
