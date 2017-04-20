using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerMethods
{
    // Interfaces can declare indexers
    // which then need to be implemented
    public interface IStringContainer
    {
        string this[int index] { get; set; }
    }

    public class SomeClass : IStringContainer
    {
        private List<string> myStrings = new List<string>();

        // Implement the IStingContainer indexer
        public string this[int index]
        {
            get { return myStrings[index]; }
            set { myStrings.Insert(index, value); }
        }
    }

    public class SomeOtherClass : IEnumerable
    {
        private Dictionary<string, MyClass> dict = new Dictionary<string, MyClass>();

        public MyClass this[string k]
        {
            get { return (MyClass)dict[k]; }
            set { dict[k] = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        { return dict.GetEnumerator(); }
    }

    public class MyClass
    {
        public string Variable { get; set; } = "";
        MyClass() { }
        MyClass(string v)
        {
            Variable = v;
        }
    }

    public class TwoDContainer
    {
        private int[,] twoD = new int[10, 10];

        public int this[int row, int column]
        {
            get { return twoD[row, column]; }
            set { twoD[row, column] = value; }
        }
    }
}
