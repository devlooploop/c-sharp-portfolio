using System;
using Business;
using System.Windows.Forms;


namespace DVLD_2_my.Applications.Local_Driving_License
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        private int _localDrivingLicenseApplicationID = -1;
   
        public frmLocalDrivingLicenseApplicationInfo(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        }

        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrDrivingLicenseApplicationInfo1.LoadDrivingLicenseApplicationInfoByID(_localDrivingLicenseApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
