using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaMultipleParams
{
    class Program
    {
        public delegate string VerySimpleDelegate();

        static void Main(string[] args)
        {
            SimpleMath m = new SimpleMath();
            m.SetMathHandler((msg, result) => {
                Console.WriteLine("Message: {0}, Result: {1}", msg, result);
            });

            // This will execute the lambda expression
            m.Add(10, 10);
            VerySimpleDelegate vsd = new VerySimpleDelegate(
                () => { return "Enjoy your string!"; });
            Console.WriteLine(vsd());


            Console.ReadLine();
        }
    }
}
