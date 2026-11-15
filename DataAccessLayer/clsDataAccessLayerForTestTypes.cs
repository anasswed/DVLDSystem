using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    
    public class clsDataAccessLayerForTestTypes
    {
        public static DataTable GetAllTestTypes()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * From TestTypes";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable table = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
             
                table.Load(reader);
               
                
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return table;
        }

        public static bool FindTestTypeByID(int TestTypeID,ref string Title,ref string Description,ref decimal Fees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * from TestTypes WHERE TestTypeID=@TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    Title = (string)reader["TestTypeTitle"];
                    Description = (string)reader["TestTypeDescription"];
                    Fees = Convert.ToDecimal(reader["TestTypeFees"]);
                    IsFound = true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static int GetNumberOfTestType()
        {
            int NumberOfTestType = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select count(*) From TestTypes";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result!=null)
                {
                    NumberOfTestType = (int)result;
                }
            }
            catch(Exception ex)
            {
                throw ex;

            }
            finally
            {
                connection.Close();
            }
            return NumberOfTestType;
        }
        public static bool UpdateTestTypeInfo(int TestTypeID,string Title,string Description, decimal Fees)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Update TestTypes set TestTypeDescription=@Description,
                                                 TestTypeTitle=@Title,
                                                  TestTypeFees=@Fees
                                                WHERE TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@Fees", Fees);
            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if(rowAffected>0)
                {
                    IsUpdated = true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsUpdated;
        }
    }
}
