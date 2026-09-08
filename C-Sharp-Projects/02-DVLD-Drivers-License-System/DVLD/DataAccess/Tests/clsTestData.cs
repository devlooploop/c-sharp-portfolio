using System;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess.Tests
{
    public class clsTestData
    {
        public static DataTable GetAllTestsInfoData()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Tests";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(query,connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    dt.Load(reader);
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static byte PassedTestCountData()
        {

            // need to join 2 tables and get the result + count back
            string query @" SELECT *  FROM Tests INNER JOIN TestTypes ON  Tests.TestID = TestTypes.TestTypeID
                WHERE TestTypes.TestTypeID = 3 AND Tests.TestID = 64";

        }



    }
}
