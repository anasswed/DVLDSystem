using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{ 
    public class clsPeople
    {
        private enum enMode { UpdatePerson,AddNewPerson}
        private enMode _Mode;
        public int PersonID { set; get; }
        public string Nationalno { set; get; }

        public string FirstName { set; get; }

        public string SecondName{ set; get; }

        public string ThirdName { set; get; }

        public string LastName { set; get; }

        public DateTime DateOfBirth { set; get; }

        public  byte Gendor{ set; get; }

        public string Address { set; get; }

        public string Phone { set; get; }

        public string Email { set; get; }

        public int NationalityCountryID { set; get; }

        public string ImagePath { set; get; }

        public clsPeople()
        {
            Nationalno = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gendor = 3;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            ImagePath = "";
            PersonID = -1;
            _Mode = enMode.AddNewPerson;
        }

        private clsPeople(int personID,string nationalNo, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, byte gendor, string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            PersonID = personID;
            Nationalno = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gendor = gendor;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
            _Mode = enMode.UpdatePerson;
        }

        public static DataTable GetAllCountries()
        {
            return (clsDataAccessLayerForPeople.GetAllCountries());
        }
        public static DataTable GetAllPeople()
        {
            return (clsDataAccessLayerForPeople.GetAllPeople());
        }
        public static clsPeople FindPerson(int personID)
        {
            string firstName = "", secondName = "", thirdName = "", lastName = "", nationalNo = "", address = "", phone = "",
                email = "", imagePath = "";
            int nationalityCountryID = -1;
            byte gendor = 0;
            DateTime dateOfBirth = DateTime.Now;
            if(clsDataAccessLayerForPeople.FindPerson(personID,ref nationalNo,ref firstName,ref secondName,ref thirdName,ref lastName,ref dateOfBirth,ref gendor,ref address,ref phone,ref email,ref nationalityCountryID,ref imagePath))
            {
                return new clsPeople(personID ,nationalNo, firstName, secondName, thirdName, lastName, dateOfBirth, gendor, address, phone, email, nationalityCountryID, imagePath);
            }
            else
            {
                return null;
            }
        }

        public static clsPeople FindPersonByNationalNo(string nationalNo)
        {
            string firstName = "", secondName = "", thirdName = "", lastName = "",address = "", phone = "",
                email = "", imagePath = "";
            int nationalityCountryID = -1;
            int personID = -1;
            byte gendor = 0;
            DateTime dateOfBirth = DateTime.Now;
            if (clsDataAccessLayerForPeople.FindPersonByNationalNo(ref personID,nationalNo, ref firstName, ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref gendor, ref address, ref phone, ref email, ref nationalityCountryID, ref imagePath))
            {
                return new clsPeople(personID, nationalNo, firstName, secondName, thirdName, lastName, dateOfBirth, gendor, address, phone, email, nationalityCountryID, imagePath);
            }
            else
            {
                return null;
            }
        }

        public static bool IsNationalNumberExist(string NationalNo)
        {
            return (clsDataAccessLayerForPeople.IsNationalNoExist(NationalNo));
        }

        private bool _AddNewPerson()
        {

             int personID = clsDataAccessLayerForPeople.AddNewPerson(Nationalno, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);

            if(personID!=-1)
            {
                this.PersonID = personID;
                return true;
            }
            return false;

        }

        private bool _UpdatePersonInfo()
        {
            return (clsDataAccessLayerForPeople.UpdatePersonInfo(PersonID, Nationalno, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath));
        }
        public bool SavePerson()
        {
            switch (_Mode)
            {
                case enMode.AddNewPerson:
                    {
                        if(_AddNewPerson())
                        {
                            _Mode = enMode.UpdatePerson;
                            return true;
                        }

                    }break;
                case enMode.UpdatePerson:
                    {
                        if(_UpdatePersonInfo())
                        {
                            return true;
                        }
                        
                    }break;

            
            }

            return false;
        }

        public static bool IsPersonExist(int PersonID)
        {
            return (clsDataAccessLayerForPeople.IsPersonExist(PersonID));
        }

        public static bool DeletePerson(int PersonID)
        {
            return (clsDataAccessLayerForPeople.DeletePerson(PersonID));
        }

        public static string GetCountryName(int NationalityCountryID)
        {
            return (clsDataAccessLayerForPeople.GetCountryName(NationalityCountryID));
        }
        public string GetFullName()
        {
            return (FirstName + " " + SecondName + " " + ThirdName + " " + LastName);
        }

        public static int GetPersonIDByNationalNo(string NationalNo)
        {
            return (clsDataAccessLayerForPeople.GetPersonIDByNationalNo(NationalNo));
        }

    }
}
