using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ThreadStats
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Primary Thread stats *****");
            // Get name of the current thread
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";

            // Show details of hosting appdomain/context
            Console.WriteLine("Name of current AppDomain: {0}",
                Thread.GetDomain().FriendlyName);
            Console.WriteLine("ID of current context: {0}",
                Thread.CurrentContext.ContextID);

            // Print some stats
            Console.WriteLine("Thread name: {0}",
                primaryThread.Name);
            Console.WriteLine("Started? {0}",primaryThread.IsAlive);
            Console.WriteLine("Priority Level: {0}", primaryThread.Priority);
            Console.WriteLine("Thread state: {0}", primaryThread.ThreadState);

            Console.ReadLine();
        }

    }
}
