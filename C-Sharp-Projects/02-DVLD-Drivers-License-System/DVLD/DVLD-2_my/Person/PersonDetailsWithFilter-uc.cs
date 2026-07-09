using Business;
using System;
using System.Windows.Forms;


namespace DVLD_2_my
{
    public partial class PersonDetailsWithFilter_uc : UserControl
    {

        // Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;

        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        private int _personID = -1;

        public int PersonID
        {
            get { return personDetails_uc1.PersonID; }
        }

        private enum enUserFilter { eNationalNo = 0, ePersonID = 1 }
        enUserFilter filter;

        private bool _isGBFilterPersonEnabled = true;

        public bool DisableFilterPersonGroupBox
        {
            set { gbFilterPersonBy.Enabled = this._isGBFilterPersonEnabled; }
            get { return gbFilterPersonBy.Enabled = _isGBFilterPersonEnabled; }
        }

        public void FoucusTxtUc()
        {
            txtFilterPerson.Focus();
        }

        public PersonDetailsWithFilter_uc()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int personID)
        {
            txtFilterPerson.Text = personID.ToString();
            personDetails_uc1.LoadPersonInfo(personID);
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, " +
                    "put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtFilterPerson.Text))
            {
                MessageBox.Show("Please enter search value.", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbFilterPersonBy.SelectedIndex == (int)enUserFilter.eNationalNo)
            {
                personDetails_uc1.LoadPersonInfo(txtFilterPerson.Text);
            }
            else
            {
                int person_ID = -1;
                if (int.TryParse(txtFilterPerson.Text, out person_ID))
                {
                    if (clsPerson.IsPersonExists(person_ID))
                    {
                        personDetails_uc1.LoadPersonInfo(person_ID);
                    }
                    else
                    {
                        MessageBox.Show("Person not found");
                        personDetails_uc1.ResetPersonInfo();
                        _personID = -1;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Person ID");
                    return;
                }
            }

            // Update after loading
            _personID = personDetails_uc1.PersonID;

            if (_personID != -1)
            {
                personDetails_uc1.AllowLinkLabelEditPersonEnabled = true;
                PersonSelected(_personID);
            }

        }

        private void PersonDetailsWithFilter_uc_Load(object sender, EventArgs e)
        {
            cbFilterPersonBy.SelectedIndex = 0;
            personDetails_uc1.AllowLinkLabelEditPersonEnabled = true;
        }

        private void txtFilterPerson_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                btnFindPerson.PerformClick();
            }

            if (char.IsControl(e.KeyChar) && e.KeyChar != (char)13)
                return;

            filter = (enUserFilter)cbFilterPersonBy.SelectedIndex;
            switch (filter)
            {
                case enUserFilter.eNationalNo:
                    string futureText = txtFilterPerson.Text + e.KeyChar;
                    e.Handled = !clsValidations.ValidateNationalNo(futureText);
                    break;

                case enUserFilter.ePersonID:
                    e.Handled = !char.IsDigit(e.KeyChar);
                    break;
            }
        }

        private void cbFilterPersonBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterPerson.Clear();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.OnDataBack += ShowPersonInfo_OnDataBack;
            frm.ShowDialog();
        }

        private void ShowPersonInfo_OnDataBack(object sender, int personID)
        {
            LoadPersonInfo(personID);
        }


    }
}
