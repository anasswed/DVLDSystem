using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer
{
    public class clsLocalDrivingLicense
    {
        private enum enMode { AddNewLocalLicenseApp, UpdateLocalDrivingLicese}

        private enMode _Mode;
        public int LocalDrivingLicenseID { set; get; }

        public int ApplicationID { set; get; }

        public int LicenseClassID { set; get; }

        public clsLicenseClass LicenseClass { set; get; }

        public clsApplications Application { set; get; }
        public static DataTable GetAllDrivingLicenseApplication()
        {
            return (clsDataAccessLayerForLocalDrivingLicenseApp.GetAllLocalDrivingLicenseApplication());
        }
        public clsLocalDrivingLicense()
        {
            _Mode = enMode.AddNewLocalLicenseApp;
            Application = new clsApplications();
           
           

        }


        private clsLocalDrivingLicense(int ApplicationID,int LicenseClassID, int LocalDrivingLicenseAppID)
        {
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.LocalDrivingLicenseID = LocalDrivingLicenseAppID;
            Application = clsApplications.FindApplicationByID(ApplicationID);
            LicenseClass = clsLicenseClass.FindLicenseClassByID(LicenseClassID);
            _Mode = enMode.UpdateLocalDrivingLicese;
            
        }
        public static clsLocalDrivingLicense FindLocalDrivingLicenseApp(int LocalDrivingLicenseAppID)
        {
            int ApplicationID = -1, LicenseClassID = -1;
            if(clsDataAccessLayerForLocalDrivingLicenseApp.FindLocalDrivingLicenseAppByID(ref LicenseClassID,ref ApplicationID,LocalDrivingLicenseAppID))
            {
                return new clsLocalDrivingLicense(ApplicationID, LicenseClassID,LocalDrivingLicenseAppID);
                

            }
            else
            {
                return null;
            }
        }
        public int HasNewApplication()
        {
            return (clsDataAccessLayerForLocalDrivingLicenseApp.HasNewApplication(Application.ApplicantPersonID, LicenseClassID));
        }

        public bool HasCompletedApplication()
        {
            return (clsDataAccessLayerForLocalDrivingLicenseApp.HasCompletedApplication(Application.ApplicantPersonID, LicenseClassID));
        }
        private bool _AddNewLocalDrivingLicenseApp()
        {
            int LocalDrivingLicenseID = clsDataAccessLayerForLocalDrivingLicenseApp.AddNewLocalDrivingLicenseApp(ApplicationID, LicenseClassID);
            if(LocalDrivingLicenseID!=-1)
            {
                this.LocalDrivingLicenseID = LocalDrivingLicenseID;
                return true;
            }
            return false;

            
        }
        private bool _UpdateLocalDrivingLicense()
        {
            return (clsDataAccessLayerForLocalDrivingLicenseApp.UpdateLocalLicense(LocalDrivingLicenseID, LicenseClassID));
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNewLocalLicenseApp:
                    {
                        if(_AddNewLocalDrivingLicenseApp())
                        {
                            _Mode = enMode.UpdateLocalDrivingLicese;
                            return true;
                        }

                    }break;
                case enMode.UpdateLocalDrivingLicese:
                    {
                        if(_UpdateLocalDrivingLicense())
                        {
                            return true;
                        }
                    }break;
            }
            return false;

        }

        public static bool CancleApplication(int LDLAppID)
        {
            return (clsDataAccessLayerForLocalDrivingLicenseApp.CancleApplication(LDLAppID));
        }

        public static bool DeleteLocalDrivingLicenseApp(int LDLAppID)
        {
            return (clsDataAccessLayerForLocalDrivingLicenseApp.DeleteLocalDrivingLicenseApp(LDLAppID));
        
        }

       
        public static int GetApplicationID(int LDLAppID)
        {
            return (clsDataAccessLayerForLocalDrivingLicenseApp.GetApplicationID(LDLAppID));
        }
    }
}
