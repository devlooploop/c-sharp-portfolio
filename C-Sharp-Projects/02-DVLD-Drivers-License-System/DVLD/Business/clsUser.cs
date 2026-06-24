using DataAccess;
using System.Data;


namespace Business
{

    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }

        public int PersonID { get; set; }

        public clsPerson PersonInfo;

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public clsUser()
        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;

            Mode = enMode.AddNew;
        }

        private clsUser(int userID, string userName, int personID, string password, bool isActive)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
            this.PersonInfo = clsPerson.Find(personID);

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUserData(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUserData(this.UserID, this.PersonID, this.UserName, this.Password,
                this.IsActive);
        }

        public static clsUser FindByPersonID(int personID)
        {
            int userID = -1;
            string userName = "";
            string password = "";
            bool isActive = false;

            bool isFound = clsUserData.GetUserInfoByPersonID(personID, ref userName, ref userID, ref password, ref isActive);

            if (isFound)
                return new clsUser(personID, userName, userID, password, isActive);
            else
                return null;
        }

        public static clsUser FindByUserID(int userID)
        {
            int personID = -1;
            string userName = "", password = "";
            bool isActive = false;

            bool isFound = clsUserData.GetUserInfoByUserID(userID, ref userName, ref password, ref personID, ref isActive);

            if (isFound)
                return new clsUser(userID, userName, personID, password, isActive);
            else
                return null;
        }

        public static clsUser FindUserByNameAndPassword(string userName, string password)
        {
            int userID = -1;
            int personID = -1;
            bool isActive = false;

            if (clsUserData.GetUserInfoByUserNameAndPassword(userName, ref userID, ref personID, password,
                ref isActive))
                return new clsUser(userID, userName, personID, password, isActive);
            else
                return null;
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();

            }

            return false;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool isUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }

        public static bool IsUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        public static bool IsUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
        }


    }

}
