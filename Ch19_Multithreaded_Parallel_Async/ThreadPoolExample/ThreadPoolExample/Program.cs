using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace ThreadPoolExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the CLR Thread pool *****\n");

            Console.WriteLine("Main thread started. Thread ID: {0}",
                Thread.CurrentThread.ManagedThreadId);

            Printer p = new Printer();

            WaitCallback workItem = new WaitCallback(PrintTheNumbers);
            // Queue the method ten times
            for(int i=0; i<10; ++i)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            }
            Console.WriteLine("All tasks queued");


            Console.ReadLine();
        }

        static void PrintTheNumbers(object state)
        {
            Printer task = (Printer)state;
            task.PrintNumbers();
        }
    }

    public class Printer
    {
        public void PrintNumbers()
        {
            // Display thread info
            Console.WriteLine("-> {0} is executing PrintNumbers()",
                Thread.CurrentThread.Name);
            // Print out numbers
            Console.WriteLine("Your numbers: ");
            for (int i = 0; i < 10; ++i)
            {
                Console.Write("{0}, ", i);
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}
