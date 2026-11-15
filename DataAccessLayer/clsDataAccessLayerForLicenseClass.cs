using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsDataAccessLayerForLicenseClass
    {
        public static DataTable GetNameForAllLicenseClasses()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select LicenseClassID,ClassName From LicenseClasses";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable table = new DataTable();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    table.Load(reader);
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
            return table;
        }

        public static bool FindLicenseClassByID(int LicenseClassID,ref string ClassDescription,ref string ClassName,ref byte DefaultValidityLength,ref byte MinAge,ref decimal ClassFees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * from LicenseClasses WHERE LicenseClassID=@LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    ClassDescription = (string)reader["ClassDescription"];
                    ClassName = (string)reader["ClassName"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    MinAge = (byte)reader["MinimumAllowedAge"];
                    ClassFees = (decimal)reader["ClassFees"];
                    IsFound = true;

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
            return IsFound;
        }


    }
}
