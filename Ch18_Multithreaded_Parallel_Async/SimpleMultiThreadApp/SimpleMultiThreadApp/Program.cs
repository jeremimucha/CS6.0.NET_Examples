using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace SimpleMultiThreadApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Amazing Thread App *****\n");
            Console.Write("Do you want [1] or [2] threads? ");
            string tcnt = Console.ReadLine();

            // name the current thread
            Thread thread_primary = Thread.CurrentThread;
            thread_primary.Name = "Primary";

            // display thread info
            Console.WriteLine("-> {0} is executing Main()",
                Thread.CurrentThread.Name);

            // Make worker class
            Printer p = new Printer();
            switch (tcnt)
            {
                case "2":
                    // make thread
                    Thread thread_background = new Thread(
                        new ThreadStart(p.PrintNumbers));
                    thread_background.Name = "Secondary";
                    thread_background.Start();
                    break;
                case "1":
                    p.PrintNumbers();
                    break;
                default:
                    Console.WriteLine("I don't know what you want... you get 1 thread.");
                    goto case "1";
            }
            MessageBox.Show("I'm busy!", "Work on main thread...");

            Console.ReadLine();
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
            for(int i=0; i<10; ++i)
            {
                Console.Write("{0}, ", i);
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}
