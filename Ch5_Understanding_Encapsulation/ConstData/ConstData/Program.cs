using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstData
{
    class MyMathClass
    {  
        // Can be set only at compile time
        // static by default
        public const double sqrt2 = 1.41;

        // 'readonly' fields can be set in constructors at runtime
        // they're NOT static by default
        public readonly double myReadonlyVal;

        // static readonly field accessible at the class level
        // can be set at runtime as well - in the static constructor
        public static readonly double PI;

        MyMathClass()
        {
            myReadonlyVal = 2.718;
        }

        static MyMathClass()
        {
            PI = 3.14;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
