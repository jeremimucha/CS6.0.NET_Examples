using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace FileStreamApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** FileStreams *****\n");

            // obtain a FileStream object
            using (FileStream fStream = File.Open(@"./test_messaage.dat",
                FileMode.Create))
            {
                // Encode a string as an array of bytes
                string msg = "Hello!";
                byte[] msg_asbytes = Encoding.Default.GetBytes(msg);

                // Write byte[] to file
                fStream.Write(msg_asbytes, 0, msg_asbytes.Length);

                // Reset internal position of stream
                fStream.Position = 0;

                // Read the types from file and display to console
                Console.Write("Your message as an  array of bytes: ");
                byte[] bytes_fromfile = new byte[msg_asbytes.Length];
                for(int i=0; i<msg_asbytes.Length; ++i)
                {
                    bytes_fromfile[i] = (byte)fStream.ReadByte();
                    Console.Write(bytes_fromfile[i]);
                }
                Console.Write("\nDecoded Message: ");
                Console.WriteLine(Encoding.Default.GetString(bytes_fromfile));
            }
            Console.ReadLine();
        }
    }
}
