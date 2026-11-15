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
    public partial class frmDriverInternationalLicenseInfo : Form
    {
        private clsInternationalLicenses _InternationalLicense;
        public frmDriverInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            
            _InternationalLicense = clsInternationalLicenses.FindInternationalLicenseByID(InternationalLicenseID);
            _InternationalLicense.Application = clsApplications.FindApplicationByID(_InternationalLicense.ApplicationID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDriverInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseInfo1.LoadDataOnInternationalLicenseOnControl(_InternationalLicense);
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
            this.ctrlInternationalLicenseInfo1.BackColor = SurfaceColor;

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
