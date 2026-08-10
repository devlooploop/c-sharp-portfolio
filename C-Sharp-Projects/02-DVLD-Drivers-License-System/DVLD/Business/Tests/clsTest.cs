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

        // TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID

        public static DataTable GetAllTestsInfo()
        {
            return clsTestData.GetAllTestsInfoData();
        }



    }
}
