using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * System.Array methods
             * Length
             * Rank - number of dimensions
             * CLear()
             * CopyTo()
             * Reverse()
             * Sort()
             */
        }

        static void PrintArray(int[] myInts)
        {
            for( int i=0; i<myInts.Length; ++i )
            {
                Console.WriteLine("myInts[{0}] == {1}", i, myInts[i]);
            }
        }

        static string[] GetStringArray()
        {
            string[] theStrings = { "Hello", "from", "GetStringArray" };
            return theStrings;
        }

        static void PassAndReceiveArrays()
        {
            Console.WriteLine("=> Arrays as params and return values.");
            // Pass arrray as param
            int[] intarr = { 1, 2, 3, 4, 5 };
            PrintArray(intarr);

            // Get array
            string[] strarr = GetStringArray();
            foreach(string s in strarr )
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }
    }
}
