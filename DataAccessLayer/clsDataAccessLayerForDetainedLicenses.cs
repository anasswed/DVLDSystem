using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class clsDataAccessLayerForDetainedLicenses
    {
        public static bool IsLicneseDetained(int LicneseID)
        {
            bool IsDetained = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select LicenseID from DetainedLicenses
                        WHERE LicenseID=@LicenseID AND IsReleased=0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicneseID);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    IsDetained = true;
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
            return IsDetained;
        }


        public static int AddDetainedLicense(int LicenseID, bool IsReleased, int CreatedByUserID, decimal FineFees, DateTime DetainDate)
        {
            int DetainID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"INSERT INTO DetainedLicenses(LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased)
                    VALUES(@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,@IsReleased)
                        SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    DetainID = Convert.ToInt32(result);
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
            return DetainID;
        }

        public static bool FindDetainedLicneseByLicenseID(int LicneseID, ref int DetainID, ref int CreatedByUserID, ref DateTime DetainDate, ref bool IsReleased, ref decimal FineFees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select DetainID,CreatedByUserID,DetainDate,IsReleased,FineFees FROM DetainedLicenses WHERE LicenseID=@LicenseID AND IsReleased=0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicneseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    DetainID = Convert.ToInt32(reader["DetainID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    DetainDate = (DateTime)reader["DetainDate"];
                    IsReleased = (bool)reader["IsReleased"];
                    FineFees = Convert.ToDecimal(reader["FineFees"]);
                    IsFound = true;
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
        public static bool UpdateDetainedLicense(int DetainID, bool IsReleased, DateTime ReleaseDate,int ReleasedByUserID,int ReleaseApplicationID)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"UPDATE DetainedLicenses set IsReleased=@IsReleased,ReleaseDate=@ReleaseDate,ReleasedByUserID=@ReleasedByUserID,ReleaseApplicationID=@ReleaseApplicationID
                            WHERE DetainID=@DetainID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
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
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return IsUpdated;
        }

        public static DataTable GetListForAllDetainedLicenses()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select DL.DetainID As [Detain ID],DL.LicenseID As[License ID],DL.DetainDate AS[Detain Date], DL.IsReleased [IsReleased],DL.FineFees As [Fine Fees],
                            DL.ReleaseDate As [Release Date],P.NationalNo As[National No],CONCAT(P.FirstName,' ',P.SecondName,' ',P.ThirdName,' ',P.LastName) As [Full Name],
                            DL.ReleaseApplicationID AS [Release Application ID] FROM DetainedLicenses AS DL LEFT JOIN Licenses As L On DL.LicenseID=L.LicenseID LEFT JOIN  Applications AS A on L.ApplicationID=A.ApplicationID
                        LEFT JOIN People AS P on A.ApplicantPersonID=P.PersonID";
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
