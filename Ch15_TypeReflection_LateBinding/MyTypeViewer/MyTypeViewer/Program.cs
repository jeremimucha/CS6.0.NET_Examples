using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace MyTypeViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to MyTypeViewer *****");
            string typeName = "";

            do
            {
                Console.WriteLine("\nEnter a type name to evaluate");
                Console.WriteLine("or enter Q to quit: ");

                // Get name of type
                typeName = Console.ReadLine();

                // does use want to quit?
                if (typeName.ToUpper() == "Q")
                    break;

                try
                {
                    Type t = Type.GetType(typeName);
                    Console.WriteLine();
                    ListVariousStats(t);
                    ListFields(t);
                    ListProps(t);
                    ListMethods(t);
                    ListInterfaces(t);
                }
                catch
                {
                    Console.WriteLine("Sorry, can't find type {0}", typeName);
                }
            } while (true);
        }

        static void ListMethods(Type t)
        {
            Console.WriteLine("***** ListMethods *****");
            MethodInfo[] mi = t.GetMethods();
            Console.WriteLine("{0} methods:", t.Name);
            foreach (MethodInfo m in mi)
            {
                string retVal = m.ReturnType.FullName;
                string paramInfo = "(";
                foreach (ParameterInfo pi in m.GetParameters())
                    paramInfo += string.Format("{0} {1} ", pi.ParameterType, pi.Name);
                paramInfo += ")";

                Console.WriteLine("\t->{0} {1} {2}", retVal, m.Name, paramInfo);
            }
            
            Console.WriteLine();
        }

        static void ListFields(Type t)
        {
            Console.WriteLine("***** ListFields *****");
            var fieldNames = from f in t.GetFields() select f.Name;
            Console.WriteLine("{0} fields:", t.Name);
            foreach (var name in fieldNames)
                Console.WriteLine("\t->{0}", name);
            Console.WriteLine();
        }

        static void ListProps(Type t)
        {
            Console.WriteLine("***** ListProps *****");
            var propNames = from p in t.GetProperties() select p.Name;
            Console.WriteLine("{0} properties:", t.Name);
            foreach (var name in propNames)
                Console.WriteLine("\t->{0}", name);
            Console.WriteLine();
        }

        static void ListInterfaces(Type t)
        {
            Console.WriteLine("***** ListInterfaces *****");
            var ifaces = from i in t.GetInterfaces() select i;
            Console.WriteLine("{0} interfaces:", t.Name);
            foreach (Type i in ifaces)
                Console.WriteLine("\t->{0}", i.Name);
        }

        static void ListVariousStats(Type t)
        {
            Console.WriteLine("***** ListVariousStats *****");
            Console.WriteLine("Base class is: {0}", t.BaseType);
            Console.WriteLine("Is type abstract? {0}", t.IsAbstract);
            Console.WriteLine("Is type sealed? {0}", t.IsSealed);
            Console.WriteLine("Is tyep generic? {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("Is type a class type? {0}", t.IsClass);
            Console.WriteLine();
        }
    }
}
