using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 11;
            int b = 22;
            Console.WriteLine("Before swap: a={0}, b={1}",a,b);
            Swap<int>(ref a, ref b);
            Console.WriteLine("After swap: a={0}, b={1}", a, b);
            Console.WriteLine();

            // Swap 2 strings
            string s1 = "foo";
            string s2 = "bar";
            Console.WriteLine("Before swap: {0}, {1}", s1, s2);
            Swap<string>(ref s1, ref s2);
            Console.WriteLine("After swap: {0}, {1}", s1, s2);

            DisplayBaseClass<string>();
            Console.WriteLine();
            DisplayBaseClass<Array>();

            Console.ReadLine();
        }

        static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("You sent Swap a {0}", typeof(T));
            T temp = a;
            a = b;
            b = temp;
        }

        public static void DisplayBaseClass<T>()
        {
            Console.WriteLine("Base class of {0} is: {1}",
                typeof(T), typeof(T).BaseType);
        }
    }
}
