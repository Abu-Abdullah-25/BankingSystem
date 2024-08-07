using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BankingSystem_DataAccess;


namespace BankingSystem_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
        public int PersonID { set; get; }
        public clsPerson PersonInfo;
        public string UserName { set; get; }
        public string Password { set; get; }
        public int Permissions { set; get; }
        public bool IsActive { set; get; }


        public enum enPermissions
        {
            eAll = -1,
            pManagePeople = 1,
            pManageUsers = 2,
            pListClients = 4,
            pAddNewClient = 8,
            pUpdateClients = 16,
            pDeleteClient = 32,
            pChangePinCode = 64,
            pTranactions = 128,
            pShowtransferLog = 256,
            pShowLogInRegister = 512
        };

        public bool CheckAccessPermission(enPermissions Permission)
        {
            if (Permissions == (int)enPermissions.eAll)
                return true;

            if ((int)Permission == ((Permissions) & (int)Permission))
                return true;

            return false;
        }


        public clsUser()

        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.Permissions = 0;
            this.IsActive = true;
            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, int PersonID, string Username, string Password,
            int Permissions ,bool IsActive)

        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserName = Username;
            this.Password = Password;
            this.Permissions = Permissions;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            string encryptedPassword = clsPasswordHasher.ComputeHash(this.Password);
            //call DataAccess Layer 

            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName,
                encryptedPassword, this.Permissions, this.IsActive);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            string encryptedPassword = clsPasswordHasher.ComputeHash(this.Password);

            //call DataAccess Layer 

            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName,
                 encryptedPassword, this.Permissions, this.IsActive);
        }

        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = -1, Permissions = 0;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUserID
                                (UserID, ref PersonID, ref UserName, ref Password, ref Permissions,
                                ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, PersonID, UserName, Password, Permissions, IsActive);
            else
                return null;
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            //not Completed here
            int UserID = -1, Permissions = 0;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByPersonID
                                (PersonID, ref UserID, ref UserName, ref Password,ref Permissions,
                                ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, PersonID, UserName, Password, Permissions, IsActive);
            else
                return null;
        }

        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            string encryptedPassword = clsPasswordHasher.ComputeHash(Password);

            int UserID = -1;
            int PersonID = -1;
            int Persmissions = 0;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword
                                (UserName, encryptedPassword, ref UserID, ref PersonID, ref Persmissions, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, PersonID, UserName, Password,Persmissions, IsActive);
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

        public static bool isUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        public static bool isUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
        }


        public static DataTable GetLoginRegisterList()
        {
            return clsUserData.GetLoginRegisterList();
        }

        public void RegisterLogIn()
        {

            clsUserData.RegisterLogIn(DateTime.Now, this.UserID,this.Permissions);

        }


        
    }
}
