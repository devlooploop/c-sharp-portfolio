using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Business.Tests;

namespace DVLD_2_my.Tests
{
    public partial class frmVisionTestAppointment : Form
    {

        private int _testAppointmentId = -1;

        public frmVisionTestAppointment()
        {
            InitializeComponent();
        }

        public frmVisionTestAppointment(int testAppointmentId)
        {
            InitializeComponent();
            _testAppointmentId = testAppointmentId;
        }

        private void frmVisionTestAppointment_Load(object sender, EventArgs e)
        {
            // ctrDrivingLicenseApplicationInfo1.LoadDrivingLicenseApplicationInfo(_testAppointmentId);
            int DrivingLicenseApplicationID = clsTestAppointment.FindTestAppointmentByID(_testAppointmentId).LocalDrivingLicenseApplicationID;

            ctrDrivingLicenseApplicationInfo1.LoadDrivingLicenseApplicationInfo(DrivingLicenseApplicationID);

            
        }

        
    }
}
