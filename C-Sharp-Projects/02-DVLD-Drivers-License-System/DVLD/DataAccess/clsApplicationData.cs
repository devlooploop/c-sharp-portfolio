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


        public static int AddNewApplicationData()
        {

        }
    }
}
