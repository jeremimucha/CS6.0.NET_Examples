using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Nullable Data *****\n");
            DatabaseReader dr = new DatabaseReader();

            // Get intfrom "database"
            int? i = dr.GetIntFromDatabase();
            if( i.HasValue )
                Console.WriteLine("Value of \"i\" is: {0}", i.Value);
            else
                Console.WriteLine("Value of \"i\" is undefined.");
            // Get bool from "database"
            bool? b = dr.GetBoolFromDatabase();
            if( b != null )
                Console.WriteLine("Value of 'b' is: {0}", b.Value);
            else
                Console.WriteLine("Value of 'b' is undefined.");


            // null coalescing operator - '??'
            // Assign a value to a nullable type if the retrieved value
            // is in fact null

            // assigns 100 to myData if dr.GetIntFromDatabase() returns null
            int myData = dr.GetIntFromDatabase() ?? 100;
            Console.WriteLine("Value of myData: {0}", myData);

            // The null conditional operator
            // the '?' sufix can be used instead of a explicit test for the null value
            // Explicit test for null
            string[] s = null;
            if( s != null )
                Console.WriteLine($"The string array is {s.Length} elements");

            // utilizing the '?' operator
            Console.WriteLine($"The string array is {s?.Length} elements");

            // it can also be used in conjunction with the '??' operator
            Console.WriteLine($"The string array is {s?.Length ?? 0} elements");

            Console.ReadLine();
        }

        static void LocalNullableVariables()
        {
            // Define some local nullable variables
            int? nullableInt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            char? nullableChar = 'a';
            int?[] arrayOfNullableInts = new int?[10];

            // the '?' suffix is actually just a shorthand for
            // System.Nullable<T>
            Nullable<int> nInt = 10;
            Nullable<double> nDouble = 3.14;
            Nullable<bool> nBool = null;
            Nullable<char> nChar = 'a';
            Nullable<int>[] nIntArr = new Nullable<int>[10];
        }
    }

    class DatabaseReader
    {
        // Nullable data field
        public int? numericValue = null;
        public bool? boolValue = true;

        // Note the nullable return type
        public int? GetIntFromDatabase()
        { return numericValue; }

        public bool? GetBoolFromDatabase()
        { return boolValue; }
    }
}
