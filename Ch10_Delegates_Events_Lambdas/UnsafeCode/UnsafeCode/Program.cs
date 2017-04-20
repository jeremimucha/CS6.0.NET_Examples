using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsafeCode
{
    struct Point
    {
        public int x;
        public int y;

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }

    class PointRef
    {
        public int x;
        public int y;

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                // work with pointers here
                int myInt = 10;
                SquareIntPointer(&myInt);
                Console.WriteLine("myInt: {0}", myInt);

                PrintValueAndAddress();
                Console.WriteLine("\n***** UsePointerToPoint *****");
                UsePointerToPoint();

                Console.WriteLine("\n***** UnsafeStackAlloc *****");
                UnsafeStackAlloc();

                Console.WriteLine("\n***** SizeofCustomTypes *****");
                SizeofCustomTypes();
            }
        }

        unsafe static void SquareIntPointer(int* myIntPointer)
        {
            // Square the value just for a test
            *myIntPointer *= *myIntPointer;
        }

        unsafe static void PrintValueAndAddress()
        {
            int myInt;

            // Define an int pointer, and
            // assign it the address of myInt
            int* ptrToMyInt = &myInt;

            // Assign value of myInt using pointer idirection
            *ptrToMyInt = 123;

            // Print some stats
            Console.WriteLine("Value of myInt {0}", myInt);
            Console.WriteLine("Address of myInt {0:X}", (int)&ptrToMyInt);
        }

        unsafe public static void UnsafeSwap(int* i, int* j)
        {
            int temp = *i;
            *i = *j;
            *j = temp;
        }

        unsafe static void UsePointerToPoint()
        {
            // access  members via pointer
            Point point;
            Point* p = &point;
            p->x = 100;
            p->y = 200;
            Console.WriteLine(p->ToString());

            // Access members via pointer indirection
            Point point2;
            Point* p2 = &point2;
            (*p2).x = 100;
            (*p2).y = 200;
            Console.WriteLine("(*p2).ToString()");
        }

        // stackalloc keyword
        unsafe static void UnsafeStackAlloc()
        {
            char* p = stackalloc char[256];
            for(int k = 0; k<256; ++k )
            {
                p[k] = (char)k;
            }
            for(char* c = p; c != p + 256; )
            {
                Console.Write(*c++);
            }
        }

        unsafe static void UseAndPinPoint()
        {
            PointRef pt = new PointRef();
            pt.x = 5;
            pt.y = 6;

            // Pin pt in place so it will not
            // be moved or GC-ed
            fixed (int* p = &pt.x)
            {
                // use int* variable here
            }

            // pt is now unpinned, and ready to be GC-ed once
            // the method completes
            Console.WriteLine("Point is: {0}", pt);
        }

        unsafe static void SizeofCustomTypes()
        {
            // to get the sizeof() a custom defined type
            // the operator needs to be used in an unsafe context
            Console.WriteLine("The size of Point is {0}", sizeof(Point));
        }
    }
}
