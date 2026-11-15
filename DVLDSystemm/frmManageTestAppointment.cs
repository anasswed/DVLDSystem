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
    public partial class frmManageTestAppointment : Form
    {

        public bool IsDataUpdated = false;
        public clsLocalDrivingLicense _LocalLicense;
        private DataTable _dtTestAppointments;

        private clsTestTypes TestType;
        public frmManageTestAppointment(int LDLAppID,int TestTypeID)
        {
            InitializeComponent();
            
            _LocalLicense = clsLocalDrivingLicense.FindLocalDrivingLicenseApp(LDLAppID);
            TestType = clsTestTypes.FindTestTypeByID(TestTypeID);
            if (TestTypeID==1)
            {
                this.Text = "Vision Test Appointments";
                lblTestTypeName.Text = "Vision Test Appointments";
            }
            else if(TestTypeID==2)
            {
                this.Text = "Written Test Appointments";
                lblTestTypeName.Text = "Written Test Appointments";
            }
            else if(TestTypeID==3)
            {
                this.Text = "Street Test Appointments";
                lblTestTypeName.Text = "Street Test Appointments";
            }
            
            
        }

        private void frmManageTestAppointment_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseAppInfoAndAppIInfo1._LoadDataOnControls(_LocalLicense);
            _dtTestAppointments = clsTestAppointments.GetAppointmentsForPerson(_LocalLicense.LocalDrivingLicenseID,TestType.TestTypeID);
            dataGridView1.DataSource = _dtTestAppointments;
            lblRecordResult.Text = _dtTestAppointments.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clsTestAppointments.IsPersonHaveActiveTestAppointment(_LocalLicense.LocalDrivingLicenseID,TestType.TestTypeID))
            {
                MessageBox.Show("The person already have an active appointment for this test,you cant add a new appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (clsTests.IsPersonPassedTest(_LocalLicense.LocalDrivingLicenseID, TestType.TestTypeID))
            {
                MessageBox.Show("The person already passed this test,you can only retake faild test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (clsTests.IsPersonFailedInTest(_LocalLicense.LocalDrivingLicenseID, TestType.TestTypeID))
            {
                frmSceduleTest frm = new frmSceduleTest(TestType, -1, _LocalLicense, true);
                frm.ShowDialog();
                if (frm.IsDataUpdated)
                {
                   
                    _dtTestAppointments = clsTestAppointments.GetAppointmentsForPerson(_LocalLicense.LocalDrivingLicenseID, TestType.TestTypeID);
                    lblRecordResult.Text = _dtTestAppointments.Rows.Count.ToString();
                    dataGridView1.DataSource = _dtTestAppointments;
                }
            }
            else
            {
                frmSceduleTest frm = new frmSceduleTest(TestType,-1,_LocalLicense,false);
                frm.ShowDialog();
                if(frm.IsDataUpdated)
                {
                  
                    _dtTestAppointments = clsTestAppointments.GetAppointmentsForPerson(_LocalLicense.LocalDrivingLicenseID, TestType.TestTypeID);
                    lblRecordResult.Text = _dtTestAppointments.Rows.Count.ToString();
                    dataGridView1.DataSource = _dtTestAppointments;
                }
            }
        }

        private void ctrlDrivingLicenseAppInfoAndAppIInfo1_Load(object sender, EventArgs e)
        {

        }

        private void editTestAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
           
                frmSceduleTest frm = new frmSceduleTest(TestType, TestAppointmentID, _LocalLicense, false);
                frm.ShowDialog();
                if (frm.IsDataUpdated)
                {
                    _dtTestAppointments = clsTestAppointments.GetAppointmentsForPerson(_LocalLicense.LocalDrivingLicenseID, TestType.TestTypeID);

                    dataGridView1.DataSource = _dtTestAppointments;
                }
            
           

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
            int TestAppointmentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DateTime AppointmentDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[1].Value);
            if (DateTime.Today == AppointmentDate.Date)
            {
                if (!clsTestAppointments.IsTestLocked(TestAppointmentID))
                {
                    frmTakeTest frm = new frmTakeTest(TestAppointmentID);
                    frm.ShowDialog();
                    if (frm.IsDataUpdated)
                    {
                        _dtTestAppointments = clsTestAppointments.GetAppointmentsForPerson(_LocalLicense.LocalDrivingLicenseID, TestType.TestTypeID);
                        dataGridView1.DataSource = _dtTestAppointments;
                    }
                    if (frm.IsPassed)
                    {
                        this.IsDataUpdated = true;
                        ctrlDrivingLicenseAppInfoAndAppIInfo1.UpdatePassedTest();
                    }
                }
                else
                {
                    MessageBox.Show("The person is already sat for this test", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The appointment date hasnt came yet!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // MAIN TITLE
            // =========================

            this.lblTestTypeName.ForeColor = Gold;

            this.lblTestTypeName.Font =
                new Font(
                    "Segoe UI Semibold",
                    24F,
                    FontStyle.Bold);


            // =========================
            // APPOINTMENTS LABEL
            // =========================

            this.label2.ForeColor = SecondaryText;

            this.label2.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);


            // =========================
            // ADD APPOINTMENT BUTTON
            // =========================

            this.button1.BackColor = Gold;
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
                GoldHover;


            // =========================
            // DATA GRID VIEW
            // =========================

            this.dataGridView1.BackgroundColor =
                SurfaceColor;

            this.dataGridView1.BorderStyle =
                BorderStyle.None;

            this.dataGridView1.GridColor =
                Color.FromArgb(225, 228, 233);

            this.dataGridView1.EnableHeadersVisualStyles =
                false;


            // =========================
            // HEADER
            // =========================

            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                HeaderColor;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                HeaderText;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI Semibold",
                    9F,
                    FontStyle.Bold);

            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            // =========================
            // ROWS
            // =========================

            this.dataGridView1.DefaultCellStyle.BackColor =
                SurfaceColor;

            this.dataGridView1.DefaultCellStyle.ForeColor =
                DarkText;

            this.dataGridView1.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F);

            this.dataGridView1.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(255, 243, 205);

            this.dataGridView1.DefaultCellStyle.SelectionForeColor =
                DarkText;

            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 249, 251);


            // =========================
            // RECORD COUNT
            // =========================

            this.label3.ForeColor = SecondaryText;

            this.label3.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);


            this.lblRecordResult.ForeColor = Gold;

            this.lblRecordResult.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);


            // =========================
            // CONTEXT MENU
            // =========================

            this.contextMenuStrip1.BackColor =
                SurfaceColor;

            this.contextMenuStrip1.ForeColor =
                DarkText;

            this.contextMenuStrip1.Font =
                new Font(
                    "Segoe UI",
                    9F);


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
                    new Font(
                        "Segoe UI",
                        9F);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
