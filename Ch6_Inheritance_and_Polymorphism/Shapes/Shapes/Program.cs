using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] myShapes = {new Hexagon(), new Circle(), new Hexagon("Mick"),
                            new Circle("Beth"), new Hexagon("Linda") };

            // Loop over each item and interact with the
            // polymoriphic interface
            foreach(Shape s in myShapes)
            {
                s.Draw();
            }

            Console.ReadLine();
        }
    }
}
