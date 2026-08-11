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

namespace DVLD_2_my.Applications.Controls
{
    public partial class ctrDrivingLicenseApplicationInfo : UserControl
    {
        public int DrivingLicenseApplicationId { get; set; }

        public string LicenseClassName { get; set; }

        public short PassedTestCount { get; set; }


        public ctrDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void LoadValues()
        {
            clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(this.DrivingLicenseApplicationId);
        }

        private void ctrDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            LoadValues();
        }


    }
}
