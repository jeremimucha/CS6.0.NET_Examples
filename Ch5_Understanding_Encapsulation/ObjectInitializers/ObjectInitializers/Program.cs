using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make a Point by setting each property manually
            Point firstPoint = new Point();
            firstPoint.X = 10;
            firstPoint.Y = 10;
            firstPoint.DisplayStats();

            // Make a Point via a custom constructor
            Point anotherPoint = new Point(20, 20);
            anotherPoint.DisplayStats();

            // Or make a Point using object init syntax
            // This is just a shorthand for using the default constructor
            // to create an object and settign the fields using the
            // public properties
            Point finalPoint = new Point { X = 30, Y = 30 };
            finalPoint.DisplayStats();

            // any constructor can be called when using the obj. init syntax
            Point goldPoint = new Point(PointColor.Gold) { X = 90, Y = 20 }
            goldPoint.DisplayStats();

            // Init a Rectangle
            Rectangle myRect = new Rectangle {
                TopLeft = new Point { X = 10, Y = 10 },
                BottomRight = new Point { X = 200, Y = 200 }
            };

            Console.ReadLine();
        }
    }
}
