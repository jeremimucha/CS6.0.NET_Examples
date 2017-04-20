using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using AutoLotDAL.Models;


namespace AutoLotDAL.ConnectedLayer
{
    public class InventoryDAL
    {
        private SqlConnection _sqlConnection = null;

        public void OpenConnection(string connectionString)
        {
            _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();
        }

        public void CloseConnection()
        {
            _sqlConnection.Close();
        }

        public void InsertAuto(int id, string color, string make, string petName)
        {
            // Format and execute SQL statement
            string sql = "Insert Into Inventory" +
                "(Make, Color, PetName) Values" +
                "(@Make, @Color, @PetName)";

            // Execute using our connection
            using (SqlCommand com = new SqlCommand(sql, _sqlConnection))
            {
                // Fill params collection
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@Make",
                    Value = make,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                com.Parameters.Add(param);

                param = new SqlParameter
                {
                    ParameterName = "@Color",
                    Value = color,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                com.Parameters.Add(param);

                param = new SqlParameter
                {
                    ParameterName = "@PetName",
                    Value = petName,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                com.Parameters.Add(param);

                com.ExecuteNonQuery();
            }
        }

        public void InsertAuto(NewCar car)
        {
            // Format and execute SQL statement
            string sql = "Insert Into Inventory (Make, Color, PetName) Values" +
                $"('{car.Make}', '{car.Color}', '{car.PetName}')";

            using (SqlCommand com = new SqlCommand(sql, _sqlConnection))
            {
                com.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int id)
        {
            // Deleting the car with the specified CarId
            string sql = $"Delete from Inventory where CarId = '{id}'";
            using (SqlCommand com = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    com.ExecuteNonQuery();
                }catch(SqlException e)
                {
                    Exception error = new Exception("Sorry! That car is on order!", e);
                    throw error;
                }
            }
        }

        public void UpdateCarPetName(int id, string newPetName)
        {
            // Update the PetName of the car with the specified CarId
            string sql = $"Update Inventory Set PetName = '{newPetName}' Where CarId = '{id}'";
            using (SqlCommand com = new SqlCommand(sql, _sqlConnection))
            {
                com.ExecuteNonQuery();
            }
        }

        public List<NewCar> GetAllInventoryAsList()
        {
            // This will hold the records
            List<NewCar> inv = new List<NewCar>();

            // Prep command object
            string sql = "Select * From Inventory";
            using (SqlCommand com = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader dataReader = com.ExecuteReader();
                while (dataReader.Read())
                {
                    inv.Add(new NewCar
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    });
                }
                dataReader.Close();
            }
            return inv;
        }

        public DataTable GetAllInventoryAsDataTable()
        {
            // This will hold the records
            DataTable dt = new DataTable();

            // Prep command
            string sql = "Select * From Inventory";
            using (SqlCommand cmd = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                // Fill the DataTable with data from the reader and clean up
                dt.Load(reader);
                reader.Close();
            }
            return dt;
        }

        public string LookUpPetName(int carID)
        {
            string carPetName;

            // Establish name of stored proc.
            using (SqlCommand cmd = new SqlCommand("GetPetName", _sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Input param
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@carID",
                    SqlDbType = SqlDbType.Int,
                    Value = carID,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(param);

                // output param
                param = new SqlParameter
                {
                    ParameterName = "@petName",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(param);

                // execute stored procedure
                cmd.ExecuteNonQuery();

                // return output param
                carPetName = (string)cmd.Parameters["@petName"].Value;
            }
            return carPetName;
        }

        public void ProcessCreditRisk(bool throwEx, int custId)
        {
            // First look up curent name based on customer ID
            string fName;
            string lName;
            var cmdSelect =
                new SqlCommand($"Select * from Customers where CustId = {custId}", _sqlConnection);
            using (var reader = cmdSelect.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    fName = (string)reader["FirstName"];
                    lName = (string)reader["LastName"];
                }
                else
                {
                    return;
                }
            }

            var cmdRemove =
                new SqlCommand($"Delete from Customers where CustId = {custId}", _sqlConnection);
            var cmdInsert =
                new SqlCommand($"Insert Into CreditRisks (Firstname, LastName) Values('{fName}', '{lName}')", _sqlConnection);

            SqlTransaction tx = null;
            try
            {
                tx = _sqlConnection.BeginTransaction();

                // Enlist the commands into this transaction
                cmdInsert.Transaction = tx;
                cmdRemove.Transaction = tx;

                // execute the commands
                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();

                // simulate error
                if (throwEx)
                {
                    throw new Exception("Sorry! Database error! Tx failed...");
                }

                // Commit it!
                tx.Commit();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                // Any error will roll back transaction
                // Using the new conditional access operator to check for null
                tx?.Rollback();
            }
        }

    }
}
