using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            int myInt = 12345678;
            myInt.DisplayDefiningAssembly();    // !?

            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiningAssembly();

            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.DisplayDefiningAssembly();

            int[] iarr = { 1, 12, 123, 1234, 12345, 123456, 1234567, 12340 };

            foreach(int i in iarr )
            {
                // new int functionality defined in "MyExtensions"
                int a = i.ReverseDigits();
                int b = i.ReverseDigitsAlt();
                if(a != b)
                {
                    Console.WriteLine("Failed: {0}, {1}", a, b);
                }
            }
        }
    }
}
