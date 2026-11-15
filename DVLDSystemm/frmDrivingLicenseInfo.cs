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
    public partial class frmDrivingLicenseInfo : Form
    {
        private clsLocalDrivingLicense LocalLicenseApp;

        private clsLicenses License;
        public frmDrivingLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            
            License = clsLicenses.FindLicenseByID(LicenseID);
            License.Application = clsApplications.FindApplicationByID(License.ApplicationID);
            License.LicenseClass = clsLicenseClass.FindLicenseClassByID(License.LicenseClassID);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDrivingLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfo1.LoadDataOnControl(License);
        }

        private void ApplyTheme()
        {
            Color MainBackground = Color.FromArgb(245, 247, 250);
            Color SurfaceColor = Color.White;

            Color DarkText = Color.FromArgb(35, 38, 45);

            Color Gold = Color.FromArgb(218, 165, 32);

            Color ButtonColor = Color.FromArgb(45, 52, 62);
            Color ButtonHover = Color.FromArgb(65, 75, 88);

            this.BackColor = MainBackground;
            this.ForeColor = DarkText;

            // Title
            this.label1.ForeColor = Gold;
            this.label1.Font = new Font(
                "Segoe UI Semibold",
                24F,
                FontStyle.Bold);

            // UserControl
            this.ctrlLicenseInfo1.BackColor = SurfaceColor;

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
        }
    }
}
