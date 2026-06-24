using Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace DVLD_2_my.User
{
    public partial class frmChangePassword : Form
    {
        private int _userID;
        private clsUser _user;

        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void ClearPasswordFields()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            //txtCurrentPassword.Focus();

        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ClearPasswordFields();

            _user = clsUser.FindByUserID(_userID);

            if (_user == null)
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Could not Find User with id = " + _userID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;

            }
            ctrUserCard1.LoadUserInfo(_userID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Please fix validation errors first.", "put the mouse over the red icon(s) to see the errors",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _user.Password = txtConfirmPassword.Text;

            bool isSaved = _user.Save();

            if (isSaved)
            {
                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                ClearPasswordFields();
            }
            else
            {
                MessageBox.Show("Failed to change password.", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }

        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password can not be blank.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }

            if (_user.Password != txtCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password is wrong!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Passwords confirmation does not match the New Password!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }

        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New Password cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }

}
