
using Business;
using Business.Tests;
using DVLD_2_my.Applications.Controls;
using DVLD_2_my.Properties;
using System;
using System.Windows.Forms;
using static Business.clsTestType;


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

        private void _LoadTestTypeImageAndTitle(clsTestType.enTestType testType)
        {
            frmListTestAppointments frm = new frmListTestAppointments();
            
            switch (testType)
            {
                case clsTestType.enTestType.VisionTest:
                    frm.Text = "Vision Test";
                    frm.lbl_Title_frmListTestAppointments.Text = "Vision Test Appointments";
                    frm.pbListTestAppointments.Image = Resources.Vision_512;
                    break;

                case clsTestType.enTestType.WrittenTheoryTest:
                    frm.Text = "Written Theory Test";
                    frm.lbl_Title_frmListTestAppointments.Text = "Written Theory Test Appointments";
                    frm.pbListTestAppointments.Image = Resources.Written_Test_512;
                    break;
                case clsTestType.enTestType.StreetPracticalTest:
                    frm.Text = "Practical Street Test";
                    frm.lbl_Title_frmListTestAppointments.Text = "Practical Street Appointments";
                    frm.pbListTestAppointments.Image = Resources.Street_Test_32;
                    break;

                default:
                    frm.Text = "List Test Appointment";
                    frm.pbListTestAppointments.Image = Resources.Vision_512;
                    break;
            
            }

        }


        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {

            _LoadTestTypeImageAndTitle(_testType);

            frmListTestAppointments frm = new frmListTestAppointments(_localDrivingLicenseApplicationID, clsTestType.enTestType.VisionTest);

            ctrDrivingLicenseApplicationInfo1.LoadDrivingLicenseApplicationInfoByID(_localDrivingLicenseApplicationID);

        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
           
             frmScheduleTest frm = new frmScheduleTest(_localDrivingLicenseApplicationID, _testType);
           
           clsLocalDrivingLicenseApplication _localDrivingLicenseApplication = 
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_localDrivingLicenseApplicationID);



            //if (testAppointment.TestAppointmentID != -1)
            if (clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_testType))
            {
                MessageBox.Show("This person already has an active appointment for this test." +
                                    " You cannot add a new appointment!", "Active Appointment",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            frm.ShowDialog();

        }



    }
}
