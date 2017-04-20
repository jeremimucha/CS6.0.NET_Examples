using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqRetValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ Return Values *****");

            IEnumerable<string> subset = GetStringSubset();
            foreach( string s in subset )
                Console.WriteLine(s);

            Console.WriteLine("\nGetStringSubsetAsArray");
            foreach( string s in GetStringSubsetAsArray() )
                Console.WriteLine(s);

            Console.ReadLine();
        }

        static IEnumerable<string> GetStringSubset()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };

            // subset implements IEnumerable<string>
            IEnumerable<string> subset = from c in colors
                                         where c.Contains("Red") select c;

            return subset;
        }

        static string[] GetStringSubsetAsArray()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };

            return (from c in colors where c.Contains("Red") select c).ToArray();
        }
    }
}
