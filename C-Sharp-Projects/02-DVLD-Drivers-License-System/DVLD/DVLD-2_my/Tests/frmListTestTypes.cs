using Business;
using System;
using System.Data;
using System.Windows.Forms;


namespace DVLD_2_my.Tests
{
    public partial class frmListTestTypes : Form
    {
        private DataTable _dtAllTestTypes;

        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshData()
        {
            _dtAllTestTypes = clsTestType.GetAllTestInfo();
            dgvListTestTypes.DataSource = _dtAllTestTypes;
            lblRecordCount.Text = _dtAllTestTypes.Rows.Count.ToString();    

            dgvListTestTypes.Columns[0].HeaderText = "ID";
            dgvListTestTypes.Columns[0].Width = 120;

            dgvListTestTypes.Columns[1].HeaderText = "Title";
            dgvListTestTypes.Columns[1].Width = 200;

            dgvListTestTypes.Columns[2].HeaderText = "Description";
            dgvListTestTypes.Columns[2].Width = 400;

            dgvListTestTypes.Columns[3].HeaderText = "Fees";
            dgvListTestTypes.Columns[3].Width = 100;
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmUpdateTestType frm = new frmUpdateTestType((int)dgvListTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            // RefreshData();
            frmListTestTypes_Load(null, null);
        }
    }
}
