using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;


namespace LateBindingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Late Binding *****");

            Assembly a = null;
            try
            {
                a = Assembly.Load("CarLibrary");
            }catch(FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            if (a != null)
                CreateUsingLateBinding(a);

            Console.ReadLine();
        }

        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                Type miniVan = asm.GetType("CarLibrary.MiniVan");

                // Create a minivan instanceon te fly
                object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine("Created a {0} using late binding!", obj);

                // Get info for TurboBoost
                MethodInfo mi = miniVan.GetMethod("TurboBoost");

                // Invoke method ('null' for no parameters)
                mi.Invoke(obj, null);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InvokeMethodWithArgumentsUingLateBinding(Assembly asm)
        {
            try
            {
                // Get metadata description of the sports car
                Type sport = asm.GetType("CarLibrary.SportsCar");

                // create the SportsCar
                object obj = Activator.CreateInstance(sport);

                // Invoke TurnOnRadio() with args
                MethodInfo mi = sport.GetMethod("TurnOnRadio");
                // package arguments in an array of objects
                mi.Invoke(obj, new object[] { true, 2 });
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
