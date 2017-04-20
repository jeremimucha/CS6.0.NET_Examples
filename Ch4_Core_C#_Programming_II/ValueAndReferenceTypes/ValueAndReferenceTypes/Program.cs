using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueTypeAssignment();
            ReferenceTypeAssignment();
            ValueTypeContainingRefType();
        }

        static void ValueTypeAssignment()
        {
            Console.WriteLine("Assigning vlaue types\n");
            Point p1 = new Point(10, 10);
            Point p2 = p1;

            p1.Display();
            p2.Display();

            p1.x = 100;
            Console.WriteLine("\n=> Changed p1.x\n");
            p1.Display();
            p2.Display();
        }

        static void ReferenceTypeAssignment()
        {
            Console.WriteLine("Assigning reference types\n");
            PointRef p1 = new PointRef(10, 10);
            PointRef p2 = p1;

            p1.Display();
            p2.Display();

            p1.x = 100;
            Console.WriteLine("\n=> Changed p1.x\n");
            p1.Display();
            p2.Display();
        }

        static void ValueTypeContainingRefType()
        {
            // Create the first Rectangle
            Console.WriteLine("-> Creating r1");
            Rectangle r1 = new Rectangle("First Rect", 10, 10, 50, 50);

            Console.WriteLine("-> Assigning r2 to r1");
            Rectangle r2 = r1;

            // Change some values of r2;
            Console.WriteLine("-> Changing values of r2");
            r2.rectInfo.infoString = "This is new info!";
            r2.rectBottom = 4444;

            // Print values of both rectangles
            r1.Display();
            r2.Display();
        }
    }


    class ShapeInfo
    {
        public string infoString;
        public ShapeInfo(string info)
        { infoString = info; }

    }

    struct Rectangle
    {
        // The rectangle structure contains a reference type member.
        public ShapeInfo rectInfo;
        public int rectTop, rectLeft, rectBottom, rectRight;

        public Rectangle(string info, int top, int left, int bottom, int right)
        {
            rectInfo = new ShapeInfo(info);
            rectTop = top; rectBottom = bottom;
            rectLeft = left; rectRight = right;
        }

        public void Display()
        {
            Console.WriteLine("String = {0}, Top = {1}, Bottom = {2}, Left = {3}, Right = {4}",
                rectInfo.infoString, rectTop, rectBottom, rectLeft, rectRight);
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

    class PointRef
    {
        public int x;
        public int y;

        public PointRef(int xx, int yy)
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
