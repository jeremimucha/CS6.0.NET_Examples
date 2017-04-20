using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryStringWithOperators();
            QueryStringWithEnumerableAndLambda();
            QueryStringWithAnonymousMethods();
            VeryComplexQueryExpression.QueryStringsWithRawDelegates();
        }

        static void QueryStringWithOperators()
        {
            Console.WriteLine("***** Using Query Operators *****");
            string[] currentGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            var subset = from g in currentGames
                         where g.Contains(" ")
                         orderby g
                         select g;
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
            Console.WriteLine();
        }

        static void QueryStringWithEnumerableAndLambda()
        {
            Console.WriteLine("***** Using Enumerable and lambdas *****");
            string[] currentGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            var subset = currentGames.Where(g => g.Contains(" "))
                .OrderBy(g => g).Select(g => g);
            foreach (var v in subset)
                Console.WriteLine("Item: {0}", v);
            Console.WriteLine();
        }

        static void QueryStringWithAnonymousMethods()
        {
            Console.WriteLine("***** Using Anonymous Methods *****");
            string[] currentGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            // Build delegates using anonymous methods
            Func<string, bool> searchFilter =
                delegate (string game) { return game.Contains(" "); };
            Func<string, string> itemToProcess =
                delegate (string s) { return s; };

            // Pass the delegates into the methods of Enumerable
            var subset = currentGames.Where(searchFilter)
                .OrderBy(itemToProcess).Select(itemToProcess);

            foreach (var v in subset)
                Console.WriteLine(v);
            Console.WriteLine();
        }
    }

    class VeryComplexQueryExpression
    {
        public static void QueryStringsWithRawDelegates()
        {
            Console.WriteLine("***** Using Raw Delegates *****");
            string[] currentGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            Func<string, bool> searchFilter = new Func<string, bool>(Filter);
            Func<string, string> itemsToProcess = new Func<string, string>(ProcessItems);

            var subset = currentGames.Where(searchFilter)
                .OrderBy(itemsToProcess).Select(itemsToProcess);

            foreach (var v in subset)
                Console.WriteLine(v);
            Console.WriteLine();
        }

        public static bool Filter(string game)
        { return game.Contains(" "); }

        public static string ProcessItems(string game)
        { return game; }
    }
}
