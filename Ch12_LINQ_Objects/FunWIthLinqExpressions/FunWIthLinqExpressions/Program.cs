using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWIthLinqExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with LINQ Expressions *****\n");
            ProductInfo[] products = {
                new ProductInfo{ Name = "Mac's Coffee",
                Description = "Coffee with TEETH",
                NumberInStock = 24},
                new ProductInfo{ Name = "Milk Maid Milk",
                Description = "Milk cow's love",
                NumberInStock = 100},
                new ProductInfo{ Name = "Pure Silk Tofu",
                Description = "Bland as Possible",
                NumberInStock = 120},
                new ProductInfo{ Name = "Cruchy Pops",
                Description = "Cheezy, peppery goodness",
                NumberInStock = 2},
                new ProductInfo{ Name = "RipOff Water",
                Description = "From the tap to your wallet",
                NumberInStock = 100},
                new ProductInfo{ Name = "Classic Valpo Pizza",
                Description = "Everyone loves pizza!",
                NumberInStock = 73}
            };

            SelectEveryting(products);
            ListProductNames(products);
            GetOverStock(products);
            GetNamesAndDescriptions(products);
            Array objs = GetProjectedSubset(products);
            foreach( object o in objs )
                Console.WriteLine(o);
            GetCountFromQuery();
            ReverseEverything(products);
            AlphabetizeProductNames(products);

            Console.WriteLine("\nUnions, differences, concatenations, intersections:");
            DisplayDiff(); Console.WriteLine();
            DisplayUnion(); Console.WriteLine();
            DisplayIntersection(); Console.WriteLine();
            DisplayConcat(); Console.WriteLine();
            DisplayConcatNoDups();

            Console.WriteLine("\nAggregation Operations:");
            AggregateOps();

            Console.ReadLine();
        }

        static void SelectEveryting(ProductInfo[] products)
        {
            Console.WriteLine("All Products details:");
            var allProducts = from p in products select p;
            foreach( var p in allProducts )
                Console.WriteLine(p);
        }

        static void ListProductNames(ProductInfo[] products)
        {
            Console.WriteLine("Only product Names:");
            var names = from p in products select p.Name;
            foreach( var v in names )
                Console.WriteLine("Name: {0}",v);
        }

        static void GetOverStock(ProductInfo[] products)
        {
            Console.WriteLine("Over stock items:");
            var overstock = from item in products
                            where item.NumberInStock > 25
                            select item;
            foreach( var item in overstock )
                Console.WriteLine(item);
        }

        static void GetNamesAndDescriptions(ProductInfo[] products)
        {
            Console.WriteLine("Names and Descriptions:");
            var nameDesc = from p in products
                           select new { p.Name, p.Description };
            foreach(var item in nameDesc )
            {
                Console.WriteLine("Name: {0}, Desc: {1}", item.Name, item.Description);
                // Or use the automatically-overloaded ToString() of the anon-type
                // Console.WriteLine(item);
            }
        }

        static Array GetProjectedSubset(ProductInfo[] products)
        {
            // Returns an array of Object
            var subset = from p in products
                         select new { p.Name, p.Description };
            return subset.ToArray();
        }

        static void GetCountFromQuery()
        {
            string[] currentVideoGames = {"Morrowind", "Uncharted 2",
                        "Fallout 3", "Daxter", "System Shock 2"};
            int numb = (from g in currentVideoGames
                        where g.Length > 6 select g).Count();
            Console.WriteLine("Games with name lenght > 6: {0}", numb);
        }

        static void ReverseEverything(ProductInfo[] products)
        {
            Console.WriteLine("Products in reverse:");
            var allPr = from p in products select p;
            foreach( var p in allPr.Reverse() )
                Console.WriteLine(p);
        }

        static void AlphabetizeProductNames(ProductInfo[] products)
        {
            // Get names of products, alphabetized
            var subset = from p in products
                         orderby p.Name select p;
            // ascending is the default order, but can be made explicit:
            // var sub = from p in products
            //           orderby p.Name ascending
            //           select p;
            Console.WriteLine("Ordered by name: ");
            foreach( var v in subset )
                Console.WriteLine(v);

            var descending_ordering = from p in products
                                      orderby p.Name descending
                                      select p;
            Console.WriteLine("Descending order:");
            foreach (var v in descending_ordering)
                Console.WriteLine(v);
        }

        static void DisplayDiff()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carDiff = (from c in myCars select c)
                .Except(from c2 in yourCars select c2);

            Console.WriteLine("DisplayDiff():");
            foreach (string s in carDiff)
                Console.WriteLine(s);
        }

        static void DisplayIntersection()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            // Get common  members
            var carIntersect = (from c in myCars select c)
                .Intersect(from c2 in yourCars select c2);

            Console.WriteLine("DisplayIntersection():");
            foreach (string s in carIntersect)
                Console.WriteLine(s);
        }

        static void DisplayUnion()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            // get the union of containers
            var carUnion = (from c in myCars select c)
                .Union(from c2 in yourCars select c2);

            Console.WriteLine("DisplayUnion():");
            foreach (string s in carUnion)
                Console.WriteLine(s);
        }

        static void DisplayConcat()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carConcat = (from c in myCars select c)
                .Concat(from c2 in yourCars select c2);

            Console.WriteLine("DisplayConcat():");
            foreach (string s in carConcat)
                Console.WriteLine(s);
        }

        static void DisplayConcatNoDups()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carConcat = (from c in myCars select c)
                .Concat(from c2 in yourCars select c2);

            Console.WriteLine("DisplayConcatNoDups():");
            foreach (string s in carConcat.Distinct())
                Console.WriteLine(s);
        }

        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };

            // various aggregation examples
            Console.WriteLine("Max temp: {0}",
                (from t in winterTemps select t).Max());

            Console.WriteLine("Min temp: {0}",
                (from t in winterTemps select t).Min());

            Console.WriteLine("Average temp: {0}",
                (from t in winterTemps select t).Average());

            Console.WriteLine("Sum of all temps: {0}",
                (from t in winterTemps select t).Sum());
        }
    }
}
