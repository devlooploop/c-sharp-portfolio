using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccess;


namespace Business
{

    public class clsLicense
    {
        public int License_ID { get; set; }

        public int Application_ID { get; set; }

        public int Driver_ID { get; set; }

        public byte LicenseClass { get; set; }
        
        public DateTime IssueDate { get; set; }
        
        public DateTime ExpirationDate { get; set; }
        
        public string Notes { get; set; }
        
        public float PaidFees { get; set; }
        
        public bool IsActive { get;set; }
        
        public byte IssueReason { get; set; }
        
        public int CreatedByUser_ID { get; set; }
        
        public clsUser user;


        private clsLicense(int license_Id, int application_Id, int driver_Id, byte licenseClass, DateTime issueDate, DateTime expirationDate, 
            string notes, float paidFees, bool isActive, byte issueReason, int createdByUserID)
        {
            this.License_ID = license_Id;
            this.Application_ID = application_Id; 
            this.Driver_ID = driver_Id; 
            this.LicenseClass = licenseClass; 
            this.IssueDate = issueDate; 
            this.ExpirationDate = expirationDate;
            this.Notes = notes;
            this.PaidFees = paidFees;
            this.IsActive = isActive;
            this.IssueReason = issueReason;
            this.CreatedByUser_ID = createdByUserID;
        
        }

        public static clsLicense FindUserCreatorByID(int id)
        {
            int application_Id = -1; int driver_Id = -1; byte licenseClass = 0; DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now; string notes = ""; float paidFees = 0; bool isActive = false;
            byte issueReason = 0; int createdByUserID = -1;

            if (clsLicenseData.FindUserCreatorByID_Data(id, ref application_Id, ref driver_Id, ref licenseClass, ref issueDate,
            ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReason, ref createdByUserID))
            {
                return new clsLicense(id , application_Id, driver_Id, licenseClass, issueDate, expirationDate, notes, 
                    paidFees, isActive, issueReason, createdByUserID);
            }
            else
            { 
                return null;
            }

        }

        public static bool IsLicenseExistByPersonID(int personId, int LicesensClassTypeId)
        {
            return clsLicenseData.IsLicenseExistByPersonIdData(personId, LicesensClassTypeId);
        }


    }
}
