using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BusinessLayer.clsApplicationType;

namespace PresentationLayer
{
    public partial class frmNewApplicationForReplacmentLicense : Form
    {

        private clsLicenses _LocalLicense;

        private clsApplicationType _ApplicationType1 = null;

        private clsApplicationType _ApplicationType2 = null;

        private int ReplacedLicenseID;

        private int OwnerOfReplacedLicenseID;
        public frmNewApplicationForReplacmentLicense()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _DataBackOfLicense(clsLicenses License)
        {
            _LocalLicense = License;
            _LocalLicense.Application = clsApplications.FindApplicationByID(_LocalLicense.ApplicationID);
            _LocalLicense.LicenseClass = clsLicenseClass.FindLicenseClassByID(_LocalLicense.LicenseClassID);
            btnIssueReplacement.Enabled = true;
            ctrlLicenseInfo1.LoadDataOnControl(_LocalLicense);
            ctrlApplicationInfoForReplacment1.LoadOldLicenseID(_LocalLicense);
        }

        private void frmNewApplicationForReplacmentLicense_Load(object sender, EventArgs e)
        {
            ctrlSearchOnInternattionalLicense1.DataBack += _DataBackOfLicense;

            _ApplicationType1 = clsApplicationType.FindApplicationTypeByID(Convert.ToInt32(clsApplicationType.enApplicationType.ReplacmentForDamaged));
            _ApplicationType2 = clsApplicationType.FindApplicationTypeByID(Convert.ToInt32(clsApplicationType.enApplicationType.ReplacmentForLost));
            if (rbDamagedLicense.Checked)
            {
        
                ctrlApplicationInfoForReplacment1.LoadDataOfApplication(_ApplicationType1);
            }
            else if(rbLostLicense.Checked)
            {
            
                ctrlApplicationInfoForReplacment1.LoadDataOfApplication(_ApplicationType2);
            }
            
        }
       

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
           
            if(rbDamagedLicense.Checked)
            {
                label1.Text = "Replacement For Damaged License";
                ctrlApplicationInfoForReplacment1.LoadDataOfApplication(_ApplicationType1);
            }
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
           if(rbLostLicense.Checked)
            {
                label1.Text = "Replacement For Lost License";
                ctrlApplicationInfoForReplacment1.LoadDataOfApplication(_ApplicationType2);
            }
        }

        private clsApplications _GetDataOfReplcementLicenseApplication()
        {
            clsApplications applications = new clsApplications();
            applications.ApplicationStatus = clsApplications.enApplicationStatus.NewApplication;
            applications.ApplicantPersonID = _LocalLicense.Application.ApplicantPersonID;
            applications.ApplicationDate = DateTime.Now;
            applications.LastStatusDate = DateTime.Now;
            if (rbDamagedLicense.Checked)
            {
                applications.ApplicationType = _ApplicationType1;
                applications.ApplicationTypeID = _ApplicationType1.ApplicationTypeID;
                applications.PaidFees = _ApplicationType1.Fees;
            }
             if(rbLostLicense.Checked)
            {
                applications.ApplicationType = _ApplicationType2;
                applications.ApplicationTypeID = _ApplicationType2.ApplicationTypeID;
                applications.PaidFees = _ApplicationType2.Fees;
            }
            applications.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            applications.Person = _LocalLicense.Application.Person;
            return applications;
        }
        private clsLicenses _GetDataOfReplacedLicense(clsApplications ReplacementLicenseApp)
        {
            clsLicenses License = new clsLicenses();
            License.Application = ReplacementLicenseApp;
            License.ApplicationID = ReplacementLicenseApp.ApplicationID;
            License.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            License.DriverID = _LocalLicense.DriverID;
            License.IsActive = true;
            License.IssueDate = DateTime.Now;
            License.LicenseClassID = _LocalLicense.LicenseClassID;
            License.LicenseClass = _LocalLicense.LicenseClass;
            if (rbDamagedLicense.Checked) {
                License.IssueReason = clsLicenses.enIssueReason.ReplacmentForDamaged;
              
                    }
            else if(rbLostLicense.Checked)
            {
                License.IssueReason = clsLicenses.enIssueReason.ReplacmentForLost;
            }
            License.ExpirationDate = DateTime.Now.AddYears(License.LicenseClass.DefaultVaildityLength);
            License.PaidFees = License.LicenseClass.ClassFess;
            return License;
        }
        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to issue replaced license ?","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                clsApplications ReplacementLicenseApplication = _GetDataOfReplcementLicenseApplication();
                if(ReplacementLicenseApplication.Save())
                {
                    clsLicenses ReplacedLicense = _GetDataOfReplacedLicense(ReplacementLicenseApplication);
                    if(ReplacedLicense.ReplaceLicenseForDamagedOrLost())
                    {
                        if(_LocalLicense.DeactivateLicense())
                        {
                            llShowLicenseInfo.Enabled = true;
                            ReplacedLicenseID = ReplacedLicense.LicenseID;
                            OwnerOfReplacedLicenseID = ReplacedLicense.Application.Person.PersonID;
                            ctrlApplicationInfoForReplacment1.LoadReplacementLicenseApplicationIDAndReplacedLicenseID(ReplacementLicenseApplication.ApplicationID, ReplacedLicense.LicenseID);
                            MessageBox.Show("The license has replaced successfully with ID=" + ReplacedLicense.LicenseID, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("There is error in deactiviting license");
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is error in adding new license");
                    }
                }
                else
                {
                    MessageBox.Show("There is error in Adding Application");
                }
            }
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmHistoryLicenses frm = new frmHistoryLicenses(OwnerOfReplacedLicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDrivingLicenseInfo frm = new frmDrivingLicenseInfo(ReplacedLicenseID);
            frm.ShowDialog();
        }

        private void ApplyTheme()
        {
            Color MainBackground = Color.FromArgb(245, 247, 250);
            Color SurfaceColor = Color.White;
            Color SurfaceLight = Color.FromArgb(248, 249, 251);

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
            // REPLACEMENT GROUP BOX
            // =========================

            this.groupBox1.BackColor = SurfaceColor;
            this.groupBox1.ForeColor = DarkText;

            this.groupBox1.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);


            // =========================
            // RADIO BUTTONS
            // =========================

            this.rbDamagedLicense.BackColor =
                Color.Transparent;

            this.rbDamagedLicense.ForeColor =
                DarkText;

            this.rbDamagedLicense.Font =
                new Font(
                    "Segoe UI",
                    9F);


            this.rbLostLicense.BackColor =
                Color.Transparent;

            this.rbLostLicense.ForeColor =
                DarkText;

            this.rbLostLicense.Font =
                new Font(
                    "Segoe UI",
                    9F);


            // =========================
            // USER CONTROLS
            // =========================

            this.ctrlSearchOnInternattionalLicense1.BackColor =
                SurfaceColor;

            this.ctrlLicenseInfo1.BackColor =
                SurfaceColor;

            this.ctrlApplicationInfoForReplacment1.BackColor =
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
            // ISSUE REPLACEMENT BUTTON
            // =========================

            this.btnIssueReplacement.BackColor = Gold;
            this.btnIssueReplacement.ForeColor = Color.White;

            this.btnIssueReplacement.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.btnIssueReplacement.FlatStyle =
                FlatStyle.Flat;

            this.btnIssueReplacement.FlatAppearance.BorderSize = 0;

            this.btnIssueReplacement.FlatAppearance.MouseOverBackColor =
                GoldHover;
        }
    }
}
