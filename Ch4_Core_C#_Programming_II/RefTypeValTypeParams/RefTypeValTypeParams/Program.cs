using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTypeValTypeParams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Passing Person object by value *******");
            Person fred = new Person("Fred", 12);
            Console.WriteLine("\nBefore by value call, Person is:");
            fred.Display();
            SendPersonByValue(fred);
            Console.WriteLine("\nAfter by value call, Person is:");
            fred.Display();


            // Passing ref-types by ref
            Console.WriteLine("**** Passing Person object by reference ****");
            Person mel = new Person("Mel", 23);
            Console.WriteLine("Before by ref call, Person is:");
            mel.Display();
            SendPersonByeReference(ref mel);
            Console.WriteLine("After by ref call, Person is:");
            mel.Display();


            Console.ReadLine();
        }

        static void SendPersonByValue(Person p)
        {
            // Change the age of p
            p.personAge = 99;

            // Will the caller see this reassignment?
            p = new Person("Nikki", 99);
        }

        static void SendPersonByeReference(ref Person p)
        {
            // Change some data of "p"
            p.personAge = 555;

            // "p" is now pointing to a new object on the heap!
            p = new Person("Nikki", 999);
        }
    }

    class Person
    {
        public string personName;
        public int personAge;

        // Constructors
        public Person(string name, int age)
        {
            personName = name;
            personAge = age;
        }
        public Person() { }

        public void Display()
        {
            Console.WriteLine("Name: {0}, Age: {1}", personName, personAge);
        }
    }
}
