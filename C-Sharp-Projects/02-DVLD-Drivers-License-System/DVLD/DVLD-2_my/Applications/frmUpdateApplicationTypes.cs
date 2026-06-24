using Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace DVLD_2_my.Applications
{
    public partial class frmUpdateApplicationType : Form
    {

        private int _applicationID = -1;
        private clsApplicationTypes _applicationTypes;

        public frmUpdateApplicationType(int applicationID)
        {
            InitializeComponent();
            _applicationID = applicationID;
        }

        private void LoadApplicationInfo()
        {
            lbl_ID.Text = _applicationID.ToString();
            _applicationTypes = clsApplicationTypes.FindApplicationByID(_applicationID);

            if (_applicationTypes != null)
            {
                txtTitle.Text = _applicationTypes.Title;
                txtFees.Text = _applicationTypes.Fees.ToString();
            }

        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            LoadApplicationInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _applicationTypes.Title = txtTitle.Text.Trim();
            _applicationTypes.Fees = Convert.ToSingle(txtFees.Text.Trim());

            if (_applicationTypes.Save())
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }

        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees can not be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }

            if (!clsValidations.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }

        }
    }
}
