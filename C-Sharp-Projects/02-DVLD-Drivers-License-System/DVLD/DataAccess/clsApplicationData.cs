using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace DataAccess
{
    public class clsApplicationData
    {
        public static bool GetApplicationInfoBuIdData(int applicationId, ref int applicantPersonId, ref DateTime applicationDate, ref int applicationTypeId,
                                                     ref byte applicationStatus, ref DateTime lastStatusDate, ref float paidFees, ref int createdByUserId)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            
            string query = @"SELECT * FROM Applications WHERE ApplicationID = @applicationId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationId);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    applicantPersonId = (int)reader["ApplicantPersonID"];
                    applicationDate = (DateTime)reader["ApplicationDate"];
                    applicationTypeId = (int)reader["ApplicationTypeID"];
                    applicationStatus = (byte)reader["ApplicationStatus"];
                    lastStatusDate = (DateTime)reader["LastStatusDate"];
                    paidFees = (float)(reader["PaidFees"]);
                    createdByUserId = (int)reader["CreatedByUserID"];
                }
                else
                {
                    isFound = false;
                }
                
                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return isFound;
        }

        public static DataTable GetAllApplicationsData()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from ApplicationsList_View order by ApplicationDate desc";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }


        public static int AddNewApplicationData( int applicantPersonID , DateTime applicationDate ,int applicationTypeID, 
            byte applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID )
        {
            int applicationID = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            
            string query = @"INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID
                                                        ,ApplicationStatus ,LastStatusDate, PaidFees, CreatedByUserID )
                                      VALUES ( @applicantPersonID, @applicationDate, @applicationTypeID,
                                                @applicationStatus, @lastStatusDate, @paidFees, @createdByUserID )
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
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Applications
                                SET ApplicantPersonID = @ApplicantPersonID, ApplicationDate = @ApplicationDate,
                                    ApplicationTypeID = @ApplicationTypeID, ApplicationStatus = @ApplicationStatus,
                                    LastStatusDate = @LastStatusDate, PaidFees = @PaidFees, CreatedByUserID = @CreatedByUserID
                            WHERE applicationID = @applicationID";

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
                return false;
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
            
            string query = @"DELETE FROM Applications  WHERE ApplicationID = @ApplicationId";
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

        public static bool FindApplicationByIdData(int applicationId, ref int applicantPersonId, ref DateTime applicationDate, ref int applicationTypeId,
             ref byte applicationStatus, ref DateTime lastStatusDate, ref float paidFees, ref int createdByUserId)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ApplicationID ,ApplicantPersonID ,ApplicationDate ,ApplicationTypeID,ApplicationStatus ,
                                        LastStatusDate , PaidFees, CreatedByUserID
                            FROM  Applications
                            WHERE ApplicationID = @applicationId";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ApplicationID", applicationId);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", applicantPersonId);
            cmd.Parameters.AddWithValue("@ApplicationDate", applicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeId);
            cmd.Parameters.AddWithValue("@ApplicationStatus", applicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", lastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", paidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserId);

            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
                conn.Open();
                if(reader.Read())
                {
                    isFound = true;

                    applicantPersonId = (int)(reader["ApplicationID"]);
                    applicationDate = (DateTime)(reader["ApplicationDate"]);
                    applicationTypeId = (int)(reader["ApplicationTypeID"]);
                    applicationStatus = (byte)(reader["ApplicationStatus"]);
                    lastStatusDate = (DateTime)(reader["LastStatusDate"]);
                    paidFees = (float)(reader["PaidFees"]);
                    createdByUserId = (int)(reader["CreatedByUserID"]);
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
            return isFound;
        }

        public static bool IsApplicationExistData(int applicationId)
        {

            bool isFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found=1 FROM Applications WHERE ApplicationID = @applicationId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationId);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
                throw;
            }
            finally
            {
                conn.Close();
            }
            
            return isFound;
        }

        public static bool DoesPersonHaveActiveApplicationData(int personId, int applicationTypeId)
        {
            return (GetActiveApplicationIdData(personId, applicationTypeId) !=-1);
        }

        public static int GetActiveApplicationIdData(int personId, int ApplicationTypeId)
        {
            int activeApplicationId = -1;
            
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ActiveApplicationID=ApplicationID FROM Applications 
                             WHERE  ApplicantPersonID = @ApplicantPersonID and ApplicationTypeID=@ApplicationTypeID and ApplicationStatus=1";


            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PersonID", personId);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeId);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int returnedId))
                {
                    activeApplicationId = returnedId;
                }
                
            }
            catch (Exception ex)
            {
                return activeApplicationId;
            }
            finally
            {
                conn.Close();
            }

            return activeApplicationId;
        }

        public static int GetActiveApplicationIDForLicenseClassData(int personId, int applicationTypeId, int licenseClassId) ffff
        {
            int activeApplicationId = -1; 

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" SELECT * FROM Applications 
                              INNER JOIN    LicenseClasses 
                              ON       Applications.ApplicationTypeID = LicenseClasses.LicenseClassID 
                              INNER JOIN  People ON People.PersonID = Applications.ApplicationID
                        SELECT SCOPE_IDENTITY();";

            

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PersonID", personId);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeId);
            cmd.Parameters.AddWithValue("@LicenseClassID", licenseClassId);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int returnedId))
                {
                    activeApplicationId = returnedId;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return activeApplicationId;
        }

        public static int GetActiveApplicationIdData(int applicationTypeId)
        {
            int activeApplicationId = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT  ApplicationStatus FROM  Applications
                        SELECT SCOPE_IDENTITY();";


            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeId);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int returnedId))
                {
                    activeApplicationId = returnedId;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return activeApplicationId;
        }
    }
}
