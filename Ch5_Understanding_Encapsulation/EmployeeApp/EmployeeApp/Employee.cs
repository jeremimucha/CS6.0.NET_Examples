using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    class Employee
    {
        // static data
        private static double bonusRate = 0.85;
        // Field data
        private string empName;
        private int empAge;
        private string empSSN;
        private int empID;
        private float currPay;

        // Properties
        // the 'value' is a contextual keyword - when used in the set scope
        // of the property - it represents the value being assigned by the caller
        // it is of the same type as the property itself.
        public string Name
        {
            get { return empName; }
            set {
                if( value.Length > 15 )
                    Console.WriteLine("Error! Name length exceeds 15 chars!");
                else
                    empName = value;
            }
        }

        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }

        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }

        public int Age
        {
            get { return empAge; }
            set {
                if( value < 0 || value > 100 )
                    Console.WriteLine("<Employe.Age>: Error! Invalid Age value");
                else
                    empAge = value;
            }
        }

        // read-only property
        public string SSN
        {
            get { return empSSN; }
        }

        // static property
        public static double BonusRate
        {
            get { return bonusRate; }
            set { bonusRate = value; }
        }

        // Constructors
        public Employee() { }
        public Employee(string name, int id, float pay)
            : this(name, 0, "", id, pay) { }
        public Employee(string name, int age, int id, float pay)
            : this(name, age, "", id, pay) { }
        public Employee(string name, int age, string ssn, int id, float pay)
        {
            // Use properties to set the values in constructor to avoid
            // duplicating code with the properties
            Name = name;
            Age = age;
            empSSN = ssn;
            ID = id;
            Pay = pay;
        }

        public void GiveBonus(float amount)
        {
            Pay += (float)(amount * BonusRate);
        }

        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("ID: {0}", ID);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Pay: {0}", Pay);
        }
    }
}
