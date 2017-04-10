using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandline
{
    class Program
    {
        static void Main(string[] args){
            foreach(string s in args)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\nSame, but using System.Environment.GetCommandLineArgs():");
            string[] clineAegs = Environment.GetCommandLineArgs();
            foreach(string s in clineAegs)
            {
                Console.WriteLine(s);
            }
            ShowEnvDetails();
            Console.ReadLine();
        }

        static void ShowEnvDetails()
        {
            foreach(string d in Environment.GetLogicalDrives())
            {
                Console.WriteLine(d);
            }
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Processor count: {0}", Environment.ProcessorCount);
            Console.WriteLine("NET version: {0}", Environment.Version);
        }
    }
}
