using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.ConnectedLayer;
using AutoLotDAL.Models;
using System.Configuration;
using System.Data;
using static System.Console;


namespace AutoLotCUIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** The AutoLot Console UI *****\n");

            // Get connection string from App.config
            string conStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            bool userDone = false;
            string userCommand = "";

            // Create our InventoryDAL object
            InventoryDAL invDAL = new InventoryDAL();
            invDAL.OpenConnection(conStr);

            // Keep asking for input until user presses the Q key
            try
            {
                ShowInstructions();
                do
                {
                    Write("\nPlease enter your command: ");
                    userCommand = ReadLine();
                    WriteLine();
                    switch (userCommand?.ToUpper() ?? "")
                    {
                        case "I":
                            InsertNewCar(invDAL);
                            break;
                        case "U":
                            UpdateCarPetName(invDAL);
                            break;
                        case "D":
                            DeleteCar(invDAL);
                            break;
                        case "L":
                            ListInventory(invDAL);
                            break;
                        case "S":
                            ShowInstructions();
                            break;
                        case "P":
                            LookUpPetName(invDAL);
                            break;
                        case "Q":
                            userDone = true;
                            break;
                        default:
                            WriteLine("Bad data! Try again!");
                            break;
                    }
                } while (!userDone);
            }catch(Exception e)
            {
                WriteLine(e.Message);
            }
            finally
            {
                invDAL.CloseConnection();
            }
        }

        private static void ShowInstructions()
        {
            WriteLine("I: Inserts a new car.");
            WriteLine("U: Updates an existing car");
            WriteLine("D: Deletes an existing car.");
            WriteLine("L: Lists current inventory.");
            WriteLine("S: Shows these instructions.");
            WriteLine("P: Looks up pet name.");
            WriteLine("Q: Quits program.");
        }

        private static void ListInventory(InventoryDAL invaDAL)
        {
            DataTable dt = invaDAL.GetAllInventoryAsDataTable();
            DisplayTable(dt);
        }

        private static void DisplayTable(DataTable dt)
        {
            for(int col = 0; col<dt.Columns.Count; ++col)
            {
                Write($"{dt.Columns[col].ColumnName}\t");
            }
            WriteLine("\n----------------------------------");

            for(int row = 0; row<dt.Rows.Count; ++row)
            {
                for(int col = 0; col<dt.Columns.Count; ++col)
                {
                    Write($"{dt.Rows[row][col]}\t");
                }
                WriteLine();
            }
        }

        private static void ListInventoryViaList(InventoryDAL invdal)
        {
            List<NewCar> record = invdal.GetAllInventoryAsList();

            WriteLine("CarId:\tMake:\tColor:\tPetName:");
            foreach(NewCar c in record)
            {
                WriteLine($"{c.CarId}\t{c.Make}\t{c.Color}\t{c.PetName}");
            }
        }

        private static void DeleteCar(InventoryDAL invdal)
        {
            // Get ID of car to delete
            Write("Enter ID of Car to delete: ");
            int id = int.Parse(ReadLine() ?? "0");

            // Just in cas eyou have a referential integrity violation
            try
            {
                invdal.DeleteCar(id);
            }catch(Exception e)
            {
                WriteLine(e.Message);
            }
        }

        private static void InsertNewCar(InventoryDAL invdal)
        {
            Write("Enter Car ID: ");
            var newCarId = int.Parse(ReadLine() ?? "0");
            Write("Enter Car Color: ");
            var newCarColor = ReadLine();
            Write("Enter Car Make: ");
            var newCarMake = ReadLine();
            Write("Enter Pet Name: ");
            var newCarPetName = ReadLine();

            // Now pass to dat aaccess library
            invdal.InsertAuto(newCarId, newCarColor, newCarMake, newCarPetName);
        }

        private static void UpdateCarPetName(InventoryDAL invdal)
        {
            Write("Enter Car ID: ");
            var carID = int.Parse(ReadLine() ?? "0");
            Write("Enter new Pet Name: ");
            var newCarPetName = ReadLine();

            // Now pass to data access library
            invdal.UpdateCarPetName(carID, newCarPetName);
        }

        private static void LookUpPetName(InventoryDAL invdal)
        {
            // Get ID of car to look up
            Write("Enter ID of Car ot look up");
            int id = int.Parse(ReadLine() ?? "0");
            WriteLine($"Petname of {id} is {invdal.LookUpPetName(id).TrimEnd()}.");
        }
    }

}
