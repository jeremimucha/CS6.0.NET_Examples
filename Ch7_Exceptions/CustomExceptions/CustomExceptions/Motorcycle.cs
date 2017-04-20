using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassExample
{
    class Motorcycle
    {
        public int driverIntensity;
        public string driverName;

        public Motorcycle()
        {
            Console.WriteLine("In default ctro");
        }

        public Motorcycle(int intensity)
            : this(intensity, "")
        {
            Console.WriteLine("In ctor taking an int");
        }

        public Motorcycle(string name)
            : this(0, name)
        {
            Console.WriteLine("In ctor taking a string");
        }

        public Motorcycle(int intensity, string name)
        {
            Console.WriteLine("In master ctor ");
            if( intensity > 10 ){
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
        }

        public void SetDriverName(string name)
        { driverName = name; }

        public void SetDriverIntensity(int intensity)
        { driverIntensity = intensity; }

        public void PopAWheely()
        {
            for(int i=0; i<driverIntensity; ++i )
            {
                Console.WriteLine("Wheeeeeeleeeey");
            }
        }
    }
}
