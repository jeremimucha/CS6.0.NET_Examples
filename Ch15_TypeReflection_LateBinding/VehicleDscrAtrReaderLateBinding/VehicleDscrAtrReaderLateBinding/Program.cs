using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;


namespace VehicleDscrAtrReaderLateBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Value of VehicleDescriptionAttribute *****\n");
            ReflectAttributesUsingLateBinding();
        }

        private static void ReflectAttributesUsingLateBinding()
        {
            try
            {
                // Load the local copy of AttributedCarLibrary
                Assembly asm = Assembly.Load("AttributedCarLibrary");

                Type vehicleDsc = asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");

                // Get Type info of the Description property
                PropertyInfo propDsc = vehicleDsc.GetProperty("Description");

                Type[] types = asm.GetTypes();

                foreach(Type t in types)
                {
                    object[] objs = t.GetCustomAttributes(vehicleDsc, false);

                    // Iterate over each VehicleDescriptionAttribute and print
                    // the description using late binding
                    foreach(object o in objs)
                    {
                        Console.WriteLine("->{0}: {1}\n",t.Name, propDsc.GetValue(o,null));
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
