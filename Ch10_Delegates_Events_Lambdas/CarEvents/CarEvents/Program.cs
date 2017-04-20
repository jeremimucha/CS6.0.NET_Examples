using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");
            Car c1 = new Car("SlugBlug", 100, 10);

            // Register event handlers
            //c1.AboutToBlow += new Car.CarEngineHandler(CarIsAlmostDoomed);
            //c1.AboutToBlow += new Car.CarEngineHandler(CarAboutToBlow);
            //Car.CarEngineHandler d = new Car.CarEngineHandler(CarExploaded);
            //c1.Exploded += d;

            // method group conversion - simplifies dregistering with events
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;
            c1.Exploded += CarExploaded;

            Console.WriteLine("***** Speeding up *****");
            for(int i=0; i<6; ++i )
            {

                c1.Accelerate(20);
            }

            // remove CarExploaded method
            // from invocation list
            c1.Exploded -= CarExploaded;

            Console.WriteLine("***** Speeding up *****\n");
            for(int i=0; i<6; ++i )
            {
                c1.Accelerate(20);
            }

            Console.ReadLine();
        }

        public static void CarAboutToBlow(string msg)
        { Console.WriteLine(msg); }

        public static void CarIsAlmostDoomed(string msg)
        { Console.WriteLine("=> Critical Message from Car: {0}"); }

        public static void CarExploaded(string msg)
        { Console.WriteLine(msg); }


    }
}
