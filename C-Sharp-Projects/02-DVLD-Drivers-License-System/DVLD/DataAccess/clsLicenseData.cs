using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace DataAccess
{
    public class clsLicenseData
    {
        public static DataTable GetAllLicenseInfoData()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Licenses";

            SqlCommand cmd = new SqlCommand(query,conn);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
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
            {
                conn.Close();
            }
            
            return dt;
        }

        public static bool FindUserCreatorByID_Data(int license_Id, ref int application_Id, ref int driver_Id, ref byte licenseClass, 
             ref DateTime issueDate, ref DateTime expirationDate, ref string notes, ref float paidFees, ref bool isActive, 
             ref byte issueReason, ref int createdByUserID)
        {
            bool isFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Licenses WHERE CreatedByUserID = @ID_Creator";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID_Creator", license_Id);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    isFound = true;

                    license_Id = (int)reader["LicenseID"];
                    application_Id = (int)reader["ApplicationID"];
                    driver_Id = (int)reader["DriverID"];
                    licenseClass = Convert.ToByte(reader["LicenseClass"]);
                    expirationDate = (DateTime)reader["ExpirationDate"];
                    issueDate = (DateTime)reader["IssueDate"];

                    if(reader["Notes"] != DBNull.Value)
                        notes = (string)reader["Notes"];
                    else
                        notes = "";
                    
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    isActive = (bool)reader["IsActive"];
                    issueReason = (byte)reader["IssueReason"];
                    createdByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch (Exception)
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

        public static bool IsLicenseExistByPersonIdData(int personId, int licesensClassTypeId)
        {

            bool isFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT isFound = 1 FROM Licenses 
                              WHERE    Licenses.ApplicationID = @ApplicationId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationId", licesensClassTypeId);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    isFound = reader.HasRows;
                }

                reader.Close();

            }
            catch (Exception)
            {
                isFound =false; throw;
            }
            finally
            {  
                conn.Close(); 
            }

            return isFound;
        }

    }
}
