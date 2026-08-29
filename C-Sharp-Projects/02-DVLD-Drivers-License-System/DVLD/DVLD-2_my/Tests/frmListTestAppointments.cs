
using System;
using System.Data;
using DVLD_2_my.Properties;
using System.Windows.Forms;
using Business.Tests;
using Business;


namespace DVLD_2_my.Tests
{
    public partial class frmListTestAppointments : Form
    {

        private int _localDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _testType;

        private DataTable _dtTestAppointments;

        public frmListTestAppointments()
        {
            InitializeComponent();
        }

        public frmListTestAppointments(int localDrivingLicenseApplicationID, clsTestType.enTestType testType)
        {
            InitializeComponent();

            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            _testType = testType;
        }

        private void RefreshListTestAppointmentsInfo()
        {
            _dtTestAppointments = clsTestAppointment.GetTestAppointmentsInfo();
        }

        private void _LoadTestTypeImageAndTitle(clsTestType.enTestType testType)
        {
            frmListTestAppointments frm = new frmListTestAppointments();
            
            switch (testType)
            {
                case clsTestType.enTestType.VisionTest:
                    frm.Text = "Vision Test";
                    frm.lbl_Title_frmListTestAppointments.Text = "Vision Test Appointments";
                    frm.pbListTestAppointments.Image = Resources.Vision_512;
                    break;

                case clsTestType.enTestType.WrittenTheoryTest:
                    frm.Text = "Written Theory Test";
                    frm.lbl_Title_frmListTestAppointments.Text = "Written Theory Test Appointments";
                    frm.pbListTestAppointments.Image = Resources.Written_Test_512;
                    break;
                case clsTestType.enTestType.StreetPracticalTest:
                    frm.Text = "Practical Street Test";
                    frm.lbl_Title_frmListTestAppointments.Text = "Practical Street Appointments";
                    frm.pbListTestAppointments.Image = Resources.Street_Test_32;
                    break;

                default:
                    frm.Text = "List Test Appointment";
                    frm.pbListTestAppointments.Image = Resources.Vision_512;
                    break;
            
            }

        }


        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            
            // RefreshListTestAppointmentsInfo();

            ctrDrivingLicenseApplicationInfo1.LoadDrivingLicenseApplicationInfoByID(_localDrivingLicenseApplicationID);
            
            _dtTestAppointments = clsTestAppointment.GetTestAppointmentsInfo();

           // dgvLicenseTestAppointments.DataSource = _dtTestAppointments.DefaultView;
            dgvLicenseTestAppointments.DataSource = _dtTestAppointments;

            if (dgvLicenseTestAppointments.RowCount > 0)
            {
                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[0].Width = 110;

                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[1].Width = 110;

                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[2].Width = 110;

                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
                dgvLicenseTestAppointments.Columns[3].Width = 110;

                dgvLicenseTestAppointments.Columns["LocalDrivingLicenseApplicationID"].Visible = false;
                dgvLicenseTestAppointments.Columns["TestTypeTitle"].Visible = false;
                dgvLicenseTestAppointments.Columns["ClassName"].Visible = false;
                dgvLicenseTestAppointments.Columns["FullName"].Visible = false;

            }

            lbl_RecordCount.Text = dgvLicenseTestAppointments.RowCount.ToString();

            //_LoadTestTypeImageAndTitle(_testType);

            //frmListTestAppointments frm = new frmListTestAppointments(_localDrivingLicenseApplicationID, clsTestType.enTestType.VisionTest);
            here

        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
           
             frmScheduleTest frm = new frmScheduleTest(_localDrivingLicenseApplicationID, _testType);
           
           clsLocalDrivingLicenseApplication _localDrivingLicenseApplication = 
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_localDrivingLicenseApplicationID);

            if (_localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_testType))
            {
                MessageBox.Show("This person already has an active appointment for this test." +
                                    " You cannot add a new appointment!", "Active Appointment",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            frm.ShowDialog();

        }



    }
}
