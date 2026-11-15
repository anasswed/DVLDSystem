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
    public partial class frmRenewLocalDrivingLicense : Form
    {
        private clsLicenses License;

        private clsLicenses NewLicense;
        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
            
        }

        private void _LoadDataOfRenewApplication()
        {
            ctrlApplicationNewLicenseInfo1.LoadDataOfRenewApplication();
        }
        private void _DataOfLicenseBack(clsLicenses License)
        {
            this.License = License;
            this.License.Application = clsApplications.FindApplicationByID(License.ApplicationID);
            this.License.LicenseClass = clsLicenseClass.FindLicenseClassByID(License.LicenseClassID);
            ctrlApplicationNewLicenseInfo1.LoadDataRelatedToLicense(License);
            ctrlLicenseInfo1.LoadDataOnControl(License);
            if(License.ExpirationDate.Date<=DateTime.Today)
            {
                btnRenew.Enabled = true;
            }
            else
            {
                MessageBox.Show("The selected license hasnt expired yet,it will expire at " + License.ExpirationDate.ToString("dd,MM,yyy"),"Not allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlSearchOnInternattionalLicense1.DataBack += _DataOfLicenseBack;
            _LoadDataOfRenewApplication();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       private clsApplications _GetDataOfRenewLicenseApplication()
        {
            clsApplications application = new clsApplications();
            application.ApplicationStatus = clsApplications.enApplicationStatus.NewApplication;
            application.ApplicationDate = DateTime.Now;
            application.LastStatusDate = DateTime.Now;
            application.Person = License.Application.Person;
            application.ApplicantPersonID = application.Person.PersonID;
            application.ApplicationTypeID = Convert.ToInt32(clsApplicationType.enApplicationType.RenewDrivingLicense);
            application.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            application.ApplicationType = clsApplicationType.FindApplicationTypeByID(application.ApplicationTypeID);
            application.PaidFees = application.ApplicationType.Fees;
            return application;
        }

        private clsLicenses _GetDataOfNewLicense(clsApplications Application)
        {
            clsLicenses License = new clsLicenses();
            License.Application = Application;
            License.IssueDate = DateTime.Now;
            License.Notes = ctrlApplicationNewLicenseInfo1.GetNoteReletedToNewLicense();
            License.IssueReason = clsLicenses.enIssueReason.Renew;
            License.ApplicationID = Application.ApplicationID;
            License.CreatedByUserID =this.License.CreatedByUserID;
            License.DriverID = this.License.DriverID;
            License.LicenseClassID = this.License.LicenseClassID;
            License.LicenseClass = this.License.LicenseClass;
            License.IsActive = true;
            License.ExpirationDate = License.IssueDate.AddYears(License.LicenseClass.DefaultVaildityLength);
            License.PaidFees = License.LicenseClass.ClassFess;
            return License;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to renew license ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
            {
                clsApplications RenewLicenseApplication = _GetDataOfRenewLicenseApplication();
                if(RenewLicenseApplication.Save())
                {
                    clsLicenses NewLicense = _GetDataOfNewLicense(RenewLicenseApplication);
                    if(NewLicense.RenewLicense())
                    {
                        if(this.License.DeactivateLicense())
                        {
                            this.NewLicense = NewLicense;
                            MessageBox.Show("License renewd successfully with ID=" + NewLicense.LicenseID, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            llNewLicenseInfo.Enabled = true;
                            
                        }

                    }
                }
            }
        }

        private void llNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDrivingLicenseInfo frm = new frmDrivingLicenseInfo(NewLicense.LicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmHistoryLicenses frm = new frmHistoryLicenses(License.Application.Person.PersonID);
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

            Color BorderColor = Color.FromArgb(225, 228, 233);


            // =========================
            // FORM
            // =========================

            this.BackColor = MainBackground;
            this.ForeColor = DarkText;


            // =========================
            // LICENSE SEARCH
            // =========================

            this.ctrlSearchOnInternattionalLicense1.BackColor =
                SurfaceColor;


            // =========================
            // LICENSE INFO
            // =========================

            this.ctrlLicenseInfo1.BackColor =
                SurfaceColor;


            // =========================
            // NEW APPLICATION INFO
            // =========================

            this.ctrlApplicationNewLicenseInfo1.BackColor =
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
            // SHOW NEW LICENSE INFO
            // =========================

            this.llNewLicenseInfo.BackColor =
                Color.Transparent;

            this.llNewLicenseInfo.ForeColor =
                Color.FromArgb(160, 165, 172);

            this.llNewLicenseInfo.LinkColor =
                Color.FromArgb(160, 165, 172);

            this.llNewLicenseInfo.ActiveLinkColor =
                GoldHover;

            this.llNewLicenseInfo.VisitedLinkColor =
                Color.FromArgb(160, 165, 172);

            this.llNewLicenseInfo.Font =
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
            // RENEW BUTTON
            // =========================

            this.btnRenew.BackColor = Gold;
            this.btnRenew.ForeColor = Color.White;

            this.btnRenew.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.btnRenew.FlatStyle =
                FlatStyle.Flat;

            this.btnRenew.FlatAppearance.BorderSize = 0;

            this.btnRenew.FlatAppearance.MouseOverBackColor =
                GoldHover;


            // =========================
            // USER CONTROLS
            // =========================

            ApplyThemeToControls(
                this,
                SurfaceColor,
                SurfaceLight,
                DarkText,
                SecondaryText,
                Gold,
                GoldHover,
                ButtonColor,
                ButtonHover);
        }

        private void ApplyThemeToControls(
    Control parent,
    Color SurfaceColor,
    Color SurfaceLight,
    Color DarkText,
    Color SecondaryText,
    Color Gold,
    Color GoldHover,
    Color ButtonColor,
    Color ButtonHover)
        {
            foreach (Control control in parent.Controls)
            {
                // =========================
                // GROUP BOX
                // =========================

                if (control is GroupBox)
                {
                    control.BackColor = SurfaceColor;
                    control.ForeColor = DarkText;

                    control.Font =
                        new Font(
                            "Segoe UI Semibold",
                            9F,
                            FontStyle.Bold);
                }

                // =========================
                // LABEL
                // =========================

                else if (control is Label)
                {
                    control.BackColor = Color.Transparent;
                    control.ForeColor = SecondaryText;

                    // لا نغير الـ Font
                }

                // =========================
                // BUTTON
                // =========================

                else if (control is Button)
                {
                    Button button = (Button)control;

                    button.BackColor = ButtonColor;
                    button.ForeColor = Color.White;

                    button.Font =
                        new Font(
                            "Segoe UI Semibold",
                            9F,
                            FontStyle.Bold);

                    button.FlatStyle =
                        FlatStyle.Flat;

                    button.FlatAppearance.BorderSize = 0;

                    button.FlatAppearance.MouseOverBackColor =
                        ButtonHover;
                }

                // =========================
                // COMBO BOX
                // =========================

                else if (control is ComboBox)
                {
                    ComboBox comboBox =
                        (ComboBox)control;

                    comboBox.BackColor = SurfaceColor;
                    comboBox.ForeColor = DarkText;

                    comboBox.Font =
                        new Font(
                            "Segoe UI",
                            9.5F);

                    comboBox.FlatStyle =
                        FlatStyle.Flat;
                }

                // =========================
                // TEXT BOX
                // =========================

                else if (control is TextBox)
                {
                    TextBox textBox =
                        (TextBox)control;

                    textBox.BackColor = SurfaceColor;
                    textBox.ForeColor = DarkText;

                    textBox.Font =
                        new Font(
                            "Segoe UI",
                            9.5F);
                }

                // =========================
                // DATE TIME PICKER
                // =========================

                else if (control is DateTimePicker)
                {
                    DateTimePicker datePicker =
                        (DateTimePicker)control;

                    datePicker.BackColor = SurfaceColor;
                    datePicker.ForeColor = DarkText;

                    datePicker.Font =
                        new Font(
                            "Segoe UI",
                            9.5F);
                }

                // =========================
                // LINK LABEL
                // =========================

                else if (control is LinkLabel)
                {
                    LinkLabel link =
                        (LinkLabel)control;

                    link.BackColor =
                        Color.Transparent;

                    link.ForeColor = Gold;
                    link.LinkColor = Gold;

                    link.ActiveLinkColor =
                        GoldHover;

                    link.VisitedLinkColor =
                        Gold;
                }


                // =========================
                // RECURSIVE
                // =========================

                if (control.HasChildren)
                {
                    ApplyThemeToControls(
                        control,
                        SurfaceColor,
                        SurfaceLight,
                        DarkText,
                        SecondaryText,
                        Gold,
                        GoldHover,
                        ButtonColor,
                        ButtonHover);
                }
            }
        }
    }
}
