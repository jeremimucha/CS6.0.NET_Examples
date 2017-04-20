using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("SlugBug", 100, 10);
            // Tell the car which method to call
            // when it wants to send us a message
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent2));

            Console.WriteLine("***** Speeding up *****");
            for( int i = 0; i < 6; ++i )
                c1.Accelerate(20);

            Console.ReadLine();
        }

        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n*****  Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("************************************\n");
        }

        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("OnCarEngineEvent2: {0}\n", msg);
        }
    }
}
