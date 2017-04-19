using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BackgroundThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Background Threads *****\n");
            Printer p = new Printer();
            Thread bgthread = new Thread(new ThreadStart(p.PrintNumbers));

            // This is now a background (daemonic) thread
            // if won't be able to finish it's work - app will quit once the main foreground thread is done
            bgthread.IsBackground = true;
            bgthread.Start();
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
