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
    public partial class frmDriversList : Form
    {
        private DataTable _dtListAllDrivers;
        public frmDriversList()
        {
            InitializeComponent();
            
        }
        private void _LoadData()
        {
            _dtListAllDrivers = clsDrivers.GetListAllDrivers();
            dataGridView1.DataSource = _dtListAllDrivers;
            dataGridView1.AutoSizeColumnsMode =
    DataGridViewAutoSizeColumnsMode.Fill;
            lblRecordResult.Text = _dtListAllDrivers.Rows.Count.ToString();

            foreach(DataColumn column in _dtListAllDrivers.Columns)
            {
                cbFilterBy.Items.Add(column.ColumnName);
            }
            tbFilterBy.Visible = false;
            cbFilterBy.Items.Remove("Active Licenses");
            cbFilterBy.Items.Remove("Date");
            cbFilterBy.Items.Add("None");
            cbFilterBy.SelectedItem = "None";
        }
        private void frmDriversLise_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void _CheckTypeOfFiltering()
        {
          if(cbFilterBy.SelectedItem.ToString()=="Driver ID")
            {
                _dtListAllDrivers.DefaultView.RowFilter = $"[{cbFilterBy.SelectedItem.ToString()}]={Convert.ToInt32(tbFilterBy.Text)}";
                lblRecordResult.Text = _dtListAllDrivers.DefaultView.Count.ToString();
            }
          else if(cbFilterBy.SelectedItem.ToString()=="Person ID")
            {
                _dtListAllDrivers.DefaultView.RowFilter = $"[{cbFilterBy.SelectedItem.ToString()}]={Convert.ToInt32(tbFilterBy.Text)}";
                lblRecordResult.Text = _dtListAllDrivers.DefaultView.Count.ToString();
            }
          else if(cbFilterBy.SelectedItem.ToString()=="National No")
            {
                _dtListAllDrivers.DefaultView.RowFilter = $"[{cbFilterBy.SelectedItem.ToString()}] Like '%{tbFilterBy.Text}%'";
                lblRecordResult.Text = _dtListAllDrivers.DefaultView.Count.ToString();
            }
          else if(cbFilterBy.SelectedItem.ToString()=="Full Name")
            {
                _dtListAllDrivers.DefaultView.RowFilter = $"[{cbFilterBy.SelectedItem.ToString()}] LIKE '%{tbFilterBy.Text}%'";
                lblRecordResult.Text = _dtListAllDrivers.DefaultView.Count.ToString();
            }
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

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbFilterBy.Text))
            {
                _CheckTypeOfFiltering();
            }
            else
            {
                _dtListAllDrivers.DefaultView.RowFilter = "";
                lblRecordResult.Text = _dtListAllDrivers.Rows.Count.ToString();
            }
        }

        private void ApplyTheme()
        {
            Color MainBackground = Color.FromArgb(245, 247, 250);
            Color SurfaceColor = Color.White;

            Color DarkText = Color.FromArgb(35, 38, 45);
            Color SecondaryText = Color.FromArgb(90, 96, 105);

            Color Gold = Color.FromArgb(218, 165, 32);

            Color HeaderColor = Color.FromArgb(45, 52, 62);
            Color HeaderText = Color.White;

            this.BackColor = MainBackground;
            this.ForeColor = DarkText;

            // Title
            this.label1.ForeColor = Gold;
            this.label1.Font = new Font(
                "Segoe UI Semibold",
                24F,
                FontStyle.Bold);

            // Filter
            this.label2.ForeColor = SecondaryText;
            this.label2.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            this.cbFilterBy.BackColor = SurfaceColor;
            this.cbFilterBy.ForeColor = DarkText;
            this.cbFilterBy.Font = new Font("Segoe UI", 9.5F);
            this.cbFilterBy.FlatStyle = FlatStyle.Flat;

            this.tbFilterBy.BackColor = SurfaceColor;
            this.tbFilterBy.ForeColor = DarkText;
            this.tbFilterBy.Font = new Font("Segoe UI", 9.5F);

            // DataGridView
            this.dataGridView1.BackgroundColor = SurfaceColor;
            this.dataGridView1.BorderStyle = BorderStyle.None;
            this.dataGridView1.GridColor =
                Color.FromArgb(225, 228, 233);

            this.dataGridView1.EnableHeadersVisualStyles = false;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                HeaderColor;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                HeaderText;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI Semibold", 9F, FontStyle.Bold);

            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView1.DefaultCellStyle.BackColor =
                SurfaceColor;

            this.dataGridView1.DefaultCellStyle.ForeColor =
                DarkText;

            this.dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            this.dataGridView1.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(255, 243, 205);

            this.dataGridView1.DefaultCellStyle.SelectionForeColor =
                DarkText;

            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 249, 251);

            // Records
            this.label3.ForeColor = SecondaryText;
            this.label3.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            this.lblRecordResult.ForeColor = Gold;
            this.lblRecordResult.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
