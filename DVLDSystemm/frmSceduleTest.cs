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
    public partial class frmSceduleTest : Form
    {
     
        private clsTestTypes _TestType;
        public enum enMode { AddTestAppointment, UpdateTestAppointment };
        public enMode _Mode;
        public bool IsDataUpdated = false;

        public bool IsRetakeTestAppointment;
        private clsLocalDrivingLicense _LocalLicense;
        private clsTestAppointments TestAppointment;

        private bool IsFailed = false;
        private clsApplications RetakeTestApp;
        public frmSceduleTest(clsTestTypes TestType,int TestAppointmentID,clsLocalDrivingLicense LocalLicense,bool IsFailed)
        {
            InitializeComponent();
            


            _TestType = TestType;
            _LocalLicense = LocalLicense;
             ctrlSceduleTest2.ChangeGroupBoxName(TestType.Title);


            this.IsFailed = IsFailed;
            ctrlSceduleTest2.IsFailed = IsFailed;
            if (IsFailed)
            {
                ctrlSceduleTest2.EnableRetakeTest();
                clsApplications RetakeTestApplication = GetDataOfRetakeTestApplication(_LocalLicense);
                RetakeTestApp = RetakeTestApplication;

               
              
                if(RetakeTestApplication.Save())
                {
                    ctrlSceduleTest2.LoadRetakeTestAppID(RetakeTestApplication);
                }
            }

            
            
           if(TestAppointmentID==-1)
           {
                _Mode = enMode.AddTestAppointment;
                ctrlSceduleTest2._Mode = ctrlSceduleTest.enMode.AddAppointment;
             
           }
            else
            {
                _Mode = enMode.UpdateTestAppointment;
                TestAppointment = clsTestAppointments.FindTestAppointment(TestAppointmentID);
                ctrlSceduleTest2._Mode = ctrlSceduleTest.enMode.UpdateAppointment;
            }
           

        }

        private clsApplications GetDataOfRetakeTestApplication(clsLocalDrivingLicense LocalLicense)
        {
            clsApplications RetakeTestApplication = new clsApplications();
            RetakeTestApplication.ApplicationStatus = clsApplications.enApplicationStatus.NewApplication;
     
            RetakeTestApplication.ApplicationDate = DateTime.Now;
            RetakeTestApplication.LastStatusDate = DateTime.Now;
            RetakeTestApplication.ApplicationTypeID = Convert.ToInt32(clsApplicationType.enApplicationType.RetakeTest);
            RetakeTestApplication.ApplicationType = clsApplicationType.FindApplicationTypeByID(RetakeTestApplication.ApplicationTypeID);
            RetakeTestApplication.PaidFees = RetakeTestApplication.ApplicationType.Fees;
            RetakeTestApplication.User = clsCurrentUser.CurrentUser;
            RetakeTestApplication.CreatedByUserID = RetakeTestApplication.User.UserID;
            RetakeTestApplication.Person = LocalLicense.Application.Person;
            RetakeTestApplication.ApplicantPersonID = RetakeTestApplication.Person.PersonID;
            return RetakeTestApplication;

        }

      
        private void frmSceduleTest_Load(object sender, EventArgs e)
        {
            ctrlSceduleTest2._LoadDataOnControls(TestAppointment, _LocalLicense, _TestType,RetakeTestApp);
            if (_Mode == enMode.UpdateTestAppointment)
            {
                if (clsTestAppointments.IsTestLocked(TestAppointment.TestAppointmentID))
                {
                    ctrlSceduleTest2.DisableDateSetting();
                    btnSave.Enabled = false;
                }
            }
        }

        private void ctrlSceduleTest2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (_Mode)
            {

                case enMode.AddTestAppointment:
                    {
                        
                        TestAppointment = ctrlSceduleTest2.GetDataOfTestAppointment(_TestType,_LocalLicense);
                        if (TestAppointment.SaveTestAppointmet())
                        {
                            
                            MessageBox.Show("The appointment added successfully", "Adding Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            IsDataUpdated = true;
                            
                            _Mode = enMode.UpdateTestAppointment;
                        }
                    }
                    break;
                case enMode.UpdateTestAppointment:
                    {
                        TestAppointment.AppointmentDate = ctrlSceduleTest2.GetDateOfAppointmentAfterUpdate();
                        if(TestAppointment.SaveTestAppointmet())
                        {
                            MessageBox.Show("The appointment updated successfully", "Adding Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            IsDataUpdated = true;
                        }
                    }break;
            }

        }
        private void ApplyTheme()
        {
            Color MainBackground = Color.FromArgb(245, 247, 250);
            Color SurfaceColor = Color.White;
            Color DarkText = Color.FromArgb(35, 38, 45);

            Color Gold = Color.FromArgb(218, 165, 32);
            Color GoldHover = Color.FromArgb(235, 185, 55);

            Color ButtonColor = Color.FromArgb(45, 52, 62);
            Color ButtonHover = Color.FromArgb(65, 75, 88);

            this.BackColor = MainBackground;
            this.ForeColor = DarkText;

            // UserControls
            this.ctrlSceduleTest1.BackColor = SurfaceColor;
            this.ctrlSceduleTest2.BackColor = SurfaceColor;

            // Close Button
            this.btnClose.BackColor = ButtonColor;
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = ButtonHover;

            // Save Button
            this.btnSave.BackColor = Gold;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = GoldHover;
        }
    }
}
