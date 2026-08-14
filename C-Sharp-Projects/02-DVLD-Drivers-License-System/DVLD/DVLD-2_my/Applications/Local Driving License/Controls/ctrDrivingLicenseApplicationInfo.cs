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

            ctrlApplicationBasicInfo1.LoadApplicationInfo(_localDrivingLicenseApplication.ApplicationID);

            fixed here later 
        }

        
       
    }
}
