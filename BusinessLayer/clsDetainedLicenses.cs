using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDetainedLicenses
    {
        private enum enMode { AddDetainLicense, UpdateDetainedLicense };

        private enMode _Mode;
        public int DetainID { set; get; }

        public int LicenseID { set; get; }

        public clsLicenses License { set; get; }

        public DateTime DetainDate { set; get; }

        public decimal FineFees { set; get; }

        public int CreatedByUserID { set; get; }

        public clsUsers User { set; get; }

       public bool IsReleased { set; get; }
       public DateTime ReleaseDate { set; get; }

        public int ReleaseByUserID { set; get; }

        public int ReleaseApplicationID { set; get; }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return (clsDataAccessLayerForDetainedLicenses.IsLicneseDetained(LicenseID));
        }

        public clsDetainedLicenses(int detainID, int licenseID, DateTime detainDate, decimal fineFees, int createdByUserID, bool isReleased, DateTime releaseDate, int releaseByUserID, int releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleaseByUserID = releaseByUserID;
            ReleaseApplicationID = releaseApplicationID;
            _Mode = enMode.UpdateDetainedLicense;
        }

        public clsDetainedLicenses (int DetainID,int LicenseID,int CreatedByUserID,bool IsReleased,DateTime DetainDate,decimal FineFees)
        {
            this.DetainID = DetainID;
            this.CreatedByUserID = CreatedByUserID;
            this.DetainDate = DetainDate;
            this.LicenseID = LicenseID;
            this.FineFees = FineFees;
            this.IsReleased = IsReleased;
            _Mode = enMode.UpdateDetainedLicense;
        }

        public clsDetainedLicenses()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = DateTime.Now;
            ReleaseByUserID = -1;
            ReleaseApplicationID = -1;
            _Mode = enMode.AddDetainLicense;
            
        }

        public static clsDetainedLicenses FindDetainedLicenseByLicenseID(int LicenseID)
        {
            int DetainID = -1;
            int CretaedByUserID = -1;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = 0;
            bool IsReleased = false;
            if(clsDataAccessLayerForDetainedLicenses.FindDetainedLicneseByLicenseID(LicenseID,ref DetainID,ref CretaedByUserID ,ref DetainDate,ref IsReleased,ref FineFees))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, CretaedByUserID,IsReleased, DetainDate, FineFees);
            }
            return null;
        }
        private bool _AddDetainedLicense()
        {
            int DetainID = clsDataAccessLayerForDetainedLicenses.AddDetainedLicense(LicenseID, IsReleased, CreatedByUserID, FineFees, DetainDate);
            if(DetainID!=-1)
            {
                this.DetainID = DetainID;
                return true;
            }
            return false;
        }

        public bool _UpdateDetainedLicense()
        {
            return (clsDataAccessLayerForDetainedLicenses.UpdateDetainedLicense(DetainID, IsReleased, ReleaseDate, ReleaseByUserID, ReleaseApplicationID));
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddDetainLicense:
                    {
                        if(_AddDetainedLicense())
                        {
                            _Mode = enMode.UpdateDetainedLicense;
                            return true;
                        }
                    }break;
                case enMode.UpdateDetainedLicense:
                    {
                        if(_UpdateDetainedLicense())
                        {
                            return true;
                        }
                    }break;
                    
            }
            return false;

        }

        public static DataTable GetListForAllDetainedLicenses()
        {
            return (clsDataAccessLayerForDetainedLicenses.GetListForAllDetainedLicenses());
        }
    }

}
