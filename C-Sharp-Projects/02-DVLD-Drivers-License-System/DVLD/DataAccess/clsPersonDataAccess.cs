using System;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
    public class clsPersonDataAccess
    {

        private const string SelectQuery = @"SELECT PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, 
                                                     DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath  
                                            FROM    People WHERE PersonID = @PersonID";

        private const string SelectQueryNationalNo = @"SELECT PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, 
                                                     DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath  
                                            FROM    People WHERE NationalNo = @NationalNo";


        private const string InsertQuery = @"INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, Gender, Address, DateOfBirth, 
                                                        Phone, Email, NationalityCountryID, ImagePath)
                                            VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @Gender, @Address, @DateOfBirth, 
                                                    @Phone, @Email, @NationalityCountryID, @ImagePath);
                                            SELECT SCOPE_IDENTITY();";

        private const string UpdateQuery = @"Update  People  
                        SET NationalNo = @NationalNo, 
                            FirstName = @FirstName, 
                            SecondName = @SecondName, 
                            ThirdName = @ThirdName, 
                            LastName = @LastName, 
                            Gender = @Gender, 
                            Address = @Address, 
                            DateOfBirth = @DateOfBirth, 
                            Phone = @Phone, 
                            Email = @Email, 
                            NationalityCountryID = @NationalityCountryID, 
                            ImagePath = @ImagePath
                            
                            WHERE PersonID = @PersonID";

        private const string AllPeopleQuery = "SELECT * FROM People";

        private const string DeletePersonQuery = @"DELETE People WHERE PersonID = @PersonID";

        private const string NationalNoExistsQuery = "SELECT Found=1 FROM People WHERE NationalNo = @NationalNo";

        private const string SelectByNationalNoQuery = @"SELECT * FROM People WHERE NationalNo = @NationalNo";

        private const string QueryGetAllPeopleWithDetails = @"SELECT People.PersonID, People.NationalNo,
                                 People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			                     People.DateOfBirth, People.Gender,  
				                    CASE
                                    WHEN People.Gender = 0 THEN 'Male'

                                    ELSE 'Female'

                                    END as GenderCaption ,
			                    People.Address, People.Phone, People.Email, 
                                People.NationalityCountryID, Countries.CountryName, People.ImagePath
                                FROM            People INNER JOIN
                                Countries ON People.NationalityCountryID = Countries.CountryID
                                ORDER BY People.FirstName";


        // ====================== Get Person ======================
        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName,
            ref string SecondName, ref string ThirdName,
            ref string LastName, ref DateTime DateOfBirth, ref short Gender, ref string Address, ref string Phone,
            ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection SqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(SelectQuery, SqlConnection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                SqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    NationalNo = Convert.ToString(reader["NationalNo"]);
                    FirstName = Convert.ToString(reader["FirstName"]);
                    SecondName = Convert.ToString(reader["SecondName"]);

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = Convert.ToString(reader["ThirdName"]);
                    else
                        ThirdName = "";

                    LastName = Convert.ToString(reader["LastName"]);
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = Convert.ToSByte(reader["Gender"]);
                    Address = Convert.ToString(reader["Address"]);
                    Phone = Convert.ToString(reader["Phone"]);

                    if (reader["Email"] != DBNull.Value)
                        Email = Convert.ToString(reader["Email"]);
                    else
                        Email = "";

                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = Convert.ToString(reader["ImagePath"]);
                    else
                        ImagePath = "";
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception)
            {
                //    Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                SqlConnection.Close();
            }

            return isFound;
        }

        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName,
             string LastName, string NationalNo, DateTime DateOfBirth, short Gender, string Address, string Phone,
             string Email, int NationalityCountryID, string ImagePath)
        {
            //this function will return the new Person id if succeeded and -1 if not.
            int PersonID = -1;

            SqlConnection SqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(InsertQuery, SqlConnection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "" && ThirdName != null)
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                SqlConnection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("Error: " + ex.Message); 
            }
            finally
            {
                SqlConnection.Close();
            }

            return PersonID;
        }

        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName,
             string LastName, short Gender, string Address, DateTime DateOfBirth, string Phone,
             string Email, int NationalityCountryID, string ImagePath)
        {

            int rowsAffected = 0;

            SqlConnection SqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(UpdateQuery, SqlConnection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "" && ThirdName != null)
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                SqlConnection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                SqlConnection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection SqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(QueryGetAllPeopleWithDetails, SqlConnection);

            try
            {
                SqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception)
            {
                // error log here
            }
            finally
            {
                SqlConnection.Close();
            }

            return dt;
        }

        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;

            SqlConnection SqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(DeletePersonQuery, SqlConnection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                SqlConnection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                SqlConnection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found = 1 FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception)
            {
                //  Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        // ************** ************* *************//
        //                New Methodes               //
        // ************** ************* *************//

        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName,
           ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
           ref short Gender, ref string Address, ref string Phone,
           ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {

            bool isFound = false;

            SqlConnection SqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, SqlConnection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                SqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    //ThirdName: allows null in database so we should handle null
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    //Email: allows null in database so we should handle null
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception)
            {
                //  Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                SqlConnection.Close();
            }

            return isFound;
        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;

            string Query = "SELECT Found=1 FROM People WHERE NationalNo = @NationalNo";

            SqlConnection sqlConnection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                sqlConnection.Close();
            }

            return isFound;
        }

    }
}
