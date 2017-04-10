using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ over Generic Collections *****");
            List<Car> cars = new List<Car> {
                new Car{PetName="One", Color="Red", Speed=100, Make="BMW" },
                new Car{PetName="Two", Color="Dark Red", Speed=80, Make="VW" },
                new Car{PetName="Three", Color="Yellow", Speed=60, Make="Ford" },
                new Car{PetName="Four", Color="Black", Speed=40, Make="Merc" },
                new Car{PetName="Five", Color="White", Speed=20, Make="Fiat" }
            };

            GetFastCars(cars);
            GetFastBMWs(cars);
            LinqOverArrayList();
            OfTypeAsFilter();
            Console.ReadLine();
        }

        static void GetFastCars(List<Car> cars)
        {
            var fastCars = from car in cars where car.Speed > 40 select car;
            foreach( var car in fastCars )
                Console.WriteLine("{0} is going {1}", car.PetName, car.Speed);
        }

        static void GetFastBMWs(List<Car> cars)
        {
            var fastBMWs = from car in cars where car.Speed > 40 && car.Make == "BMW" select car;
            foreach( var car in fastBMWs )
                Console.WriteLine("{0} is a {1} going {2}", car.PetName, car.Make, car.Speed);
        }

        static void LinqOverArrayList()
        {
            Console.WriteLine("***** LINQ Over ArrayList *****");
            ArrayList cars = new ArrayList {
                new Car{PetName="One", Color="Red", Speed=100, Make="BMW" },
                new Car{PetName="Two", Color="Dark Red", Speed=80, Make="VW" },
                new Car{PetName="Three", Color="Yellow", Speed=60, Make="Ford" },
                new Car{PetName="Four", Color="Black", Speed=40, Make="Merc" },
                new Car{PetName="Five", Color="White", Speed=20, Make="Fiat" }
            };

            // Transform ArrayList into IEnumerable<T>-compatible type
            var carsEnumerable = cars.OfType<Car>();

            var fastCars = from car in carsEnumerable
                           where car.Speed > 40 select car;
            foreach( var car in fastCars )
                Console.WriteLine("{0} is going {1}", car.PetName, car.Speed);

        }

        static void OfTypeAsFilter()
        {
            ArrayList a = new ArrayList();
            a.AddRange(new object[] { 10, 400, 8, "Donger", 1.2, 1.32, , new Car() });
            // OfType<> will filter out variables that don't match the type
            var myInts = a.OfType<int>();

            foreach( int i in myInts )
                Console.WriteLine("Int value: {0}",i);
        }
    }
}
