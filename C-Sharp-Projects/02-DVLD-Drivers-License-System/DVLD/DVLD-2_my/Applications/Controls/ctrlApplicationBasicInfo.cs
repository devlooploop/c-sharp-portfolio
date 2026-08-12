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



namespace DVLD_2_my.Applications.Controls
{

    public partial class ctrlApplicationBasicInfo : UserControl
    {

        private clsApplication _application;
        private int _applicationId;

        public int ApplicationID 
        { 
            get { return _applicationId; } 
        }
       

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public ctrlApplicationBasicInfo(int applicationId)
        {
            InitializeComponent();
            _applicationId = applicationId;
        }


        public void LoadApplicationInfo(int applicationId)
        {
            _application = clsApplication.FindBaseApplicationByID(applicationId);

            if (_application == null)
            {
                MessageBox.Show($"No Application found with Id = {applicationId}");
                return;
            }


            lbl_ID.Text = _application.ApplicationID.ToString();
            lbl_Status.Text = _application.StatusText.ToString();
            lbl_Fees.Text = _application.PaidFees.ToString();
            lbl_Type.Text = _application.applicationTypeInfo.ToString(); // ??
            lbl_Applicant.Text = _application.ApplicantFullName.ToString();
            lbl_Date.Text = _application.ApplicationDate.ToShortDateString();
            lbl_StatusDate.Text = _application.LastStatusDate.ToString();
            lbl_CreatedBy.Text = _application.createdByUserInfo.ToString();
            
        }

        private void ctrlApplicationBasicInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
