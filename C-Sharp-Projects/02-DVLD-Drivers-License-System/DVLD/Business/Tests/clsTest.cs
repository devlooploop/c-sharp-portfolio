using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess.Tests;

namespace Business.Tests
{
    public class clsTest
    {

        enum enTestResult { Fail=0, Pass=1};

        // TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID
        public int TestID { get; }
        public int TestAppointmentID { get; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }


        public clsTest()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = ""; 
            CreatedByUserID = -1;
        }

        public static DataTable GetAllTestsInfo()
        {
            return clsTestData.GetAllTestsInfoData();
        }


        public static byte PassedTestCount(int localDrivingLicenseApplicationID)
        {
           return clsTestData.PassedTestCountData(localDrivingLicenseApplicationID);
        }


    }
}
