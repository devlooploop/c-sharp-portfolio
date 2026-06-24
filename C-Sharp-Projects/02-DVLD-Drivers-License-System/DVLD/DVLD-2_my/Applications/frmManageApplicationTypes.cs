using Business;
using System;
using System.Data;
using System.Windows.Forms;


namespace DVLD_2_my.Applications
{
    public partial class frmManageApplicationTypes : Form
    {

        private DataTable _dtAllApplicationTypes;

        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            _dtAllApplicationTypes = clsApplicationTypes.GetApplicationTypeInfo();
            dgvApplicationTypes.DataSource = _dtAllApplicationTypes;
            lblRecordCount.Text = dgvApplicationTypes.Rows.Count.ToString();

            if (_dtAllApplicationTypes == null)
            {
                MessageBox.Show("Data source is null!");
                return;
            }

            if (dgvApplicationTypes.Columns.Count > 0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[0].Width = 80;

                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[1].Width = 260;

                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvApplicationTypes.Columns[2].Width = 100;
            }

        }


        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            RefreshData();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvApplicationTypes.CurrentRow != null)
            {
                
                frmUpdateApplicationType frm = new frmUpdateApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
                frm.ShowDialog();

                 RefreshData();
              // frmManageApplicationTypes_Load(null,null);
            }
            else
            {
                MessageBox.Show("Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

    }
}
