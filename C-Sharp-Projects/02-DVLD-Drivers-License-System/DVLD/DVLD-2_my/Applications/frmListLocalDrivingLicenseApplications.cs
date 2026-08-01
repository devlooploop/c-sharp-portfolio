using Business;
using System;
using System.Data;
using System.Windows.Forms;


namespace DVLD_2_my.Applications
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {

       private DataTable _AllApplicationsInfo;
       
       public frmListLocalDrivingLicenseApplications()
       {
           InitializeComponent();
       }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            RefreshLocalDrivingLicenseApplications();

            cbFilterBy.SelectedIndex = 0;
            
            lblRecordCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();

            if (dgvLocalDrivingLicenseApplications.Rows.Count > 0)
            {
                dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplications.Columns[0].Width = 120;

                dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplications.Columns[1].Width = 300;

                dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No.";
                dgvLocalDrivingLicenseApplications.Columns[2].Width = 150;

                dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplications.Columns[3].Width = 350;

                dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplications.Columns[4].Width = 170;

                dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplications.Columns[5].Width = 150;
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

        private void tsmiShowApplicationDetails_Click(object sender, EventArgs e)
        {
            // ****** make class/ form LocalDrivingLicesnseApplicationInfo

            /*
            
            frmLocalDrivingLicesnseApplicationInfo frm = 
                new frmLocalDrivingLicesnseApplicationInfo((int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.Show();
            
             */

        }

        private void tsmiDeleteApplication_Click(object sender, EventArgs e)
        {
                   ...
        }

    }

}
