using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsDataAccessLayerForTests
    {
        public static bool IsPersonFailedInTest(int LDLAppID,int TestTypeID)
        {
            bool IsPassed = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select TestID From Tests INNER JOIN TestAppointments As TA
                                    ON Tests.TestAppointmentID=TA.TestAppointmentID
                                WHERE TA.TestTypeID=@TestTypeID AND TA.LocalDrivingLicenseApplicationID=@LDLAppID AND TestResult=0 AND TA.IsLocked=1";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    IsPassed = true;
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
            return IsPassed;
        }

        public static int GetNumberOfPassedTests(int LDLAppID)
        {
            int NumberOfPassedTest = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select Sum(CASE WHEN TestResult=1 then 1 else 0 END) FROM Tests 
    inner join TestAppointments AS TA on Tests.TestAppointmentID=TA.TestAppointmentID
            WHERE TA.LocalDrivingLicenseApplicationID=@LDLAppID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result!=null)
                {
                    if (result == DBNull.Value)
                        NumberOfPassedTest = 0;
                    else
                    {
                        NumberOfPassedTest = (int)result;
                    }
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
            return NumberOfPassedTest;
        }
        public static bool IsPersonPassedTest(int LDLAppID, int TestTypeID)
        {
            bool IsPassed = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select TestID From Tests INNER JOIN TestAppointments As TA
                                    ON Tests.TestAppointmentID=TA.TestAppointmentID
                                WHERE TA.TestTypeID=@TestTypeID AND TA.LocalDrivingLicenseApplicationID=@LDLAppID AND TestResult=1 AND TA.IsLocked=1";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    IsPassed = true;
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
            return IsPassed;
        }

        public static bool FindTestByID(int TestID,ref int TestAppointmentID,ref int CreatedByUserID,ref string Notes,ref bool TestResult)
        {
            bool Found = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * from Tests WHERE TestID=@TestID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    {
                        Notes = (string)reader["Notes"];
                    }
                    TestResult = (bool)reader["TestResult"];
                    Found = true;
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
            return Found;
        }

        public static int AddTest(int TestAppointmentID,int CreatedByUserID,string Notes,bool TestResult)
        {
            int TestID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"INSERT INTO Tests(TestAppointmentID,CreatedByUserID,Notes,TestResult)
                            VALUES(@TestAppointmentID,@CreatedByUserID,@Notes,@TestResult)
                                SELECT SCOPE_IDENTITY() ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@TestResult", TestResult);

            try

            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result!=null)
                {
                    TestID =Convert.ToInt32(result);
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
            return TestID;
        }

        public static int GetNumberOfTrialToIntroduceTest(int LDLAppID, int TestTypeID)
        {
            int Trial = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select count(*) from Tests
inner join TestAppointments As TA on Tests.TestAppointmentID=TA.TestAppointmentID
WHERE TA.LocalDrivingLicenseApplicationID=@LDLAppID AND TA.TestTypeID=@TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    Trial = Convert.ToInt32(result);
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
            return Trial;
        }


    }
}
