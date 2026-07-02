using System;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
    public class clsApplicationTypesData
    {

        public static DataTable GetAllApplicationTypeInfoData()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT ApplicationTypeID, ApplicationTypeTitle, ApplicationFees FROM ApplicationTypes";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception)
            {
                // log here 
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static int AddNewApplicationType(string Title, float Fees)
        {
            int id = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO ApplicationTypes (ApplicationTypeTitle, ApplicationFees) 
                                VALUES (@AppTitle, @AppFees)
                                SELECT SCOPE_IDENTITY() ";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@AppTitle", Title);
            cmd.Parameters.AddWithValue("@AppFees", Fees);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    id = insertedID;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { conn.Close(); }

            return id;

        }

        public static bool GetApplicationTypeByID(int appID, ref string appTitle, ref float appFees)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM ApplicationTypes 
                                WHERE ApplicationTypeID = @appID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@appID", appID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    appTitle = (string)reader["ApplicationTypeTitle"];
                    appFees = Convert.ToSingle(reader["ApplicationFees"]);
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
            }
            finally
            { connection.Close(); }

            return isFound;
        }

        public static bool UpdateTestTypeData(int appID, string appTitle, float appFees)
        {

            int rowAffected = 0;
            SqlConnection connect = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE ApplicationTypes
                             SET ApplicationTypeTitle = @Title, ApplicationFees = @Fees
                             WHERE ApplicationTypeID = @ID;";

            SqlCommand cmd = new SqlCommand(query, connect);

            cmd.Parameters.AddWithValue("@Title", appTitle);
            cmd.Parameters.AddWithValue("@Fees", appFees);
            cmd.Parameters.AddWithValue("@ID", appID);

            try
            {
                connect.Open();
                rowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { connect.Close(); }

            return (rowAffected > 0);
        }

    }
}
