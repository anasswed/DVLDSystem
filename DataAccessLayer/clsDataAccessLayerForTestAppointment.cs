using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsDataAccessLayerForTestAppointment
    {
        public static bool IsPesronHaveActiveTestAppointment(int LDLAppID,int TestTypeID)
        {
            bool IsActiveAppointment = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select TestAppointmentID From TestAppointments WHERE LocalDrivingLicenseApplicationID=@LDLAppID AND IsLocked=0 AND TestTypeID=@TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result!=null)
                {
                    IsActiveAppointment = true;
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
            return IsActiveAppointment;
        }

       

        public static DataTable GetTestAppointmentsForPerson(int LDLAppID,int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select TestAppointmentID,AppointmentDate,PaidFees,IsLocked
                FROM TestAppointments WHERE LocalDrivingLicenseApplicationID=@LDLAppID AND TestTypeID=@TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
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

        public static bool FindTestAppointment(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseID, ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedUserID, ref bool IsLocked, ref int RetakeTestAppID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * from TestAppointments WHERE TestAppointmentID=@TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedUserID = (int)reader["CreatedByUserID"];
                    
                    IsLocked = (bool)reader["IsLocked"];
                    
                   if(reader["RetakeTestApplicationID"]!=DBNull.Value)
                    {
                        RetakeTestAppID = (int)reader["RetakeTestApplicationID"];
                    }
                   else
                    {
                        RetakeTestAppID = 0;
                    }
                    IsFound = true;
                    reader.Close();
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
            return IsFound;
        }

        public static int AddTestAppointment(int TestTypeID,int LDLAppID,DateTime AppDate,decimal PaidFees,int CreatedByUserID,bool IsLocked,int RetakeTestAppID)
        {
            int TestAppID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"INSERT INTO TestAppointments(TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID)
                VALUES(@TestTypeID,@LDLAppID,@AppDate,@PaidFees,@CreatedByUserID,@IsLocked,@RetakeTestAppID)
                        SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LDLAppID", LDLAppID);
            command.Parameters.AddWithValue("@AppDate", AppDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            if (RetakeTestAppID != 0)
            {
                command.Parameters.AddWithValue("@RetakeTestAppID", RetakeTestAppID);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestAppID", DBNull.Value);


            }

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result!=null)
                {
                    TestAppID = Convert.ToInt32(result);
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
            return TestAppID;
        }

        public static bool IsTestLocked(int TestAppointmentID)
        {
            bool IsLocked = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select IsLocked From TestAppointments WHERE TestAppointmentID=@TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result!=null)
                {
                    IsLocked = (bool)result;
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
            return IsLocked;
        }

        public static bool UpdateTestAppointment(int TestAppointmentID,bool IsLocked,DateTime AppointmentDate)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Update TestAppointments set IsLocked=@IsLocked,AppointmentDate=@AppointmentDate
                        WHERE TestAppointmentID=@TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("AppointmentDate", AppointmentDate);

            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    IsUpdated = true;
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
            return IsUpdated;
        }

     

    }
}
