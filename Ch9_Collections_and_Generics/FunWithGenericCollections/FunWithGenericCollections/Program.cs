using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            UseGenericList();
            UseGenericStack();
            UseSortedSet();
            UseDictionary();
        }

        static void UseGenericList()
        {
            Console.WriteLine("\n->UseGenericList:");
            List<Person> persons = new List<Person> {
                new Person("Homer", "Simpson", 47),
                new Person("Marge", "Simpson", 48),
                new Person("Lisa", "Simpson", 9),
                new Person("Bart", "Simpson",8)
            };

            Console.WriteLine("Number of items: {0}", persons.Count);

            foreach( Person p in persons )
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Inserting new Person\n");
            persons.Insert(2, new Person("Maggie", "Simpson", 2));
            Console.WriteLine("Items in list: {0}", persons.Count);

            // copy data into a new array
            Person[] ppl_array = persons.ToArray();
            for( int i = 0; i < ppl_array.Length; ++i )
            {
                Console.WriteLine("First Names: {0}", ppl_array[i].FirstName);
            }
        }

        static void UseGenericStack()
        {
            Console.WriteLine("\n->UseGenericStack:");
            Stack<Person> persons = new Stack<Person>();
            persons.Push(new Person("Homer", "Simpson", 47));
            persons.Push(new Person("Marge", "Simpson", 48));
            persons.Push(new Person("Lisa", "Simpson", 9));
            try {
                for( int i = 0; ; ++i )
                {
                    Console.WriteLine("{0} Person is: {1}", i, persons.Peek());
                    Console.WriteLine("Popped off {0}", persons.Pop());
                }
            }catch( InvalidOperationException e )
            {
                Console.WriteLine("\nError: {0}",e.Message);
            }
        }

        static void UseSortedSet()
        {
            Console.WriteLine("\n->UseSortedSet");
            SortedSet<Person> pplset = new SortedSet<Person>(Person.CompareByAge) {
                new Person("Homer", "Simpson", 47),
                new Person("Marge", "Simpson", 48),
                new Person("Lisa", "Simpson", 9),
                new Person("Bart", "Simpson",8)
            };

            foreach(Person p in pplset )
            {
                Console.WriteLine(p);
            }

            pplset.Add(new Person("Some", "Dude", 23));
            pplset.Add(new Person("Some", "Dudette", 19));

            foreach(Person p in pplset )
            {
                Console.WriteLine(p);
            }
        }

        static void UseDictionary()
        {
            Console.WriteLine("\n->UseDictionary:");
            Dictionary<string, Person> ppldict = new Dictionary<string, Person>() {
                {"Homer", new Person("Homer", "Simpson", 47) },
                {"Marge", new Person("Marge", "Simpson", 48) },
                {"Lisa", new Person("Lisa", "Simpson", 9) },
                {"Bart", new Person("Bart", "Simpson",8) }
            };
            Person p = ppldict["Homer"];
            Console.WriteLine(p);

            // Dictionary initialization syntax:
            Dictionary<string, Person> ppldict2 = new Dictionary<string, Person>() {
                ["Homer"] = new Person("Homer", "Simpson", 47),
                ["Marge"] = new Person("Marge", "Simpson", 48),
                ["Lisa"] = new Person("Lisa", "Simpson", 9),
                ["Bart"] = new Person("Bart", "Simpson", 8)
            };
            Console.WriteLine(ppldict2["Lisa"]);
        }
    }
}
