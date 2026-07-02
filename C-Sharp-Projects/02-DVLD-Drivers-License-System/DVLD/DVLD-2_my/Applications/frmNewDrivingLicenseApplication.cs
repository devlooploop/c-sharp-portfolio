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
using Business;


namespace DVLD_2_my
{
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode mode = enMode.AddNew;

        private int _localDrivingLicesnseApplicationId = -1;
        private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;

        public frmAddUpdateLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
            mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicesnseApplication(int applicationId)
        {
            InitializeComponent();
            _localDrivingLicesnseApplicationId = applicationId;
            mode = enMode.Update;
        }

        private void ResetDefaultValues()
        {
            btnSave.Enabled = false;

            lbl_DLApplicationID.Text = "[???]";
            tcPersonalApplicationInfo.SelectedTab = tcPersonalApplicationInfo.TabPages["tpPersonal_Info"];

            tpApplicationInfo.Enabled = false;
            lblDate.Text = DateTime.Now.ToString();

            cbxLicenseClass.SelectedIndex = 3;
            lbl_ApplicationFees.Text = clsApplicationTypes.FindApplicationByID((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
            
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
        
            if(mode == enMode.AddNew)
            {
                btnSave.Enabled = false;
                tpApplicationInfo.Enabled = false;
                lbl_DLApplicationID.Text = "[???]";
                this.Text = "Add New Local Driving License Application";
                lblTitle.Text = "New Local Driving License Application";
                tcPersonalApplicationInfo.SelectedTab = tcPersonalApplicationInfo.TabPages["tpPersonal_Info"];

                cbxLicenseClass.SelectedIndex = cbxLicenseClass.FindString(cbxLicenseClass.Text);
                clsLocalDrivingLicenseApplication newLocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
            }

            if(mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                lbl_DLApplicationID.Text = "[???]";
                this.Text = "Update Local Driving License Application";
                lblTitle.Text = "Update Local Driving License Application";
                tcPersonalApplicationInfo.SelectedTab = tcPersonalApplicationInfo.TabPages["tpApplicationInfo"];

                cbxLicenseClass.SelectedIndex = cbxLicenseClass.FindString(cbxLicenseClass.Text);
                
                clsLocalDrivingLicenseApplication newLocalDrivingLicenseApplication = new
                    clsLocalDrivingLicenseApplication(this._localDrivingLicesnseApplicationId, this._localDrivingLicenseApplication.ApplicationID,
                        this._localDrivingLicenseApplication.LicenseClassId);

            }

            lblDate.Text = DateTime.Now.ToString("dd/mm/yyyy");
            lbl_UserName.Text = clsGlobal.currentUser.UserName;
            lbl_ApplicationFees.Text = clsApplicationTypes.FindApplicationByID((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           // LoadDataValues();
            tcPersonalApplicationInfo.SelectedTab = tcPersonalApplicationInfo.TabPages["tpApplicationInfo"];
            btnNext.Hide();

            if (mode == enMode.AddNew)
            {
                ResetDefaultValues();
            }

            if(mode == enMode.Update)
            {
                LoadDataValues();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

        }

        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            ResetDefaultValues();

            if(mode == enMode.Update) 
                LoadDataValues();
        }

    }
}
