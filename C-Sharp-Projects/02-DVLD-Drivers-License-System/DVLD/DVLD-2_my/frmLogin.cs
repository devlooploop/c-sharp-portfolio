using Business;
using System;
using System.Windows.Forms;


namespace DVLD_2_my
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            clsUser user = clsUser.FindUserByNameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());

            if (string.IsNullOrWhiteSpace(txtUsername.Text) && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username and password can not be empty!", "Wrong Credentials",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user != null)
            {
                if (!user.IsActive)
                {
                    MessageBox.Show("Your account is not active, contact your admin!", "Inactive Account",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (chkRememberMe.Checked)
                {
                    clsGlobal.RememberUserCredentials(txtUsername.Text, txtPassword.Text);
                }
                else
                {
                    clsGlobal.RememberUserCredentials("", "");
                }

                clsGlobal.currentUser = user;

                this.Hide();
                Form frm = new frmMainMenu(this);
                frm.ShowDialog();

            }
            else
            {
                txtUsername.Focus();
                MessageBox.Show("Invalid username/password!", "Wrong Credentials",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string userName = "", password = "";

            if (clsGlobal.GetUserStoredCredentials(ref userName, ref password))
            {
                txtUsername.Text = userName;
                txtPassword.Text = password;
                chkRememberMe.Checked = true;
            }
            else
            {
                chkRememberMe.Checked = false;
            }

        }
    }
}
