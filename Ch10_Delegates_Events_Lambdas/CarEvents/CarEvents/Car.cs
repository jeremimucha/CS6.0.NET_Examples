using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvents
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

        // This car can send these events
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        // method to invoke the delegate's
        // invocation list under the correct circumstances
        public void Accelerate(int delta)
        {
            // if this car is 'dead', send dead message
            if( carIsDead )
            {
                //if( Exploded != null )
                //    Exploded("Sorry, this car is dead...");
                // Simplified syntax with the null conditional operator
                Exploded?.Invoke("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;

                // Is  this car 'almost dead?'
                //if( 10 == (MaxSpeed - CurrentSpeed)
                //    && AboutToBlow != null )
                //{
                //    AboutToBlow("Careful buddy! It's gonna blau!");
                //}
                // Simplified syntax with the null conditional operator
                if( 10 == (MaxSpeed - CurrentSpeed) )
                    AboutToBlow?.Invoke("Careful buddy! It's gonna blow!");
                if( CurrentSpeed >= MaxSpeed )
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
}
