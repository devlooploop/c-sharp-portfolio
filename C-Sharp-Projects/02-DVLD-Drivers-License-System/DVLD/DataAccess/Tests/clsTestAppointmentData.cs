using System;
using System.Data;
using System.Data.SqlClient;



namespace DataAccess.Tests
{
    public class clsTestAppointmentData
    {
        public static DataTable GetTestAppointmentsInfoData()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestAppointments";

            SqlCommand command = new SqlCommand(query, conn);

            try
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
                // error log here !!
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }


        public static bool FindTestAppointmentDataByID(int testAppointmentID, ref int testTypeID,
            ref int localDrivingLicenseApplicationID, ref DateTime appointmentDate,
            ref float paidFees, ref int createdByUserID, ref bool isLocked, 
            ref int retakeTestApplicationID)
        {
            
            bool isFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM TestAppointments 
                              WHERE TestAppointmentID = @testAppointmentID";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);

            try
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    isFound = true;

                    testTypeID = (int)reader["TestTypeID"];
                    localDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    appointmentDate = (DateTime)reader["AppointmentDate"];
                    paidFees = Convert.ToSingle(reader["PaidFees"]); 
                    createdByUserID = (int)reader["CreatedByUserID"]; 
                    isLocked = (bool)reader["IsLocked"]; 
                    retakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
                // error log here !!
            }
            finally
            {
                conn.Close();
            }

            return isFound;

        }


        public static bool FindTestAppointmentByDrivinglicenseID_Data(int localDrivingLicenseApplicationID, ref int testAppointmentID, ref int testTypeID,
                  ref DateTime appointmentDate, ref float paidFees, ref int createdByUserID, ref bool isLocked, ref int retakeTestApplicationID)
        {
            
            bool isFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM TestAppointments  
                                WHERE LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationId";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationId", localDrivingLicenseApplicationID);

            try
            {
                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    
                    testAppointmentID = (int)reader["TestAppointmentID"];
                    testTypeID = (int)reader["TestTypeID"];
              //      localDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    appointmentDate = (DateTime)reader["AppointmentDate"];
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    createdByUserID = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["IsLocked"];

                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        retakeTestApplicationID = -1;
                    else
                        retakeTestApplicationID = (int)reader["RetakeTestApplicationID"];

                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
                // error log here !!
            }
            finally
            {
                conn.Close();
            }

            return isFound;

        }

    }

}

    
