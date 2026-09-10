using System;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess.Tests
{
    public class clsTestData
    {
        public static DataTable GetAllTestsInfoData()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Tests";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    dt.Load(reader);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static byte PassedTestCountData(int localDrivingLicenseApplicationID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PassedTestCount=COUNT(TestTypeID)  FROM Tests 
							INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
								
                                  WHERE TestAppointments.LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID 
								    AND Tests.TestResult = 1";


            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue(@"localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            byte passedTestCounter = 0;
            try
            {
                connection.Open();
                object returnedObj = cmd.ExecuteScalar();

                if (returnedObj != null && byte.TryParse(returnedObj.ToString(), out byte testCount))
                {
                    passedTestCounter = testCount;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return passedTestCounter;
        }


    }
}
