using DataAccess;
using System.Data;


namespace Business
{
    public class clsApplicationTypes
    {
        private enum enMode { addNew = 0, update = 1 }
        private enMode _mode = enMode.addNew;

        public int ID { get; set; }

        public string Title { get; set; }

        public float Fees { get; set; }

        public clsApplicationTypes()
        {
            this.ID = -1;
            this.Title = "";
            this.Fees = 0;
            _mode = enMode.addNew;
        }

        public clsApplicationTypes(int appID, string title, float fees)
        {
            this.ID = appID;
            this.Title = title;
            this.Fees = fees;
            _mode = enMode.update;
        }

        public static clsApplicationTypes FindApplicationByID(int appID)
        {
            string title = "";
            float fees = 0;

            if (clsApplicationTypesData.GetApplicationTypeByID((int)appID, ref title, ref fees))
                return new clsApplicationTypes(appID, title, fees);
            else
                return null;
        }

        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 
            this.ID = clsApplicationTypesData.AddNewApplicationType(this.Title, this.Fees);

            return (this.ID != -1);
        }

        public static DataTable GetApplicationTypeInfo()
        {
            return clsApplicationTypesData.GetAllApplicationTypeInfoData();
        }

        private bool _UpdateTestType()
        {
            return clsApplicationTypesData.UpdateTestTypeData(this.ID, this.Title, this.Fees);
        }

        public bool Save()
        {
            switch (_mode)
            {
                case enMode.addNew:
                    if (_AddNewApplicationType())
                    {
                        _mode = enMode.update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.update:
                    return _UpdateTestType();

            }

            return false;

        }

    }

}
