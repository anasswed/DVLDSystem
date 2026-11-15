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
    public partial class frmManageLocalDrivingLicenseApplication : Form
    {
        private DataTable _dtListLocalDrivingLicenseApplication;

        private enum enTestType { Vision=1,Written=2,Street=3 }

        private enTestType _TestType;

       

        public frmManageLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            
        }

        private void frmManageLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _dtListLocalDrivingLicenseApplication = clsLocalDrivingLicense.GetAllDrivingLicenseApplication();
            dgvListAllLocalDrivingLicenseApp.DataSource = _dtListLocalDrivingLicenseApplication;
            dgvListAllLocalDrivingLicenseApp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            tbFilterBy.Visible = false;
            cbFilterBy.Items.Add("None");
            cbFilterBy.SelectedItem = "None";
            cbFilterBy.Items.Add("NationalNo");
            cbFilterBy.Items.Add("L.D.L.AppID");
            cbFilterBy.Items.Add("Full Name");
            cbFilterBy.Items.Add("Status");
            lblRecordResult.Text = _dtListLocalDrivingLicenseApplication.Rows.Count.ToString();
            

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedItem.ToString()!="None")
            {
                tbFilterBy.Visible = true;
            }
            else
            {
                tbFilterBy.Visible = false;
            }
        }
        private void _CheckTypeOfFiltering()
        {
            if (cbFilterBy.SelectedItem.ToString() == "NationalNo")
            {
                _dtListLocalDrivingLicenseApplication.DefaultView.RowFilter = $"NationalNo Like'%{tbFilterBy.Text}%'";
                lblRecordResult.Text = _dtListLocalDrivingLicenseApplication.DefaultView.Count.ToString();

            }
            else if (cbFilterBy.SelectedItem.ToString() =="L.D.L.AppID")
            {
                _dtListLocalDrivingLicenseApplication.DefaultView.RowFilter = $"[L.D.L.AppID]={Convert.ToUInt32(tbFilterBy.Text)}";
                lblRecordResult.Text = _dtListLocalDrivingLicenseApplication.DefaultView.Count.ToString();
            }
            else if(cbFilterBy.SelectedItem.ToString()=="Full Name")
            {
                _dtListLocalDrivingLicenseApplication.DefaultView.RowFilter = $"[Full Name] Like'%{tbFilterBy.Text}%'";
                lblRecordResult.Text = _dtListLocalDrivingLicenseApplication.DefaultView.Count.ToString();
            }
            else if(cbFilterBy.SelectedItem.ToString()=="Status")
            {
                _dtListLocalDrivingLicenseApplication.DefaultView.RowFilter = $"Status Like '%{tbFilterBy.Text}%'";
                lblRecordResult.Text = _dtListLocalDrivingLicenseApplication.DefaultView.Count.ToString();
            }
        }
        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tbFilterBy.Text))
            {
                _CheckTypeOfFiltering();
            }
            else
            {
                _dtListLocalDrivingLicenseApplication.DefaultView.RowFilter = "";
                lblRecordResult.Text = _dtListLocalDrivingLicenseApplication.Rows.Count.ToString();
            }
        }

        private void btnAddLocalLicenseApplication_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicense frm = new frmNewLocalDrivingLicense(-1);
            frm.ShowDialog();
            if(frm.IsDataUpdated)
            {
                _dtListLocalDrivingLicenseApplication = clsLocalDrivingLicense.GetAllDrivingLicenseApplication();
                dgvListAllLocalDrivingLicenseApp.DataSource = _dtListLocalDrivingLicenseApplication;
                lblRecordResult.Text = _dtListLocalDrivingLicenseApplication.Rows.Count.ToString();
            }
        }

        private void cancleApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvListAllLocalDrivingLicenseApp.CurrentRow.Cells[0].Value);
            if(MessageBox.Show("Are you sure you want to cancle Application ?","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Information)==DialogResult.OK)
            {
                if(clsLocalDrivingLicense.CancleApplication(LDLAppID))
                {
                    MessageBox.Show("The Application Cancled Successfully", "Cancling Appliction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _dtListLocalDrivingLicenseApplication = clsLocalDrivingLicense.GetAllDrivingLicenseApplication();
                    dgvListAllLocalDrivingLicenseApp.DataSource = _dtListLocalDrivingLicenseApplication;
                }
            }
            else
            {
                MessageBox.Show("You reject to perform a process");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvListAllLocalDrivingLicenseApp.CurrentRow.Cells[0].Value);
            int ApplicationID = clsLocalDrivingLicense.GetApplicationID(LDLAppID);
            if (MessageBox.Show("Are you sure you want to delete this application ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsLocalDrivingLicense.DeleteLocalDrivingLicenseApp(LDLAppID))
                {
                   
                    if (clsApplications.DeleteApplication(ApplicationID))
                    {
                        MessageBox.Show("The application deleted successfully", "Deleting Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _dtListLocalDrivingLicenseApplication = clsLocalDrivingLicense.GetAllDrivingLicenseApplication();
                        dgvListAllLocalDrivingLicenseApp.DataSource = _dtListLocalDrivingLicenseApplication;
                        lblRecordResult.Text = _dtListLocalDrivingLicenseApplication.Rows.Count.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("The application wasnt deleted");
                }
            }
            else
            {
                MessageBox.Show("You reject to perform this process");
            }
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvListAllLocalDrivingLicenseApp.CurrentRow.Cells[0].Value);
            frmNewLocalDrivingLicense frm = new frmNewLocalDrivingLicense(LDLAppID);
            frm.ShowDialog();
            if(frm.IsDataUpdated)
            {
                _dtListLocalDrivingLicenseApplication = clsLocalDrivingLicense.GetAllDrivingLicenseApplication();
                dgvListAllLocalDrivingLicenseApp.DataSource = _dtListLocalDrivingLicenseApplication;
            }
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvListAllLocalDrivingLicenseApp.CurrentRow.Cells[0].Value);
            int TestTypeID = (int)enTestType.Vision;
            frmManageTestAppointment frm = new frmManageTestAppointment(LDLAppID,TestTypeID);
            frm.ShowDialog();
            if (frm.IsDataUpdated)
            {
                _dtListLocalDrivingLicenseApplication = clsLocalDrivingLicense.GetAllDrivingLicenseApplication();
                dgvListAllLocalDrivingLicenseApp.DataSource = _dtListLocalDrivingLicenseApplication;
            }
        }
        private void _BackToDefaultStatus()
        {
            cancleApplicationToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = true;
            deleteToolStripMenuItem.Enabled = true;
            scheduleTestsToolStripMenuItem.Enabled = true;
            scheduleVisionTestToolStripMenuItem.Enabled = true;
            scheduleWrittenTestToolStripMenuItem.Enabled = false;
            scheduleStreetTestToolStripMenuItem.Enabled = false;

            issueDrivingToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;

        }

        private void _CheckStatusOfMenuStrip(int TestPassed,string Status)
        {
            if (TestPassed == 0)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = true;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
            }
            else if (TestPassed == 1)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;

                scheduleWrittenTestToolStripMenuItem.Enabled = true;
            }
            else if (TestPassed == 2)
            {
                scheduleWrittenTestToolStripMenuItem.Enabled = false;
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = true;
            }
            else if (TestPassed == 3 && Status != "Completed")
            {

                scheduleTestsToolStripMenuItem.Enabled = false;
                issueDrivingToolStripMenuItem.Enabled = true;
            }
            else if (TestPassed == 3 && Status == "Completed")
            {
                issueDrivingToolStripMenuItem.Enabled = false;
                cancleApplicationToolStripMenuItem.Enabled = false;
                scheduleTestsToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = true;
            }
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
      
            int TestPassed = Convert.ToInt32(dgvListAllLocalDrivingLicenseApp.CurrentRow.Cells["Passed Tests"].Value);
            string Status = dgvListAllLocalDrivingLicenseApp.CurrentRow.Cells["Status"].Value.ToString();
            _BackToDefaultStatus();
            _CheckStatusOfMenuStrip(TestPassed,Status);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvListAllLocalDrivingLicenseApp.CurrentRow.Cells[0].Value);
            int TestTypeID = (int)enTestType.Written;
            frmManageTestAppointment frm = new frmManageTestAppointment(LDLAppID,TestTypeID );
            frm.ShowDialog();
            if(frm.IsDataUpdated)
            {

                _dtListLocalDrivingLicenseApplication = clsLocalDrivingLicense.GetAllDrivingLicenseApplication();
                dgvListAllLocalDrivingLicenseApp.DataSource = _dtListLocalDrivingLicenseApplication;
            }
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvListAllLocalDrivingLicenseApp.CurrentRow.Cells[0].Value);
            int TestTypeID = (int)enTestType.Street;
            frmManageTestAppointment frm = new frmManageTestAppointment(LDLAppID,TestTypeID);
            frm.ShowDialog();
            if (frm.IsDataUpdated)
            {

                _dtListLocalDrivingLicenseApplication = clsLocalDrivingLicense.GetAllDrivingLicenseApplication();
                dgvListAllLocalDrivingLicenseApp.DataSource = _dtListLocalDrivingLicenseApplication;
            }

        }

        private void issueDrivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvListAllLocalDrivingLicenseApp.CurrentRow.Cells[0].Value);
            frmIssueDrivingLicenseForTheFirstTime frm = new frmIssueDrivingLicenseForTheFirstTime(LDLAppID);
            frm.ShowDialog();
            if(frm.IsLicenseIssued)
            {
                _dtListLocalDrivingLicenseApplication = clsLocalDrivingLicense.GetAllDrivingLicenseApplication();
                dgvListAllLocalDrivingLicenseApp.DataSource = _dtListLocalDrivingLicenseApplication;
            }
           
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsPeople.GetPersonIDByNationalNo(dgvListAllLocalDrivingLicenseApp.CurrentRow.Cells[2].Value.ToString());
            frmHistoryLicenses frm = new frmHistoryLicenses(PersonID);
            frm.ShowDialog();
            
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvListAllLocalDrivingLicenseApp.CurrentRow.Cells[0].Value);
            int ApplicationID = clsLocalDrivingLicense.GetApplicationID(LDLAppID);
            int LicenseID = clsLicenses.GetLicenseIDByApplicationID(ApplicationID);
            frmDrivingLicenseInfo frm = new frmDrivingLicenseInfo(LicenseID);
            frm.ShowDialog();
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

            this.label1.ForeColor = Gold;

            this.label1.Font =
                new Font(
                    "Segoe UI Semibold",
                    24F,
                    FontStyle.Bold);


            // =========================
            // FILTER LABELS
            // =========================

            this.label2.ForeColor = SecondaryText;
            this.label3.ForeColor = SecondaryText;

            this.label2.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            this.label3.Font =
                new Font("Segoe UI Semibold", 10F, FontStyle.Bold);


            // =========================
            // FILTER COMBOBOX
            // =========================

            this.cbFilterBy.BackColor = SurfaceColor;
            this.cbFilterBy.ForeColor = DarkText;

            this.cbFilterBy.Font =
                new Font("Segoe UI", 9.5F);

            this.cbFilterBy.FlatStyle = FlatStyle.Flat;


            // =========================
            // FILTER TEXTBOX
            // =========================

            this.tbFilterBy.BackColor = SurfaceColor;
            this.tbFilterBy.ForeColor = DarkText;

            this.tbFilterBy.Font =
                new Font("Segoe UI", 9.5F);


            // =========================
            // ADD BUTTON
            // =========================

            this.btnAddLocalLicenseApplication.BackColor = Gold;
            this.btnAddLocalLicenseApplication.ForeColor =
                Color.FromArgb(25, 25, 25);

            this.btnAddLocalLicenseApplication.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.btnAddLocalLicenseApplication.FlatStyle =
                FlatStyle.Flat;

            this.btnAddLocalLicenseApplication.FlatAppearance.BorderSize = 0;

            this.btnAddLocalLicenseApplication.FlatAppearance.MouseOverBackColor =
                GoldHover;


            // =========================
            // RECORD COUNT
            // =========================

            this.lblRecordResult.ForeColor = Gold;

            this.lblRecordResult.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);


            // =========================
            // DATA GRID VIEW
            // =========================

            this.dgvListAllLocalDrivingLicenseApp.BackgroundColor =
                SurfaceColor;

            this.dgvListAllLocalDrivingLicenseApp.BorderStyle =
                BorderStyle.None;

            this.dgvListAllLocalDrivingLicenseApp.GridColor =
                Color.FromArgb(225, 228, 233);

            this.dgvListAllLocalDrivingLicenseApp.EnableHeadersVisualStyles =
                false;


            // Header

            this.dgvListAllLocalDrivingLicenseApp.ColumnHeadersDefaultCellStyle.BackColor =
                HeaderColor;

            this.dgvListAllLocalDrivingLicenseApp.ColumnHeadersDefaultCellStyle.ForeColor =
                HeaderText;

            this.dgvListAllLocalDrivingLicenseApp.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.dgvListAllLocalDrivingLicenseApp.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            // Rows

            this.dgvListAllLocalDrivingLicenseApp.DefaultCellStyle.BackColor =
                SurfaceColor;

            this.dgvListAllLocalDrivingLicenseApp.DefaultCellStyle.ForeColor =
                DarkText;

            this.dgvListAllLocalDrivingLicenseApp.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            this.dgvListAllLocalDrivingLicenseApp.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(255, 243, 205);

            this.dgvListAllLocalDrivingLicenseApp.DefaultCellStyle.SelectionForeColor =
                DarkText;

            this.dgvListAllLocalDrivingLicenseApp.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 249, 251);


            // =========================
            // CONTEXT MENU
            // =========================

            this.contextMenuStrip1.BackColor = SurfaceColor;
            this.contextMenuStrip1.ForeColor = DarkText;

            this.contextMenuStrip1.Font =
                new Font("Segoe UI", 9F);


            ApplyContextMenuTheme(
                this.contextMenuStrip1.Items,
                DarkText,
                Gold,
                SurfaceColor);
        }
        private void ApplyContextMenuTheme(
    ToolStripItemCollection items,
    Color TextColor,
    Color GoldColor,
    Color BackgroundColor)
        {
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripSeparator)
                    continue;

                item.BackColor = BackgroundColor;
                item.ForeColor = TextColor;

                item.Font =
                    new Font("Segoe UI", 9F);

                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menuItem =
                        (ToolStripMenuItem)item;

                    menuItem.DropDown.BackColor =
                        BackgroundColor;

                    ApplyContextMenuTheme(
                        menuItem.DropDownItems,
                        TextColor,
                        GoldColor,
                        BackgroundColor);
                }
            }
        }
    }
}
