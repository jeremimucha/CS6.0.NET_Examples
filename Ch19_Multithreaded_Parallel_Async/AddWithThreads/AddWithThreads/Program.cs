using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AddWithThreads
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("***** ParameterizedThreadStart *****");
            Console.WriteLine("ID of main thread: {0}",
                Thread.CurrentThread.ManagedThreadId);

            AddParams ap = new AddParams(10, 20);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);

            // Wait here until notified
            waitHandle.WaitOne();
            Console.WriteLine("Other thread is done!");
            Console.ReadLine();
        }

        static void Add(object data)
        {
            Console.WriteLine("ID of thread running Add(): {0}",
                Thread.CurrentThread.ManagedThreadId);

            AddParams ap = (AddParams)data;
            Console.WriteLine("{0} + {1} = {2}",
                ap.a, ap.b, ap.a + ap.b);

            // Thell the other thread that we're done
            waitHandle.Set();
        }
    }

    public class AddParams
    {
        public int a, b;
        public AddParams(int x, int y)
        {
            a = x; b = y;
        }
    }
}
