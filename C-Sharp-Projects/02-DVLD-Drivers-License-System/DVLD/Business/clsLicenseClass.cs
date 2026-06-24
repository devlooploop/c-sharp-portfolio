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


       public int ID { get; private set; }

       public string CreatorName { get; set; }

       public string Description { get; set; }

       public byte MinimumAllowedAge { get; set; }

       public byte DefaultValidatyLength { get; set; }

       public float Fees { get; set; }


       public clsUser User;


       public clsLicenseClass() 
       {
            this.ID = -1;
            this.CreatorName = "";
            this.Description = "";
            this.MinimumAllowedAge = 18;
            this.DefaultValidatyLength = 0;
            this.Fees = 0;
       }

       public clsLicenseClass(int id, string creatorName, string description, byte minAllowedAge=18, byte defaultValidatyLength=0, float fees=0) 
       {
            this.ID = id;
            this.CreatorName = creatorName;
            this.Description = description;
            this.MinimumAllowedAge = minAllowedAge;
            this.DefaultValidatyLength = defaultValidatyLength;
            this.Fees = fees;
       }

       public static DataTable GetAllLicenseClasses()
       {
           return clsLicenseClassData.GetAllLicenseClassesData();
       }

       public static clsLicenseClass FindByID(int id)
       {
            string creatorName = ""; string description = ""; byte minAllowedAge = 18; byte defaultValidatyLength = 0; float fees = 0;

            if (clsLicenseClassData.FindByID(id))
            {
                return new clsLicenseClass(id, creatorName,  description,  minAllowedAge,  defaultValidatyLength, fees);
            }
            else
            {
                return null;
            }

       }



    }
}
