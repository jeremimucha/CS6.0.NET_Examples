using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;


namespace AsyncCallbackDelegate
{
    public delegate int BinaryOp(int x, int y);

    class Program
    {
        private static bool isDone = false;

        static void Main(string[] args)
        {
            Console.WriteLine("***** AsyncCallbackDelegate Example *****");
            // Print out the ID of the executing thread
            Console.WriteLine("Main() invoked on thread {0}.",
                Thread.CurrentThread.ManagedThreadId);

            // Invoke Add in a synchronous manner
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult asyncr = b.BeginInvoke(10, 10,
                new AsyncCallback(AddComplete), "Thanks for adding those numbers");

            while (!isDone)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Doing more work in Main()");
            }

            // AddComplete has retrieved the result of the async function call at this point

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

        static void AddComplete(IAsyncResult iar)
        {
            Console.WriteLine("AddComplete() invoked on thread {0}",
                Thread.CurrentThread.ManagedThreadId);
            AsyncResult ares = (AsyncResult)iar;
            BinaryOp b = (BinaryOp)ares.AsyncDelegate;
            Console.WriteLine("10 + 10 is {0}", b.EndInvoke(iar));
            string msg = (string)iar.AsyncState;
            Console.WriteLine(msg);
            isDone = true;
        }
    }
}
