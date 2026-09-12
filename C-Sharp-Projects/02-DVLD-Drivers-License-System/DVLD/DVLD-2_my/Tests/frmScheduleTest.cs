using Business;
using Business.Tests;
using DVLD_2_my.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Business.clsTestType;


namespace DVLD_2_my.Tests
{
    public partial class frmScheduleTest : Form
    {
        int _localDrivingLicenseApplicationID = -1;

        private clsTestType.enTestType _testType;
        private clsTestType _testTypeDetails;


        public frmScheduleTest()
        {
            InitializeComponent();
        }

        public frmScheduleTest(int localDrivingLicenseApplicationID, clsTestType.enTestType testType)
        {
            InitializeComponent();

            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _testType = testType;
        }

        private void _LoadTestTypeImageAndTitle(clsTestType.enTestType testType)
        {
            frmScheduleTest frm = new frmScheduleTest();

            switch (testType)
            {
                case clsTestType.enTestType.VisionTest:
                    frm.Text = "Vision Test";
                    frm.lbl_FromScheduleTitle.Text = "Vision Test Appointments";
                    frm.pbScheduleTest.Image = Resources.Vision_512;
                    break;

                case clsTestType.enTestType.WrittenTheoryTest:
                    frm.Text = "Written Theory Test";
                    frm.lbl_FromScheduleTitle.Text = "Written Theory Test Appointments";
                    frm.pbScheduleTest.Image = Resources.Written_Test_512;
                    break;

                case clsTestType.enTestType.StreetPracticalTest:
                    frm.Text = "Practical Street Test";
                    frm.lbl_FromScheduleTitle.Text = "Practical Street Appointments";
                    frm.pbScheduleTest.Image = Resources.Street_Test_32;
                    break;

                default:
                    frm.Text = "Schedule Test";
                    frm.pbScheduleTest.Image = Resources.Vision_512;
                    break;

            }

        }

        private void LoadValues()
        {
            clsTestAppointment testAppointment 
                = clsTestAppointment.FindTestAppointmentByDrivinglicenseID(_localDrivingLicenseApplicationID);

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = 
                clsLocalDrivingLicenseApplication.FindLocalApplicationById(_localDrivingLicenseApplicationID);

            if (testAppointment == null)
            {
                MessageBox.Show("Test Appointment value is NULL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbl_DLAppID.Text = testAppointment.LocalDrivingLicenseApplicationID.ToString();
            lbl_DClass.Text = testAppointment.LicenseClassInfo.ClassName.ToString();

            lbl_Name.Text = testAppointment.LocalDrivingLicenseApplication.ApplicantFullName;
            //lbl_Trail.Text = ;
            
            dtpScheduleTest.Text = testAppointment.AppointmentDate.ToString();
            lbl_Fees.Text = testAppointment.PaidFees.ToString();

            // RetakTestInfo group box:
            lbl_RAppFees.Text =  testAppointment.PaidFees.ToString();
            lbl_RTestAppID.Text = testAppointment.RetakeTestApplicationID.ToString();
            lbl_TotalFees.Text = _testTypeDetails.TestTypeFees.ToString();

            _LoadTestTypeImageAndTitle( _testType);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Comming soon near you ", "Save Button", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            LoadValues();
        }

       
    }

}
