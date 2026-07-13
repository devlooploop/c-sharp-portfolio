using Business;
using System;
using System.Data;
using System.Windows.Forms;



namespace DVLD_2_my
{
    public partial class frmManagePeople : Form
    {
        private static DataTable _AllPeopleData = clsPerson.GetAllPeople();

        private DataTable _dtPeople = _AllPeopleData.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                        "FirstName", "SecondName", "ThirdName", "LastName",
                                                        "GenderCaption", "DateOfBirth", "CountryName",
                                                        "Phone", "Email");
        //----  
        private void _RefreshPeopleData()
        {
            _AllPeopleData = clsPerson.GetAllPeople();
            _dtPeople = _AllPeopleData.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                        "FirstName", "SecondName", "ThirdName", "LastName",
                                                        "GenderCaption", "DateOfBirth", "CountryName",
                                                        "Phone", "Email");

            dgvManagePeople.DataSource = _dtPeople;
            lblRecord.Text = dgvManagePeople.Rows.Count.ToString();
        }

        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditPerson();
            frm.ShowDialog();
            _RefreshPeopleData();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {

            dgvManagePeople.DataSource = _dtPeople;
            cbFilterBy.SelectedIndex = 0;
            lblRecord.Text = dgvManagePeople.Rows.Count.ToString();

            if (dgvManagePeople.Rows.Count > 0)
            {
                dgvManagePeople.Columns[0].HeaderText = "Person ID";
                dgvManagePeople.Columns[0].Width = 110;

                dgvManagePeople.Columns[1].HeaderText = "National No.";
                dgvManagePeople.Columns[1].Width = 120;

                dgvManagePeople.Columns[2].HeaderText = "First Name";
                dgvManagePeople.Columns[2].Width = 120;

                dgvManagePeople.Columns[3].HeaderText = "Second Name";
                dgvManagePeople.Columns[3].Width = 125;

                dgvManagePeople.Columns[4].HeaderText = "Third Name";
                dgvManagePeople.Columns[4].Width = 120;

                dgvManagePeople.Columns[5].HeaderText = "Last Name";
                dgvManagePeople.Columns[5].Width = 120;

                dgvManagePeople.Columns[6].HeaderText = "Gender";
                dgvManagePeople.Columns[6].Width = 120;

                dgvManagePeople.Columns[7].HeaderText = "Date Of Birth";
                dgvManagePeople.Columns[7].Width = 125;

                dgvManagePeople.Columns[8].HeaderText = "Nationality";
                dgvManagePeople.Columns[8].Width = 125;

                dgvManagePeople.Columns[9].HeaderText = "Phone";
                dgvManagePeople.Columns[9].Width = 125;

                dgvManagePeople.Columns[10].HeaderText = "Email";
                dgvManagePeople.Columns[10].Width = 125;

            }
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gender":
                    FilterColumn = "GenderCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (tbFilterBy.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecord.Text = dgvManagePeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbFilterBy.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbFilterBy.Text.Trim());

            lblRecord.Text = dgvManagePeople.Rows.Count.ToString();

        }

        private void cbFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            tbFilterBy.Visible = (cbFilterBy.Text != "None");

            if (tbFilterBy.Visible)
            {
                tbFilterBy.Text = "";
                tbFilterBy.Focus();
            }
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dgvManagePeople.CurrentRow.Cells[0].Value +
                "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                if (clsPerson.DeletePerson((int)dgvManagePeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person deleted successfully", "Person Record Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshPeopleData();
                }
                else
                {
                    MessageBox.Show("Due to data linked to Person, record deletion failed.", "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditPerson(clsPerson.Find((int)dgvManagePeople.CurrentRow.Cells[0].Value).PersonID);
            frm.ShowDialog();
            _RefreshPeopleData();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvManagePeople.CurrentRow.Cells[0].Value;
            Form frm = new frmPersonDetails(personID);
            frm.ShowDialog();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();
            _RefreshPeopleData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature not implemented yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature not implemented yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
