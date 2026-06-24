using Business;
using DVLD_2_my.User;
using System;
using System.Data;
using System.Windows.Forms;



namespace DVLD_2_my
{
    public partial class frmManageUsers : Form
    {

        private DataTable _UsersData;

        private enum enUserFilter { eNone, eUserID, eUserName, ePersonID, eFullName, eIsActive }

        private enum enIsActive { eAll = 0, eYes = 1, eNo = 2 }

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void cbFilterUser_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterUser.SelectedItem == null)
                return;

            enUserFilter SelectedFilter = (enUserFilter)cbFilterUser.SelectedIndex;

            txtFilterUser.Visible =
                (SelectedFilter != enUserFilter.eNone && SelectedFilter != enUserFilter.eIsActive);

            cbIsActive.Visible = (SelectedFilter == enUserFilter.eIsActive);

        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _UsersData = clsUser.GetAllUsers();
            _UsersData.CaseSensitive = false;
            dgvManageUsers.DataSource = _UsersData;

            lblRecord.Text = dgvManageUsers.Rows.Count.ToString();

            cbIsActive.SelectedIndex = 0;
            cbIsActive.Visible = false;
            cbFilterUser.SelectedIndex = 0;

            if (dgvManageUsers.Rows.Count > 0)
            {
                dgvManageUsers.Columns[0].HeaderText = "User ID";
                dgvManageUsers.Columns[0].Width = 110;

                dgvManageUsers.Columns[1].HeaderText = "Person ID";
                dgvManageUsers.Columns[1].Width = 120;

                dgvManageUsers.Columns[2].HeaderText = "Full Name";
                dgvManageUsers.Columns[2].Width = 350;

                dgvManageUsers.Columns[3].HeaderText = "UserName";
                dgvManageUsers.Columns[3].Width = 120;

                dgvManageUsers.Columns[4].HeaderText = "Is Active";
                dgvManageUsers.Columns[4].Width = 120;
            }

        }

        private void txtFilterUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            enUserFilter filter = (enUserFilter)cbFilterUser.SelectedIndex;

            if ((filter == enUserFilter.eUserID || filter == enUserFilter.ePersonID) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

            if (filter == enUserFilter.eFullName && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtFilterUser_TextChanged(object sender, EventArgs e)
        {

            enUserFilter Selected = (enUserFilter)cbFilterUser.SelectedIndex;

            if (string.IsNullOrEmpty(txtFilterUser.Text))
            {
                _UsersData.DefaultView.RowFilter = "";
                return;
            }

            switch (Selected)
            {
                case enUserFilter.eUserID:

                    bool isUserID = int.TryParse(txtFilterUser.Text, out int userID);
                    if (isUserID)
                        _UsersData.DefaultView.RowFilter = $"UserID = {userID}";
                    break;

                case enUserFilter.ePersonID:
                    bool isPersonID = int.TryParse(txtFilterUser.Text, out int personID);
                    if (isPersonID)
                        _UsersData.DefaultView.RowFilter = $"PersonID = {personID}";
                    break;

                case enUserFilter.eFullName:
                    _UsersData.DefaultView.RowFilter = $"FullName LIKE '%{txtFilterUser.Text}%'";
                    break;

                case enUserFilter.eUserName:
                    _UsersData.DefaultView.RowFilter = $"UserName LIKE '%{txtFilterUser.Text}%'";
                    break;

                default:
                    if (txtFilterUser.Text == "")
                    {
                        _UsersData.DefaultView.RowFilter = "";
                    }
                    break;
            }

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            enIsActive Selected = (enIsActive)cbIsActive.SelectedIndex;

            switch (Selected)
            {
                case enIsActive.eYes:
                    _UsersData.DefaultView.RowFilter = "IsActive = true";
                    break;
                case enIsActive.eNo:
                    _UsersData.DefaultView.RowFilter = "IsActive = false";
                    break;

                default:
                    _UsersData.DefaultView.RowFilter = "";
                    break;
            }

        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser();
            frm.ShowDialog();

            frmManageUsers_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUserInfo((int)dgvManageUsers.CurrentRow.Cells["UserID"].Value);
            frm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateUser();
            frm.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = (int)dgvManageUsers.CurrentRow.Cells["UserID"].Value;

            frmAddUpdateUser frm = new frmAddUpdateUser(userID);

            frm.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = (int)dgvManageUsers.CurrentRow.Cells["UserID"].Value;

            if (clsUser.DeleteUser(userID))
            {
                MessageBox.Show("User Deleted Successfully", "User Data Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmManageUsers_Load(null, null);
            }
            else
            {
                MessageBox.Show("User is not deleted due to data connected to it.", "Faild",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = (int)dgvManageUsers.CurrentRow.Cells["UserID"].Value;

            frmChangePassword frm = new frmChangePassword(userID);
            frm.Show();
        }

    }

}
