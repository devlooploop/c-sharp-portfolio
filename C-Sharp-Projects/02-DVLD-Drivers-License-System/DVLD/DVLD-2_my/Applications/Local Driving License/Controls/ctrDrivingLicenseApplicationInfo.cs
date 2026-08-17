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

        public void LoadDrivingLicenseApplicationInfo(int drivingLicenseApplicationId)
        {

            _localDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(drivingLicenseApplicationId);

            if (_localDrivingLicenseApplication == null)
            {
                MessageBox.Show($"No Application found with Id = {drivingLicenseApplicationId}");
                return;
            }

            lbl_DLAppID.Text = _localDrivingLicenseApplication.LocalDrivingLicenseApplicationId.ToString();

            lbl_AppliedForLicense.Text =
                clsLicenseClass.FindByID(_localDrivingLicenseApplication.LicenseClassId).ClassName.ToString();
            
            lbl_PassedTests.Text = "???Add later????";

            //<<
            int applicationId = _localDrivingLicenseApplication.ApplicationID;

            MessageBox.Show($"Local DL App ID: {_localDrivingLicenseApplication.LocalDrivingLicenseApplicationId}\n" +
                            $"Application ID: {applicationId}");
            //>>

            ctrlApplicationBasicInfo1.LoadApplicationInfo(_localDrivingLicenseApplication.ApplicationID);
            //ctrlApplicationBasicInfo1.LoadApplicationInfo(_localDrivingLicenseApplication.LocalDrivingLicenseApplicationId);

            MessageBox.Show(
    $"Control Name: {ctrlApplicationBasicInfo1.Name}\n" +
    $"Visible: {ctrlApplicationBasicInfo1.Visible}\n" +
    $"Size: {ctrlApplicationBasicInfo1.Size}\n" +
    $"Location: {ctrlApplicationBasicInfo1.Location}"
);

        }

        make neww ctrBasicInfo in the frmlocaldriving ...
       
    }
}
