using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CustomEnumeratorWithYield
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
            foreach( Car c in cararray )
                yield return c;
        }

        public IEnumerable GetTheCars(bool reverse = false)
        {
            if( reverse )
            {
                for( int i = cararray.Length - 1; i >= 0; --i )
                    yield return cararray[i];
            }
            else
                foreach(Car c in cararray )
                {
                    yield return c;
                }
        }
    }
}
