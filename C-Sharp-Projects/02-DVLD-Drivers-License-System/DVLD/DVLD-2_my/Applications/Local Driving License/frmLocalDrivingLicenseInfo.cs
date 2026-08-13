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


namespace DVLD_2_my.Applications.Local_Driving_License
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        private int _localDrivingLicenseApplicationID;
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
            
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_localDrivingLicenseApplicationID);

        }

    }
}
