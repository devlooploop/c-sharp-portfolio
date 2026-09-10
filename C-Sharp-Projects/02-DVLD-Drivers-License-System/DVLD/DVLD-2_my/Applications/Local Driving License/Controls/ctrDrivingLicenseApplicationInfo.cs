using System;
using Business;
using Business.Tests;
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
            lbl_DLAppID.Text = 
                _localDrivingLicenseApplication.LocalDrivingLicenseApplicationId.ToString();

            lbl_AppliedForLicense.Text =
                clsLicenseClass.FindByID(_localDrivingLicenseApplication.LicenseClassId).ClassName.ToString();

            lbl_PassedTests.Text = 
                clsTest.PassedTestCount(_localDrivingLicenseApplication.LocalDrivingLicenseApplicationId).ToString();
        }

        public void LoadDrivingLicenseApplicationInfoByID(int drivingLicenseApplicationId)
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

        private void ll_ShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show($"Under construction","Comming soon ....",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
   
        
    
    }
}
