using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Tests;


namespace Business.Tests
{
    public class clsTestAppointment
    {
        private int _testAppointmentID = -1;
        private int _testTypeID = -1;
        private int _localDrivingLicenseApplicationID = -1;
        private DateTime _appointmentDate = DateTime.Now;
        private float _paidFees = 0.00f;
        private int _createdByUserID = -1;
        private bool _isLocked = false;
        private int _retakeTestApplicationID = -1;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID 
        {
            get { return _localDrivingLicenseApplicationID; } 
            set { _localDrivingLicenseApplicationID = value; } 
        }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        public clsLicenseClass LicenseClassInfo;


        private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;

        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication
        {
            set { _localDrivingLicenseApplication = value ;}

            get {return _localDrivingLicenseApplication;} 
        }

        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0.00f;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;

        }

        private clsTestAppointment(int testAppointmentID, int testTypeID,int localDrivingLicenseApplicationID, 
            DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked, 
            int retakeTestApplicationID)
        {
            this.TestAppointmentID = testAppointmentID;
            this.TestTypeID = testTypeID;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.AppointmentDate = appointmentDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.IsLocked = isLocked;
            this.RetakeTestApplicationID = retakeTestApplicationID;
        }

        public static DataTable GetTestAppointmentsInfo()
        {
            return clsTestAppointmentData.GetTestAppointmentsInfoData();
        }

        public static clsTestAppointment FindTestAppointmentByID(int testAppointmentID)
        {
            int testTypeId = -1; int localDrivingLicenseApplicationId = -1;
            DateTime appointment_Date = DateTime.Now; float paid_Fees = 0.00F;
            int createdByUser_ID = -1; bool is_Locked = false; int retakeTestApplication_ID = -1;

            bool isFound =  clsTestAppointmentData.FindTestAppointmentDataByID(testAppointmentID, ref testTypeId,
            ref localDrivingLicenseApplicationId, ref appointment_Date,
            ref paid_Fees, ref createdByUser_ID, ref is_Locked, ref retakeTestApplication_ID);

            if(isFound)
            {
                return new clsTestAppointment(testAppointmentID,testTypeId,localDrivingLicenseApplicationId, 
                    appointment_Date,paid_Fees,createdByUser_ID, is_Locked, retakeTestApplication_ID);
            }
            else
            {
                return null;
            }

        }

        public static clsTestAppointment FindTestAppointmentByDrivinglicenseID(int localDrivingLicenseApplicationID)
        {
            int testAppointmentID = -1;  int testTypeID = -1; 
            DateTime appointmentDate = DateTime.Now; float paidFees = 0.00F;
            int createdByUserID = -1; bool isLocked = false; int retakeTestApplicationID = -1;
            string testTypeTitle = ""; string fullName = ""; string className = "";

            bool isFound =  clsTestAppointmentData.FindTestAppointmentByDrivinglicenseID_Data( localDrivingLicenseApplicationID, ref testAppointmentID, 
                ref testTypeTitle, ref className, ref appointmentDate, ref paidFees, ref fullName, ref isLocked, ref retakeTestApplicationID);

            if(isFound)
            {
                // check retakeTestApplicationID ???
                return new clsTestAppointment(testAppointmentID,testTypeID,localDrivingLicenseApplicationID, 
                    appointmentDate,paidFees,createdByUserID, isLocked, retakeTestApplicationID);
            }
            else
            {
                return null;
            }

        }

        public void LoadTestAppointmentInfo()
        {
            clsTestAppointmentData.GetTestAppointmentsInfoData();
        }


    }
}
