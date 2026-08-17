using Business;
using System;
using System.Windows.Forms;

namespace DVLD_2_my.Applications.Controls
{
    public partial class ctrDrivingLicenseApplicationInfo : UserControl
    {

        clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;

        public ctrDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void FillValues()
        {
            lbl_DLAppID.Text = _localDrivingLicenseApplication.LocalDrivingLicenseApplicationId.ToString();

            lbl_AppliedForLicense.Text =
                clsLicenseClass.FindByID(_localDrivingLicenseApplication.LicenseClassId).ClassName.ToString();

            lbl_PassedTests.Text = "???Add later????";
        }

        public void LoadDrivingLicenseApplicationInfo(int drivingLicenseApplicationId)
        {

            _localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(drivingLicenseApplicationId);

            if (_localDrivingLicenseApplication == null)
            {
                MessageBox.Show($"No Application found with Id = {drivingLicenseApplicationId}");
                return;
            }

            FillValues();

            ctrlApplicationBasicInfo1.LoadApplicationInfo(_localDrivingLicenseApplication.ApplicationID);
       

        }
    }
}
