using System;
using Business;
using System.Windows.Forms;


namespace DVLD_2_my.Applications.Local_Driving_License
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        private int _localDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;
        private clsApplication _application;

        public frmLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public frmLocalDrivingLicenseApplicationInfo(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        }

        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {

            ctrlDrivingLicenseApplicationInfo1.LoadDrivingLicenseApplicationInfo(_localDrivingLicenseApplicationID);

        }

    }
}
