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
            Point p;
            p.x = 1;
            p.y = 2;
            p.Display();

            Point dp = new Point();
            dp.Display();

            Point pp = new Point(11, 42);
            pp.Display();
            pp.Increment();
            pp.Display();
        }
    }

    struct Point
    {
        public int x;
        public int y;

        public Point(int xx, int yy)
        { x = xx; y = yy; }

        public void Increment()
        { ++x; ++y; }

        public void Decrement()
        { --x; --y; }

        public void Display()
        {
            Console.WriteLine("x = {0}, y = {1}", x, y);
        }
    }
}
