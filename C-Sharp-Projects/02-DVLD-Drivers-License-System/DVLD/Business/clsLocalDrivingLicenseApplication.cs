using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Business.clsApplication;
using static System.Net.Mime.MediaTypeNames;


namespace Business
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enum enMode {AddNew =0,Update =1 };
        private enMode _mode;
        
        public int LocalDrivingLicenseApplicationId {  get; set; }
       
        public int ApplicationId {  get; set; }
        public int LicenseClassId {  get; set; }

        public clsApplication  ApplicationInfo;
        public clsLicenseClass LicenseClassInfo;

        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationId = -1;
            ApplicationId = -1;
            LicenseClassId = -1;
        }

        public clsLocalDrivingLicenseApplication(int localDrivingLicenseApplicationId, int applicationId, int licenseClassId,
            int applicantPersonId, DateTime applicationDate, int applicationTypeId, byte applicationStatus, DateTime lastStatusDate, 
            float paidFees, int createdByUserId)
        {
            this.LocalDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
            this.ApplicationId = applicationId;
            this.LicenseClassId = licenseClassId;
            this.ApplicationInfo.ApplicantPersonID = applicantPersonId;
            this.ApplicationInfo.ApplicationDate = applicationDate;
            this.ApplicationInfo.ApplicationTypeID = applicationTypeId;
            this.ApplicationInfo.ApplicationStatus = (clsApplication.enApplicationStatus)applicationStatus;
            this.ApplicationInfo.LastStatusDate = lastStatusDate;
            this.ApplicationInfo.PaidFees = paidFees;
            this.ApplicationInfo.CreatedByUserID = createdByUserId;

        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID(int localDrivingLicenseApplicationId)
        {
            int applicationId = -1; int licenseClassId = -1;
            int applicantPersonId = -1;
            DateTime applicationDate = DateTime.Now; int applicationTypeId = -1; byte applicationStatus = 1; DateTime lastStatusDate = DateTime.Now; 
            float paidFees = 0; int createdByUserId = -1; 

            if (clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByIdData(localDrivingLicenseApplicationId, ref applicationId,
            ref licenseClassId))
            {
                return new clsLocalDrivingLicenseApplication(localDrivingLicenseApplicationId, applicationId, licenseClassId,applicantPersonId, 
                    applicationDate, applicationTypeId, applicationStatus, lastStatusDate,paidFees, createdByUserId);
            }
            else
            {
                return null; 
            }

        }

        public static DataTable GetLocalDrivingLicenseApplicationInfo()
        {
            return  clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoData();
        }

        private bool AddNewApplication()
        {
             this.LocalDrivingLicenseApplicationId = 
                clsLocalDrivingLicenseApplicationData.AddNewData(this.ApplicationID, this.LicenseClassId);
            
            return this.LocalDrivingLicenseApplicationId != -1;
        }

        private bool UpdateApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateApplicationData(this.ApplicationId);
        }

        public bool Save()
        {

            if(!base.Save())
                return !base.Save();

            base.mode = (clsApplication.enMode) _mode;

            switch (_mode)
            {
                case enMode.AddNew:
                    if(AddNewApplication())
                    {
                        _mode = enMode.Update;
                        return true;
                    }
                    else
                    { return false; }

                case enMode.Update:
                    return UpdateApplication();
            }

            return false;
        }
        
        public bool Delete()
        {
            return clsLocalDrivingLicenseApplicationData.DeleteData(this.ApplicationId);
        }

        public void Cancel()
        {
           clsLocalDrivingLicenseApplicationData.can

        }

    }

}
