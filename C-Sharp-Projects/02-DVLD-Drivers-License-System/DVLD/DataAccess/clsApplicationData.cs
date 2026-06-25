using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace DataAccess
{
    public class clsApplicationData
    {
        public static DataTable GetAllApplicationsData()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            
            string query = @"SELECT * FROM Applications";

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int applicationID = (int)reader["ApplicationID"];
                    int applicantPersonID = (int)reader["ApplicantPersonID"];
                    DateTime applicationDate = (DateTime)reader["ApplicationDate"];
                    int applicationTypeID = (int)reader["ApplicationTypeID"];
                    byte applicationStatus = (byte)reader["ApplicationStatus"];
                    DateTime lastStatusDate = (DateTime)reader["LastStatusDate"];
                    decimal paidFees = (decimal)(reader["PaidFees"]);
                    int createdByUserID = (int)reader["CreatedByUserID"];

                    dt.Load(reader);
                }
                
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }


        public static int AddNewApplicationData( int applicantPersonID , DateTime applicationDate ,int applicationTypeID, 
            byte applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID )
        {
            int applicationID = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Applications (
                                                        ApplicantPersonID, ApplicationDate, ApplicationTypeID
                                                        ,ApplicationStatus ,LastStatusDate, PaidFees, CreatedByUserID
                                                      )
                                      VALUES (  @applicantPersonID, @applicationDate, @applicationTypeID,
                                                @applicationStatus, @lastStatusDate, @paidFees, @createdByUserID  
                                             )
                          SELECT SCOPE_IDENTITY(); ";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@applicantPersonID", applicantPersonID);
            cmd.Parameters.AddWithValue("@applicationDate", applicationDate);
            cmd.Parameters.AddWithValue("@applicationTypeID", applicationTypeID);
            cmd.Parameters.AddWithValue("@applicationStatus", applicationStatus);
            cmd.Parameters.AddWithValue("@lastStatusDate", lastStatusDate);
            cmd.Parameters.AddWithValue("@paidFees", paidFees);
            cmd.Parameters.AddWithValue("@createdByUserID", createdByUserID);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(), out int resultId))
                    applicationID = resultId;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return applicationID;
        }

        public static bool UpdateApplicationData(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID,
            byte applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            int rowsAffected = 0;

            string query = @"UPDATE Applications
                                SET ApplicantPersonID = @ApplicantPersonID, ApplicationDate = @ApplicationDate,
                                    ApplicationTypeID = @ApplicationTypeID, ApplicationStatus = @ApplicationStatus,
                                    LastStatusDate = @LastStatusDate, PaidFees = @PaidFees, CreatedByUserID = @CreatedByUserID
                            WHERE applicationID = @applicationID";

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@applicationID", applicationID);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", applicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", applicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", applicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", lastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", paidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteApplicationData(int applicationId)
        {
            int rowsAffected = 0;
            
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            
            string query = @"DELETE FROM Applications  WHERE applicationId = @ApplicationId";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ApplicationID", applicationId);
            
            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool FindApplicationByIdData(int applicationId,..)
        {

        }
    }
}
