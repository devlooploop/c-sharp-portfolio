using Business;
using System;
using System.ComponentModel.Design;
using System.Windows.Forms;


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
            lbl_Applicant.Text = "[???]";
            lbl_Date.Text = "[???]";
            lbl_StatusDate.Text = "[???]";
            lbl_CreatedBy.Text = "[???]";
        }


        public void LoadApplicationInfo(int applicationId)
        {

            _application = clsApplication.FindBaseApplicationByID(applicationId);

            if (_application == null)
            {
                ResetCtrValues();
                return;
            }

            FillCtrlValues();

        }

        private void FillCtrlValues()
        {
            _applicationId = _application.ApplicationID;

            lbl_ID.Text = _application.ApplicationID.ToString();
            lbl_Status.Text = _application.StatusText;
            lbl_Fees.Text = _application.PaidFees.ToString("0.00");

            clsApplicationTypes applicationType =
                clsApplicationTypes.FindApplicationByID(_application.ApplicationTypeID);

            if (applicationType != null)
                lbl_Type.Text = applicationType.Title;

            lbl_Applicant.Text = _application.ApplicantFullName;

            lbl_Date.Text = _application.ApplicationDate.ToShortDateString();

            lbl_StatusDate.Text = _application.LastStatusDate.ToShortDateString();

            if (_application.createdByUserInfo != null)
                lbl_CreatedBy.Text = _application.createdByUserInfo.UserName;

        }

    }
}
