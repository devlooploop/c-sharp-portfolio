using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace DataAccess
{
    public class clsLocalDrivingLicenseApplicationData 
    {

        public static DataTable GetLocalDrivingLicenseApplicationInfoData()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View";

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
            catch (Exception )
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public static bool GetLocalDrivingLicenseApplicationInfoByIdData(int localDrivingLicenseApplicationId, ref int applicationId,
            ref int licenseClassId)
        {
            
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            
            string query = @"SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LocalDrivingLicenseApplications.ApplicationID, 
		                        LocalDrivingLicenseApplications.LicenseClassID ,Applications.ApplicationID, Applications.ApplicantPersonID, 
		                        Applications.ApplicationDate, Applications.ApplicationTypeID, Applications.ApplicationStatus, 
                                Applications.LastStatusDate,Applications.PaidFees, Applications.CreatedByUserID 
                            FROM Applications   
			                INNER JOIN LocalDrivingLicenseApplications 
                            ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
			                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationId);

            bool isFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    localDrivingLicenseApplicationId = (int)reader["LocalDrivingLicenseApplicationID"];
                    applicationId = (int)reader["ApplicationID"];
                    licenseClassId = (int)reader["LicenseClassID"];
                
                }

                reader.Close();
            }
            catch (Exception )
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

        public static int AddNewData(int applicationId, int licenseClassId)
        {
            int localDrivingLicenseApplicationId = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            
            string query = @"INSERT INTO  LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                                    VALUES  (@applicationId, @licenseClassId);
                               SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@applicationId", applicationId);
            cmd.Parameters.AddWithValue("@licenseClassId", licenseClassId);

            try
            {
                conn.Open();
                object obj = cmd.ExecuteScalar();

                if (obj != null && int.TryParse(obj.ToString(), out int resultId))
                {
                    localDrivingLicenseApplicationId = resultId;
                }
            }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return localDrivingLicenseApplicationId ;
        }

        public static bool UpdateApplicationStatus(int applicationId, short newStatus)
        {
            int rowsAffected = 0;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Applications 
                             SET    ApplicationStatus = @newStatus, 
                                    LastStatusDate = @lastStatusDate
                            
                            WHERE  ApplicationID = @applicationId";

            SqlCommand cmd = new SqlCommand(query, conn);
            
            cmd.Parameters.AddWithValue("@applicationId", applicationId);
            cmd.Parameters.AddWithValue("@newStatus", newStatus);
            cmd.Parameters.AddWithValue("@lastStatusDate", DateTime.Now);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteData(int localDrivingLicenseApplicationId)
        {
            int rowsAffected = 0;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE LocalDrivingLicenseApplications 
                                    WHERE LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@localDrivingLicenseApplicationId", localDrivingLicenseApplicationId);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return (rowsAffected > 0);
        }


        public static bool UpdateLocalDrivingLicenseApplication(int localDrivingLicenseApplicationId,
                int applicationId, int licenseClassId)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  LocalDrivingLicenseApplications  
                            set ApplicationID = @applicationId,
                                LicenseClassID = @licenseClassId
                            where LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@localDrivingLicenseApplicationId", localDrivingLicenseApplicationId);
            command.Parameters.AddWithValue("ApplicationId", applicationId);
            command.Parameters.AddWithValue("LicenseClassId", licenseClassId);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
                // Error log here 
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }

}
