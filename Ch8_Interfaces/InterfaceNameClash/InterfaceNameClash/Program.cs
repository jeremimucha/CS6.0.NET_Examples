using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceNameClash
{
    class Program
    {
        static void Main(string[] args)
        {
            Octagon oct = new Octagon();

            // Must use explicit casting to access the Draw()
            // members
            IDrawToForm idtf = (IDrawToForm)oct;
            idtf.Draw();

            // Shorthand notation
            ((IDrawToPrinter)oct).Draw();

            // use 'is'
            if( oct is IDrawToMemory )
                ((IDrawToMemory)oct).Draw();
        }
    }
}
