using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Business.Tests;



namespace DVLD_2_my.Tests
{
    public partial class frmScheduleTest : Form
    {
        int _localDrivingLicenseApplicationID = -1;


        private clsTestType.enTestType _testType;

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

        private void LoadValues()
        {
            clsTestAppointment testAppointment 
                = clsTestAppointment.FindTestAppointmentByDrivinglicenseID(_localDrivingLicenseApplicationID);

            if (testAppointment == null)
            {
                MessageBox.Show("Test Appointment value is NULL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lbl_DLAppID.Text = testAppointment.LocalDrivingLicenseApplicationID.ToString();
            lbl_DClass.Text = testAppointment.LicenseClassInfo.ClassName.ToString();

            lbl_Name.Text = testAppointment.LocalDrivingLicenseApplication.ApplicantFullName;
            //lbl_Trail.Text;
            
            dtpScheduleTest.Text = testAppointment.AppointmentDate.ToString();
            lbl_Fees.Text = testAppointment.PaidFees.ToString();

            // RetakTestInfo group box:
            lbl_RAppFees.Text =  testAppointment.PaidFees.ToString();
            lbl_RTestAppID.Text = testAppointment.RetakeTestApplicationID.ToString();
            //lbl_TotalFees.Text = 

        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            LoadValues();
        }


        /* make schedule test at this point ... enum and switch on the 3-tets(vision, street & written)
         * then let the switch-on statment chose witch (pic-box to show + related info).
         * .... later at this point!
         */
    }

}
