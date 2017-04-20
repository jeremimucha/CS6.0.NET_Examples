using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MInterfaceHierarchy
{
    public class Rectangle : IShape
    {
        // Common implementation of the Draw method
        public void Draw()
        {
            Console.WriteLine("Drawing...");
        }

        public int GetNumberOfSides()
        {
            return 4;
        }

        public void Print()
        {
            Console.WriteLine("Printing...");
        }
    }

    public class Square : IShape
    {
        void IPrintable.Draw()
        { Console.WriteLine("Drawing IPrintable..."); }

        void IDrawable.Draw()
        { Console.WriteLine("Drawing IDrawable..."); }

        public void Print()
        { Console.WriteLine("Printing..."); }

        public int GetNumberOfSides()
        { return 4; }
    }
}
