using Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace DVLD_2_my.Tests
{
    public partial class frmUpdateTestType : Form
    {
        private clsTestType.enTestType _testID = clsTestType.enTestType.VisionTest;
        clsTestType _testType;

        public frmUpdateTestType(clsTestType.enTestType testID)
        {
            InitializeComponent();
            _testID = testID;
        }

        private void LoadTestData()
        {
            lbl_ID.Text = ((int)_testID).ToString();
            txtTitle.Text = _testType.Title;
            txtDescription.Text = _testType.Description;
            txtFees.Text = _testType.Fees.ToString();
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _testType = clsTestType.FindByID( _testID);

            if (_testType != null)
            {
                LoadTestData();
            }
            else
            {
                MessageBox.Show("Could not find Test Type with id = " + _testID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren())
            {
                MessageBox.Show("Put the cursor on the blinking red to see the error!");
                return;
            }

            _testType.Title = txtTitle.Text;
            _testType.Description = txtDescription.Text;
            _testType.Fees = Convert.ToSingle(txtFees.Text);

            if(_testType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                errorProvider1.SetError(txtTitle, "");
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtDescription, "");
            }

        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");
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
