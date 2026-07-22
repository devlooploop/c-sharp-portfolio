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
            // int localDrivingLicenseApplicationId, int applicationId, int licenseClassId
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications";

            SqlCommand cmd = new SqlCommand(query, conn);
            //cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationId", localDrivingLicenseApplicationId);
            //cmd.Parameters.AddWithValue("@ApplicationId", applicationId);
            //cmd.Parameters.AddWithValue("@LicenseClassId", licenseClassId);
            
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //localDrivingLicenseApplicationId = (int)reader["LocalDrivingLicenseApplicationID"];
                    //applicationId = (int)reader["ApplicationID"];
                    //licenseClassId = (int)reader["LicenseClassID"];

                    dt.Load(reader);
                }
                else
                {
                    dt = null;
                }

                reader.Close();
            }
            catch (Exception ex)
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
            // cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", applicationId);
            // cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationId);

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

        public static bool AddNewData()
        {
            int rowsAffected = 0;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO  LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                                    VALUES  (@applicationId, @licenseClassId);
                               SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool UpdateApplicationData(int applicationId)
        {
            int rowsAffected = 0;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE LocalDrivingLicenseApplications 
                                    SET ApplicationID = @ApplicationID, LicenseClassID = @licenseClassId
                                    WHERE LocalDrivingLicenseApplicationID = @applicationId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", applicationId);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteData(int applicationId)
        {
            int rowsAffected = 0;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE LocalDrivingLicenseApplications 
                                    WHERE LocalDrivingLicenseApplicationID = @applicationId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", applicationId);

            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return (rowsAffected > 0);
        }

    
    }

}
