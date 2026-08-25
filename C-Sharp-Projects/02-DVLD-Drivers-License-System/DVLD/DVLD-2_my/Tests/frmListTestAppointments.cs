
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

          ctrDrivingLicenseApplicationInfo1.LoadDrivingLicenseApplicationInfo(_localDrivingLicenseApplicationID);

        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest();

            ctrDrivingLicenseApplicationInfo1.LoadDrivingLicenseApplicationInfo(_localDrivingLicenseApplicationID);

            clsTestAppointment testAppointment = clsTestAppointment.FindTestAppointmentByDrivinglicenseID(_localDrivingLicenseApplicationID);

            if (testAppointment == null)
            {
                MessageBox.Show("No Test Appointment found!!!");
                return;
            }

            frm.ShowDialog();

        }



    }
}
