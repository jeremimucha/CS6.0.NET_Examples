using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** GC Basics *****");
            // Create a new Car object on the managed heap.
            // We are returned a reference to this object
            Car refToCar = new Car("Zippy", 50);

            // The C# dot operator (.) is used to invoke
            // members on the object using our reference var.
            Console.WriteLine(refToCar.ToString());


            Console.WriteLine("***** Fun with System.GC *****");
            // Print out estimated number of bytes on heap
            Console.WriteLine("Estimated bytes on heap: {0}",
                GC.GetTotalMemory(false));

            // MaxGeneration is zero based, so add 1 for display purposes
            Console.WriteLine("This OS has {0} object generations.\n",
                (GC.MaxGeneration + 1));

            // Print out refToCar generation
            Console.WriteLine("Generation of refToCar is: {0}",
                GC.GetGeneration(refToCar));


            // ****************************************************************
            // Force garbage collection and wait for each object to be finalized
            // Use when:
            // * About to enter a block of code that you don't want to be interrupted by GC
            // * Just allocated large number of objects and you want to remove as much
            //   of the acquired memory asa soon as possible
            GC.Collect();
            GC.WaitForPendingFinalizers();


            // Make a ton of objects for testing purposes
            object[] tonsOfObjects = new object[50000];
            for(int i = 0; i < 50000; ++i)
            {
                tonsOfObjects[i] = new object();
            }
            // Collect only gen 0 objects
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            // Print out generation of refToCar
            Console.WriteLine("Generation of refToCar after GC is: {0}",
                GC.GetGeneration(refToCar));

            // See if tonsOfObjects[9000] is still alive
            if (tonsOfObjects[9000] != null)
            {
                Console.WriteLine("Generation of tonsOfObjects[9000] is: {0}",
                    GC.GetGeneration(tonsOfObjects[9000]));
            }
            else
                Console.WriteLine("tonsOfObjects[9000] is no longer alive.");

            // Print out how many times a generation has been swept
            Console.WriteLine("\nGen 0 has been swept {0} times",
                GC.CollectionCount(0));
            Console.WriteLine("Gen 1 has ben swept {0} times",
                GC.CollectionCount(1));
            Console.WriteLine("Gen 2 has been swept {0} times",
                GC.CollectionCount(2));


            Console.ReadLine();
        }
    }
}
