using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace StringReaderWriterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** StringWriter / StringReader *****\n");

            using (StringWriter swriter = new StringWriter())
            {
                swriter.WriteLine("Don't forget Mother's Day this year...");
                // Get a copy of the contents (stored in a string) and dump to console


                // Get the internal StringBuilder
                StringBuilder sb = swriter.GetStringBuilder();
                sb.Insert(0, "Hey! ");
                Console.WriteLine("-> {0}", sb.ToString());
                sb.Remove(0, "Hey! ".Length);
                Console.WriteLine("-> {0}", sb.ToString());


                // Read data from the StringWriter
                Console.WriteLine("\n***** StringReader output: *****");
                using (StringReader sreader = new StringReader(swriter.ToString()))
                {
                    string input = null;
                    while((input = sreader.ReadLine()) != null)
                    {
                        Console.WriteLine(input);
                    }
                }

                    Console.WriteLine("\nContents of StringWriter:\n{0}", swriter);
            }

            Console.ReadLine();
        }
    }
}
