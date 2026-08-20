using System;
using Business;
using System.Data;
using DVLD_2_my.Tests;
using System.Windows.Forms;
using static Business.clsApplication;
using static Business.Tests.clsTestAppointment;
using DVLD_2_my.Applications.Local_Driving_License;


namespace DVLD_2_my.Applications
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
       public enum enMode { New = 0, Update = -1}
       public enMode mode = enMode.New;

       private int _localDrivingLicenseApplicationId = -1;

       private DataTable _AllApplicationsInfo;

       private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;

       public frmListLocalDrivingLicenseApplications()
       {
           InitializeComponent();
            mode = enMode.New;
       }

       public frmListLocalDrivingLicenseApplications(int localDrivingLicenseApplicationId )
       {
           InitializeComponent();

           _localDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
           mode = enMode.Update;
       }

       private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
       {
            RefreshLocalDrivingLicenseApplications();

            cbFilterBy.SelectedIndex = 0;
            
            lblRecordCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();

            if (dgvLocalDrivingLicenseApplications.Rows.Count > 0)
            {
                dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplications.Columns[0].Width = 110;

                dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplications.Columns[1].Width = 150;

                dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No.";
                dgvLocalDrivingLicenseApplications.Columns[2].Width = 110;

                dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplications.Columns[3].Width = 300;

                dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplications.Columns[4].Width = 170;

                dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplications.Columns[5].Width = 100;

            }

       }

        private void RefreshLocalDrivingLicenseApplications()
        {
            _AllApplicationsInfo =
                clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfo();
            dgvLocalDrivingLicenseApplications.DataSource = _AllApplicationsInfo;
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
         
            frmAddUpdateLocalDrivingLicesnseApplication frm = 
                new frmAddUpdateLocalDrivingLicesnseApplication();

            frm.ShowDialog();

            RefreshLocalDrivingLicenseApplications();
            lblRecordCount.Text = _AllApplicationsInfo.DefaultView.Count.ToString();
        }

        private string  GetColumnName(string filter)
        {
            
            switch (filter)
            {
                case "L.D.LAppID":
                    return "LocalDrivingLicenseApplicationID";

                case "National No.":
                    return "NationalNo";

                case "Full Name":
                    return "FullName";

                case "Status":
                    return "Status";            

                default:
                    return "";
            }
            
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string column = GetColumnName(cbFilterBy.Text);
            
            if (string.IsNullOrEmpty(txtFilterValue.Text))
            {
                _AllApplicationsInfo.DefaultView.RowFilter = "";
                lblRecordCount.Text = _AllApplicationsInfo.DefaultView.Count.ToString();
                return;
            }

            switch (column)
            {
                case "LocalDrivingLicenseApplicationID":
                    if(!string.IsNullOrEmpty(txtFilterValue.Text))
                    {
                        _AllApplicationsInfo.DefaultView.RowFilter =
                        $"{column} = {Convert.ToInt32(txtFilterValue.Text)}";
                    }
                    break;

                case "NationalNo":
                    if(clsValidations.ValidateNationalNo(txtFilterValue.Text))
                    {
                        _AllApplicationsInfo.DefaultView.RowFilter = 
                            $"{column} = '{txtFilterValue.Text}'";
                    }
                    break;

                case "FullName":
                    if(clsValidations.ValidateName(txtFilterValue.Text))
                    {
                        _AllApplicationsInfo.DefaultView.RowFilter = 
                            $"{column} LIKE '{txtFilterValue.Text}%'";
                    }
                    break;

                case "Status":
                    _AllApplicationsInfo.DefaultView.RowFilter = 
                        $"{column} LIKE '{txtFilterValue.Text}%'";
                    break;
            }

            lblRecordCount.Text = _AllApplicationsInfo.DefaultView.Count.ToString();
        
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
            
            if (cbFilterBy.SelectedIndex == 0)
            {
                txtFilterValue.Hide();
                _AllApplicationsInfo.DefaultView.RowFilter = "";
            }
            else
            {
                txtFilterValue.Show();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.SelectedIndex == 1 && !char.IsDigit(e.KeyChar) 
                && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFilterValue_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void tsmiCancelApplication_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Are you sure you want to cancel this record", "Confirme",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int localDrivingLicenseApplicationId = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = 
                 clsLocalDrivingLicenseApplication.FindLocalApplicationById(localDrivingLicenseApplicationId);

            if (localDrivingLicenseApplication == null)
            {
                 MessageBox.Show("Application not found.");
                    return;
            }

           if (localDrivingLicenseApplication.Cancel())
           {
           //     MessageBox.Show(localDrivingLicenseApplication.ApplicationStatus.ToString());

                MessageBox.Show($"Application canceled successfully");
                    
                RefreshLocalDrivingLicenseApplications();
           }
           else
           {
                 MessageBox.Show($"Error application not deleted");
           }

        }

        private void cmsListLocalDrivingLicenseApplications_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (dgvLocalDrivingLicenseApplications.CurrentRow == null)
            {
                e.Cancel = true;   // don't show the menu
                return;
            }

            int recordId = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            clsLocalDrivingLicenseApplication app =
                 clsLocalDrivingLicenseApplication.FindLocalApplicationById(recordId);

            if (app == null)
            {
                MessageBox.Show("Application not found.");
                return;
            }
            
                tsmiEditApplication.Enabled = !(app.StatusText == "Cancelled" || app.StatusText == "Completed");
                tsmiDeleteApplication.Enabled = !(app.StatusText == "Cancelled" || app.StatusText == "Completed");
                tsmiCancelApplication.Enabled = !(app.StatusText == "Cancelled" || app.StatusText == "Completed");
                tsmiSechduleTests.Enabled = !(app.StatusText == "Cancelled" || app.StatusText == "Completed");
                tsmiIssueDrivingLicenseFirstTime.Enabled = !(app.StatusText == "Cancelled" || app.StatusText == "Completed");
                tsmiShowLicense.Enabled = !(app.StatusText == "Cancelled" || app.StatusText == "Completed");
            
                tsmiCancelApplication.Enabled = 
                (app.ApplicationStatus == clsApplication.enApplicationStatus.New);

        }

        private void tsmiEditApplication_Click(object sender, EventArgs e)
        {

            int licesnse = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmAddUpdateLocalDrivingLicesnseApplication frm = 
                new frmAddUpdateLocalDrivingLicesnseApplication(licesnse);

            frm.ShowDialog();

            RefreshLocalDrivingLicenseApplications();
        }


        private void tsmiShowApplicationDetails_Click(object sender, EventArgs e)
        {
            
            int localDrivingLicenseApplicationId = 
               (int) dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            frmLocalDrivingLicenseApplicationInfo frm = 
                new frmLocalDrivingLicenseApplicationInfo(localDrivingLicenseApplicationId);

            frm.ShowDialog();

        }

        private void tsmiDeleteApplication_Click(object sender, EventArgs e)
        {
            int localApplicationId =
              (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

           int baseApplicationId = clsLocalDrivingLicenseApplication.FindLocalApplicationById(localApplicationId).ApplicationID;

            if (IsApplicationExist(baseApplicationId))
            {
                clsLocalDrivingLicenseApplication localDrivingLicenseApplication = 
                    clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(localApplicationId);

                if (localDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Local Driving License Application deleted successfully :-)");
                    RefreshLocalDrivingLicenseApplications();
                }
                else
                {
                    MessageBox.Show("Warning: Can not delete this Local Driving License Application because it is linked to other data.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                                
            }

        }

        private void tsmiVisionTest_Click(object sender, EventArgs e)
        {
            // ??
            int vesionTestAppointmentID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;

            
            // ++++  check vesionTestAppointmentID param instead try local driving app ID as param bellow: 
            //frmVisionTestAppointment frm = new frmVisionTestAppointment(vesionTestAppointmentID);



            frmVisionTestAppointment frm = new frmVisionTestAppointment(25);
            frm.ShowDialog();


        }

        private void tsmiIssueDrivingLicenseFirstTime_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WIP: work in progress ....", "Warning",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsmiShowLicense_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WIP: work in progress ....", "Warning",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WIP: work in progress ....", "Warning",
                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }


}

