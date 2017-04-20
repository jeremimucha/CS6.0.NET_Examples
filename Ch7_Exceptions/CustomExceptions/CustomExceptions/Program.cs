using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Custom Exceptions *****\n");
            Car myCar = new Car("Rusty", 90);
            myCar.CrankTunes(true);

            try
            {
                // Trip exception
                myCar.Accelerate(50);
            }
            // The 'when' clause allows us to filter the exception based on some condition
            catch(CarIsDeadException e) when(e.ErrorTimeStamp.DayOfWeek != DayOfWeek.Friday)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ErrorTimeStamp);
                Console.WriteLine(e.CauseOfError);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                myCar.CrankTunes(false);
            }

            try
            {
                myCar.Accelerate(-50);
            }
            catch( CarIsDeadException e )
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ErrorTimeStamp);
                Console.WriteLine(e.CauseOfError);
            }
            catch( ArgumentOutOfRangeException e )
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
