using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CustomEnumerator
{
    class Garage : IEnumerable
    {
        private Car[] cararray = new Car[4];
        public Garage()
        {
            cararray[0] = new Car("Rusty", 30);
            cararray[1] = new Car("Clunker", 55);
            cararray[2] = new Car("Zippy", 30);
            cararray[3] = new Car("Fred", 30);
        }

        public IEnumerator GetEnumerator()
        {
            return cararray.GetEnumerator();
        }
    }
}
