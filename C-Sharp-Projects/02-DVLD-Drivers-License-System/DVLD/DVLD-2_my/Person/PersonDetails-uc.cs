using Business;
using DVLD_2_my.Properties;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace DVLD_2_my
{

    public partial class PersonDetails_uc : UserControl
    {
        private clsPerson _person;
        private int _personID = -1;

        public int PersonID
        {
            get { return _personID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _person; }
        }

        public bool AllowLinkLabelEditPersonEnabled
        {
            get { return LinkLabelEditPerson.Enabled; }
            set { LinkLabelEditPerson.Enabled = value; }
        }

        public PersonDetails_uc()
        {
            InitializeComponent();
        }

        private void editPersonLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form frm = new frmAddEditPerson(_personID);
            frm.ShowDialog();

            //refresh after edit/update
            LoadPersonInfo(_personID);

        }

        private Image IsImageMan(bool IsMan = true)
        {
            if (IsMan)
                return pbGender.Image = Resources.Man_32;
            else
                return pbGender.Image = Resources.Woman_32;
        }

        private void _FillPersonInfo()
        {
            LinkLabelEditPerson.Enabled = true;
            _personID = _person.PersonID;

            lblPersonID.Text = _person.PersonID.ToString();
            lblNationalNo.Text = _person.NationalNo;
            lblFullName.Text = _person.FullName;
            lblGender.Text = (_person.Gender == 0) ? "Male" : "Female";
            pbGender.Image = (_person.Gender == 0) ? IsImageMan(true) : IsImageMan(false);
            lblEmail.Text = _person.Email;
            lblPhone1.Text = _person.Phone;
            lblAddress.Text = _person.Address;
            lblDateOfBirth.Text = _person.DateOfBirthFormatted;
            lblCountry.Text = clsCountry.Find(_person.NationalityCountryID).CountryName;

            _LoadPersonImage();
        }

        private void _LoadPersonImage()
        {
            if (_person.Gender == 0)
                pbEditPersonInfo.Image = Resources.Male_512;
            else
                pbEditPersonInfo.Image = Resources.Female_512;

            string imagePath = _person.ImagePath;
            if (imagePath != "")
            {
                if (File.Exists(imagePath))
                    pbEditPersonInfo.ImageLocation = imagePath;
                else
                    MessageBox.Show("Could not find this image: = " + imagePath,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void ResetPersonInfo()
        {
            _personID = -1;
            lblPersonID.Text = "???";
            lblFullName.Text = "???";
            lblNationalNo.Text = "???";
            lblGender.Text = "???";
            pbGender.Image = Resources.Man_32;
            lblEmail.Text = "???";
            lblAddress.Text = "???";
            lblDateOfBirth.Text = "???";
            lblPhone1.Text = "???";
            lblCountry.Text = "???";
            pbEditPersonInfo.Image = Resources.Male_512;

        }

        public void LoadPersonInfo(int personID)
        {
            _person = clsPerson.Find(personID);

            if (_person == null)
            {
                MessageBox.Show($"No Person with id [{personID}] found", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                ResetPersonInfo();
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string nationalID)
        {
            _person = clsPerson.Find(nationalID);

            if (_person == null)
            {
                ResetPersonInfo();

                MessageBox.Show($"Person with Nationl ID [{nationalID}] not found", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

    }
}