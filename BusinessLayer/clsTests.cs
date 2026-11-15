using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class clsTests
    {
        public enum enMode { AddTest, UpdateTest };
        private enMode _Mode;
        public int TestID { set; get; }
        public int TestAppointmentID { set; get; }
        public bool TestResult { set; get; }

        public clsTestAppointments TestAppointment { set; get; }
        public string Notes { set; get; }

        public int CreatedByUserID { set; get;  }

        public clsTests()
        {
            TestAppointmentID = -1;
            TestID = -1;
            TestResult = false;
            Notes = "";
            CreatedByUserID = -1;
            _Mode = enMode.AddTest;

        }
        private clsTests(int TestID,int TestAppointmentID,bool TestResult,string Notes,int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.Notes = Notes;
            this.TestResult = TestResult;
            this.CreatedByUserID = CreatedByUserID;
            TestAppointment = clsTestAppointments.FindTestAppointment(TestAppointmentID);
            _Mode = enMode.UpdateTest;
        }

        public clsTests FindTestByTestID(int TestID)
        {
     
            int TestAppointment = -1;
            int CreatedByUserID = -1;
            string Notes = "";
            bool TestResult = false;
            if (clsDataAccessLayerForTests.FindTestByID(TestID,ref TestAppointment,ref CreatedByUserID,ref Notes,ref TestResult))
            {
               return new clsTests(TestID, TestAppointment, TestResult, Notes, CreatedByUserID);
            }
            
            return null;
            

         

        }
        public static bool IsPersonFailedInTest(int LDLAppID,int TestTypeID)
        {
            return (clsDataAccessLayerForTests.IsPersonFailedInTest(LDLAppID,TestTypeID));
        }
        public static int GetNumberOfPassedTests(int LDLAppID)
        {
            return clsDataAccessLayerForTests.GetNumberOfPassedTests(LDLAppID);
        }
        public static bool IsPersonPassedTest(int LDLAppID, int TestTypeID)
        {
            return (clsDataAccessLayerForTests.IsPersonPassedTest(LDLAppID, TestTypeID));
        }

        public static int GetNumberOfTrialToIntroduceTest(int LDLAppID,int TestTypeID)
        {
            return (clsDataAccessLayerForTests.GetNumberOfTrialToIntroduceTest(LDLAppID, TestTypeID));
        }
        private bool _AddNewTest()
        {
            int TestID = clsDataAccessLayerForTests.AddTest(TestAppointmentID, CreatedByUserID, Notes, TestResult);
            if(TestID!=-1)
            {
                this.TestID = TestID;
                return true;
            }
            return false;
        }
        public bool SaveTest()
        {
            switch (_Mode)
            {
                case enMode.AddTest:
                    {
                        if(_AddNewTest())
                        {
                            _Mode = enMode.UpdateTest;
                            return true;
                        }

                    }break;

            }
            return false;

        }
    }
}
