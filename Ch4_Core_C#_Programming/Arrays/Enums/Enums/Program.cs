using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    class Program
    {
        static void Main(string[] args)
        {
            EmpType employee = EmpType.Contractor;
            AskForBonus(employee);
            Console.WriteLine(Enum.GetUnderlyingType(employee.GetType()));

            EmpTypeB empB = EmpTypeB.Manager;
            Console.WriteLine("{0} == {1}", empB.ToString(), (byte)empB);
            Console.WriteLine(Enum.GetUnderlyingType(typeof(EmpTypeB)));

            Console.WriteLine("**** Evaluating Enums ****");
            EmpType e2 = EmpType.Contractor;
            // These types are Enums in the System namespace
            DayOfWeek day = DayOfWeek.Monday;
            ConsoleColor cc = ConsoleColor.Blue;

            EvalueateEnum(e2);
            EvalueateEnum(day);
            EvalueateEnum(cc);

            Console.ReadLine();
        }

        static void AskForBonus(EmpType emp)
        {
            switch( emp )
            {
                case EmpType.Manager:
                    Console.WriteLine("Manager bonus");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("Grunt bonus");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("Contractor bonus");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("VicePresident bonus");
                    break;
            }
        }

        static void EvalueateEnum(System.Enum e)
        {
            Console.WriteLine("=> Information about {0}", e.GetType().Name);
            Console.WriteLine("Underlying storage type: {0}", Enum.GetUnderlyingType(e.GetType()));

            // Get all name/value pairs
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);

            // Now show the string name and associated value, using the D format flag
            for(int i=0; i<enumData.Length; ++i )
            {
                Console.WriteLine("Name: {0}, Value: {0:D}", enumData.GetValue(i));
            }
        }
    }

    enum EmpType
    {
        Manager = 102,
        Grunt,
        Contractor,
        VicePresident,
        Baller = 222,
        Nerd = 144 // values don't need to be sequential
    }

    // The default underlying storage type for enum is System.Int32 (i.e. int)
    // A different type can be declared
    enum EmpTypeB : byte
    {
        Manager = 10,
        Grunt,
        Contractor
    }

}

// bzwbk