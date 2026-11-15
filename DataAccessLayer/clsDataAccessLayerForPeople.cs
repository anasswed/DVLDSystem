using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace DataAccessLayer
{
    public class clsDataAccessLayerForPeople
    {
        public static DataTable GetAllPeople()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * from People";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable peopleTable = new DataTable();
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

              

                
              peopleTable.Load(reader);
                    
                
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

            return peopleTable;
        }

        public static DataTable GetAllCountries()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * from Countries";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable CountryTable = new DataTable();
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();



                if (reader.Read())
                {
                    CountryTable.Load(reader);
                   
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

            return CountryTable;
        }

        public static bool FindPerson(int PersonID,ref string nationalNo,ref string firstName,ref string secondName,ref string thirdName,ref string lastName,ref DateTime dateOfBirth,ref byte gendor,ref string address,ref string phone,ref string email,ref int nationalityCountryID,ref string imagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * from People WHERE PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    firstName = (string)reader["FirstName"];
                    secondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        thirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        thirdName = "";
                    }
                    lastName = (string)reader["LastName"];
                    nationalNo = (string)reader["NationalNo"];
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    gendor = (byte)reader["Gendor"];
                    address = (string)reader["Address"];
                    if (reader["Email"] != DBNull.Value)
                    {
                        email = (string)reader["Email"];
                    }
                    phone = (string)reader["Phone"];
                    nationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        imagePath = (string)reader["ImagePath"];
                    }
                    isFound = true;
                    reader.Close();
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
            return isFound;
        }

        public static bool IsNationalNoExist(string NationalNo)
        {
            bool IsExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select NationalNo From People WHERE NationalNo=@NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if(result!=null)
                {
                    IsExist = true;
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
            return IsExist;
        }

        public static int AddNewPerson(string nationalNo, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, byte gendor, string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            int personID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Insert into People(NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath)
                                VALUES(@nationalNo,@firstName,@secondName,@thirdName,@lastName,@dateOfBirth,@gendor,@address,@phone,@email,@nationalityCountryID,@imagePath)
                                    Select Scope_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nationalNo", nationalNo);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@secondName", secondName);

            if (string.IsNullOrEmpty(thirdName))
            {
                command.Parameters.AddWithValue("@thirdName", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@thirdName", thirdName);
            }

            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@gendor", gendor);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@phone", phone);
            if (string.IsNullOrEmpty(email))
            {
                command.Parameters.AddWithValue("@email", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@email", email);
            }

            command.Parameters.AddWithValue("@nationalityCountryID", nationalityCountryID);
            if (string.IsNullOrEmpty(imagePath))
            {
                command.Parameters.AddWithValue("@imagePath", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@imagePath",imagePath);
            }
        
            try
            {
                connection.Open();
                Object result = command.ExecuteScalar();

                if(result!=null&&int.TryParse(result.ToString(),out personID))
                {
                    connection.Close();
                    return personID;
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
            return personID;
        }

        public static bool FindPersonByNationalNo( ref int PersonID ,string nationalNo, ref string firstName, ref string secondName, ref string thirdName, ref string lastName, ref DateTime dateOfBirth, ref byte gendor, ref string address, ref string phone, ref string email, ref int nationalityCountryID, ref string imagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * from People WHERE NationalNo=@nationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nationalNo", nationalNo);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    firstName = (string)reader["FirstName"];
                    secondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        thirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        thirdName = "";
                    }
                    lastName = (string)reader["LastName"];
                    nationalNo = (string)reader["NationalNo"];
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    gendor = (byte)reader["Gendor"];
                    address = (string)reader["Address"];
                    if (reader["Email"] != DBNull.Value)
                    {
                        email = (string)reader["Email"];
                    }
                    phone = (string)reader["Phone"];
                    nationalityCountryID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        imagePath = (string)reader["ImagePath"];
                    }
                    isFound = true;
                    reader.Close();
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
            return isFound;
        }

        public static int GetPersonIDByNationalNo(string NationalNo)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select PersonID From people WHERE NationalNo=@NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    PersonID = Convert.ToInt32(result);
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
            return PersonID;
        }
        public static bool UpdatePersonInfo(int personID,string nationalno, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, byte gendor, string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"UPDATE People 
                           set NationalNo=@nationalNo,
                                FirstName=@firstName,
                                SecondName=@secondName,
                                ThirdName=@thirdName,
                                LastName=@lastName,
                                DateOfBirth=@dateOfBirth,
                                Gendor=@gendor,     
                                Address=@address,
                                Phone=@phone,
                                Email=@email,
                                NationalityCountryID=@nationalityCountryID,
                                ImagePath=@imagePath
                                WHERE PersonID=@personID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personID", personID);
            command.Parameters.AddWithValue("@nationalno", nationalno);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@secondName", secondName);

            if (string.IsNullOrEmpty(thirdName))
            {
                command.Parameters.AddWithValue("@thirdName", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@thirdName", thirdName);
            }

            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@gendor", gendor);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@phone", phone);
            if (string.IsNullOrEmpty(email))
            {
                command.Parameters.AddWithValue("@email", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@email", email);
            }

            command.Parameters.AddWithValue("@nationalityCountryID", nationalityCountryID);
            if (string.IsNullOrEmpty(imagePath))
            {
                command.Parameters.AddWithValue("@imagePath", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@imagePath", imagePath);
            }
            

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

        public static bool IsPersonExist(int PersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select PersonID From people WHERE PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if(result!=null)
                {
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

        public static bool DeletePerson(int PersonID)
        {
            bool IsDeleted = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Delete From People WHERE PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static string GetCountryName(int CountryID)
        {
            string countryName = "";
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select CountryName From Countries WHERE CountryID=@CountryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                Object result = command.ExecuteScalar();
                if (result != null)
                {
                    countryName = result.ToString();
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
            return countryName;
        }
    }

}
