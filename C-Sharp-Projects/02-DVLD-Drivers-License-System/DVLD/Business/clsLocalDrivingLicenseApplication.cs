using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;


namespace Business
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enum enMode {AddNew =0,Update =1 };
        public enMode mode = enMode.AddNew;
        
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

        public clsLocalDrivingLicenseApplication(int localDrivingLicenseApplicationId, int applicationId, int licenseClassId)
        {
            this.LocalDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
            this.ApplicationId = applicationId;
            this.LicenseClassId = licenseClassId;

            ApplicationInfo = clsApplication.FindBaseApplicationByID(this.ApplicationId);
            LicenseClassInfo = clsLicenseClass.FindByID(this.LicenseClassId);
        }

        
        public static DataTable GetLocalDrivingLicenseApplicationInfo()
        {
            // int localDrivingLicenseApplicationId = -1; int applicationId = -1; int licenseClassId = -1;
            return  clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoData();
        }

        private bool AddNewApplication()
        {
            return clsLocalDrivingLicenseApplicationData.AddNewData();
        }

        private bool UpdateApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateApplicationData(this.ApplicationId);
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

    }

}
