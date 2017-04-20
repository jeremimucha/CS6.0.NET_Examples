using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Lambdas *****\n");
            TraditionalDelegateSyntax();
            AnonymousMethodSyntax();
            LambdaExpressionSyntax();
            Console.ReadLine();
        }

        static void TraditionalDelegateSyntax()
        {
            // Make a list of ints
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Call FindAll() using traditional delegate syntax
            Predicate<int> cb = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(cb);

            Console.WriteLine("Here are your even numbers: ");
            foreach(int evenNumber in evenNumbers )
            {
                Console.WriteLine("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        static bool IsEvenNumber(int i)
        {
            return (i % 2) == 0;
        }

        static void AnonymousMethodSyntax()
        {
            // Make a list of integers
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Use an anonymous method
            List<int> evenNumbers = list.FindAll(
                delegate (int i) {
                    return (i % 2) == 0;
                });

            Console.WriteLine("Here are your even numbers:");
            foreach(int evenNumber in evenNumbers )
            {
                Console.WriteLine("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        static void LambdaExpressionSyntax()
        {
            // Make a list of integers
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            List<int> evenNumbers = list.FindAll((i) =>
            {
                Console.WriteLine("Value of i is: {0}", i);
                return (i % 2) == 0;
            });

            Console.WriteLine("Here are your even numbers:");
            foreach(int evenNumber in evenNumbers )
            {
                Console.WriteLine("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
    }
}
