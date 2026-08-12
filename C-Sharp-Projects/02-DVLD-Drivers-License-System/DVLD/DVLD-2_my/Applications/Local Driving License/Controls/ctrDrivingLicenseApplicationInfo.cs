using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_2_my.Applications.Controls
{
    public partial class ctrDrivingLicenseApplicationInfo : UserControl
    {
        private int _drivingLicenseApplicationID = -1;
        // clsApplication _application;

        clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;

        public int DrivingLicenseApplicationId { get; set; }

        public string LicenseClassName { get; set; }

        public short PassedTestCount { get; set; }


        public ctrDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public ctrDrivingLicenseApplicationInfo(int DrivingLicenseApplicationID)
        {
            InitializeComponent();

            _drivingLicenseApplicationID = DrivingLicenseApplicationID;
        }

        private void LoadValues(check param later ... _localDrivingLicenseApplication )
        {
            // _application = clsApplication.FindBaseApplicationByID(_drivingLicenseApplicationID);

            _localDrivingLicenseApplication = 
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_drivingLicenseApplicationID);

            if (_localDrivingLicenseApplication == null)
            {
                MessageBox.Show($"No Application found with Id = {_drivingLicenseApplicationID}");
                return;
            }

            lbl_DLAppID.Text = _localDrivingLicenseApplication.ApplicationID.ToString();
            lbl_AppliedForLicense.Text = _localDrivingLicenseApplication.LicenseClassInfo.ToString();
            lbl_PassedTests.Text = "9999"; // add test count value later ....

        }

        private void ctrDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            LoadValues();
        }


    }
}
