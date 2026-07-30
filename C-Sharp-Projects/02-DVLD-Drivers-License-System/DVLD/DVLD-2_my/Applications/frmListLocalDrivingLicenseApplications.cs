using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_2_my.Applications
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
       private DataTable _AllApplicationsInfo;
       private clsLocalDrivingLicenseApplication _listLocalDrivingLicenseApplications;


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
        }

        private string  GetColumnName(string filter)
        {
            
            string columnName = "";

            switch (filter)
            {

                case "L.D.LAppID":
                    columnName = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    columnName = "NationalNo";
                    break;

                case "Full Name":
                    columnName = "FullName";
                    break;

                case "Status":
                    columnName = "Status";
                    break;

                    fix the rest.....

                default:
                    return "";
            }
            
            return columnName;
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            // RefreshLocalDrivingLicenseApplications();
            string column = GetColumnName(cbFilterBy.Text);

            if (string.IsNullOrEmpty(column) || string.IsNullOrEmpty(txtFilterValue.Text))
                return;

            if (column == "LocalDrivingLicenseApplicationID" && 
                clsValidations.ValidatePersonID(txtFilterValue.Text)
                && int.TryParse(txtFilterValue.Text, out int AppId))
            {
                _AllApplicationsInfo.DefaultView.RowFilter = $"{column} = {AppId}";
            }

            else if (column == "NationalNo" && clsValidations.ValidateNationalNo(txtFilterValue.Text))
            {
                _AllApplicationsInfo.DefaultView.RowFilter = $"{column} = '{txtFilterValue.Text}'";
            }

            else if (column == "FullName" && clsValidations.ValidateName(txtFilterValue.Text))
            {
                _AllApplicationsInfo.DefaultView.RowFilter = $"{column} LIKE '{txtFilterValue.Text}%'";
            }

            else if (column == "Status")
            {
                _AllApplicationsInfo.DefaultView.RowFilter = $"{column} LIKE '{txtFilterValue.Text}%'";
            }


        }
    }
}
