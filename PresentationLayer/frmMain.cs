using BusinessLayer;
using DVLDSystemm;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frmPeopleScreen = new frmManagePeople();
            frmPeopleScreen.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmLogin frm = Application.OpenForms.OfType<frmLogin>().FirstOrDefault();

            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form != frm)
                    form.Close();
            }

            frm.Show();
            frm.BringToFront();

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsCurrentUser.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void curretnUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            frmUserInfo frm = new frmUserInfo(clsCurrentUser.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void manageApplicatioTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicense frm = new frmNewLocalDrivingLicense(-1);
            frm.ShowDialog();
        }

        private void localDrivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplication frm = new frmManageLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void newDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
           
         

        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriversList frm = new frmDriversList();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddInternationalLicense frm = new frmAddInternationalLicense();
            frm.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenses frm = new frmManageInternationalLicenses();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicense frm = new frmRenewLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void replacmentForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewApplicationForReplacmentLicense frm = new frmNewApplicationForReplacmentLicense();
            frm.ShowDialog();
        }

        private void detainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenses frm = new frmReleaseDetainedLicenses(-1);
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplication frm = new frmManageLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenses frm = new frmReleaseDetainedLicenses(-1);
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListAllDetainedLicenses frm = new frmListAllDetainedLicenses();
            frm.ShowDialog();
        }

        private void ApplyTheme()
        {
            // =========================
            // FORM
            // =========================

            this.BackColor = Color.FromArgb(245, 247, 250);
            this.ForeColor = Color.FromArgb(35, 38, 45);


            // =========================
            // MENU STRIP
            // =========================

            this.menuStrip1.BackColor =
                Color.FromArgb(24, 28, 36);

            this.menuStrip1.ForeColor = Color.White;

            this.menuStrip1.Font =
                new Font("Segoe UI", 11F, FontStyle.Regular);

            this.menuStrip1.RenderMode =
                ToolStripRenderMode.Professional;


            // =========================
            // MAIN MENU ITEMS
            // =========================

            foreach (ToolStripMenuItem mainItem in this.menuStrip1.Items)
            {
                mainItem.ForeColor = Color.White;

                mainItem.Font =
                    new Font("Segoe UI Semibold", 11F, FontStyle.Regular);

                ApplySubMenuTheme(mainItem);
            }


            // =========================
            // PANEL
            // =========================

            this.panel1.BackColor =
                Color.FromArgb(24, 28, 36);


            // =========================
            // LABELS
            // =========================

            this.label1.ForeColor = Color.White;
            this.label2.ForeColor = Color.White;

            this.label1.Font =
                new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            this.label2.Font =
                new Font("Segoe UI", 10F, FontStyle.Regular);
        }
        private void ApplySubMenuTheme(ToolStripMenuItem menuItem)
        {
            foreach (ToolStripItem item in menuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem subMenu =
                        (ToolStripMenuItem)item;

                    subMenu.ForeColor =
                        Color.FromArgb(35, 38, 45);

                    subMenu.Font =
                        new Font("Segoe UI", 10F, FontStyle.Regular);

                    ApplySubMenuTheme(subMenu);
                }
                else
                {
                    item.ForeColor =
                        Color.FromArgb(35, 38, 45);
                }
            }
        }
    }
}
