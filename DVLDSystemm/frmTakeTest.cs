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
    public partial class frmTakeTest : Form

    {
        private clsTestAppointments TestAppointment;

        public bool IsDataUpdated = false;

        public bool IsPassed = false;
        
        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            
          
            
            TestAppointment = clsTestAppointments.FindTestAppointment(TestAppointmentID);
            if(TestAppointment.TestTypeID==1)
            {
                ctrlTakeTest1.ChangeNameOfGroubBox("Vision Test");
            }
            else if(TestAppointment.TestTypeID==2)
            {
                ctrlTakeTest1.ChangeNameOfGroubBox("Written Test");
            }
            else if(TestAppointment.TestTypeID==3)
            {
                ctrlTakeTest1.ChangeNameOfGroubBox("Street Test");
            }
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlTakeTest1.LoadDataOnControl(TestAppointment);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save the information", "Saving Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                clsTests Test = ctrlTakeTest1.GetTestInfo(TestAppointment);
                if (Test.SaveTest())
                {
                    ctrlTakeTest1.AddTestIDToLable(Test);
                    Test.TestAppointment.IsLocked = true;
                    Test.TestAppointment.SaveTestAppointmet();
                    IsDataUpdated = true;
                   if(Test.TestResult)
                    {
                        IsPassed = true;
                    }
                    MessageBox.Show("The data added successfully", "Adding Test Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You canceled the process", "Canceling saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void ApplyTheme()
        {
            Color MainBackground = Color.FromArgb(245, 247, 250);
            Color SurfaceColor = Color.White;

            Color Gold = Color.FromArgb(218, 165, 32);
            Color GoldHover = Color.FromArgb(235, 185, 55);

            Color ButtonColor = Color.FromArgb(45, 52, 62);
            Color ButtonHover = Color.FromArgb(65, 75, 88);

            this.BackColor = MainBackground;

            // UserControl
            this.ctrlTakeTest1.BackColor = SurfaceColor;

            // Close Button
            this.button1.BackColor = ButtonColor;
            this.button1.ForeColor = Color.White;
            this.button1.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = ButtonHover;

            // Save Button
            this.button2.BackColor = Gold;
            this.button2.ForeColor = Color.White;
            this.button2.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.button2.FlatStyle = FlatStyle.Flat;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = GoldHover;
        }
    }
}
