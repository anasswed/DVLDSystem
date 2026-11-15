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
    public partial class frmReleaseDetainedLicenses : Form
    {
        private clsLicenses LocalLicense;

        private clsDetainedLicenses ReleaseDetainedLicense;
        private clsApplications ReleaseDetainedLicenseApp;

        public bool IsDataUpdated = false;
        private int LicenseID;
        public frmReleaseDetainedLicenses(int LicenseID)
        {
            InitializeComponent();
            
            this.LicenseID = LicenseID;
            if(LicenseID!=-1)
            {
                LocalLicense = clsLicenses.FindLicenseByID(LicenseID);
                LocalLicense.Application = clsApplications.FindApplicationByID(LocalLicense.ApplicationID);
                LocalLicense.LicenseClass = clsLicenseClass.FindLicenseClassByID(LocalLicense.LicenseClassID);
                ReleaseDetainedLicense = clsDetainedLicenses.FindDetainedLicenseByLicenseID(LicenseID);
                ctrlSearchOnInternattionalLicense1.LoadLicenseIDOnTextBox(LicenseID);
                ctrlLicenseInfo1.LoadDataOnControl(LocalLicense);
                ctrlDetainInfoForReleaseLicenseForm1.LoadDataOfDetainedLicenseOnControls(ReleaseDetainedLicense);
                ctrlDetainInfoForReleaseLicenseForm1.LoadLicenseID(LicenseID);
                ctrlSearchOnInternattionalLicense1.Enabled = false;
                btnRelease.Enabled = true;
            }
        }
        private void _DataBackOfLocalLicense(clsLicenses LocalLicense)
        {
            this.LocalLicense = LocalLicense;
            this.LocalLicense.Application = clsApplications.FindApplicationByID(LocalLicense.ApplicationID);
            this.LocalLicense.LicenseClass = clsLicenseClass.FindLicenseClassByID(LocalLicense.LicenseClassID);
            ctrlLicenseInfo1.LoadDataOnControl(LocalLicense);
            ctrlDetainInfoForReleaseLicenseForm1.LoadLicenseID(LocalLicense.LicenseID);

            if(clsDetainedLicenses.IsLicenseDetained(LocalLicense.LicenseID))
            {
                btnRelease.Enabled = true;
               ReleaseDetainedLicense = clsDetainedLicenses.FindDetainedLicenseByLicenseID(LocalLicense.LicenseID);

                ctrlDetainInfoForReleaseLicenseForm1.LoadDataOfDetainedLicenseOnControls(ReleaseDetainedLicense);
            }
            else
            {
                MessageBox.Show("The license isnt detained choose another license", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReleaseDetainedLicenses_Load(object sender, EventArgs e)
        {
            if (LicenseID == -1)
            {
                ctrlSearchOnInternattionalLicense1.DataBack += _DataBackOfLocalLicense;
            }

        }
        private clsApplications _GetReleaseDetainedLicenseAppInfo()
        {
            clsApplications ReleaseDetainedLicenseApp = new clsApplications();
            ReleaseDetainedLicenseApp.ApplicantPersonID = LocalLicense.Application.ApplicantPersonID;
            ReleaseDetainedLicenseApp.ApplicationDate = DateTime.Now;
            ReleaseDetainedLicenseApp.ApplicationStatus = clsApplications.enApplicationStatus.NewApplication;
            ReleaseDetainedLicenseApp.LastStatusDate = DateTime.Now;
            ReleaseDetainedLicenseApp.ApplicationTypeID = Convert.ToInt32(clsApplicationType.enApplicationType.ReleaseDetainedLicense);
            ReleaseDetainedLicenseApp.ApplicationType = clsApplicationType.FindApplicationTypeByID(ReleaseDetainedLicenseApp.ApplicationTypeID);
           
            ReleaseDetainedLicenseApp.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            ReleaseDetainedLicenseApp.Person = LocalLicense.Application.Person;
            ReleaseDetainedLicenseApp.PaidFees = ReleaseDetainedLicenseApp.ApplicationType.Fees;
            return ReleaseDetainedLicenseApp;
        }
        private void _GetDataOfReleasingLicense(ref clsDetainedLicenses ReleaseDetainedLicense,clsApplications ReleaseDetianedLicenseApp)
        {
            ReleaseDetainedLicense.ReleaseDate = DateTime.Now;
            ReleaseDetainedLicense.IsReleased = true;
            ReleaseDetainedLicense.ReleaseApplicationID = ReleaseDetianedLicenseApp.ApplicationID;
            ReleaseDetainedLicense.ReleaseByUserID = clsCurrentUser.CurrentUser.UserID;

        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to perform this process", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
            {
                ReleaseDetainedLicenseApp = _GetReleaseDetainedLicenseAppInfo();
                if (ReleaseDetainedLicenseApp.Save())
                {
                   
                    _GetDataOfReleasingLicense(ref ReleaseDetainedLicense, ReleaseDetainedLicenseApp);
                    if(ReleaseDetainedLicense.Save())
                    {
                        MessageBox.Show("The license is released successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ctrlDetainInfoForReleaseLicenseForm1.LoadReleaseID(ReleaseDetainedLicense.ReleaseApplicationID);
                        llShowLicenseInfo.Enabled = true;
                        btnRelease.Enabled = false;
                        ctrlSearchOnInternattionalLicense1.Enabled = false;
                        ctrlLicenseInfo1.UpdateStatusOfDetainedLicense(ReleaseDetainedLicense.LicenseID);
                        IsDataUpdated = true;
                    }

                }
            }
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDrivingLicenseInfo frm = new frmDrivingLicenseInfo(LocalLicense.LicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmHistoryLicenses frm = new frmHistoryLicenses(LocalLicense.Application.ApplicantPersonID);
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
            Color SecondaryText = Color.FromArgb(90, 96, 105);

            Color Gold = Color.FromArgb(218, 165, 32);
            Color GoldHover = Color.FromArgb(235, 185, 55);

            Color ButtonColor = Color.FromArgb(45, 52, 62);
            Color ButtonHover = Color.FromArgb(65, 75, 88);

            Color DisabledText = Color.FromArgb(160, 165, 172);


            // =========================
            // FORM
            // =========================

            this.BackColor = MainBackground;
            this.ForeColor = DarkText;


            // =========================
            // TITLE
            // =========================

            this.label1.ForeColor = Gold;

            this.label1.Font =
                new Font(
                    "Segoe UI Semibold",
                    24F,
                    FontStyle.Bold);


            // =========================
            // USER CONTROLS
            // =========================

            this.ctrlSearchOnInternattionalLicense1.BackColor =
                SurfaceColor;

            this.ctrlLicenseInfo1.BackColor =
                SurfaceColor;

            this.ctrlDetainInfoForReleaseLicenseForm1.BackColor =
                SurfaceColor;


            // =========================
            // SHOW LICENSE HISTORY
            // =========================

            this.llShowLicenseHistory.BackColor =
                Color.Transparent;

            this.llShowLicenseHistory.ForeColor = Gold;
            this.llShowLicenseHistory.LinkColor = Gold;

            this.llShowLicenseHistory.ActiveLinkColor =
                GoldHover;

            this.llShowLicenseHistory.VisitedLinkColor =
                Gold;

            this.llShowLicenseHistory.Font =
                new Font(
                    "Segoe UI",
                    9F);


            // =========================
            // SHOW LICENSE INFO
            // =========================

            this.llShowLicenseInfo.BackColor =
                Color.Transparent;

            this.llShowLicenseInfo.ForeColor =
                DisabledText;

            this.llShowLicenseInfo.LinkColor =
                DisabledText;

            this.llShowLicenseInfo.ActiveLinkColor =
                GoldHover;

            this.llShowLicenseInfo.VisitedLinkColor =
                DisabledText;

            this.llShowLicenseInfo.Font =
                new Font(
                    "Segoe UI",
                    9F);


            // =========================
            // CLOSE BUTTON
            // =========================

            this.button1.BackColor = ButtonColor;
            this.button1.ForeColor = Color.White;

            this.button1.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.button1.FlatStyle =
                FlatStyle.Flat;

            this.button1.FlatAppearance.BorderSize = 0;

            this.button1.FlatAppearance.MouseOverBackColor =
                ButtonHover;


            // =========================
            // RELEASE BUTTON
            // =========================

            this.btnRelease.BackColor = ButtonColor;
            this.btnRelease.ForeColor = Color.White;

            this.btnRelease.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.btnRelease.FlatStyle =
                FlatStyle.Flat;

            this.btnRelease.FlatAppearance.BorderSize = 0;

            this.btnRelease.FlatAppearance.MouseOverBackColor =
                ButtonHover;
        }
    }
}
