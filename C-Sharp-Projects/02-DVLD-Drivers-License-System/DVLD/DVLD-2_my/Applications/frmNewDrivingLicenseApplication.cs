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


namespace DVLD_2_my
{
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {
        
        private clsLicenseClass _licenseClass;
        private clsLicense _license;
        private clsUser _user;
        private clsApplication _application;

        public frmAddUpdateLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
        }

        private void ResetDefaultValues()
        {
            
            btnSave.Enabled = false;

            lbl_DLApplicationID.Text = "[???]";
            tcPersonalApplicationInfo.SelectedTab = tcPersonalApplicationInfo.TabPages["tpPersonal_Info"];
            lblDate.Text = DateTime.Now.ToString();

            cbxLicenseClass.SelectedIndex = 3;
            lbl_ApplicationFees.Text = _application.ApplicationID.ToString();
            lbl_UserName.Text = clsGlobal.currentUser.UserName;

        }

        private void FillLicenseClassesCBbox()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow item in dt.Rows)
            {
                cbxLicenseClass.Items.Add(item["ClassName"]);
            }

        }

        private void LoadDataValues()
        {
            FillLicenseClassesCBbox();
            btnSave.Enabled = false;

            lbl_DLApplicationID.Text = "[???]";
            tcPersonalApplicationInfo.SelectedTab = tcPersonalApplicationInfo.TabPages["tpApplicationInfo"];
            lblDate.Text = DateTime.Now.ToString();

            cbxLicenseClass.SelectedIndex = 3;
            lbl_ApplicationFees.Text = _application.ApplicationID.ToString();
            lbl_UserName.Text = clsGlobal.currentUser.UserName;

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnNext.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            LoadDataValues();
        }

    }
}
