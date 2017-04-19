using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace AsyncDelegate
{
    public delegate int BinaryOp(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Async Delegate Invocation *****");
            // Print out the ID of the executing thread
            Console.WriteLine("Main() invoked on thread {0}.",
                Thread.CurrentThread.ManagedThreadId);

            // Invoke Add on a secondary thread
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult ascres = b.BeginInvoke(10, 10, null, null);

            // Keep doing more work
            //while (!ascres.IsCompleted)
            //{
            //    Console.WriteLine("Doing more work in Main()");
            //    Thread.Sleep(1000);
            //}
            while (!ascres.AsyncWaitHandle.WaitOne(1000,true))
            {
                Console.WriteLine("Doing more work in Main()");
            }


            // Get the result of Add
            int result = b.EndInvoke(ascres);
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
