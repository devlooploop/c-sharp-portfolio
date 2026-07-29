using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{

    public class clsLicenseClass
    {
       enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementDamaged = 3, ReplacementLost = 4}


       public int LicenseClassId { get; set; }

       public string ClassName { get; set; }

       public string ClassDescription { get; set; }

       public byte MinimumAllowedAge { get; set; }

       public byte DefaultValidatyLength { get; set; }

       public float Fees { get; set; }


       public clsUser User;


       public clsLicenseClass() 
       {
            this.LicenseClassId = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 18;
            this.DefaultValidatyLength = 0;
            this.Fees = 0;
       }

       public clsLicenseClass(int licenseClassId, string className, string classDescription, byte minAllowedAge=18, byte defaultValidatyLength=0, float fees=0) 
       {
            this.LicenseClassId = licenseClassId;
            this.ClassName = className;
            this.ClassDescription = classDescription;
            this.MinimumAllowedAge = minAllowedAge;
            this.DefaultValidatyLength = defaultValidatyLength;
            this.Fees = fees;
       }

       public static DataTable GetAllLicenseClasses()
       {
           return clsLicenseClassData.GetAllLicenseClassesData();
       }

       public static clsLicenseClass FindByID(int licenseClassId)
       {
            string className = ""; string description = ""; 
            byte minAllowedAge = 18; byte defaultValidatyLength = 0; float fees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByIdData( licenseClassId, ref className, ref description,
                       ref minAllowedAge, ref defaultValidatyLength, ref fees))
            {
                return new clsLicenseClass(licenseClassId, className, description, minAllowedAge, defaultValidatyLength, fees);
            }
            else
            {
                return null;
            }

       }

       public static clsLicenseClass FindByName(string className)
       {
            int licenseClassId = -1; string classDescription = ""; byte minAllowedAge = 18; 
            byte defaultValidatyLength = 0; float fees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByNameData(ref licenseClassId, className, ref classDescription, ref minAllowedAge, ref defaultValidatyLength, ref fees))
            {
                return new clsLicenseClass(licenseClassId, className, classDescription, minAllowedAge, defaultValidatyLength, fees);
            }
            else
            {
                return null;
            }

       }

    }
}
