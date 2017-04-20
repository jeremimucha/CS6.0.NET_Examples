using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDispose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Dispose *****");
            // Create a disposable objects and call Dispose()
            // to free any internal resources
            MyResourceWrapper rw = new MyResourceWrapper();
            try{
                // use rw
            }
            finally{
               rw.Dispose();
            }

            // the same can be achieved with the following syntax:
            // Dispose() is called automatically when the
            // using scope exits
            using (MyResourceWrapper rw1 = new MyResourceWrapper(),
                                     rw2 = new MyResourceWrapper())
            {
                // use rw1, rw2
                // Dispose() called on both rw1 and rw2
                // when the scope ends
            }

            Console.ReadLine();
        }
    }
}
