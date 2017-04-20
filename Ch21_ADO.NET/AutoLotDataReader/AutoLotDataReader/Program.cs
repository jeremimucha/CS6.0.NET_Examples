using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static System.Console;

namespace AutoLotDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Data Readers *****\n");

            // Assume the connectionString was obtained from a *.config file
            string connectionString =
                @"Data Source=.\SQLEXPRESS; Integrated Security=SSPI;Initial Catalog=AutoLot";

            var cnStringBuilder = new SqlConnectionStringBuilder(connectionString)
            {
                // Override the selected values
                InitialCatalog = "AutoLot",
                DataSource = @".\SQLEXPRESS",
                ConnectTimeout = 30,
                IntegratedSecurity = true
            };

            // Create and open a connection
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = cnStringBuilder.ConnectionString;
                con.Open();
                ShowConnectionStatus(con);

                // Create SQL command object - note that two commands are seprated with a semicolon
                string sql = "Select * From Inventory;Select * From Customers";
                SqlCommand command = new SqlCommand(sql, con);

                // Obtain a data reader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Loop over the results
                    do
                    {
                        while (reader.Read())
                        {
                            WriteLine("***** Record *****");
                            for (int i=0; i<reader.FieldCount; ++i)
                            {
                                WriteLine($"{reader.GetName(i)} = {reader.GetValue(i)}");
                            }
                            WriteLine();
                        }
                    } while (reader.NextResult());
                }
            }

            ReadLine();
        }

        static void ShowConnectionStatus(SqlConnection con)
        {
            WriteLine("***** Connection Info *****");
            WriteLine($"Database location: {con.DataSource}");
            WriteLine($"Database name: {con.Database}");
            WriteLine($"Timeout: {con.ConnectionTimeout}");
            WriteLine($"Connection state: {con.State}\n");
        }
    }
}
