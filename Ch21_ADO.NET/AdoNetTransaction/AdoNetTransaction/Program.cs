using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL;
using AutoLotDAL.ConnectedLayer;
using AutoLotDAL.Models;
using static System.Console;


namespace AdoNetTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Simple Transaction Example *****\n");

            bool throwEx = true;

            Write("Do you want to throw an exception (Y or N): ");
            var userAnswer = ReadLine();
            if(userAnswer?.ToLower() == "n")
            {
                throwEx = false;
            }

            var dal = new InventoryDAL();
            dal.OpenConnection(@"Data Source=.\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=AutoLot");

            // Process customer 5 - enter id for Homer Simpson in the next line
            dal.ProcessCreditRisk(throwEx, 5);
            WriteLine("Check CreditRisk table for results");
            ReadLine();
        }
    }
}
