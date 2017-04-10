using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    struct Point
    {
        public int x;
        public int y;

        public void Increment()
        { ++x; ++y; }

        public void Decrement()
        { --x; --y; }

        public void Display()
        { Console.WriteLine("({0},{1})", x, y); }
    }
    
}
