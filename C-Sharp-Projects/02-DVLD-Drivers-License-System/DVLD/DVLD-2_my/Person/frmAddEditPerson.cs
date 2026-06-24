using Business;
using DVLD_2_my.Global_Classes;
using DVLD_2_my.Properties;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace DVLD_2_my
{
    public partial class frmAddEditPerson : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler OnDataBack;

        private enum enGender { Male = 0, Female = 1 };
        private enum _enMode { eAddNewRecord = 0, eEditRecord = 1 }

        private int _PersonID = -1;
        private clsPerson _Person;
        private _enMode _Mode;


        public frmAddEditPerson()
        {
            InitializeComponent();
            _Mode = _enMode.eAddNewRecord;
        }

        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _Mode = _enMode.eEditRecord;
            _PersonID = PersonID;
        }

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _ResetToDefaultValues()
        {

            _FillCountriesInComoboBox();

            if (_Mode == _enMode.eAddNewRecord)
            {
                lblAddEditPerson.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblAddEditPerson.Text = "Edit Person";
            }

            int index = cbCountry.FindString("Italy");
            if (index >= 0)
                cbCountry.SelectedIndex = index;

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            LLRemoveImage.Visible = (pbImage.ImageLocation != null);

            if (rbMale.Checked)
                pbImage.Image = Resources.Male_512;
            else
                pbImage.Image = Resources.Female_512;

            rbMale.Checked = true;
            pbImage.ImageLocation = null;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"Person with person id {_PersonID} not found!", "Person Not Found!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.LastName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);
            txtAddress.Text = _Person.Address;

            if (_Person.ImagePath != "")
                pbImage.ImageLocation = _Person.ImagePath;

            LLRemoveImage.Visible = (_Person.ImagePath != "");
            lblPersonID.Text = _Person.PersonID.ToString();

        }

        private void frmAddEditPerson_Load_1(object sender, EventArgs e)
        {
            _ResetToDefaultValues();

            if (_Mode == _enMode.eEditRecord)
                _LoadData();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Please correct the validation errors before saving!",
                                "Validation Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandleImage())
                return;

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Gender = (rbMale.Checked ? (short)enGender.Male : (short)enGender.Female);
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();

            int CountryIDPerson = clsCountry.Find(cbCountry.Text).CountryID;
            _Person.NationalityCountryID = CountryIDPerson;

            if (pbImage.ImageLocation != null)
                _Person.ImagePath = pbImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                lblAddEditPerson.Text = "Edit Person";
                _Mode = _enMode.eEditRecord;

                MessageBox.Show("Person Saved Successfully", "Data Saved!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                OnDataBack?.Invoke(this, _Person.PersonID);
            }
            else
            {
                MessageBox.Show("Person Record NOT Saved!");
            }

        }

        private bool _HandleImage()
        {
            if (_Person.ImagePath != pbImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // error msg in case deletion failed 
                    }
                }

                if (pbImage.ImageLocation != null)
                {

                    string sourceImageFile = pbImage.ImageLocation.ToString();

                    if (clsUtil.CopyFileToProjectFolder(ref sourceImageFile))
                    {
                        pbImage.ImageLocation = sourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error! Image not copied !!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private void LLRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;

            if (rbMale.Checked)
                pbImage.Image = Resources.Male_512;
            else
                pbImage.Image = Resources.Female_512;

            LLRemoveImage.Visible = false;
        }

        private void LLSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            openFileDialog1.Filter = "Image Files|*.png;*.jpeg;*.jpg;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string SelectedFilePath = openFileDialog1.FileName;
                pbImage.Load(SelectedFilePath);
                LLRemoveImage.Visible = true;
            }
        }

        private void ValidateEmptyTxtBox(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // set AutoValidate property of your Form to EnableAllowFocusChange in designer
            System.Windows.Forms.TextBox TxtBox = (System.Windows.Forms.TextBox)sender;

            if (string.IsNullOrEmpty(TxtBox.Text.Trim()))
            {

                if (!clsValidations.ValidateName(TxtBox.Text))
                {
                    e.Cancel = true;
                    errorProviderAddUpdatePerson.SetError(TxtBox, "The field can't be empty!");
                }
                else
                {
                    errorProviderAddUpdatePerson.SetError(TxtBox, string.Empty);
                }
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            if (!clsValidations.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProviderAddUpdatePerson.SetError(txtEmail, "Enter Valid Email Address!");
            }
            else
            {
                errorProviderAddUpdatePerson.SetError(txtEmail, null);
            }
        }

        private void txtNationalNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProviderAddUpdatePerson.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProviderAddUpdatePerson.SetError(txtNationalNo, null);
            }

            if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProviderAddUpdatePerson.SetError(txtNationalNo, "National Number is used for another person!");
            }
            else
            {
                errorProviderAddUpdatePerson.SetError(txtNationalNo, null);
            }

            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                e.Cancel = true;
                errorProviderAddUpdatePerson.SetError(txtAddress, "Address should not be empty!");
            }
            else
            {
                errorProviderAddUpdatePerson.SetError(txtAddress, null);
            }

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
                pbImage.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
                pbImage.Image = Resources.Female_512;
        }

    }

}

