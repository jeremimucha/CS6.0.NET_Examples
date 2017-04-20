using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace StreamWriterReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with StreamWriter / StreamReader *****\n");

            using (StreamWriter writer = File.CreateText("reminders.txt"))
            {
                writer.WriteLine("Don't forget Mother's Day this year...");
                writer.WriteLine("Don't forget Father's Day this year...");
                writer.WriteLine("Don't forget these numbers:");
                for (int i = 0; i < 10; ++i)
                    writer.Write(string.Format("{0} ", i));

                writer.Write(writer.NewLine);
            }

            Console.WriteLine("Created file and wrote some thoughts...");

            // Now read data from file
            using (StreamReader sr = File.OpenText("reminders.txt"))
            {
                string input = null;
                while((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }


            //
            // StreamReader and StreamWriter classes can be used directly as well
            //
            using (StreamWriter writer = new StreamWriter("reminders.txt"))
            {
                // ...
            }

            // Now read data from file
            using (StreamReader sr = new StreamReader("reminders.txt"))
            {
                // ...
            }

                Console.ReadLine();
        }
    }
}
