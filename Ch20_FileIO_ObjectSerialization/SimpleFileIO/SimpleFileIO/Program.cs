using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SimpleFileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple I/O with the File Type *****\n");
            string[] tasks =
            {
                "Fix bathroom sink", "Call Dave", "Call Mom and Dad", "Play Some Guitar"
            };

            // Write out all data to a file
            File.WriteAllLines(@"./tasks.txt", tasks);

            // read it all back and print out
            foreach (string task in File.ReadAllLines(@"./tasks.txt"))
            {
                Console.WriteLine("TODO: {0}", task);
            }

            Console.ReadLine();
        }
    }
}
