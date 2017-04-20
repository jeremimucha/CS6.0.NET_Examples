using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodDefinitions
{
    class Program
    {
        static void Main(string[] args)
        {
            // by value:
            Console.WriteLine("Add(5, 4) == {0}", Add(5, 4));

            // Calling a method with output parameters also requires
            // the use of the out modifier. The variable used as the out param
            // may be uninitialized - it will be assigned by the method.
            int ans;    // uninitialized
            Add(90, 90, out ans);
            Console.WriteLine("90 + 90 = {0}", ans);


            // Passing parameters by reference requires the use of 'ref' keyword
            string s1 = "Flip";
            string s2 = "Flop";
            Console.WriteLine("Before: {0}, {1} ", s1, s2);
            SwapStrings(ref s1, ref s2);
            Console.WriteLine("After: {0}, {1} ", s1, s2);

            // Passing to a function with a 'params' parameter
            double average;
            average = CalculateAverage(4.0, 3.2, 5.6, 52.22, 85, 1);
            Console.WriteLine("Average of data is: {0}", average);

            // An array can be passed instead
            double[] data = { 4.0, 3.2, 5.7 };
            average = CalculateAverage(data);
            Console.WriteLine("Average of data is: {0}", average);

            // Invoking methods using named parameters
            SomeFunction(str1: "foo", str2: "bar", str3: "donger");
            // in any order, but positional first
            SomeFunction("foo", str3: "donger", str2: "bar");

            Console.ReadLine();
        }

        // Arguments are passed by value by default
        static int Add(int x, int y)
        {
            return x + y;
        }

        // Output parameters - 'out'
        // 'out' modifier defines parameters as output parameters.
        // If the method doesn't assign all of the 'out' parameters
        // the compiler issues an error.
        static void Add(int x, int y, out int ans)
        {
            ans = x + y;
        }

        // Reference parameters - 'ref'
        public static void SwapStrings(ref string s1, ref string s2)
        {
            string temp = s1;
            s1 = s2;
            s2 = temp;
        }

        // Variable number of arguments - 'params'
        // like *args in python, or elipsis '...' in C++/Java
        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("You sent me {0} doubles.", values.Length);

            double sum = 0;
            if( values.Length == 0 )
                return sum;
            for( int i = 0; i < values.Length; ++i )
                sum += values[i];
            return (sum / values.Length);
        }

        // Optional parameters with default values
        static void EnterLogData(string message, string owner = "Programmer")
        {
            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }

        // Named parameters
        static void SomeFunction(string str1, string str2, string str3)
        {
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            Console.WriteLine(str3);
        }
    }
}
