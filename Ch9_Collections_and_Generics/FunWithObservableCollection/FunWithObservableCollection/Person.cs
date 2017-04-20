using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithObservableCollection
{
    class Person
    {
        public static PersonSortByAge CompareByAge { get; } = PersonSortByAge.Instance;

        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        

        public Person() { }
        public Person(string firstName, string lastName, int age)
        { Age = age; FirstName = firstName; LastName = lastName; }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}, Age: {2}",
                FirstName, LastName, Age);
        }
    }

    class PersonSortByAge : IComparer<Person>
    {
        static readonly PersonSortByAge instance;
        public static PersonSortByAge Instance
        { get { return instance; } }

        static PersonSortByAge()
        { instance = new PersonSortByAge(); }

        private PersonSortByAge() { }

        public int Compare(Person a, Person b)
        {
            return a.Age - b.Age;
        }
    }
}
