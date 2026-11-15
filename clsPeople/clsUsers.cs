using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer

{
    public class clsUsers
    {
       private enum enMode { UpdateUser, AddNewUser };
       private enMode _Mode;
        private clsPeople _Person;

        public clsPeople Person { set { _Person = value; } get { return _Person; } }
        public int UserID { set; get; }
        public int PersonID { set; get; }

        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }
        
        private clsUsers(string UserName,string Password,int UserID,int PersonID,bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Password = Password;
            this.UserName = UserName;
            this.IsActive = IsActive;
            _Person = clsPeople.FindPerson(this.PersonID);
            _Mode = enMode.UpdateUser;
        }

        public clsUsers()
        {
            
            _Mode = enMode.AddNewUser;
        }
        public static clsUsers FindUserByUserNameAndPassword(string UserName,string Password)
        {
            int PersonID = -1;
            int UserID = -1;
            bool IsActive = false;
            if (clsDataAccessLayerForUsers.FindUserByUserNameAndPassword(UserName, Password,ref UserID,ref PersonID,ref IsActive))
            {
                return new clsUsers(UserName, Password, UserID, PersonID, IsActive);
            }
            else
            {
                return null;
            }
            

        }

        public static clsUsers FindUser(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;
            if (clsDataAccessLayerForUsers.FindUser(ref UserName,ref Password, UserID, ref PersonID, ref IsActive))
            {
                return new clsUsers(UserName, Password, UserID, PersonID, IsActive);
            }
            else
            {
                return null;
            }


        }
        public static DataTable GetAllUsers()
        {
            return (clsDataAccessLayerForUsers.GetAllUsers());
        }
        
        public static bool IsPersonUser(int PersonID)
        {
            return (clsDataAccessLayerForUsers.IsPersonUser(PersonID));
        }
        private bool _AddNewUser()
        {
            int UserID = clsDataAccessLayerForUsers.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            this.UserID = UserID;

            if(UserID!=-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsUserExist(int UserID)
        {
            return (clsDataAccessLayerForUsers.IsUserExist(UserID));
        }

        private bool _UpdateUserInfo()
        {
            return (clsDataAccessLayerForUsers.UpdateUserInfo(this.UserName, this.Password, this.IsActive, this.UserID));
        }

        public static bool DeleteUser(int UserID)
        {
            return (clsDataAccessLayerForUsers.DeleteUser(UserID));
        }
        public bool SaveUser()
        {
            switch (_Mode)
            {
                case enMode.AddNewUser:
                    {
                        if(_AddNewUser())
                        {
                            _Mode = enMode.UpdateUser;
                            return true;
                        }
                    }break;
                case enMode.UpdateUser:
                    {
                        if(_UpdateUserInfo())
                        {
                            return true;
                        }
                    }break;
                  
            }
            return false;
        }
    }
}
