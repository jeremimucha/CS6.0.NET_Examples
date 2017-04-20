using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace BinaryWriterReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Binary Writer / Reader *****\n");

            // Open  a binary writer for a file
            FileInfo f = new FileInfo("bin_file.dat");
            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                // Print out the type of BaseStream
                // (System.IO.FileStream in this case)
                Console.WriteLine("Base stream is: {0}", bw.BaseStream);

                // Create some data to save in the file
                double adouble = 1234.56;
                int anint = 543212;
                string astring = "ABCDE";

                // Write the data
                bw.Write(adouble);
                bw.Write(anint);
                bw.Write(astring);
            }

            Console.WriteLine("\nBinaryReader output:");
            using (BinaryReader br = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }

                Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
