using DataAccess;
using System;
using System.Data;

namespace Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string NationalNo { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }

        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }

        public DateTime DateOfBirth { set; get; }

        public string DateOfBirthFormatted
        {
            get { return DateOfBirth.ToString("dd.MM.yyyy"); }
        }

        public short Gender { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }

        public clsCountry CountryInfo;

        private string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = -1;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.CountryInfo = null;
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
            DateTime DateOfBirth, short Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = clsPersonDataAccess.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName,
            this.LastName, this.NationalNo, this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);

        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPersonDataAccess.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
               this.LastName, this.Gender, this.Address, this.DateOfBirth, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "",
              Phone = "", Email = "", ImagePath = ""; DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            short Gender = 0;

            bool IsFound = clsPersonDataAccess.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName, ref SecondName,
                 ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,
                 ref NationalityCountryID, ref ImagePath);

            if (IsFound)
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                           DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "",
              Phone = "", Email = "", ImagePath = ""; DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1, PersonID = -1;
            short Gender = 0;

            bool IsFound = clsPersonDataAccess.GetPersonInfoByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName,
                ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,
                ref NationalityCountryID, ref ImagePath);

            if (IsFound)
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                    DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);

            else
                return null;

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();
            }

            return false;
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonDataAccess.DeletePerson(PersonID);
        }

        public static bool IsPersonExist(string NationlNo)
        {
            return clsPersonDataAccess.IsPersonExist(NationlNo);
        }

        public static bool IsPersonExists(int PersonID)
        {
            return clsPersonDataAccess.IsPersonExist(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonDataAccess.GetAllPeople();
        }
    }

}
