using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.CodeDom;
using System.Net.Http.Headers;
namespace DataAccessLayer
{
    public class clsDataAccessLayerForInternationalLicenses
    {
        public static DataTable ListAllInternationalLicense(int DriverID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select  IL.InternationalLicenseID As [int.LicenseID],
        IL.ApplicationID As [ApplicationID],IL.IssuedUsingLocalLicenseID As[L.LicenseID],
            IL.IssueDate As [Issue Date],IL.ExpirationDate As[Expiration Date],IL.IsActive As[Is Active]
            FROM InternationalLicenses As IL WHERE IL.DriverID=@DriverID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            DataTable table = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return table;
        }
        public static int IsDriverHasInternationalLicense(int DriverID)
        {
            int InternationalLicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select InternationalLicenseID From InternationalLicenses WHERE DriverID=@DriverID AND IsActive=1";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                object reault = command.ExecuteScalar();
                if (reault != null)
                {
                    InternationalLicenseID = Convert.ToInt32(reault);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();

            }
            return InternationalLicenseID;
        }

        public static int AddNewInternationalLicense(int DriverID,int ApplicationID,int IssuedUsingLocalLicenseID,int CreatedByUserID,DateTime IssueDate,DateTime ExpirationDate,bool IsActive)
        {
            int InterLicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"INSERT INTO InternationalLicenses(ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID)
                    VALUES(@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID)
                        SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result!=null)
                {
                    InterLicenseID = Convert.ToInt32(result);
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
            return InterLicenseID;
        }

        public static bool FindInternationalLicenseByID(int InternationalLicenseID,ref int DriverID,
            ref int ApplicationID,ref int CreatedByUserID, ref DateTime IssueDate, ref DateTime ExpirationDate,ref bool IsActive,ref int IssuedUsingLocalLicenseID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * from InternationalLicenses WHERE InternationalLicenseID=@InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
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

        public static DataTable GetListOfInternationalLicensesApplications()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select InternationalLicenseID As[int.License ID],ApplicationID As[Application ID],
                   DriverID As [Driver ID],IssuedUsingLocalLicenseID As[L.License ID],IssueDate As[Issue Date],ExpirationDate As[Expiration Date],IsActive As[IsActive]
                    FROM InternationalLicenses";

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
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return table;
        }
        


    }
}
