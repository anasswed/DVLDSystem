using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsDataAccessLayerForApplicationTypes
    {
        public static DataTable GetAllApplicationTypes()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * From ApplicationTypes";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable dtApplicationType = new DataTable();



            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dtApplicationType.Load(reader);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                connection.Close();
            }
            return dtApplicationType;
        }

        public static bool FindApplicationTypeByID(int ApplicationTypeID,ref string Title,ref decimal Fees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * From ApplicationTypes WHERE ApplicationTypeID=@ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    Title = (string)reader["ApplicationTypeTitle"];
                    Fees = Convert.ToDecimal(reader["ApplicationFees"]);
                    IsFound = true;
                }
                reader.Close();
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

        public static bool UpdateApplicationTypeInfo(int ApplicationTypeID,string Title,decimal Fees)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Update ApplicationTypes set ApplicationTypeTitle=@Title,
                                                        ApplicationFees=@Fees
                                                        WHERE ApplicationTypeID=@ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@Title", Title);
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

