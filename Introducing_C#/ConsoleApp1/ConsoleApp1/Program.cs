using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConsoleIO
{
    class Program
    {
        static void Main(string[] args){
            Console.WriteLine("***** Basic Console I/O *****");
            GetUserData();
            FormatNumericalData();
            DisplayMessage();
            Console.ReadLine();
        }

        private static void GetUserData()
        {
            // get name and age
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            Console.Write("Please enter your age: ");
            string userAge = Console.ReadLine();

            // Change echo color,
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Echo to the console
            Console.WriteLine("Hello {0}! You are {1} years old.", userName, userAge);

            // Restore previous color
            Console.ForegroundColor = prevColor;
        }

        private static void FormatNumericalData()
        {
            int value = 99999;
            Console.WriteLine("The value {0} in various formats:",value);
            Console.WriteLine("c format: {0:c}", value);
            Console.WriteLine("d9 format: {0:d9}", value);
            Console.WriteLine("f3 format: {0:f3}", value);
            Console.WriteLine("n format: {0:n}", value);

            // Notice that upper- or lovercasing for hex
            // determines if letters are upper- or lowercase.
            Console.WriteLine("E format: {0:E}", value);
            Console.WriteLine("e format: {0:e}", value);
            Console.WriteLine("X format: {0:X}", value);
            Console.WriteLine("x format: {0:x}", value);
        }

        private static void DisplayMessage()
        {
            string userMessage = string.Format("100000 in hex is {0:x}", 100000);
            System.Windows.MessageBox.Show(userMessage);
        }
    }
}
