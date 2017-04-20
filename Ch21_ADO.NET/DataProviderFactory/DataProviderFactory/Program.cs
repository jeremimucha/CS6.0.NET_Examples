using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;
using static System.Console;


namespace DataProviderFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Data Provider Factories *****\n");
            // Get connection string/provider from *.config
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            //string connectionString = ConfigurationManager.AppSettings["connectionString"];
            //  Use the <connectionStrings> app settings instead
            string connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            // Get the factory provider
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

            // Get the connection object
            using (DbConnection connection = factory.CreateConnection())
            {
                if(connection == null)
                {
                    ShowError("Connection");
                    return;
                }
                WriteLine($"Your connection object is a: {connection.GetType().Name}");
                connection.ConnectionString = connectionString;
                connection.Open();

                // Make command object
                DbCommand command = factory.CreateCommand();
                if(command == null)
                {
                    ShowError("Command");
                    return;
                }
                WriteLine($"Your command object is a: {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * From Inventory";

                // Print out data with data reader
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    WriteLine($"Your data reader object is a: {dataReader.GetType().Name}");
                    WriteLine("\n***** Current Inventory *****");
                    while (dataReader.Read())
                    {
                        WriteLine($"-> Car #{dataReader["CarId"]} is a {dataReader["Make"]}.");
                    }
                }
                ReadLine();
            }
        }

        private static void ShowError(string objectname)
        {
            WriteLine($"Ther was an issue creating the {objectname}");
            ReadLine();
        }
    }
}
