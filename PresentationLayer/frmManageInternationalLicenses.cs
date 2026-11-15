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
    public partial class frmManageInternationalLicenses : Form
    {
        private int PersonID;
        private DataTable _dtListInternationalLicensesApplication;
        public frmManageInternationalLicenses()
        {
            InitializeComponent();
            
        }
        private void _LoadListOfInternationalLicenseApplication()
        {
            _dtListInternationalLicensesApplication = clsInternationalLicenses.GetListOfAllInternationalLicsesesApplications();
            dataGridView1.DataSource = _dtListInternationalLicensesApplication;
            lblRecordResult.Text = _dtListInternationalLicensesApplication.Rows.Count.ToString();

            foreach(DataColumn column in _dtListInternationalLicensesApplication.Columns)
            {
                cbFilterBy.Items.Add(column.ColumnName);
            }
            tbFilterBy.Visible = false;
            cbFilterBy.Items.Remove("Issue Date");
            cbFilterBy.Items.Remove("Expiration Date");
            cbFilterBy.Items.Remove("Is Active");
            cbFilterBy.Items.Add("None");
            cbFilterBy.SelectedItem = "None";
        }

        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _LoadListOfInternationalLicenseApplication();

            

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedItem.ToString()!="None")
            {
                tbFilterBy.Visible = true;
            }
        }

        private void _CheckTypeOfFiltering()
        {
            if (cbFilterBy.SelectedItem.ToString()== "int.License ID")
            {
                _dtListInternationalLicensesApplication.DefaultView.RowFilter = $"[int.License ID]={Convert.ToInt32(tbFilterBy.Text)}";
                lblRecordResult.Text = _dtListInternationalLicensesApplication.DefaultView.Count.ToString();
            }
            else if (cbFilterBy.SelectedItem.ToString() == "Application ID")
            {
                _dtListInternationalLicensesApplication.DefaultView.RowFilter = $"[Application ID]={Convert.ToInt32(tbFilterBy.Text)}";
                lblRecordResult.Text = _dtListInternationalLicensesApplication.DefaultView.Count.ToString();
            }
            else if (cbFilterBy.SelectedItem.ToString() == "L.License ID")
            {
                _dtListInternationalLicensesApplication.DefaultView.RowFilter = $"[L.License ID]={Convert.ToInt32(tbFilterBy.Text)}";
                lblRecordResult.Text = _dtListInternationalLicensesApplication.DefaultView.Count.ToString();
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
                _dtListInternationalLicensesApplication.DefaultView.RowFilter = "";
                lblRecordResult.Text = _dtListInternationalLicensesApplication.Rows.Count.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddInternationalLicense frm = new frmAddInternationalLicense();
            frm.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsDrivers.GetPersonIDOfDriver(Convert.ToInt32(dataGridView1.CurrentRow.Cells["Driver ID"].Value));
          
            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
           

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["L.License ID"].Value);
            frmDrivingLicenseInfo frm = new frmDrivingLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsDrivers.GetPersonIDOfDriver(Convert.ToInt32(dataGridView1.CurrentRow.Cells["Driver ID"].Value));
            frmHistoryLicenses frm = new frmHistoryLicenses(PersonID);
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
            // MAIN TITLE
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
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.label3.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);


            // =========================
            // FILTER COMBOBOX
            // =========================

            this.cbFilterBy.BackColor = SurfaceColor;
            this.cbFilterBy.ForeColor = DarkText;

            this.cbFilterBy.Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            this.cbFilterBy.FlatStyle =
                FlatStyle.Flat;


            // =========================
            // FILTER TEXTBOX
            // =========================

            this.tbFilterBy.BackColor = SurfaceColor;
            this.tbFilterBy.ForeColor = DarkText;

            this.tbFilterBy.Font =
                new Font(
                    "Segoe UI",
                    9.5F);


            // =========================
            // ADD APPLICATION BUTTON
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
    }
}
