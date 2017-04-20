using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFinalize
{
    class MyResourceWrapper
    {
        // Finalizers aren't overriden using the usual syntax
        // protected override void Finalize() {...}
        // results in a compile-time error!

        // Use the C++ destructor syntax to override Finalize
        ~MyResourceWrapper()
        {
            // Clean unmanaged resources here

            // Beep when destroyed (testing purposes)
            Console.Beep();
        }
    }
}
