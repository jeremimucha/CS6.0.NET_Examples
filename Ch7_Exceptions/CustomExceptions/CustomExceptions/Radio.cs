using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    class Radio
    {
        public void TurnOn(bool on)
        {
            if( on )
                Console.WriteLine("Jammin...");
            else
                Console.WriteLine("Quiet time...");
        }
    }
}
