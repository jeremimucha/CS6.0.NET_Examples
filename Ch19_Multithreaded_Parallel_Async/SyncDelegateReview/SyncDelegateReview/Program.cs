using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SyncDelegateReview
{
    public delegate int BinaryOp(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Synch Delegate Review *****");
            // Print out the ID of the executing thread
            Console.WriteLine("Main() invoked on thread {0}.",
                Thread.CurrentThread.ManagedThreadId);
            // Invoke Add in a synchronous manner
            BinaryOp b = new BinaryOp(Add);
            int result = b(10, 10);

            // These lines will execute once Add() has returned
            Console.WriteLine("Doing more work in Main()");
            Console.WriteLine("10 + 10 is {0}.", result);

            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            Console.WriteLine("Add() invoked on Thread {0}.",
                Thread.CurrentThread.ManagedThreadId);
            // Pause to simulate a lengthy operation
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
