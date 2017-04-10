using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args){
            // Set up consile UI
            Console.Title = "My Mothafuckin' App";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("****************************************");
            Console.WriteLine("**** Welcome to My Mothafuckin' App ****");
            Console.WriteLine("****************************************");
            Console.BackgroundColor = ConsoleColor.Black;

            // Wait for Enter to be pressed
            Console.ReadLine();
            MessageBox.Show("All done!");
        }
    }
}
