using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;


namespace LateBindingWithDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            AddWithReflection();
            AddWithDynamic();
        }

        private static void AddWithReflection()
        {
            Assembly asm = Assembly.Load("MathLibrary");
            try
            {
                // Get metadata for the SimpleMath type
                Type math = asm.GetType("MathLibrary.SimpleMath");

                // Create a SimpleMath on the fly
                object obj = Activator.CreateInstance(math);

                // Get info for Add
                MethodInfo mi = math.GetMethod("Add");

                // Invoke method (with params)
                object[] args = { 10, 70 };
                object result = mi.Invoke(obj, args);
                Console.WriteLine("AddWithReflection:");
                Console.WriteLine("\t->typeof result is: {0}", result.GetType().Name);
                Console.WriteLine("\t->Result is: {0}", result);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AddWithDynamic()
        {
            Assembly asm = Assembly.Load("MathLibrary");
            try
            {
                // Get metadata for the SimpleMath type
                Type math = asm.GetType("MathLibrary.SimpleMath");

                // Create a SimpleMath on the fly
                dynamic obj = Activator.CreateInstance(math);

                // call Add dynamically
                int result = obj.Add(10, 70);
                Console.WriteLine("AddWithDynamic:");
                Console.WriteLine("\t->typeof result is: {0}", result.GetType().Name);
                Console.WriteLine("\t->Result is: {0}", result);
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }
    }
}
