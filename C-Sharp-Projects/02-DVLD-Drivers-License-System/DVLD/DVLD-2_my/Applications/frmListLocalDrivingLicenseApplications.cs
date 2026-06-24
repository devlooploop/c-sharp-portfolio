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

namespace DVLD_2_my.Applications
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        DataTable _AllApplicationsInfo;


        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _AllApplicationsInfo = clsApplication.GetAllApplicationsInfo();
            dgvLocalDrivingLicenseApplications.DataSource = _AllApplicationsInfo;

            
        }



    }
}
