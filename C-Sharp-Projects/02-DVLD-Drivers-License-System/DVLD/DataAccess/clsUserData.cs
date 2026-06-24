using System;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
    public class clsUserData
    {
        public static bool GetUserInfoByUserName(string userName, ref int userID, ref int personID,
               ref string password, ref bool isActive)
        {

            bool isFound = false;

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string queryUserByName = @"SELECT UserID, PersonID, UserName, Password, IsActive
                                       FROM Users 
                                       WHERE UserName = @userName";

            SqlCommand sqlCmd = new SqlCommand(queryUserByName, sqlConnection);
            sqlCmd.Parameters.AddWithValue("@userName", userName);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.Read())
                {
                    userID = (int)reader["UserID"];
                    personID = (int)reader["PersonID"];
                    password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];

                    isFound = true;
                }
            }
            catch (Exception)
            {
                // log
                isFound = false;
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }

            return isFound;
        }


        public static bool GetUserInfoByUserID(int userID, ref string userName, ref string password,
            ref int personID, ref bool isActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Users WHERE UserID = @userID";

            SqlCommand cmd = new SqlCommand(query, connection);

            bool isFound = false;
            try
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@userID", userID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    personID = (int)reader["PersonID"];
                    userName = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];
                }
                else
                {
                    isFound = false;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetUserInfoByPersonID(int personID, ref string userName, ref int userID,
               ref string password, ref bool isActive)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Users WHERE PersonID = @personID";

            SqlCommand command = new SqlCommand(query, conn);

            bool isFound = false;

            try
            {
                command.Parameters.AddWithValue("@personID", personID);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    userID = (int)reader["UserID"];
                    userName = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];
                }
                else
                { isFound = false; }

                reader.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static bool GetUserInfoByUserNameAndPassword(string userName, ref int userID, ref int personID,
                string password, ref bool isActive)
        {
            bool isFound = false;

            SqlConnection sqlconnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * from Users WHERE UserName = @userName and Password = @password";

            SqlCommand sqlCmd = new SqlCommand(query, sqlconnection);

            sqlCmd.Parameters.AddWithValue("@UserName", userName);
            sqlCmd.Parameters.AddWithValue("@password", password);

            try
            {
                sqlconnection.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    userID = (int)reader["UserID"];
                    personID = (int)reader["PersonID"];
                    userName = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                sqlconnection.Close();
            }

            return isFound;
        }

        public static int AddNewUserData(int personID, string userName, string password, bool isActive)
        {
            int userID = -1;

            string query = @"INSERT INTO Users (PersonID, UserName,Password,IsActive)
                             VALUES (@PersonID,@UserName ,@Password, @IsActive) 
                              SELECT SCOPE_IDENTITY();";

            SqlConnection sqlconnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(query, sqlconnection);


            try
            {
                sqlCmd.Parameters.AddWithValue("@PersonID", personID);
                sqlCmd.Parameters.AddWithValue("@UserName", userName);
                sqlCmd.Parameters.AddWithValue("@Password", password);
                sqlCmd.Parameters.AddWithValue("@IsActive", isActive);

                sqlconnection.Open();
                object obj = sqlCmd.ExecuteScalar();

                if (obj != null && int.TryParse(obj.ToString(), out int result))
                {
                    userID = result;
                }
            }
            catch (Exception)
            {
                // log here
            }
            finally
            {
                sqlconnection.Close();
            }

            return userID;
        }

        public static bool UpdateUserData(int userID, int personID, string userName, string password, bool isActive)
        {
            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            int rowAffected = 0;

            string query = @"UPDATE Users 
                            SET PersonID = @PersonID,
                                UserName = @UserName,
                                Password = @Password,
                                IsActive = @IsActive
                            WHERE UserID = @UserID";


            SqlCommand sqlCmd = new SqlCommand(query, sqlConnection);

            try
            {
                sqlCmd.Parameters.AddWithValue("@PersonID", personID);
                sqlCmd.Parameters.AddWithValue("@UserName", userName);
                sqlCmd.Parameters.AddWithValue("@Password", password);
                sqlCmd.Parameters.AddWithValue("@IsActive", isActive);
                sqlCmd.Parameters.AddWithValue("@UserID", userID);

                sqlConnection.Open();

                rowAffected = sqlCmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }

            return rowAffected > 0;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT Users.UserID, Users.PersonID, 
                                    FullName = People.FirstName + ' ' + People.SecondName + ' ' + 
                                    ISNULL(People.ThirdName, ' ') + ' ' + People.LastName, 
                                    Users.UserName, Users.IsActive
                            FROM  Users 
                                      INNER JOIN
                                  People ON Users.PersonID = People.PersonID";


            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            try
            {
                sqlConnection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch
            {
                // log here 
            }
            finally
            {
                sqlConnection.Close();
            }

            return dt;
        }

        public static bool DeleteUser(int userID)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE Users WHERE UserID = @userID;";

            SqlCommand cmd = new SqlCommand(query, conn);

            int rowEffected = 0;

            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@userID", userID);

                rowEffected = cmd.ExecuteNonQuery();
            }
            catch
            {
                // error log here 
            }
            finally
            { conn.Close(); }

            return (rowEffected > 0);
        }

        public static bool IsUserExist(int userID)
        {
            bool isFound = false;

            string query = @"SELECT found = 1 FROM Users WHERE UserID = @userID";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                cmd.Parameters.AddWithValue("@userID", userID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static bool IsUserExist(string userName)
        {
            bool isFound = false;

            string query = @"SELECT found = 1 FROM Users WHERE UserName = @userName";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                cmd.Parameters.AddWithValue("@userName", userName);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static bool IsUserExistForPersonID(int personID)
        {
            bool isFound = false;

            string query = @"SELECT found = 1 FROM Users WHERE PersonID = @personID";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                cmd.Parameters.AddWithValue("@personID", personID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

            return isFound;
        }

        public static bool ChangePassword(int userID, string NewPassword)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Users SET Password = @NewPassword WHERE UserID = @UserID";

            SqlCommand cmd = new SqlCommand(query, conn);

            int rowEffected = 0;

            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@NewPassword", NewPassword);
                cmd.Parameters.AddWithValue("@UserID", userID);

                rowEffected = cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            { conn.Close(); }

            return (rowEffected > 0);

        }

    }
}
