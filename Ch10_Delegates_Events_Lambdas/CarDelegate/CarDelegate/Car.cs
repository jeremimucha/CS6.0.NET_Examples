using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDelegate
{
    class Car
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }

        // Is the car alive or dead?
        private bool carIsDead;

        // class constructors
        public Car() { }
        public Car(string name, int maxSpd, int currSpd)
        {
            CurrentSpeed = currSpd;
            MaxSpeed = maxSpd;
            PetName = name;
        }

        // Define a delegate type
        public delegate void CarEngineHandler(string msgForCaller);

        // Define a member variable of this delegate
        private CarEngineHandler listOfHandlers;

        // Add registration function for the caller
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }

        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }

        // method to invoke the delegate's
        // invocation list under the correct circumstances
        public void Accelerate(int delta)
        {
            // if this car is 'dead', send dead message
            if( carIsDead )
            {
                if( listOfHandlers != null )
                    listOfHandlers("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;

                // Is  this car 'almost dead?'
                if( 10 == (MaxSpeed - CurrentSpeed)
                    && listOfHandlers != null )
                {
                    listOfHandlers("Careful buddy! It's gonna blau!");
                }
                if( CurrentSpeed >= MaxSpeed )
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
}
