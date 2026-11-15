using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class frmNewLocalDrivingLicense : Form
    {
        private enum enMode { UpdateLocalLicense, AddLocalLicense };
        private enMode _Mode;

        private clsLocalDrivingLicense _LocalLicense;

        public bool IsDataUpdated { set; get; }
        public frmNewLocalDrivingLicense(int LocalDrivingLicenseAppID)
        {
            InitializeComponent();
            
            if(LocalDrivingLicenseAppID==-1)
            {
                _Mode = enMode.AddLocalLicense;
               
   
               
            }
            else
            {
                _Mode = enMode.UpdateLocalLicense;
             
                _LocalLicense = clsLocalDrivingLicense.FindLocalDrivingLicenseApp(LocalDrivingLicenseAppID);
                lblStatusOfScreen.Text = "Update Local Driving License Application";
                
            }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            tabControl1.SelectedTab = tapApplicationInfo;
        }

        private void tapApplicationInfo_Click(object sender, EventArgs e)
        {

        }
        private void LoadApplicationDataOnControl(clsLocalDrivingLicense LocalLicense)
        {
            lblApplicationIDResult.Text = LocalLicense.LocalDrivingLicenseID.ToString();
            lblApplicationDateResult.Text = LocalLicense.Application.ApplicationDate.ToString();
            lblCreatedBy.Text = LocalLicense.Application.User.UserName;
            cbLicenseClass.SelectedValue = LocalLicense.LicenseClassID;
            lblApplicationFees.Text = LocalLicense.Application.ApplicationType.Fees.ToString();
        }
        private void frmNewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            cbLicenseClass.DataSource = clsLicenseClass.GetNameForAllLicenseClass();
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
            if (_Mode == enMode.AddLocalLicense)
            {
                lblApplicationDateResult.Text = DateTime.Now.ToString();
                lblCreatedBy.Text = clsCurrentUser.CurrentUser.UserName;
            
               
                cbLicenseClass.SelectedIndex = 2;
                lblApplicationFees.Text = "15";
                ctrlFindPersonAndPersonDetails1.DisableUpdateLink();
            }
            else
            {
                ctrlFindPersonAndPersonDetails1.LoadDataOnControls(_LocalLicense.Application.Person);
                LoadApplicationDataOnControl(_LocalLicense);
                ctrlFindPersonAndPersonDetails1.EnableUpdateLink();
                ctrlFindPersonAndPersonDetails1.DisableFindBy();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void ctrlFindPersonAndPersonDetails1_Load(object sender, EventArgs e)
        {


       
        }
       
        private void GetDataOfApplication(clsApplications Application)
        {

            Application.Person = ctrlFindPersonAndPersonDetails1.GetDataOfPerson();
            Application.ApplicantPersonID = Application.Person.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationStatus = clsApplications.enApplicationStatus.NewApplication;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = 15;
            Application.User = clsCurrentUser.CurrentUser;
            Application.CreatedByUserID = clsCurrentUser.CurrentUser.UserID;
            Application.ApplicationType = clsApplicationType.FindApplicationTypeByID(1);
            Application.ApplicationTypeID = Application.ApplicationType.ApplicationTypeID;
           
            
        }

        private void GetLicenseClassName(clsLocalDrivingLicense LocalLicense)
        {
            LocalLicense.LicenseClassID = Convert.ToInt32(cbLicenseClass.SelectedValue);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            switch (_Mode)
            {

                case enMode.AddLocalLicense:
                    {


                        _LocalLicense = new clsLocalDrivingLicense();
                        GetDataOfApplication(_LocalLicense.Application);
                        _LocalLicense.LicenseClassID = Convert.ToInt32(cbLicenseClass.SelectedValue);

                        if (!_LocalLicense.HasCompletedApplication())
                        {
                            int ApplicationID = _LocalLicense.HasNewApplication();
                            if (ApplicationID == -1)
                            {
                                if (_LocalLicense.Application.Save())
                                {
                                    IsDataUpdated = true;
                                    _LocalLicense.ApplicationID = _LocalLicense.Application.ApplicationID;

                                    if (_LocalLicense.Save())
                                    {
                                        MessageBox.Show("Data Saved Successfully", "Saving Data of application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        _Mode = enMode.UpdateLocalLicense;
                                        lblStatusOfScreen.Text = "Update Local Driving License Application";
                                        lblApplicationIDResult.Text = _LocalLicense.LocalDrivingLicenseID.ToString();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Data Wasnt Saved Successfully", "Saving Data of application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    IsDataUpdated = false;
                                    MessageBox.Show("Data Of Application Wasnt Saved Successfully", "Saving Data of application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Choose another license class, the selected person already have an active application for the selected class with ID =" + ApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("perosn have already license with the same applied driving license,choose different license class", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }





                    }
                    break;

                case enMode.UpdateLocalLicense:
                    {
                        GetLicenseClassName(_LocalLicense);
                        if (_LocalLicense.Save())
                        {
                            IsDataUpdated = true;
                            MessageBox.Show("The data of application updated successfully", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        }

                    }
                    break;
            }
        }


        private void ApplyTheme()
        {
            Color MainBackground = Color.FromArgb(245, 247, 250);
            Color SurfaceColor = Color.White;
            Color DarkText = Color.FromArgb(35, 38, 45);
            Color SecondaryText = Color.FromArgb(90, 96, 105);

            Color Gold = Color.FromArgb(218, 165, 32);
            Color GoldHover = Color.FromArgb(235, 185, 55);

            Color HeaderColor = Color.FromArgb(45, 52, 62);
            Color HeaderText = Color.White;

            Color ButtonColor = Color.FromArgb(45, 52, 62);
            Color ButtonHover = Color.FromArgb(65, 75, 88);


            // =========================
            // FORM
            // =========================

            this.BackColor = MainBackground;
            this.ForeColor = DarkText;


            // =========================
            // TITLE
            // =========================

            this.lblStatusOfScreen.BackColor = Color.Transparent;
            this.lblStatusOfScreen.ForeColor = Gold;

            this.lblStatusOfScreen.Font =
                new Font(
                    "Segoe UI Semibold",
                    23F,
                    FontStyle.Bold);


            // =========================
            // TAB CONTROL
            // =========================

            this.tabControl1.BackColor = SurfaceColor;
            this.tabControl1.ForeColor = DarkText;


            // =========================
            // TAB PAGES
            // =========================

            this.tapPersonalInfo.BackColor = SurfaceColor;
            this.tapPersonalInfo.ForeColor = DarkText;

            this.tapApplicationInfo.BackColor = SurfaceColor;
            this.tapApplicationInfo.ForeColor = DarkText;


            // =========================
            // LABELS
            // =========================

            this.label1.ForeColor = SecondaryText;
            this.label2.ForeColor = SecondaryText;
            this.label3.ForeColor = SecondaryText;
            this.label4.ForeColor = SecondaryText;
            this.label6.ForeColor = SecondaryText;

            this.label1.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            this.label2.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            this.label3.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            this.label4.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            this.label6.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);


            // =========================
            // RESULT LABELS
            // =========================

            this.lblApplicationIDResult.ForeColor = Gold;
            this.lblApplicationDateResult.ForeColor = DarkText;
            this.lblCreatedBy.ForeColor = DarkText;

            this.lblApplicationIDResult.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            this.lblApplicationDateResult.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            this.lblCreatedBy.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);


            // =========================
            // APPLICATION FEES
            // =========================

            this.lblApplicationFees.ForeColor = Gold;

            this.lblApplicationFees.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);


            // =========================
            // LICENSE CLASS COMBOBOX
            // =========================

            this.cbLicenseClass.BackColor = SurfaceColor;
            this.cbLicenseClass.ForeColor = DarkText;

            this.cbLicenseClass.Font =
                new Font("Segoe UI", 9.5F);

            this.cbLicenseClass.FlatStyle =
                FlatStyle.Flat;


            // =========================
            // NEXT BUTTON
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
            // CLOSE BUTTON
            // =========================

            this.button2.BackColor = ButtonColor;
            this.button2.ForeColor = Color.White;

            this.button2.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.button2.FlatStyle =
                FlatStyle.Flat;

            this.button2.FlatAppearance.BorderSize = 0;

            this.button2.FlatAppearance.MouseOverBackColor =
                ButtonHover;


            // =========================
            // SAVE BUTTON
            // =========================

            this.button3.BackColor = Gold;
            this.button3.ForeColor =
                Color.FromArgb(25, 25, 25);

            this.button3.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.button3.FlatStyle =
                FlatStyle.Flat;

            this.button3.FlatAppearance.BorderSize = 0;

            this.button3.FlatAppearance.MouseOverBackColor =
                GoldHover;
        }


    }
    }

