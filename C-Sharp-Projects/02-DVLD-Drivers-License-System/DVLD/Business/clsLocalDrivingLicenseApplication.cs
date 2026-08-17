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
        public enMode mode = enMode.AddNew;
        
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

            mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplication(int localDrivingLicenseApplicationId, int applicationId, int licenseClassId,
            int applicantPersonId, DateTime applicationDate, int applicationTypeId, enApplicationStatus applicationStatus,
            DateTime lastStatusDate, float paidFees, int createdByUserId)
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

            mode = enMode.Update;
        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID(int localDrivingLicenseApplicationId)
        {
            int applicationId = -1; int licenseClassId = -1;

            bool isFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByIdData(localDrivingLicenseApplicationId, ref applicationId,
            ref licenseClassId);
            
            if (isFound)
            {
                // find base application first!

                clsApplication baseApplication = clsApplication.FindBaseApplicationByID(applicationId);

                return new clsLocalDrivingLicenseApplication(localDrivingLicenseApplicationId,baseApplication.ApplicationID, 
                    licenseClassId, baseApplication.ApplicantPersonID,
                   baseApplication.ApplicationDate, baseApplication.ApplicationTypeID, 
                   baseApplication.ApplicationStatus, baseApplication.LastStatusDate,
                   baseApplication.PaidFees, baseApplication.CreatedByUserID);
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

        private bool AddNewLocalDrivingLicenseApplication()
        {
             this.LocalDrivingLicenseApplicationId = 
                clsLocalDrivingLicenseApplicationData.AddNewData(this.ApplicationID, this.LicenseClassId);
            
            return this.LocalDrivingLicenseApplicationId != -1;
        }

        public bool Save()
        {
            base.mode = (clsApplication.enMode)mode;
            if (!base.Save())
                return false;

            switch (mode)
            {
                case enMode.AddNew:
                    if(AddNewLocalDrivingLicenseApplication())
                    {
                        mode = enMode.Update;
                        return true;
                    }
                    else
                    { return false; }
              
                case enMode.Update:
                    return UpdateLocalDrivingLicenseApplication();
            }

            return false;
        }
        
        public bool Delete()
        {
            return clsLocalDrivingLicenseApplicationData.DeleteData(LocalDrivingLicenseApplicationId);
        }

        public bool Cancel(int applicationId)
        {
            return (clsLocalDrivingLicenseApplicationData.UpdateApplicationStatus
                  (applicationId, (short)enApplicationStatus.Cancelled));
        }

        public static clsLocalDrivingLicenseApplication FindLocalApplicationById(int localDrivingLicenseAppId)
        {
            int applicationId = -1; int licenseClassId = -1; 

            bool isFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByIdData(localDrivingLicenseAppId,
                ref applicationId,ref licenseClassId);
            
            if(isFound)
            {               
                clsApplication application = clsApplication.FindBaseApplicationByID(applicationId); 

                    return new clsLocalDrivingLicenseApplication(localDrivingLicenseAppId, application.ApplicationID, licenseClassId,
                      application.ApplicantPersonID, application.ApplicationDate, application.ApplicationTypeID,
                        (enApplicationStatus)application.ApplicationStatus, application.LastStatusDate, application.PaidFees, application.CreatedByUserID);
            }
            else
            {
                return null;
            }
                    
        }

        private bool UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationId, 
                      this.ApplicationID, this.LicenseClassId);
             
        }

    }

}
