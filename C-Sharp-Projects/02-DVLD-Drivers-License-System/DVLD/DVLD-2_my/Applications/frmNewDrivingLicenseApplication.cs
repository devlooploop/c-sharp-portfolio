using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace DVLD_2_my
{
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode mode = enMode.AddNew;

        private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;
        private int _localDrivingLicesnseApplicationId = -1;

        private int _selectedPersonId = -1; 
        
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
            
            _localDrivingLicenseApplication =
                    clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_localDrivingLicesnseApplicationId);

            if( _localDrivingLicenseApplication == null )
            {
                MessageBox.Show("No Application with ID = " + _localDrivingLicesnseApplicationId, "Application Not Found",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            if (mode == enMode.AddNew)
            {

                btnSave.Enabled = false;
                tpApplicationInfo.Enabled = false;
                lbl_DLApplicationID.Text = "[???]";
                this.Text = "Add New Local Driving License Application";
                lblTitle.Text = "New Local Driving License Application";
                tcPersonalApplicationInfo.SelectedTab = tcPersonalApplicationInfo.TabPages["tpPersonal_Info"];

                cbxLicenseClass.SelectedIndex = cbxLicenseClass.FindString(cbxLicenseClass.Text);
                clsLocalDrivingLicenseApplication localDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
        

            }

            if(mode == enMode.Update)
            {
                
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                lbl_DLApplicationID.Text = _localDrivingLicenseApplication.LocalDrivingLicenseApplicationId.ToString();
                this.Text = "Update Local Driving License Application";
                lblTitle.Text = "Update Local Driving License Application";
                tcPersonalApplicationInfo.SelectedTab = tcPersonalApplicationInfo.TabPages["tpApplicationInfo"];

                cbxLicenseClass.SelectedIndex = cbxLicenseClass.FindString(cbxLicenseClass.Text);

            }

            lblDate.Text = DateTime.Now.ToString("dd/mm/yyyy");
            lbl_UserName.Text = clsGlobal.currentUser.UserName;
            lbl_ApplicationFees.Text = 
                clsApplicationTypes.FindApplicationByID((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            // personDetailsWithFilter_uc1.FoucusTxtUc();    
            
            if (mode == enMode.AddNew && personDetailsWithFilter_uc1.PersonID == -1)
            {
                
                MessageBox.Show("Please select a person", "Select a person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcPersonalApplicationInfo.SelectedTab = tcPersonalApplicationInfo.TabPages["tpApplicationInfo"];
            }                                            
            
        } 

        private void btnSave_Click(object sender, EventArgs e)
        {

            int LicesensClassTypeId = clsLicenseClass.FindByName(cbxLicenseClass.Text).ID;


            int ActiveApplicationID =   
                clsApplication.GetActiveApplicationIDForLicenseClass
                (_selectedPersonId,clsApplication.enApplicationType.NewDrivingLicense,LicesensClassTypeId);


            if (ActiveApplicationID != -1)
            {

                MessageBox.Show($"The selected person already have an application with the same class id = {ActiveApplicationID}"
                     , "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLicense.IsLicenseExistByPersonID(personDetailsWithFilter_uc1.PersonID, LicesensClassTypeId))
            {
                MessageBox.Show($"The selected Person already have " +
                    "same applied driving class, please select diffrent driving class",
                        "Action Not allowed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _localDrivingLicenseApplication.ApplicationID = ActiveApplicationID;
            
            _localDrivingLicenseApplication.ApplicantPersonID = personDetailsWithFilter_uc1.PersonID;
            _localDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _localDrivingLicenseApplication.ApplicationTypeID = clsLicenseClass.FindByName(cbxLicenseClass.Text).ID;
            _localDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _localDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _localDrivingLicenseApplication.PaidFees = Convert.ToSingle(lbl_ApplicationFees);
            _localDrivingLicenseApplication.CreatedByUserID = clsGlobal.currentUser.UserID;

            if(_localDrivingLicenseApplication.Save())
            {
                MessageBox.Show("Local driving license application saved successfully",
                    "Saved successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Local driving license application Not saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            ResetDefaultValues();

            if(mode == enMode.Update) 
                LoadDataValues();
        }

        private void personDetailsWithFilter_uc1_OnPersonSelected(int obj)
        {
            _selectedPersonId = obj;
        }
    }

}
