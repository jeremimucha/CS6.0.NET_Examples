using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class Car
    {
        // Automatic properties. No need to define backing fields
        public string PetName { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }
        
        // ReadOnlyProp
        public int ReadOnlyProp { get; }

        public void DisplayStats()
        {
            Console.WriteLine("Car( {0}, {1}, {2} )", PetName, Speed, Color);
        }
    }
}
