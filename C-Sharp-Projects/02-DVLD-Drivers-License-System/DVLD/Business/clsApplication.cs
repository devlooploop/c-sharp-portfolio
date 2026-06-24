using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Business.clsApplication;


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
        
        public clsUser createdByserInfo;


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

        private clsApplication(int applicationID, int applicantPersonID, DateTime applicationDate, 
            int applicationTypeID, enApplicationStatus applicationStatus, DateTime lastStatusDate, float paidFees, int createdByUserID)
        {
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersonID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;

            this.applicationTypeInfo = clsApplicationTypes.FindApplicationByID(applicationID);
            this.createdByserInfo = clsUser.FindByUserID(CreatedByUserID);
            mode = enMode.Update;
        }

        public static DataTable GetAllApplicationsInfo()
        {
               return clsApplicationData.GetAllApplicationsData();
        }

        private bool AddNewApplication()
        {
            int applicationID = -1; int applicantPersonID = -1; DateTime applicationDate = DateTime.Now; 
            int applicationTypeID = -1; enApplicationStatus applicationStatus = enApplicationStatus.New;
            DateTime lastStatusDate = DateTime.Now; float paidFees = 0; int createdByUserID = -1;

            this.ApplicationID = clsApplicationData.AddNewApplicationData();

            return applicationID != -1; ggg
        }

        public static int UpdateApplication()
        {


        }

        public static int DeleteApplication()
        {


        }

        public static clsApplication FindBaseApplicationByID()
        {


        }

        public void Save()
        {

        }




        
    }
}
