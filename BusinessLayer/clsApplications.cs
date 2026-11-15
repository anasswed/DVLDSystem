using BusinessLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.clsApplications;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer
{
    public class clsApplications
    {
        public enum enMode { AddNewApplication, UpdateApplication }

        private enMode _Mode;

        public enum enApplicationStatus { 

            NewApplication=1,
            CancledApplication=2,
            CompletedApplication=3

        }

        public int ApplicationID { set; get; }

        public int ApplicantPersonID { set; get; }

        public DateTime ApplicationDate { set; get; }

        public int ApplicationTypeID { set; get; }

        public enApplicationStatus ApplicationStatus { set; get; }

        public DateTime LastStatusDate { set; get; }

        public decimal PaidFees { set; get; }

        public clsPeople Person { set; get; }

        public clsUsers User { set; get; }

        public clsApplicationType ApplicationType { set; get; }

        public int CreatedByUserID { set; get; }

        public clsApplications()
        {
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus =0;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            _Mode = enMode.AddNewApplication;
            
            
           
        }

        private clsApplications(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, int applicationStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus =(enApplicationStatus) applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            _Mode = enMode.UpdateApplication;
            Person = clsPeople.FindPerson(ApplicantPersonID);
            User = clsUsers.FindUser(CreatedByUserID);
            ApplicationType = clsApplicationType.FindApplicationTypeByID(applicationTypeID);

        }

        public static clsApplications FindApplicationByID(int ApplicationID)
        {
            int applicantPersonID = -1;
            DateTime applicationDate = DateTime.Now;
            int applicationTypeID = -1;
            int applicationStatus = -1;
            DateTime lastStatusDate = DateTime.Now;
            decimal paidFees =0;
            int createdByUserID = -1;


            if(clsDataAccessLayerForApplications.FindApplicationByID(ApplicationID, ref applicantPersonID, ref applicationDate, ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
            {
                return new clsApplications(ApplicationID, applicantPersonID, applicationDate, applicationTypeID, applicationStatus, lastStatusDate, paidFees, createdByUserID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewApplication()
        {
            int ApplicationID = clsDataAccessLayerForApplications.AddNewApplication(ApplicantPersonID ,ApplicationDate,ApplicationTypeID,(int)ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID);

            if(ApplicationID!=-1)
            {
                this.ApplicationID = ApplicationID;
                return true;
            }
            return false;
        }

       public bool UpdateApplicationStatus()
       {
            return (clsDataAccessLayerForApplications.UpdateApplicationStatus(ApplicationID, (int)ApplicationStatus));
       }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNewApplication:
                    {
                        if(_AddNewApplication())
                        {
                            _Mode = enMode.UpdateApplication;
                            return true;
                        }
                    }break;
                    
            }
            return false;
        }
        public static bool DeleteApplication(int ApplictionID)
        {
            return (clsDataAccessLayerForApplications.DeleteApplication(ApplictionID));
        }
        
        

    }
}
