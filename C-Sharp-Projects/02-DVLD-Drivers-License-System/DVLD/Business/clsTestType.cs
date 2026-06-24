using DataAccess;
using System.Data;


namespace Business
{
    public class clsTestType
    {
        private enum enMode { addNew = 0, update = 1 }
        private enMode _mode = enMode.addNew;

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public clsTestType.enTestType ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }

        public clsTestType()
        {
            this.ID = clsTestType.enTestType.VisionTest;
            this.Title = "";
            this.Description = "";
            this.Fees = 0;
            _mode = enMode.addNew;
        }

        public clsTestType(enTestType testID, string title, string description, float fees)
        {
            this.ID = testID;
            this.Title = title;
            this.Description = description;
            this.Fees = fees;

            _mode = enMode.update;
        }

        public static DataTable GetAllTestInfo()
        {
            return clsTestTypeData.GetAllTestTypeData();
        }

        public static clsTestType FindByID(enTestType testID)
        {
            string title = ""; string description = ""; float fees = 0;

            if (clsTestTypeData.GetTestTypeInfoID((int) testID, ref title, ref description, ref fees))
                
                return new clsTestType(testID, title, description, fees);
            else
                return null;
        }

        private bool UpdateTestType()
        {
            return clsTestTypeData.UpdateTestTypeData((int) this.ID, this.Title, this.Description, this.Fees);
        }

        private bool _AddNewTestType()
        {
            //call DataAccess Layer 

            this.ID = (clsTestType.enTestType)clsTestTypeData.AddNewTestType(this.Title, this.Description, this.Fees);

            return ((int)this.ID != -1);
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


