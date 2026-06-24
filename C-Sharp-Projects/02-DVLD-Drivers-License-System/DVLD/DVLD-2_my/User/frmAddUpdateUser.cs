using Business;
using System;
using System.Windows.Forms;


namespace DVLD_2_my
{
    public partial class frmAddUpdateUser : Form
    {

        public enum enMode { eAddNew = 0, eUpdate = 1 }
        private enMode _mode;

        private clsUser _user;
        private int _userID = -1;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _mode = enMode.eAddNew;
        }

        public frmAddUpdateUser(int userID)
        {
            InitializeComponent();
            _mode = enMode.eUpdate;
            _userID = userID;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_mode == enMode.eUpdate)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }

            if (personDetailsWithFilter_uc3.PersonID != -1)
            {
                if (clsUser.IsUserExistForPersonID(personDetailsWithFilter_uc3.PersonID))
                {
                    MessageBox.Show("Selected Person already has a user, choose another one.",
                        "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                    btnNext.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void ResetDefaultValue()
        {

            if (_mode == enMode.eAddNew)
            {
                _user = new clsUser();
                tpLoginInfo.Enabled = false;
                this.Text = "Add New User";
                lblAddEditUser.Text = "Add New User";
            }
            else
            {
                this.Text = "Edit User";
                lblAddEditUser.Text = "Edit User";
                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chbIsActive.Checked = true;
        }

        private void _LoadData()
        {
            _user = clsUser.FindByUserID(_userID);
            personDetailsWithFilter_uc3.DisableFilterPersonGroupBox = true;

            if (_user == null)
            {
                MessageBox.Show("No User with ID = " + _userID, "User Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblUserID.Text = _user.UserID.ToString();
            txtUserName.Text = _user.UserName;
            txtPassword.Text = _user.Password;
            txtConfirmPassword.Text = _user.Password;
            chbIsActive.Checked = _user.IsActive;

            personDetailsWithFilter_uc3.LoadPersonInfo(_user.PersonID);
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            ResetDefaultValue();

            if (_mode == enMode.eUpdate)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Username cannot be empty", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password cannot be empty", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_mode == enMode.eAddNew)
            {
                if (clsUser.IsUserExist(txtUserName.Text.Trim()))
                {
                    MessageBox.Show("Username already exists. Choose another one.",
                        "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _user.PersonID = personDetailsWithFilter_uc3.PersonID;
            _user.UserName = txtUserName.Text.Trim();
            _user.Password = txtPassword.Text;
            _user.IsActive = chbIsActive.Checked;

            if (_user.Save())
            {
                _mode = enMode.eUpdate;
                lblUserID.Text = _user.UserID.ToString();
                this.Text = "Update User";
                lblAddEditUser.Text = "Update User";

                MessageBox.Show("User Saved Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save user", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmAddUpdateUser_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password doesn't match!");
            }
            else
            {
                errorProvider1.Clear();
            }

        }

    }
}
