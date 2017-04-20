using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProps
{
    class Garage
    {
        // The hidden int backing field is set to zero
        //public int NumberOfCars { get; set; }

        // New syntax allows to set the default value
        public int NumberOfCars { get; set; } = 1;

        // The hidden Car backing field is set to null
        //public Car MyAuto { get; set; }

        public Car MyAuto { get; set; } = new Car();

        // Use constructors to override default
        // values assigned to hidden backing fields
        //public Garage()
        //{
        //    MyAuto = new Car();
        //    NumberOfCars = 1;
        //}

        // With the new default property value syntax:
        public Garage() { }

        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumberOfCars = number;
        }
    }
}
