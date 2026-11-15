using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsInternationalLicenses
    {
        private enum enMode { AddInternationalLicense, UpdateInternationalLicense }

        private enMode _Mode;
        public int InternationalLicenseID { set; get; }

        public int ApplicationID { set; get; }

        public clsApplications Application { set; get; }

        public int DriverID { set; get; }

        public int IssuedUsingLocalLicenseID { set; get; }

        public clsLicenses License { set; get; }

        public DateTime IssueDate { set; get; }

        public DateTime ExpirationDate { set; get; }

        public bool IsActive { set; get; }

        public int CreatedByUserID { set; get; }

        public clsUsers User { set; get; }

        public clsInternationalLicenses()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Today;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            CreatedByUserID = -1;
            _Mode = enMode.AddInternationalLicense;
        }
        public clsInternationalLicenses(int InternationalLicenseID,int DriverID,int ApplicationID,int IssuedLocalLicenseID,DateTime IssueDate,DateTime ExpirationDate,bool IsActive,int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.IsActive = IsActive;
            this.IssuedUsingLocalLicenseID = IssuedLocalLicenseID;
            this.CreatedByUserID = CreatedByUserID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            _Mode = enMode.UpdateInternationalLicense;

        }


        public static DataTable ListAllInternationalLicenseForDriver(int DriverID)
        {
            return (clsDataAccessLayerForInternationalLicenses.ListAllInternationalLicense(DriverID));
        }
        public static int IsDriverHasInternationalLicnese(int DriverID)
        {
            return (clsDataAccessLayerForInternationalLicenses.IsDriverHasInternationalLicense(DriverID));
        }

        private bool _AddNewInternationalLicense()
        {
            int InternationlLicenseID = clsDataAccessLayerForInternationalLicenses.AddNewInternationalLicense(DriverID, ApplicationID, IssuedUsingLocalLicenseID, CreatedByUserID, IssueDate, ExpirationDate, IsActive);
            if(InternationlLicenseID!=-1)
            {
                this.InternationalLicenseID = InternationlLicenseID;
                return true;
            }
            return false;
        }

        public static clsInternationalLicenses FindInternationalLicenseByID(int InternationalLicenseID)
        {
        
            int DriverID = -1;
            int ApplicationID = -1;
            int IssuedLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;
            int CreatedByUserID = -1;
            if (clsDataAccessLayerForInternationalLicenses.FindInternationalLicenseByID(InternationalLicenseID, ref DriverID, ref ApplicationID, ref CreatedByUserID, ref IssueDate, ref ExpirationDate, ref IsActive, ref IssuedLocalLicenseID))
            {
                return new clsInternationalLicenses(InternationalLicenseID, DriverID, ApplicationID, IssuedLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID); 
            }
            return null;
        }

        public static DataTable GetListOfAllInternationalLicsesesApplications()
        {
            return (clsDataAccessLayerForInternationalLicenses.GetListOfInternationalLicensesApplications());
        }
       public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddInternationalLicense:
                    {
                        if(_AddNewInternationalLicense())
                        {
                            _Mode = enMode.AddInternationalLicense;
                            return true;
                        }
                    }break;
            }
            return false;
        }

    }
}
