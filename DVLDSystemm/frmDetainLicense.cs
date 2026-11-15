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
    public partial class frmDetainLicense : Form
    {
        private clsLicenses LocalLicense;

        private int DetainedLicenseID;

        public bool IsDataUpdated = false;
        public frmDetainLicense()
        {
            InitializeComponent();
            
        }
     
        private void _DataBackOfDetainedLicense(clsLicenses LocalLicense)
        {
            this.LocalLicense = LocalLicense;
            LocalLicense.Application = clsApplications.FindApplicationByID(LocalLicense.ApplicationID);
            LocalLicense.LicenseClass = clsLicenseClass.FindLicenseClassByID(LocalLicense.LicenseClassID);
            ctrlLicenseInfo1.LoadDataOnControl(LocalLicense);
            ctrlDetainLicenseInfo1.LoadLicenseID(LocalLicense.LicenseID);
            if(!clsDetainedLicenses.IsLicenseDetained(LocalLicense.LicenseID))
            {
                btnDetain.Enabled = true;
             
            }
            else
            {
                MessageBox.Show("The selected license is already detained choose another one","Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            ctrlSearchOnInternattionalLicense1.DataBack += _DataBackOfDetainedLicense;
            ctrlDetainLicenseInfo1.LoadDefaultDataOnControl();
        }
        private clsDetainedLicenses _GetDataOfDetainedLicense()
        {
            clsDetainedLicenses DetainedLicense = new clsDetainedLicenses();
            DetainedLicense.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            DetainedLicense.DetainDate = DateTime.Now;
            DetainedLicense.FineFees = ctrlDetainLicenseInfo1.GetFineFees();
            DetainedLicense.LicenseID = LocalLicense.LicenseID;
            DetainedLicense.IsReleased = false;
            return DetainedLicense;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to perform this process ?","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(ctrlDetainLicenseInfo1.GetFineFeesTextBox())){
                    clsDetainedLicenses DetainedLicense = _GetDataOfDetainedLicense();
                    if (DetainedLicense.Save())
                    {
                        llShowLicenseInfo.Enabled = true;

                        DetainedLicenseID = DetainedLicense.LicenseID;
                        ctrlDetainLicenseInfo1.LoadDetainID(DetainedLicense.DetainID);

                        ctrlLicenseInfo1.LoadDataOnControl(LocalLicense);
                        MessageBox.Show("The license detained successfully with detain ID=" + DetainedLicense.DetainID, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IsDataUpdated = true;
                    }
                }
                else
                {
                    MessageBox.Show("You have to enter fine fees value", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDrivingLicenseInfo frm = new frmDrivingLicenseInfo(DetainedLicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmHistoryLicenses frm = new frmHistoryLicenses(LocalLicense.Application.Person.PersonID);
            frm.ShowDialog();
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
            Color Gold = Color.FromArgb(218, 165, 32);
            Color GoldHover = Color.FromArgb(235, 185, 55);

            Color ButtonColor = Color.FromArgb(45, 52, 62);
            Color ButtonHover = Color.FromArgb(65, 75, 88);

            Color DisabledText = Color.FromArgb(160, 165, 172);

            this.BackColor = MainBackground;
            this.ForeColor = DarkText;

            // Title
            this.label1.ForeColor = Gold;
            this.label1.Font = new Font(
                "Segoe UI Semibold",
                24F,
                FontStyle.Bold);

            // UserControls
            this.ctrlSearchOnInternattionalLicense1.BackColor = SurfaceColor;
            this.ctrlLicenseInfo1.BackColor = SurfaceColor;
            this.ctrlDetainLicenseInfo1.BackColor = SurfaceColor;

            // Show License History
            this.llShowLicenseHistory.BackColor = Color.Transparent;
            this.llShowLicenseHistory.ForeColor = Gold;
            this.llShowLicenseHistory.LinkColor = Gold;
            this.llShowLicenseHistory.ActiveLinkColor = GoldHover;
            this.llShowLicenseHistory.VisitedLinkColor = Gold;
            this.llShowLicenseHistory.Font = new Font(
                "Segoe UI",
                9F);

            // Show License Info - Disabled
            this.llShowLicenseInfo.BackColor = Color.Transparent;
            this.llShowLicenseInfo.ForeColor = DisabledText;
            this.llShowLicenseInfo.LinkColor = DisabledText;
            this.llShowLicenseInfo.ActiveLinkColor = GoldHover;
            this.llShowLicenseInfo.VisitedLinkColor = DisabledText;
            this.llShowLicenseInfo.Font = new Font(
                "Segoe UI",
                9F);

            // Close
            this.button1.BackColor = ButtonColor;
            this.button1.ForeColor = Color.White;
            this.button1.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = ButtonHover;

            // Detain - Disabled initially
            this.btnDetain.BackColor = Color.FromArgb(225, 227, 230);
            this.btnDetain.ForeColor = DisabledText;
            this.btnDetain.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.btnDetain.FlatStyle = FlatStyle.Flat;
            this.btnDetain.FlatAppearance.BorderSize = 0;
        }

        private void ctrlSearchOnInternattionalLicense1_Load(object sender, EventArgs e)
        {

        }
    }
}
