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
            
            FillLicenseClassesCBbox();

            btnSave.Enabled = false;
            tpApplicationInfo.Enabled = false;

            lbl_DLApplicationID.Text = "[???]";
            tcPersonalApplicationInfo.SelectedTab = tcPersonalApplicationInfo.TabPages["tpPersonal_Info"];

            lblDate.Text = DateTime.Now.ToShortDateString();

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

            // personDetailsWithFilter_uc1.FoucusTxtUc();    

            if (mode == enMode.Update || personDetailsWithFilter_uc1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcPersonalApplicationInfo.SelectedTab = tcPersonalApplicationInfo.TabPages["tpApplicationInfo"];
            }
            else
            {
                MessageBox.Show("Please select a person", "Select a person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        } 

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsLicenseClass LicenseClass = clsLicenseClass.FindByName(cbxLicenseClass.Text);
            int LicesensClassTypeId = LicenseClass.ID;

            int selectedPersonId = personDetailsWithFilter_uc1.PersonID;

            int ActiveApplicationID =   
                clsApplication.GetActiveApplicationIDForLicenseClass
                (selectedPersonId,clsApplication.enApplicationType.NewDrivingLicense,LicesensClassTypeId);

            // ++++ fix ActiveApplicationID = -1 +++*****
            if (ActiveApplicationID != -1) // +++ we can get the personId from event ***
             {
                 MessageBox.Show("Person already have an application with the same driving license type "
                     + "please select another driving license class", 
                     "Not allowed ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                 return;
             }

            if (personDetailsWithFilter_uc1.PersonID != -1) 
            {
                MessageBox.Show($"Choose another license class, the selected Person already have " +
                    $"an active application for the selected class with id:{ActiveApplicationID} please select another driving license class",
                    "Not allowed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }



        }

        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            ResetDefaultValues();

            if(mode == enMode.Update) 
                LoadDataValues();
        }
       
    }

}
