using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsDataAccessLayerFoLicense
    {

        public static bool FindLicenseByID(int LicenseID,ref int ApplicationID,ref int DriverID,ref int LicenseClassID,
           ref DateTime IssueDate,ref DateTime ExpirationDate,ref int IssueReason,ref string Notes,ref bool IsActive,ref int CreatedByUserID,ref decimal PaidFees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * from Licenses WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try

            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    if(reader["Notes"]==DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }
                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = Convert.ToInt32(reader["IssueReason"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
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

        public static int AddNewLicense(int ApplicationID,int DriverID,int LicenseClassID,int CreatedByUserID,DateTime IssueDate,
            DateTime ExpirationDate,string Notes,int IssueReason,bool IsActive,decimal PaidFees)
        {
            int LicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"INSERT INTO Licenses(ApplicationID,DriverID,LicenseClassID,
                        IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,CreatedByUserID)
VALUES(@ApplicationID,@DriverID,@LicenseClassID,
       @IssueDate,@ExpirationDate,@Notes,
@PaidFees,@IsActive,@IssueReason,@CreatedByUserID)
                                    SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (!string.IsNullOrEmpty(Notes))
            {
                command.Parameters.AddWithValue("@Notes", Notes);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result!=null)
                {
                    LicenseID =Convert.ToInt32(result);
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
            return LicenseID;
        }
        
        public static bool FindLicenseByApplicationID(int ApplicationID,ref int LicenseID,ref int DriverID,ref int LicenseClassID,ref DateTime IssueDate,ref DateTime ExpirationDate,
            ref int IssueReason,ref string Notes,ref bool IsActive,ref int CreatedByUserID,ref decimal PaidFees )
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * from Licenses WHERE ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LicenseID = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }
                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = Convert.ToInt32(reader["IssueReason"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
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

        public static DataTable ListAllLocalLicense(int DriverID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select L.LicenseID As[Lic.ID],L.ApplicationID As[App.ID],
            LC.ClassName As[Class Name],L.IssueDate As[Issue Date],L.ExpirationDate As[Expiration Date],
            L.IsActive
            From Licenses As L Inner Join LicenseClasses As LC on L.LicenseClassID=LC.LicenseClassID
            WHERE L.DriverID=@DriverID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
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
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return table;
        }

        public static bool DeactivateLicense(int LicenseID)
        {
            bool IsDeactivate = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Update Licenses set IsActive=0 WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if(rowAffected>0)
                {
                    IsDeactivate = true;
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
            return IsDeactivate;
        }

        public static int GetLicenseIDByApplicationID(int ApplicationID)
        {
            int LicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select LicenseID From Licenses WHERE ApplicationID=@ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result!=null)
                {
                    LicenseID = Convert.ToInt32(result);
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
            return LicenseID;
        }
    }


}
