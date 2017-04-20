using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    class Car
    {
        public const int MaxSpeed = 100;
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";

        private bool carIsDead;

        private Radio theMusicBox = new Radio();

        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }
        
        public void CrankTunes(bool state)
        {
            // Delegate to the inner Radio obj.
            theMusicBox.TurnOn(state);
        }

        // See if Car has overheated
        public void Accelerate(int delta)
        {
            if( delta < 0 )
                throw new
                    ArgumentOutOfRangeException("delta", "Speed must be greater than zero!");
            if( carIsDead )
                Console.WriteLine("{0} is out of order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if( CurrentSpeed > MaxSpeed )
                {
                    CurrentSpeed = 0;
                    carIsDead = true;
                    CarIsDeadException ex =
                        new CarIsDeadException(string.Format("{0} has overheated!", PetName),
                            "You have a lead foot", DateTime.Now);
                    ex.HelpLink = "http://www.CarsRUs.com";
                    throw ex;
                }
                else
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
}
