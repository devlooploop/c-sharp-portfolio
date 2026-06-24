using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class clsLicenseClassData
    {
        public static DataTable GetAllLicenseClassesData()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LicenseClasses";

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
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

        public static bool FindByID(int id)
        {
            bool isFound = false;    
                
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees FROM LicenseClasses
                              WHERE id = @ID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    string name = (string)reader["Name"];
                    string desiciption = (string)reader["ClassDescription"];
                    string minAllowedAge = (string)reader["MinimumAllowedAge"];
                    string validityLength = (string)reader["DefaultValidityLength"];
                    string fees = (string)reader["ClassFees"];
                }
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


    }

}
