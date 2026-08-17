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

            lbl_ID.Text = "HELLO";
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


        //public void LoadApplicationInfo(int applicationId)
        //{

        //    MessageBox.Show($"Received Application ID = {applicationId}");

        //    _application = clsApplication.FindBaseApplicationByID(applicationId);

        //    if (_application == null)
        //    {
        //        ResetCtrValues();

        //        MessageBox.Show($"No Application found with Id = {applicationId}");
        //        return;
        //    }

        //    MessageBox.Show( $"Application found!\n" + $"ID = {_application.ApplicationID}\n" +
        //                        $"PersonID = {_application.ApplicantPersonID}\n" + $"TypeID = {_application.ApplicationTypeID}");

        //    FillCtrlValues();  

        //}

        public void LoadApplicationInfo(int applicationId)
        {
            MessageBox.Show("1 - LoadApplicationInfo started");

            _application = clsApplication.FindBaseApplicationByID(applicationId);

            if (_application == null)
            {
                ResetCtrValues();
                MessageBox.Show("2 - Application NULL");
                return;
            }

            MessageBox.Show("2 - Application found");

            FillCtrlValues();

            MessageBox.Show(
                $"3 - After FillCtrlValues\n" +
                $"ID = [{lbl_ID.Text}]\n" +
                $"Status = [{lbl_Status.Text}]\n" +
                $"Type = [{lbl_Type.Text}]"
            );
        }

        private void FillCtrlValues()
        {
            MessageBox.Show("Fill started");

            _applicationId = _application.ApplicationID;

            lbl_ID.Text = _application.ApplicationID.ToString();
            MessageBox.Show($"ID = {lbl_ID.Text}");

            lbl_Status.Text = _application.StatusText;
            MessageBox.Show($"Status = {lbl_Status.Text}");

            lbl_Fees.Text = _application.PaidFees.ToString("0.00");

            clsApplicationTypes applicationType =
                clsApplicationTypes.FindApplicationByID(
                    _application.ApplicationTypeID);

            if (applicationType != null)
                lbl_Type.Text = applicationType.Title;

            lbl_Applicant.Text = _application.ApplicantFullName;

            lbl_Date.Text =
                _application.ApplicationDate.ToShortDateString();

            lbl_StatusDate.Text =
                _application.LastStatusDate.ToShortDateString();

            if (_application.createdByUserInfo != null)
                lbl_CreatedBy.Text =
                    _application.createdByUserInfo.UserName;

            MessageBox.Show(
                $"Fill finished\n" +
                $"ID = [{lbl_ID.Text}]\n" +
                $"Status = [{lbl_Status.Text}]\n" +
                $"Type = [{lbl_Type.Text}]\n" +
                $"Applicant = [{lbl_Applicant.Text}]"
            );
        }

        //private void FillCtrlValues()
        //{
        //    MessageBox.Show("STEP 1 - Entered FillCtrlValues");

        //    _applicationId = _application.ApplicationID;

        //    lbl_ID.Text = _application.ApplicationID.ToString();

        //    MessageBox.Show($"STEP 2 - ID filled: {lbl_ID.Text}");

        //    lbl_Status.Text = _application.StatusText;

        //    MessageBox.Show($"STEP 3 - Status filled: {lbl_Status.Text}");

        //    lbl_Fees.Text = _application.PaidFees.ToString();

        //    MessageBox.Show($"STEP 4 - Fees filled: {lbl_Fees.Text}");

        //    var applicationType =
        //        clsApplicationTypes.FindApplicationByID(
        //            _application.ApplicationTypeID);

        //    MessageBox.Show(
        //        applicationType == null
        //            ? "STEP 5 - ApplicationType is NULL"
        //            : $"STEP 5 - ApplicationType found: {applicationType.Title}");

        //    if (applicationType != null)
        //        lbl_Type.Text = applicationType.Title;

        //    lbl_Applicant.Text = _application.ApplicantFullName;

        //    MessageBox.Show($"STEP 6 - Applicant: {lbl_Applicant.Text}");

        //    lbl_Date.Text = _application.ApplicationDate.ToShortDateString();

        //    MessageBox.Show($"STEP 7 - Date: {lbl_Date.Text}");

        //    lbl_StatusDate.Text = _application.LastStatusDate.ToShortDateString();

        //    MessageBox.Show($"STEP 8 - Status Date: {lbl_StatusDate.Text}");

        //    if (_application.createdByUserInfo != null)
        //    {
        //        lbl_CreatedBy.Text =
        //            _application.createdByUserInfo.UserName;
        //    }
        //    else
        //    {
        //        lbl_CreatedBy.Text = "[Unknown]";
        //    }

        //    MessageBox.Show("STEP 9 - FillCtrlValues finished");
        //}


        // **stop debugging the Business/DataAccess layer.The problem is now almost certainly the WinForms UI / Designer / wrong control instance.
    }
}
