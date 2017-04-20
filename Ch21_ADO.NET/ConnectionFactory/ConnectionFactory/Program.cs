using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;


namespace ConnectionFactory
{
    // A list of possible providers
    enum DataProvider
    { SqlServer, OleDb, Odbc, None }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Very simple Connection Factory *****\n");
            // Get a specific connection
            IDbConnection con = GetConnection(DataProvider.SqlServer);
            Console.WriteLine($"Your connection is a {con.GetType().Name}");

            // Open, use and close connection

            Console.ReadLine();

        }

        // This method returns a specific connection obj
        // based on the value of a DataProvider enum
        static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection con = null;
            switch (dataProvider)
            {
                case DataProvider.SqlServer:
                    con = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    con = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    con = new OdbcConnection();
                    break;
            }
            return con;
        }
    }
}
