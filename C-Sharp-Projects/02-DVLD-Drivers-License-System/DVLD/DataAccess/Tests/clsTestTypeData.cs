using System;
using System.Data;
using System.Data.SqlClient;



namespace DataAccess
{
    public class clsTestTypeData
    {

        public static DataTable GetAllTestTypeData()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM TestTypes ORDER BY TestTypeID";

            SqlCommand cmd = new SqlCommand(query, conn);
             
            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { conn.Close(); }

            return dt;
        }

        
        public static bool GetTestTypeInfoID(int testID, ref string title, ref string description, ref float fees)
        {
            bool isFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM TestTypes WHERE TestTypeID = @ID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", testID);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    title = (string)reader["TestTypeTitle"];
                    description = (string)reader["TestTypeDescription"];
                    fees = Convert.ToSingle(reader["TestTypeFees"]);
                }
                else
                {
                    isFound = false;
                }
                reader.Close();

            }
            catch (Exception)
            {
                isFound = false;
                throw;
            }
            finally
            { conn.Close(); }

            return isFound;
        }
    
        public static bool UpdateTestTypeData(int testID, string title, string description, float fees)
        {
            int rowsAffected = 0; 

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE TestTypes
                             SET TestTypeTitle = @title, TestTypeDescription = @description ,TestTypeFees = @fees 
                             WHERE TestTypeID = @testTypeId;";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@testTypeId", testID);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@fees", fees);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }   
               
            return (rowsAffected > 0);
        }

        public static int AddNewTestType(string Title, string Description, float Fees)
        {
            int TestTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into TestTypes (TestTypeTitle,TestTypeTitle,TestTypeFees)
                            Values (@TestTypeTitle,@TestTypeDescription,@ApplicationFees)
                            where TestTypeID = @TestTypeID;
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", Title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestTypeID = insertedID;
                }
            }
            catch (Exception )
            {
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return TestTypeID;

        }



    }
}
