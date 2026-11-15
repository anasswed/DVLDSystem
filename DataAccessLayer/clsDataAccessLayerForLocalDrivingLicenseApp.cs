using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsDataAccessLayerForLocalDrivingLicenseApp
    {
        public static DataTable GetAllLocalDrivingLicenseApplication()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"
SELECT
    LDLA.LocalDrivingLicenseApplicationID AS [L.D.L.AppID],
    LC.ClassName AS [Driving Class],
    P.NationalNo,
    CONCAT(P.FirstName, ' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS [Full Name],
    A.ApplicationDate AS [Application Date],
    CASE A.ApplicationStatus
        WHEN 1 THEN 'New'
        WHEN 2 THEN 'Cancled'
        WHEN 3 THEN 'Completed'
    END AS [Status],
    SUM(CASE WHEN T.TestResult = 1 THEN 1 ELSE 0 END) AS [Passed Tests]
FROM LocalDrivingLicenseApplications AS LDLA
INNER JOIN Applications AS A
    ON LDLA.ApplicationID = A.ApplicationID
INNER JOIN LicenseClasses AS LC
    ON LDLA.LicenseClassID = LC.LicenseClassID
INNER JOIN People AS P
    ON A.ApplicantPersonID = P.PersonID
LEFT JOIN TestAppointments AS TA
    ON TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
LEFT JOIN Tests AS T
    ON T.TestAppointmentID = TA.TestAppointmentID
GROUP BY
    LDLA.LocalDrivingLicenseApplicationID,
    LC.ClassName,
    P.NationalNo,
    A.ApplicationDate,
    A.ApplicationStatus,
    P.FirstName,
    P.SecondName,
    P.ThirdName,
    P.LastName";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable table = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return table;
        }

        public static bool FindLocalDrivingLicenseAppByID(ref int LicenseClassID, ref int ApplicationID, int LocalDrivingLicenseAppID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * From LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseAppID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseAppID", LocalDrivingLicenseAppID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    IsFound = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }


        public static int HasNewApplication(int PersonID, int LicenseClassID)
        {
            int ApplicationID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select A.ApplicationID
FROM LocalDrivingLicenseApplications As LDL JOIN Applications As A 
on LDL.ApplicationID=A.ApplicationID
WHERE A.ApplicantPersonID=@PersonID AND LDL.LicenseClassID=@LicenseClassID AND A.ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    ApplicationID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return ApplicationID;
        }
        public static bool HasCompletedApplication(int PersonID, int LicenseClassID)
        {
            bool HasCompleted = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select A.ApplicationID
FROM LocalDrivingLicenseApplications As LDL JOIN Applications As A 
on LDL.ApplicationID=A.ApplicationID
WHERE A.ApplicantPersonID=@PersonID AND LDL.LicenseClassID=@LicenseClassID AND A.ApplicationStatus=3";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    HasCompleted = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return HasCompleted;
        }
        public static int AddNewLocalDrivingLicenseApp(int ApplicationID,int LicenseClassID)
        {
            int LocalDrivingLicenseAppID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"INSERT INTO LocalDrivingLicenseApplications(ApplicationID,LicenseClassID)
                                VALUES(@ApplicationID,@LicenseClassID)
                                SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result!=null)
                {
                    LocalDrivingLicenseAppID = Convert.ToInt32(result);
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
            return LocalDrivingLicenseAppID;
        }

        public static bool CancleApplication(int LDLApplicationID)
        {
            bool IsCancled = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Update Applications set ApplicationStatus=2 WHERE ApplicationID=(
                   Select ApplicationID From LocalDrivingLicenseApplications WHERE  LocalDrivingLicenseApplicationID=@LDLAppID)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLApplicationID);
            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if(rowAffected>0)
                {
                    IsCancled = true;
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
            return IsCancled;
        }

        public static bool DeleteLocalDrivingLicenseApp(int LDLAppID)
        {
            bool IsDeleted = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID=@LDLAppID";
                             
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLAppID",LDLAppID);

            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if(rowAffected>0)
                {
                    IsDeleted = true;
                    
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
            return IsDeleted;
        }

        public static int GetApplicationID(int LDLAppID)
        {
            int ApplicationID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select ApplicationID From LocalDrivingLicenseApplications
                                    WHERE LocalDrivingLicenseApplicationID=@LDLAppID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result!=null)
                {
                    ApplicationID = Convert.ToInt32(result);
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
            return ApplicationID;
        }

        public static bool UpdateLocalLicense(int LDLAppID,int LicenseClassID)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Update LocalDrivingLicenseApplications set LicenseClassID=@LicenseClassID
                                            WHERE LocalDrivingLicenseApplicationID=@LDLAppID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);

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
                
            }
            finally
            {
                connection.Close();
            }
            return IsUpdated;
        }

        
    }
}
        
    
