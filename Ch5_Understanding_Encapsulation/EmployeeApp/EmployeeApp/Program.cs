using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("Donger", 27, 111222, 3339.12f);

            // Reset and then get the Name property
            emp.Name = "Marv";
            Console.WriteLine("Employee is named: {0}", emp.Name);
            Console.ReadLine();

            // Encapsulating data using properties allows us to use intrinsic C# operators
            emp.Age++;
        }
    }
}
