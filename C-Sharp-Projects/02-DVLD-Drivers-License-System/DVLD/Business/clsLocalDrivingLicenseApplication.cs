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
        public enum enMode {AddNew = 0,Update = 1 };
        private enMode _mode = enMode.AddNew;
        
        public int LocalDrivingLicenseApplicationId {  get; set; }
       
        public int LicenseClassId {  get; set; }
    
        public clsLicenseClass LicenseClassInfo;

        public string PersonFullName
        {
            get 
            {
                    return base.PersonInfo.FullName;
                // return clsPerson.Find(ApplicantPersonID).FullName;
            }
        }

        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationId = -1;
            LicenseClassId = -1;

            _mode = enMode.AddNew;
        }

        public clsLocalDrivingLicenseApplication(int localDrivingLicenseApplicationId, int applicationId, int licenseClassId,
            int applicantPersonId, DateTime applicationDate, int applicationTypeId, enApplicationStatus applicationStatus, 
            DateTime lastStatusDate,float paidFees, int createdByUserId)

        {
            this.LocalDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
            this.ApplicationID = applicationId;
            this.ApplicantPersonID = applicantPersonId;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = (int)applicationTypeId;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserId;
            this.LicenseClassId = licenseClassId;
            
            this.LicenseClassInfo = clsLicenseClass.FindByID(licenseClassId);

            _mode = enMode.Update;
        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID(int localDrivingLicenseApplicationId)
        {
            int applicationId = -1; int licenseClassId = -1;
            int applicantPersonId = -1;
            DateTime applicationDate = DateTime.Now; int applicationTypeId = -1; enApplicationStatus applicationStatus = enApplicationStatus.New; DateTime lastStatusDate = DateTime.Now; 
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
            return clsLocalDrivingLicenseApplicationData.DeleteData();
        }

        public bool Cancel(int applicationId)
        {
            return (clsLocalDrivingLicenseApplicationData.UpdateApplicationStatus
                  (applicationId, (short)enApplicationStatus.Cancelled));
        }

        public static clsLocalDrivingLicenseApplication FindLocalApplication(int localDrivingLicenseAppId)
        {
            int applicationId = -1; int licenseClassId = -1; int applicantPersonId = -1;
            DateTime applicationDate = DateTime.Now; int applicationTypeId = -1; 
            enApplicationStatus applicationStatus = enApplicationStatus.New; 
            DateTime lastStatusDate = DateTime.Now; float paidFees = 0; int createdByUserId = -1;

            bool isFound =
                clsLocalDrivingLicenseApplicationData.
                GetLocalDrivingLicenseApplicationInfoByIdData(localDrivingLicenseAppId,ref applicationId,ref licenseClassId);
            
            if(isFound)
            {
               return new clsLocalDrivingLicenseApplication(localDrivingLicenseAppId, applicationId, licenseClassId, 
                      applicantPersonId, applicationDate, applicationTypeId, 
                      (byte)applicationStatus, lastStatusDate,paidFees, createdByUserId);
            }
            else
            {
                return null;
            }
                    
        }

        private bool UpdateApplication()
        {
            // Apply logic later ......

            return true;
        }

    }

}
