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
            {
                conn.Close();   
            }

            return dt;
        }

        public static bool GetLicenseClassInfoByIdData(int id, ref string className, ref string description,
                       ref byte minAllowedAge,ref byte defaultValidatyLength, ref float fees)
        {
            bool isFound = false;    
                
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LicenseClasses
                              WHERE LicenseClassID = @Id";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    className = (string)reader["ClassName"];
                    description = (string)reader["ClassDescription"];
                   minAllowedAge = (byte)reader["MinimumAllowedAge"];
                   defaultValidatyLength = (byte)reader["DefaultValidityLength"];
                   fees = Convert.ToSingle(reader["ClassFees"]);
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
        public static bool GetLicenseClassInfoByNameData(ref int id, string className, ref string description,
                       ref byte minAllowedAge, ref byte defaultValidatyLength, ref float fees)
        {
            bool isFound = false;    
                
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LicenseClasses
                              WHERE ClassName = @className";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@className", className);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    id = (int)reader["LicenseClassID"];
                    description = (string)reader["ClassDescription"];
                    minAllowedAge = (byte)reader["MinimumAllowedAge"];
                    defaultValidatyLength = (byte)reader["DefaultValidityLength"];
                    fees = Convert.ToSingle(reader["ClassFees"]);
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
