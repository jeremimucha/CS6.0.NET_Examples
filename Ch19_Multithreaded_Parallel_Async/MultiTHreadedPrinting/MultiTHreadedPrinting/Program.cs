using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MultiTHreadedPrinting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Synchronizing Threads *****\n");
            Printer p = new Printer();

            // Make 10 threads that are all pointing to the same
            // method on the same obj
            Thread[] threads = new Thread[10];
            for(int i=0; i<10; ++i)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threads[i].Name = string.Format("Worker thread #{0}", i);
            }
            foreach(Thread t in threads)
            {
                t.Start();
            }

            Console.ReadLine();
        }
    }

    public class Printer
    {
        private object threadLock = new object();

        public void PrintNumbers()
        {
            // Display thread info
            lock (this)
            {
                Console.WriteLine("-> {0} is executing PrintNumbers()",
                    Thread.CurrentThread.Name);
                // Print out numbers
                Console.WriteLine("Your numbers: ");
                for (int i = 0; i < 10; ++i)
                {
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }
        }
    }
}
