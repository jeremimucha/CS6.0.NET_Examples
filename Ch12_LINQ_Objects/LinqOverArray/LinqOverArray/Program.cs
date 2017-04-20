using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ to Objects *****\n");
            QueryOverStrings();
            Console.WriteLine("\nLonghand:");
            QueryOverStringsLongHand();
            Console.WriteLine("\nQueryOverInts:");
            QueryOverInts();
            Console.ReadLine();
        }

        static void QueryOverStrings()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ") orderby g select g;

            foreach( string s in subset )
                Console.WriteLine("Item: {0}", s);
            ReflectOverQueryResults(subset);
        }

        static void QueryOverStringsLongHand()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            List<string> gamesWithSpaces = new List<string>();
            for(int i=0; i<currentVideoGames.Length; ++i )
            {
                if( currentVideoGames[i].Contains(" ") )
                    gamesWithSpaces.Add(currentVideoGames[i]);
            }
            gamesWithSpaces.Sort();
            foreach( string s in gamesWithSpaces )
                Console.WriteLine("Item: {0}", s);
            ReflectOverQueryResults(gamesWithSpaces);
        }

        static void ReflectOverQueryResults(object resultSet)
        {
            Console.WriteLine("***** Info about your query *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }

        static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // Print only items < 10
            //IEnumerable<int> subset = from i in numbers
            //                          where i < 10 select i;
            //foreach( int i in subset )
            //    Console.WriteLine("Item: {0}", i);

            // Use implicit typing instead!
            var subset = from i in numbers
                         where i < 10 select i;
            
            // The LINQ expresion is evaluated at the point it is being iterated over
            foreach( var i in subset )
                Console.WriteLine("Item: {0}", i);

            numbers[0] = 4;
            Console.WriteLine("After setting numbers[0] = 4:");
            // LINQ expression evaluated again!
            foreach( var i in subset )
                Console.WriteLine("Item: {0}", i);
            ReflectOverQueryResults(subset);
        }

        static void ImmediateExecution()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            // get data RIGHT NOW as int[]
            int[] subsetAsIntArray =
                (from i in numbers where i < 10 select i).ToArray<int>();

            List<int> subsetAsList =
                (from i in numbers where i < 10 select i).ToList<int>();
        }
    }
}
