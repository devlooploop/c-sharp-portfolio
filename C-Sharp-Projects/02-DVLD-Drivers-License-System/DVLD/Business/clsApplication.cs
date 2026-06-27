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

    public class clsApplication
    {
        public enum enMode { AddNew =0, Update=1};
        public enMode mode = enMode.AddNew;

        public enum enApplicationType { NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3, 
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7 }

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        
        public int ApplicationTypeID { get; set; }
        public clsApplicationTypes applicationTypeInfo;

        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }

            }
        }

        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public string ApplicantFullName 
        { 
            get 
            {
                clsPerson person = clsPerson.Find(ApplicantPersonID);
                return (person != null ? person.FullName : ""); 
            } 
        }
        
        public clsUser createdByUserInfo;


        public clsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = 0;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            mode = enMode.AddNew;
        }

        private clsApplication(int applicationId, int applicantPersonId, DateTime applicationDate, 
            int applicationTypeId, enApplicationStatus applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserId)
        {
            this.ApplicationID = applicationId;
            this.ApplicantPersonID = applicantPersonId;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeId;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserId;

            this.applicationTypeInfo = clsApplicationTypes.FindApplicationByID(applicationId);
            this.createdByUserInfo = clsUser.FindByUserID(CreatedByUserID);
            mode = enMode.Update;
        }

        //public static DataTable GetAllApplicationsInfo()
        //{
        //       return clsApplicationData.GetAllApplicationsData();
        //}

        private bool AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplicationData(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID,
                                    (byte) this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return (this.ApplicationID != -1); 
        }

        private bool UpdateApplication()
        {
            return clsApplicationData.UpdateApplicationData(this.ApplicationID,this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID,
                                    (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public  bool DeleteApplication()
        {
           return  clsApplicationData.DeleteApplicationData(this.ApplicationID);
        }

        public static clsApplication FindBaseApplicationByID(int applicationId)
        {
            int applicantPersonId = -1; DateTime applicationDate = DateTime.Now; 
            int applicationTypeId = -1; byte applicationStatus = 1;
            DateTime lastStatusDate = DateTime.Now; float paidFees = 0; int createdByUserId = -1;

            bool isFound = clsApplicationData.GetApplicationByIdData(applicationId, ref applicantPersonId, ref applicationDate, ref applicationTypeId,
             ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserId);
            
            if (isFound)
                return new clsApplication(applicationId, applicantPersonId, applicationDate, applicationTypeId, 
                                           (enApplicationStatus)applicationStatus, lastStatusDate, paidFees, createdByUserId);
            else
                return null;
        }

        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    if(AddNewApplication())
                    {
                       mode = enMode.Update;
                       return true;
                    }
                    else
                    {
                        return false;
                    }
               
                case enMode.Update:
                    return UpdateApplication();

            }

            return false;
        }

        public static bool IsApplicationExist(int applicationId)
        {
             return clsApplicationData.IsApplicationExistData(applicationId);
        }

        public static bool DoesPersonHaveActiveApplication(int personId, int applicationTypeId)
        {
           return clsApplicationData.DoesPersonHaveActiveApplicationData(personId, applicationTypeId);
        }

        public bool DoesPersonHaveActiveApplication(int applicationTypeId)
        {
            return clsApplicationData.DoesPersonHaveActiveApplicationData(this.ApplicantPersonID, applicationTypeId);
        }

        public static int GetActiveApplicationID(int personId, clsApplication.enApplicationType applicationTypeId)
        {
           return clsApplicationData.GetActiveApplicationIdData(personId, (int) applicationTypeId);
        }

        public static int GetActiveApplicationIDForLicenseClass(int personId, clsApplication.enApplicationType applicationTypeId, int licenseClassId)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClassData(personId, (int)applicationTypeId, licenseClassId);
        }

        public int GetActiveApplicationID(clsApplication.enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationIdData(this.ApplicantPersonID,(int)ApplicationTypeID);
        }

        public bool Cancel()
        {

        }

        public bool SetComplete()
        {

        }


    }
}
