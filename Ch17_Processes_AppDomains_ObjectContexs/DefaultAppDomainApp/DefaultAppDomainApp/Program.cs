using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;


namespace DefaultAppDomainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with the default AppDomain *****\n");

            InitDAD();
            DisplayDADStats();
            ListAllAssembliesInAppDomain();
            

            Console.ReadLine();
        }

        static void DisplayDADStats()
        {
            // Get access to the default AppDomain for the current thread
            AppDomain defaultAD = AppDomain.CurrentDomain;

            // Print out various stats about this domain
            Console.WriteLine("\nName of this domain: {0}", defaultAD.FriendlyName);
            Console.WriteLine("ID of domain in this process: {0}", defaultAD.Id);
            Console.WriteLine("Is this the default domain?: {0}",
                defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain: {0}", defaultAD.BaseDirectory);
            Console.WriteLine();
        }

        static void ListAllAssembliesInAppDomain()
        {
            // Get access to the AppDomain for the current thread
            AppDomain ad = AppDomain.CurrentDomain;

            // Get all loaded assemblies
            var loadedAssemblies = from a in ad.GetAssemblies()
                                          orderby a.GetName().Name
                                          select a;
            Console.WriteLine("\n***** Assemblies loaded in {0} *****", ad.FriendlyName);
            foreach(Assembly a in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", a.GetName().Name);
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
            }
        }

        static void InitDAD()
        {
            // This logic will print out the name of an Assembly
            // loaded into the application domain, after it has been
            // created
            AppDomain ad = AppDomain.CurrentDomain;

            ad.AssemblyLoad += (o, s) =>
            {
                Console.WriteLine("Loaded: {0}", s.LoadedAssembly.GetName().Name);
            };
        }
    }
}
