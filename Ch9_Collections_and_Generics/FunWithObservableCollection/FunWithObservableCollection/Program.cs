using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FunWithObservableCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<Person> persons = new ObservableCollection<Person>() {
                new Person("Peter", "Murphy", 52),
                new Person("Kevin", "Key", 48)
            };
            // Register an even handler
            persons.CollectionChanged += persons_CollectionChanged;
            persons.Add(new Person("Some", "Dude", 42));
            Person p = new Person("Another", "Dude", 44);
            persons.Add(p);
            persons.Remove(p);
        }

        static void persons_CollectionChanged(object sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // What was the action that triggered the event?
            Console.WriteLine("Action for this event: {0}", e.Action);

            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove )
            {
                Console.WriteLine("OLD Items:");
                foreach( Person p in e.OldItems )
                    Console.WriteLine(p);
                Console.WriteLine();
            }
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add )
            {
                Console.WriteLine("NEW Items:");
                foreach( Person p in e.NewItems )
                    Console.WriteLine(p);
                Console.WriteLine();
            }
        }
    }
}
