using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizableDisposableClass
{
    class MyResourceWrapper : IDisposable
    {
        // Used to determine if Dispose()
        // has already been called
        private bool disposed = false;
        
        // The objects user will call this method to clean up
        // resources ASAP
        public void Dispose()
        {
            // Clean up unmanaged resources here
            // Call Dispose() on other contained disposable objects

            // Call our helper method,
            // Specifyin 'true' signifies that
            // the object user triggered the cleanup
            CleanUp(true);

            // No need to finalize if user called Dispose()
            // so suppress finalization
            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing)
        {
            // Be sure we have not already been disposed
            if(!this.disposed)
            {
                // If disposing == true, dispose all
                // managed resources
                if(disposing)
                {
                    // Dispose managed resources
                }
                // Clean up unmanaged resources here
            }
            disposed = true;
        }

        // The GC will call this method if the user
        // forgets to call Dispose
        ~MyResourceWrapper()
        {
            Console.Beep();
            // Clean up any internal unmanaged resources
            // Do **not** call Dispose() on any managed objects
            // Call our helper method
            // Specifying 'false' signifies that
            // the GC triggered  the cleanup
            CleanUp(false);
        }

        
    }
}
