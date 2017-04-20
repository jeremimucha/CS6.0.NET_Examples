using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            // Anonymous methods can access local variables
            int aboutToBlowCounter = 0;

            Car c = new Car("SlugBug", 100, 10);

            c.Exploded += new EventHandler<CarEventArgs>(MyEventHanlder);

            // register event handlers as anonymous methods
            c.AboutToBlow += delegate {
                ++aboutToBlowCounter;
                Console.WriteLine("Eeek! Going too fast!");
            };

            c.AboutToBlow += delegate (object sender, CarEventArgs e) {
                ++aboutToBlowCounter;
                Console.WriteLine("Message from Car: {0}", e.msg);
            };

            c.Exploded += delegate (object sender, CarEventArgs e) {
                Console.WriteLine("Fatal Message  from Car: {0}", e.msg);
            };

            // This will eventually trigger the events
            for(int i=0; i < 6; ++i )
            {
                c.Accelerate(20);
            }

            Console.WriteLine("AbouToBlow event was fired {0} times",
                aboutToBlowCounter);


            Console.ReadLine();
        }

        static void MyEventHanlder(object s, CarEventArgs e)
        {
            Console.WriteLine("MyEventHandler");
        }
    }
}
