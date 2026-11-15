using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BusinessLayer
{
    public class clsLicenses
    {

        private enum enLicenseMode { AddNewLicense, UpdateLicense };

        private enLicenseMode _Mode;

        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacmentForDamaged = 3, ReplacmentForLost = 4 };

        public int LicenseID { set; get; }

        public int ApplicationID { set; get; }

        public clsApplications Application { set; get; }

        public int DriverID { set; get; }

        public clsDrivers Driver { set; get; }

        public int LicenseClassID { set; get; }

        public clsLicenseClass LicenseClass { set; get; }

        public DateTime IssueDate { set; get; }

        public DateTime ExpirationDate { set; get; }

        public string Notes { set; get; }

        public decimal PaidFees { set; get; }

        public bool IsActive { set; get; }

        public enIssueReason IssueReason { set; get; }

        public int CreatedByUserID { set; get; }
        public clsUsers User { set; get; }

        public clsLicenses()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = false;
            IssueReason = enIssueReason.FirstTime;
            CreatedByUserID = -1;

            _Mode = enLicenseMode.AddNewLicense;
        }
        public clsLicenses(int LicenseID,int ApplicationID,int DriverID,int LicenseClassID,DateTime IssueDate,DateTime ExpirationDate,string Notes,decimal PaidFees,bool IsActive,int IssueReason,int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssueDate = IssueDate;
            this.IssueReason = (enIssueReason)IssueReason;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.IsActive = IsActive;
            this.PaidFees = PaidFees;
            this.LicenseClassID = LicenseClassID;
            this.CreatedByUserID = CreatedByUserID;
            _Mode = enLicenseMode.UpdateLicense;
        }
        public static clsLicenses FindLicenseByID(int LicenseID)
        {
       
           int ApplicationID = -1;
           int DriverID = -1;
           int LicenseClassID = -1;
           DateTime IssueDate = DateTime.Now;
           DateTime ExpirationDate = DateTime.Now;
           string  Notes = "";
           decimal PaidFees = 0;
           bool IsActive = false;
           int IssueReason = (int)enIssueReason.FirstTime;
           int  CreatedByUserID = -1;
            if (clsDataAccessLayerFoLicense.FindLicenseByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref IssueReason, ref Notes, ref IsActive, ref CreatedByUserID, ref PaidFees))
            {
                return (new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID));

            }
            else
            {
                return null; 
            }



        }

        private bool _AddNewLicense()
        {
            
            int LicenseID = clsDataAccessLayerFoLicense.AddNewLicense(ApplicationID, DriverID, LicenseClassID, CreatedByUserID, IssueDate, ExpirationDate, Notes, (int)IssueReason, IsActive, PaidFees);

            if (LicenseID != -1)
            {
                this.LicenseID = LicenseID;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static clsLicenses FindLicenseByApplicationID(int ApplicationID)
        {
            int LicenseID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = false;
            int IssueReason = (int)enIssueReason.FirstTime;
       
            int CreatedByUserID = -1;
            if(clsDataAccessLayerFoLicense.FindLicenseByApplicationID(ApplicationID, ref LicenseID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref IssueReason, ref Notes, ref IsActive, ref CreatedByUserID, ref PaidFees))
            {
                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public bool IssueLicense()
        {

            this.Driver = clsDrivers.FindDriverByPersonID(Application.ApplicantPersonID);
           
            if (Driver != null)
            {
                this.DriverID = Driver.DriverID;
                if (_AddNewLicense())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(Driver==null)
            {
                this.Driver = new clsDrivers();
                this.Driver.CreatedDate = DateTime.Now;
                this.Driver.CreatedByUserID = this.CreatedByUserID;
                this.Driver.PersonID = this.Application.ApplicantPersonID;
                if(this.Driver.AddNewDriver())
                {
                    this.DriverID = this.Driver.DriverID;
                    if(_AddNewLicense())
                    {
                        return true;
                    }
                    
                }
                else
                {
                    return false;
                }
            }
            return false;
           
        }

        public static DataTable ListAllLocalLicenseForDriver(int DriverID)
        {
            return (clsDataAccessLayerFoLicense.ListAllLocalLicense(DriverID));
        }
        public bool DeactivateLicense()
        {
            return (clsDataAccessLayerFoLicense.DeactivateLicense(LicenseID));
        }
        public bool RenewLicense()
        {
            
           if(_AddNewLicense())
            {
                
                return true;
            }
           else
            {
                return false;
            }
        }

        public bool ReplaceLicenseForDamagedOrLost()
        {
            if (_AddNewLicense())
            {
                return true;
            }
            else
                return false;
        }

        public static int GetLicenseIDByApplicationID(int ApplicationID)
        {
            return (clsDataAccessLayerFoLicense.GetLicenseIDByApplicationID(ApplicationID));
        }
    }
}
