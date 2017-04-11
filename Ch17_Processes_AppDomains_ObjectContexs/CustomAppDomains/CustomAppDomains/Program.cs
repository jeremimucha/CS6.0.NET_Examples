using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CustomAppDomains
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** CustomAppDomains *****\n");
            AppDomain ad = AppDomain.CurrentDomain;
            ad.ProcessExit += (o, s) =>
            {
                Console.WriteLine("Default AppDomain Unloaded!");
            };
            ListAllAssembliesInAppDomain(ad);
            MakeNewAppDomain();
        }

        private static void MakeNewAppDomain()
        {
            // Make a new AppDomain in the current process and list 
            // loaded assemblies
            AppDomain ad = AppDomain.CreateDomain("SecondAppDomain");
            ad.AssemblyLoad += (o, s) =>
            {
                Console.WriteLine("Loaded: ");
                Console.WriteLine(s.LoadedAssembly.FullName);
                Console.WriteLine("Object caller: {0}", o);
            };
            ad.DomainUnload += (o, s) =>
            {
                Console.WriteLine("Unloaded SecondAppDomain");
            };
            try
            {
                ad.Load("CarLibrary");
            }catch(FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            ListAllAssembliesInAppDomain(ad);
            AppDomain.Unload(ad);
        }

        static void ListAllAssembliesInAppDomain(AppDomain ad)
        {
            var asms = from a in ad.GetAssemblies()
                       orderby a.GetName().Name
                       select a;
            Console.WriteLine("\nAssemblies loaded in {0}:", ad.FriendlyName);
            foreach(var a in asms)
            {
                Console.WriteLine("-> Name: {0}", a.GetName().Name);
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
            }
        }
    }
}
