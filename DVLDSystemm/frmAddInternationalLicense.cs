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
    public partial class frmAddInternationalLicense : Form
    {
        private clsLicenses License;
        private clsInternationalLicenses InternationalLicense;
        public frmAddInternationalLicense()
        {
            InitializeComponent();
            
        }
        private void _LoadDataOnApplicationInfoControl()
        {
            ctrlApplicationInfo1.LoadDataOnControl();
        }
        public void _DataBack(clsLicenses License)
        {
            this.License = License;
            ctrlApplicationInfo1.LoadLicneseIDOnControl(License.LicenseID);
            if (License.LicenseClassID == Convert.ToInt32(clsLicenseClass.enLicenseClasses.Ordiniry))
            {

                License.Application = clsApplications.FindApplicationByID(License.ApplicationID);
                License.LicenseClass = clsLicenseClass.FindLicenseClassByID(License.LicenseClassID);
                ctrlLicenseInfo1.LoadDataOnControl(License);
                int InternationalLicenseID = clsInternationalLicenses.IsDriverHasInternationalLicnese(Convert.ToInt32(License.DriverID));
                if (InternationalLicenseID == -1)
                {
                    btnIssue.Enabled = true;
                  
                }
                else
                {

                    MessageBox.Show("The person is already have international license with ID=" + InternationalLicenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("International License couldnt be issued unless the type of license was ordinary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmAddInternationalLicense_Load(object sender, EventArgs e)
        {
            _LoadDataOnApplicationInfoControl();
            ctrlSearchOnInternattionalLicense1.DataBack += _DataBack;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private clsInternationalLicenses _GetDataOfInternationalLicense(clsApplications Application)
        {
            clsInternationalLicenses InternationalLicense = new clsInternationalLicenses();
            InternationalLicense.ApplicationID = Application.ApplicationID;
            InternationalLicense.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            InternationalLicense.DriverID = License.DriverID;
            InternationalLicense.ExpirationDate = DateTime.Today.AddYears(1);
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.IsActive = true;
            InternationalLicense.IssuedUsingLocalLicenseID = License.LicenseID;

            return InternationalLicense;

        }
        private clsApplications _GetDataForIssueInternationalLicenseApplication()
        {
            clsApplications Application = new clsApplications();
            Application.ApplicantPersonID = License.Application.Person.PersonID;
            Application.Person = License.Application.Person;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.NewApplication;
            Application.ApplicationDate = DateTime.Today;
            Application.ApplicationTypeID = (int)clsApplicationType.enApplicationType.NewInternationalLicense;
            Application.ApplicationType = clsApplicationType.FindApplicationTypeByID(Application.ApplicationTypeID);
            Application.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            Application.User = clsCurrentUser.CurrentUser;
            Application.PaidFees = Application.ApplicationType.Fees;
            Application.LastStatusDate = DateTime.Today;
            return Application;
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
   
                if (License.IsActive && License.ExpirationDate >= DateTime.Today)
                {
                    if (MessageBox.Show("Are you sure you want to add international license ?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
               
                       clsApplications Application = _GetDataForIssueInternationalLicenseApplication();
                        if (Application.Save())
                        {
                            clsInternationalLicenses InternationalLicense = _GetDataOfInternationalLicense(Application);
                            if (InternationalLicense.Save())
                            {
                                this.InternationalLicense = InternationalLicense;
                                MessageBox.Show("The international license issued successfully with ID=" + InternationalLicense.InternationalLicenseID, "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ctrlApplicationInfo1.LoadInternationalLicenseIDAndApplicationID(InternationalLicense);
                                llShowLicenseInfo.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("There is error in adding international license");
                            }
                        }
                        else
                        {
                            //For Programmer
                            MessageBox.Show("There is error in adding application");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("The local license isnt active or expired", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (License != null)
            {


                frmHistoryLicenses frm = new frmHistoryLicenses(License.Application.Person.PersonID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You didnt search on license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverInternationalLicenseInfo frm = new frmDriverInternationalLicenseInfo(InternationalLicense.InternationalLicenseID);
            frm.ShowDialog();
           

        }

        private void ctrlSearchOnInternattionalLicense1_Load(object sender, EventArgs e)
        {

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


            // =========================
            // FORM
            // =========================

            this.BackColor = MainBackground;
            this.ForeColor = DarkText;


            // =========================
            // MAIN BUTTON
            // =========================

            this.button1.BackColor = ButtonColor;
            this.button1.ForeColor = Color.White;

            this.button1.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor =
                ButtonHover;


            // =========================
            // ISSUE BUTTON
            // =========================

            this.btnIssue.BackColor = Gold;
            this.btnIssue.ForeColor = Color.White;

            this.btnIssue.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.btnIssue.FlatStyle = FlatStyle.Flat;
            this.btnIssue.FlatAppearance.BorderSize = 0;
            this.btnIssue.FlatAppearance.MouseOverBackColor =
                GoldHover;


            // =========================
            // LINK LABELS
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


            this.llShowLicenseInfo.BackColor =
                Color.Transparent;

            this.llShowLicenseInfo.ForeColor = Gold;
            this.llShowLicenseInfo.LinkColor = Gold;
            this.llShowLicenseInfo.ActiveLinkColor =
                GoldHover;
            this.llShowLicenseInfo.VisitedLinkColor =
                Gold;

            this.llShowLicenseInfo.Font =
                new Font(
                    "Segoe UI",
                    9F);


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

                    // لا نغير Font
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

                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor =
                        ButtonHover;
                }

                // =========================
                // COMBO BOX
                // =========================

                else if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;

                    comboBox.BackColor = SurfaceColor;
                    comboBox.ForeColor = DarkText;

                    comboBox.Font =
                        new Font(
                            "Segoe UI",
                            9.5F);

                    comboBox.FlatStyle = FlatStyle.Flat;
                }

                // =========================
                // TEXT BOX
                // =========================

                else if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;

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
                    LinkLabel link = (LinkLabel)control;

                    link.BackColor = Color.Transparent;
                    link.ForeColor = Gold;
                    link.LinkColor = Gold;
                    link.ActiveLinkColor = GoldHover;
                    link.VisitedLinkColor = Gold;
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
