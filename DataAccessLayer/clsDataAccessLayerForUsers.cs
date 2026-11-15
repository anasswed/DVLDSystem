using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsDataAccessLayerForUsers
    {
        public static bool FindUserByUserNameAndPassword( string UserName, string Password,ref int UserID,ref int PersonID,ref bool IsActive)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * From Users WHERE UserName=@UserName AND Password=@Password";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    PersonID = (int)reader["PersonID"];
                    UserID = (int)reader["UserID"];
                    IsActive = (bool)reader["IsActive"];
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

        public static bool FindUser(ref string UserName,ref string Password, int UserID, ref int PersonID, ref bool IsActive)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select * From Users WHERE UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
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

        public static DataTable GetAllUsers()
        {
            DataTable UsersList = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select UserName,UserID,People.PersonID,IsActive,
                                CONCAT(People.FirstName,' ',People.SecondName,' ',People.ThirdName,' ',People.LastName) As FullName from Users
                                                inner join People on People.PersonID=Users.PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

            
                 UsersList.Load(reader);
                
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
            return UsersList;
        }

        public static bool IsPersonUser(int PerosnID)
        {
            bool IsUser = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select UserID FROM USERS WHERE PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PerosnID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsUser = true;
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
            return IsUser;
        }

        public static int AddNewUser(int PersonID,string UserName,string Password,bool IsActive)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"INSERT INTO USERS(PersonID,UserName,Password,IsActive)
                                      Values(@PersonID,@UserName,@Password,@IsActive)
                                            Select Scope_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@PersonID", PersonID);



            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result!=null)
                    {
                    UserID =Convert.ToInt32(result);
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
            return UserID;                                       
        }

        public static bool IsUserExist(int UserID)
        {
            bool IsExist = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Select UserID FROM USERS WHERE UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
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

        public static bool UpdateUserInfo(string UserName,string Password,bool IsActive,int UserID)
        {
            bool IsUpdated = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"UPDATE Users set UserName=@UserName,
                                             Password=@Password,
                                                IsActive=@IsActive
                                                WHERE UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UserID", UserID);
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
        public static bool DeleteUser(int UserID)
        {
            bool IsDeleted = false;
            SqlConnection connection = new SqlConnection(clsDataAccessLayerSettings.connectionString);

            string query = @"Delete users WHERE UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
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
       
    }
}
