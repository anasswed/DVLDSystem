using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class ctrlTakeTest : UserControl
    {
        public ctrlTakeTest()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        public void LoadDataOnControl(clsTestAppointments TestAppointment)
        {
            lblLDLAppIDResult.Text = TestAppointment.LocalDrivingLicenseID.ToString();
            lblNameResult.Text = TestAppointment.LocalLicense.Application.Person.GetFullName();
            lblLicenseClassNameResult.Text = TestAppointment.LocalLicense.LicenseClass.ClassName;
            lblDateResult.Text = TestAppointment.AppointmentDate.ToString();
            lblFeesResult.Text = TestAppointment.TestType.Fees.ToString();
            lblTrialResult.Text = clsTests.GetNumberOfTrialToIntroduceTest(TestAppointment.LocalDrivingLicenseID, TestAppointment.TestTypeID).ToString();
        }

        public void ChangeNameOfGroubBox(string TestTypeTitle)
        {
            gbTestInfo.Text = TestTypeTitle;
            
        }

        public clsTests GetTestInfo(clsTestAppointments TestAppointment)
        {
            clsTests Test = new clsTests();
            Test.TestAppointment = TestAppointment;
            Test.TestAppointmentID = TestAppointment.TestAppointmentID;
            if(!string.IsNullOrEmpty(tbNotesResult.Text))
            {
                Test.Notes = tbNotesResult.Text;
            }
            else
            {
                Test.Notes = "";
            }
            if(rbFail.Checked)
            {
                Test.TestResult = false;
            }
            else if(rbPass.Checked)
            {
                Test.TestResult = true;
            }
            Test.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            return Test;
            
        }

        public void AddTestIDToLable(clsTests Test)
        {
            lblTestIDResult.Text = Test.TestID.ToString();
        }
        private void ctrlTakeTest_Load(object sender, EventArgs e)
        {

        }
    }
}
