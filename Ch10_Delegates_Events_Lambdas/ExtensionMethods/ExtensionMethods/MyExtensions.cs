using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ExtensionMethods
{
    static class MyExtensions
    {
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine("{0} lives here: => {1}\n", obj.GetType().Name,
                Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        public static int ReverseDigits(this int i)
        {
            // Translate int into a string, and then
            // get all the characters
            char[] digits = i.ToString().ToCharArray();

            // now reverse items in the array
            Array.Reverse(digits);

            // put back into string
            string newDigits = new string(digits);

            // finally return the modified string back as an int
            return int.Parse(newDigits);
        }

        public static int ReverseDigitsAlt(this int i)
        {
            int newInt = 0;
            int d = 1;
            for( int temp = i/10; temp != 0; temp /= 10 )
            {
                d*=10;
            }

            for( ; i != 0; d /= 10 )
            {
                newInt += (i % 10) * d;
                i /= 10;
            }
            return newInt;
        }
    }
}
