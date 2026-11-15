using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTestAppointments
    {
        private enum enMode { AddTestAppointment, UpdateTestAppointment };
        private enMode _Mode;
        public int TestAppointmentID { set; get; }

        public int TestTypeID { set; get; }

        public clsTestTypes TestType { set; get; }

        public int LocalDrivingLicenseID { set; get; }

        public clsLocalDrivingLicense LocalLicense { set; get; }

        public DateTime AppointmentDate { set; get; }

        public decimal PaidFess { set; get; }

        public clsUsers User { set; get; }
        public int CreatedByUserID { set; get; }

        public bool IsLocked { set; get; }

        public int RetakeTestApplicationID { set; get; }

        public clsTestAppointments()
        {
            _Mode = enMode.AddTestAppointment;
        }
        private clsTestAppointments(int testAppointmentID, int testTypeID, int localDrivingLicenseID, DateTime appointmentDate, decimal paidFess, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            TestType =clsTestTypes.FindTestTypeByID(TestTypeID);
            LocalDrivingLicenseID = localDrivingLicenseID;
            LocalLicense = clsLocalDrivingLicense.FindLocalDrivingLicenseApp(localDrivingLicenseID);
            AppointmentDate = appointmentDate;
            PaidFess = paidFess;
            User = clsUsers.FindUser(CreatedByUserID);
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;
            _Mode = enMode.UpdateTestAppointment;
        }

        public static clsTestAppointments FindTestAppointment(int TestAppointmentID)
        {
            int TestTypeID = -1;
            int LocalDrivingLicenseAppID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestAppID = -1;
            if (clsDataAccessLayerForTestAppointment.FindTestAppointment(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseAppID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestAppID))
            {
                return new clsTestAppointments(TestAppointmentID, TestTypeID, LocalDrivingLicenseAppID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestAppID);
            }
            else
            {
                return null;
            }

        }
        public static bool IsPersonHaveActiveTestAppointment(int LDLAppID,int TestTypeID)
        {
            return (clsDataAccessLayerForTestAppointment.IsPesronHaveActiveTestAppointment(LDLAppID,TestTypeID));
        }
       
        public static DataTable GetAppointmentsForPerson(int LDLAppID, int TestTypeID)
        {
            return (clsDataAccessLayerForTestAppointment.GetTestAppointmentsForPerson(LDLAppID,TestTypeID));
        }

        public static bool IsTestLocked(int TestAppointment)
        {
            return (clsDataAccessLayerForTestAppointment.IsTestLocked(TestAppointment));
        }
      
        private bool _AddTestAppointment()
        {
            int TestAppointmentID = clsDataAccessLayerForTestAppointment.AddTestAppointment(TestTypeID, LocalDrivingLicenseID, AppointmentDate, PaidFess, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            if(TestAppointmentID!=-1)
            {
                this.TestAppointmentID = TestAppointmentID;
                return true;
            }
                
                return false;
            
          
        }

      
        private bool _UpdateTestAppointment()
        {
            return (clsDataAccessLayerForTestAppointment.UpdateTestAppointment(TestAppointmentID, IsLocked, AppointmentDate));
        }
        public bool SaveTestAppointmet()
        {
            switch (_Mode)
            {
                case enMode.AddTestAppointment:
                    {
                        if(_AddTestAppointment())
                        {
                            
                            _Mode = enMode.UpdateTestAppointment;
                            return true;
                        }
                    }break;
                case enMode.UpdateTestAppointment:
                    {
                        if(_UpdateTestAppointment())
                        {
                            return true;
                        }

                    }break;
            
            }
            return false;
        }
    }
}
