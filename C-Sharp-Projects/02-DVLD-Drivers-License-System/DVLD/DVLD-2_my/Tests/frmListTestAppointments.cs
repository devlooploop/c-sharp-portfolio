
using DVLD_2_my.Applications.Controls;
using System;
using System.Windows.Forms;
using Business;
using Business.Tests;


namespace DVLD_2_my.Tests
{
    public partial class frmListTestAppointments : Form
    {

        private int _localDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _testType;

        public frmListTestAppointments()
        {
            InitializeComponent();
        }

        public frmListTestAppointments(int localDrivingLicenseApplicationID, clsTestType.enTestType testType)
        {
            InitializeComponent();

            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _testType = testType;
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {

          frmListTestAppointments frm = new frmListTestAppointments(_localDrivingLicenseApplicationID, clsTestType.enTestType.VisionTest);

          ctrDrivingLicenseApplicationInfo1.LoadDrivingLicenseApplicationInfoByID(_localDrivingLicenseApplicationID);

        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(localdrivingID, TestType);

           // ctrDrivingLicenseApplicationInfo1.LoadDrivingLicenseApplicationInfoByID(_localDrivingLicenseApplicationID);

            clsTestAppointment testAppointment = 
                clsTestAppointment.FindTestAppointmentByDrivinglicenseID(_localDrivingLicenseApplicationID);
            
            int testAppointmentID = testAppointment.TestAppointmentID;

            if (int.TryParse("testAppointmentID", out int testAppointment_ID) && testAppointmentID != -1)
            {
                MessageBox.Show("This person already has an active appointment for this test." +
                                    "You cannot add a new appointment!","Active Appointment", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frm.ShowDialog();

        }



    }
}
