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
            
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = 
                clsLocalDrivingLicenseApplication.FindLocalApplicationById(_localDrivingLicenseApplicationID);

            bool HasActiveTest =  
                clsLocalDrivingLicenseApplication.DoesPersonHaveActiveApplication(localDrivingLicenseApplication.LocalDrivingLicenseApplicationId, (int)_testType);

            //if (testAppointment == null)
            //{
            //    MessageBox.Show("Test Appointment value is NULL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (HasActiveTest)
            {
                MessageBox.Show("This person has already an active test Appointment", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbl_DLAppID.Text = localDrivingLicenseApplication.LocalDrivingLicenseApplicationId.ToString();
            lbl_DClass.Text = localDrivingLicenseApplication.LicenseClassInfo.ClassName.ToString();

            lbl_Name.Text = localDrivingLicenseApplication.ApplicantFullName;
            lbl_Trail.Text = "will be added soon ....";
            
            dtpScheduleTest.Text = localDrivingLicenseApplication.ApplicationDate.ToString();
            lbl_Fees.Text = _testTypeDetails.

            // RetakTestInfo group box:
            lbl_RAppFees.Text  =  localDrivingLicenseApplication.PaidFees.ToString();
            lbl_TotalFees.Text = (localDrivingLicenseApplication.PaidFees + );

             
            _LoadTestTypeImageAndTitle(_testType);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Comming soon .....", "Save Button", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            LoadValues();
        }

       
    }

}
