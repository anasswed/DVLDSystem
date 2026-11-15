using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class ctrlSceduleTest : UserControl
    {
        public bool IsFailed { set; get; }

        public enum enMode { AddAppointment, UpdateAppointment };

        public enMode _Mode { set; get; }
        public ctrlSceduleTest()
        {
            InitializeComponent();
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void ChangeGroupBoxName(string TestTypeName)
        {
            gbTestInfo.Text = TestTypeName;
        }
        public void LoadRetakeTestAppID(clsApplications RetakeTestApplication)
        {
            lblRetakeTestAppIDResult.Text = RetakeTestApplication.ApplicationID.ToString();
        }
        

        public void EnableRetakeTest()
        {
            gbRetakeTestInfo.Enabled = true;
            lblScheduleTestOrRetakeTest.Text = "Schedule Retake Test";
        }
        public clsTestAppointments GetDataOfTestAppointment(clsTestTypes TestType,clsLocalDrivingLicense LocalLicense)
        {
            clsTestAppointments TestAppointment = new clsTestAppointments();
            TestAppointment.User = clsCurrentUser.CurrentUser;
            TestAppointment.PaidFess =Convert.ToDecimal(lblRetakeAppFeesResult.Text) +Convert.ToDecimal(lblFeesResult.Text);
            TestAppointment.LocalDrivingLicenseID = LocalLicense.LocalDrivingLicenseID;
            TestAppointment.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            if (IsFailed)
            {
                TestAppointment.RetakeTestApplicationID = Convert.ToInt32(lblRetakeTestAppIDResult.Text);
            }
            TestAppointment.LocalLicense = LocalLicense;
            TestAppointment.TestType = TestType;
            TestAppointment.TestTypeID = TestType.TestTypeID;
            TestAppointment.AppointmentDate = dateTimePicker1.Value;
         
            TestAppointment.IsLocked = false;
          
            return TestAppointment;
           
        }
        public void _LoadDataOnControls(clsTestAppointments testAppointments,clsLocalDrivingLicense LocalLicense,clsTestTypes TestType,clsApplications RetakeTestApp)
        {
            lblLDLAppIDResult.Text = LocalLicense.LocalDrivingLicenseID.ToString();
            lblFeesResult.Text = TestType.Fees.ToString();
            lblLicenseClassNameResult.Text = LocalLicense.LicenseClass.ClassName.ToString();
            lblNameResult.Text = LocalLicense.Application.Person.GetFullName();
            lblTrialResult.Text =clsTests.GetNumberOfTrialToIntroduceTest(LocalLicense.LocalDrivingLicenseID,TestType.TestTypeID).ToString();
            if (_Mode == enMode.AddAppointment)
            {
                dateTimePicker1.Value = DateTime.Now;
            }
            else
            {
                dateTimePicker1.Value = testAppointments.AppointmentDate;
            }
    
            if(IsFailed)
            {
                lblRetakeTestAppIDResult.Text = RetakeTestApp.ApplicationID.ToString();
                lblRetakeAppFeesResult.Text = "5";
            }
            else
            {
                lblRetakeAppFeesResult.Text = "0";
            }
            lblTotalFeesResult.Text = (Convert.ToDecimal(lblFeesResult.Text) + Convert.ToDecimal(lblRetakeAppFeesResult.Text)).ToString();
            

        }

        public void DisableDateSetting()
        {
            dateTimePicker1.Enabled = false;
            lblWarningMessage.Visible = true;
        }

     
        public DateTime GetDateOfAppointmentAfterUpdate()
        {
            return dateTimePicker1.Value;
        }
      

        private void ctrlSceduleTest_Load(object sender, EventArgs e)
        {
           
        }
    }
}
