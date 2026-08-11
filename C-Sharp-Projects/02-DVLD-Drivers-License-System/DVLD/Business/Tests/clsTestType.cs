using DataAccess;
using System.Data;


namespace Business
{
    public class clsTestType
    {
        private enum enMode { addNew = 0, update = 1 }
        private enMode _mode = enMode.addNew;

        public enum enTestType { VisionTest = 1, WrittenTheoryTest = 2, StreetPracticalTest = 3 };

        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }

        public clsTestType()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;
            
            _mode = enMode.addNew;
        }

        public clsTestType(int testID, string title, string description, float fees)
        {
            this.TestTypeID = testID;
            this.TestTypeTitle = title;
            this.TestTypeDescription = description;
            this.TestTypeFees = fees;

            _mode = enMode.update;
        }

        public static DataTable GetAllTestInfo()
        {
            return clsTestTypeData.GetAllTestTypeData();
        }

        public static clsTestType FindByID(int testID)
        {
            string title = ""; string description = ""; float fees = 0;

            if (clsTestTypeData.GetTestTypeInfoID( testID, ref title, ref description, ref fees))
                
                return new clsTestType(testID, title, description, fees);
            else
                return null;
        }

        private bool UpdateTestType()
        {
            return clsTestTypeData.UpdateTestTypeData((int) this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, 
                this.TestTypeFees);
        }

        private bool _AddNewTestType()
        {
            //call DataAccess Layer 

            this.TestTypeID = clsTestTypeData.AddNewTestType(this.TestTypeTitle, 
                this.TestTypeDescription, this.TestTypeFees);

            return (this.TestTypeID != -1);
        }

        public bool Save()
        {
            switch(_mode)
            {
                case enMode.addNew:
                    if (_AddNewTestType())
                    {
                        _mode = enMode.update;
                        return true;
                    }
                    else
                    { 
                        return false; 
                    }

                case enMode.update:
                    return UpdateTestType();
            }

            return false;
        }

    }
}


