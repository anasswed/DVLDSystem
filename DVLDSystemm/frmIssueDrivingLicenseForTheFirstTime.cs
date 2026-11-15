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
using System.Windows.Forms.VisualStyles;

namespace PresentationLayer
{
    public partial class frmIssueDrivingLicenseForTheFirstTime : Form
    {
        private clsLocalDrivingLicense LocalLicenseApp;

        public bool IsLicenseIssued = false;
        private clsLicenses License;

        private clsDrivers Driver;

        public frmIssueDrivingLicenseForTheFirstTime(int LDLAppID)
        {
            InitializeComponent();
            
            LocalLicenseApp = clsLocalDrivingLicense.FindLocalDrivingLicenseApp(LDLAppID);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmIssueDrivingLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseAppInfoAndAppIInfo1._LoadDataOnControls(LocalLicenseApp);
        }

        private clsLicenses _GetDataOfLicense()
        {
            clsLicenses License = new clsLicenses();
            License.ApplicationID = LocalLicenseApp.ApplicationID;
            License.LicenseClassID = LocalLicenseApp.LicenseClassID;
            License.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            License.IssueDate = DateTime.Now;
            License.Notes = tbNotes.Text;
            License.IsActive = true;
            License.ExpirationDate = DateTime.Now.AddYears(LocalLicenseApp.LicenseClass.DefaultVaildityLength);
            License.PaidFees = LocalLicenseApp.LicenseClass.ClassFess;
            License.Application = LocalLicenseApp.Application;
            License.LicenseClass = LocalLicenseApp.LicenseClass;
            License.IssueReason = clsLicenses.enIssueReason.FirstTime;
            return License;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            License = _GetDataOfLicense();
            if(License.IssueLicense())
            {
           
                License.Application.ApplicationStatus = clsApplications.enApplicationStatus.CompletedApplication;
               if(License.Application.UpdateApplicationStatus())
                {
                    MessageBox.Show("License Issued Successfully with licenseID=" + License.LicenseID, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IsLicenseIssued = true;
                }
        
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyTheme()
        {
            Color MainBackground = Color.FromArgb(245, 247, 250);
            Color SurfaceColor = Color.White;

            Color DarkText = Color.FromArgb(35, 38, 45);
            Color SecondaryText = Color.FromArgb(90, 96, 105);

            Color Gold = Color.FromArgb(218, 165, 32);
            Color GoldHover = Color.FromArgb(235, 185, 55);

            Color ButtonColor = Color.FromArgb(45, 52, 62);
            Color ButtonHover = Color.FromArgb(65, 75, 88);

            this.BackColor = MainBackground;
            this.ForeColor = DarkText;

            // UserControl
            this.ctrlDrivingLicenseAppInfoAndAppIInfo1.BackColor = SurfaceColor;

            // Notes Label
            this.label1.ForeColor = SecondaryText;
            this.label1.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            // Notes TextBox
            this.tbNotes.BackColor = SurfaceColor;
            this.tbNotes.ForeColor = DarkText;
            this.tbNotes.Font = new Font(
                "Segoe UI",
                9.5F);

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

            // Issue Button
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
