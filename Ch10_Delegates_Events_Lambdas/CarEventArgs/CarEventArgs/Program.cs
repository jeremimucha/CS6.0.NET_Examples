using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEventArgs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Events *****\n");
            Car c1 = new Car("SlugBlug", 100, 10);
            c1.AboutToBlow += CarIsAlmostDoomed;
            c1.AboutToBlow += CarAboutToBlow;
            c1.Exploded += CarExploaded;

            Console.WriteLine("***** Speeding up *****");
            for( int i = 0; i < 6; ++i )
            {

                c1.Accelerate(20);
            }

            // remove CarExploaded method
            // from invocation list
            c1.Exploded -= CarExploaded;

            Console.WriteLine("***** Speeding up *****\n");
            for( int i = 0; i < 6; ++i )
            {
                c1.Accelerate(20);
            }

            Console.ReadLine();
        }

        public static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            if(sender is Car )
            {
                Car c = (Car)sender;
                Console.WriteLine("Critical Message from {0} says: {1}", c.PetName, e.msg);
            }
            
        }

        public static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        { Console.WriteLine("=> Critical Message from Car: {0}"); }

        public static void CarExploaded(object sender, CarEventArgs e)
        { Console.WriteLine("{0} says: {1}", sender, e.msg); }
    }
}
