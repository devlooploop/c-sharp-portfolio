using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;



namespace DVLD_2_my.Applications.Controls
{

    public partial class ctrlApplicationBasicInfo : UserControl
    {

        private clsApplication _application;
        private int _applicationId = -1;

        public int ApplicationID 
        { 
            get { return _applicationId; } 
        }
       

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        private void ResetCtrValues()
        {
            lbl_ID.Text = "[???]";
            lbl_Status.Text = "[???]";
            lbl_Type.Text = "[???]";
            lbl_Applicant.Text = 
            lbl_Date.Text = "[???]";
            lbl_StatusDate.Text = "[???]";
            lbl_CreatedBy.Text = "[???]";
        }

        public void LoadApplicationInfo(int applicationId)
        {

            _application = clsApplication.FindBaseApplicationByID(_applicationId);

            if (_application == null)
            {
                ResetCtrValues();

                MessageBox.Show($"No Application found with Id = {_applicationId}");
                return;
            }

            lbl_ID.Text = _application.ApplicationID.ToString();
            lbl_Status.Text = _application.StatusText;
            lbl_Fees.Text = _application.PaidFees.ToString();
            lbl_Type.Text = _application.applicationTypeInfo.ToString(); // ??
            lbl_Applicant.Text = _application.ApplicantFullName;
            lbl_Date.Text = _application.ApplicationDate.ToShortDateString();
            lbl_StatusDate.Text = _application.LastStatusDate.ToString();
            lbl_CreatedBy.Text = _application.createdByUserInfo.ToString();

            fix the bugs later ..
        }

        
    }
}
