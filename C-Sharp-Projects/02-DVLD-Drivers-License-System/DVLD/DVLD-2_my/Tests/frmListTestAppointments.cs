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




    }
}
