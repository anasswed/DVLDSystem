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
    public partial class frmManagePeople : Form
    {
        private bool _OnlyNumbers = false;
        private DataTable _dtPeople;
        public frmManagePeople()
        {
            InitializeComponent();
            
        }
        
        private void _LoadDataOnForm()
        {
           _dtPeople = clsPeople.GetAllPeople();
            dgvListPeople.DataSource = _dtPeople;
            dgvListPeople.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            lblNumberOfRecord.Text = _dtPeople.DefaultView.Count.ToString();

            
            tbFilterBy.Visible = false;

           foreach(DataGridViewColumn column in dgvListPeople.Columns)
            {
                cbFilterItems.Items.Add(column.Name);
            }
            cbFilterItems.Items.Remove("ImagePath");
            cbFilterItems.Items.Remove("DateOfBirth");
            cbFilterItems.Items.Remove("Address");
            cbFilterItems.Items.Remove("NationalityCountryID");

            cbFilterItems.Items.Add("None");
            cbFilterItems.SelectedItem = "None";

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _LoadDataOnForm();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterItems.SelectedItem.ToString()!="None")
            { 
                tbFilterBy.Visible = true;
            }
            if(cbFilterItems.SelectedItem.ToString()=="PersonID")
            {
                _OnlyNumbers = true;
            }
            else
            {
                _OnlyNumbers = false;
            }

        }

        private void _ChechTypeOfFiltering()
        {


            if (cbFilterItems.SelectedItem.ToString() == "PersonID")
            {
                _dtPeople.DefaultView.RowFilter=$"PersonID={Convert.ToInt32(tbFilterBy.Text)}";
                lblNumberOfRecord.Text = _dtPeople.DefaultView.Count.ToString();
            }
            else if (cbFilterItems.SelectedItem.ToString() == "NationalNo")
            {
                _dtPeople.DefaultView.RowFilter = $"NationalNo LIKE'%{tbFilterBy.Text}%'";
                lblNumberOfRecord.Text = _dtPeople.DefaultView.Count.ToString();

            }
            else if (cbFilterItems.SelectedItem.ToString() == "FirstName")
            {
                _dtPeople.DefaultView.RowFilter = $"FirstName LIKE'%{tbFilterBy.Text}%'";
                lblNumberOfRecord.Text = _dtPeople.DefaultView.Count.ToString();
            }
            else if (cbFilterItems.SelectedItem.ToString() == "LastName")
            {
                _dtPeople.DefaultView.RowFilter = $"LastName LIKE'%{tbFilterBy.Text}%'";
                lblNumberOfRecord.Text = _dtPeople.DefaultView.Count.ToString();
            }
            else if (cbFilterItems.SelectedItem.ToString() == "SecondName")
            {
                _dtPeople.DefaultView.RowFilter = $"SecondName LIKE'%{tbFilterBy.Text}%'";
                lblNumberOfRecord.Text = _dtPeople.DefaultView.Count.ToString();
            }
            else if (cbFilterItems.SelectedItem.ToString() == "ThirdName")
            {
                _dtPeople.DefaultView.RowFilter = $"ThirdName='{tbFilterBy.Text}'";
                lblNumberOfRecord.Text = _dtPeople.DefaultView.Count.ToString();
            }
            else if (cbFilterItems.SelectedItem.ToString() == "Nationality")
            {
                _dtPeople.DefaultView.RowFilter = $"Nationality='{tbFilterBy.Text}'";
                lblNumberOfRecord.Text = _dtPeople.DefaultView.Count.ToString();
            }
            else if (cbFilterItems.SelectedItem.ToString() == "Gendor")
            {
                _dtPeople.DefaultView.RowFilter = $"Gendor={Convert.ToInt16(tbFilterBy.Text)}";
                lblNumberOfRecord.Text = _dtPeople.DefaultView.Count.ToString();
            }
            else if (cbFilterItems.SelectedItem.ToString() == "Phone")
            {
                _dtPeople.DefaultView.RowFilter = $"Phone LIKE'%{tbFilterBy.Text}%'";
                lblNumberOfRecord.Text = _dtPeople.DefaultView.Count.ToString();
            }
            else if (cbFilterItems.SelectedItem.ToString() == "Email")
            {
                _dtPeople.DefaultView.RowFilter = $"Email LIKE '%{tbFilterBy.Text}%'";
                lblNumberOfRecord.Text = _dtPeople.DefaultView.Count.ToString();
            }

        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (tbFilterBy.Text != "")
            {
                _ChechTypeOfFiltering();
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblNumberOfRecord.Text = _dtPeople.Rows.Count.ToString();
            }
           
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_OnlyNumbers)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(-1);
            frm.ShowDialog();
            if(frm.IsSave)
            {
                _dtPeople = clsPeople.GetAllPeople();
                dgvListPeople.DataSource = _dtPeople;
                lblNumberOfRecord.Text = _dtPeople.Rows.Count.ToString();
            }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(-1);
            frm.ShowDialog();
          
           
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID =Convert.ToInt32(dgvListPeople.CurrentRow.Cells[0].Value);
            if (clsPeople.IsPersonExist(PersonID))
            {
                frmAddEditPersonInfo frm = new frmAddEditPersonInfo(PersonID);
                frm.ShowDialog();

                if (frm.IsSave)
                {
                    _dtPeople = clsPeople.GetAllPeople();
                    dgvListPeople.DataSource = _dtPeople;
                }
            }
            else
            {
                MessageBox.Show("The person isnt found!");
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvListPeople.CurrentRow.Cells[0].Value);
            if(clsPeople.IsPersonExist(PersonID))
            {
                if (clsPeople.DeletePerson(PersonID))
                {
                    MessageBox.Show("The person deleted successfully", "Deleting Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _dtPeople = clsPeople.GetAllPeople();
                    dgvListPeople.DataSource = _dtPeople;
                    lblNumberOfRecord.Text = _dtPeople.Rows.Count.ToString();
                }
                else
                {
                    MessageBox.Show("The person isnt deleted", "Deleting person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There is an error occur");
            }
        

        
            
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dgvListPeople.CurrentRow.Cells[0].Value);
            if (clsPeople.IsPersonExist(personID)) {
                frmPersonDetails frm = new frmPersonDetails(personID);
                frm.ShowDialog();
                _dtPeople = clsPeople.GetAllPeople();
                dgvListPeople.DataSource = _dtPeople;
                    }
            else
            {
                MessageBox.Show("The person isnt found");
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

            this.BackColor = MainBackground;
            this.ForeColor = DarkText;

            // Title
            this.label1.ForeColor = Gold;
            this.label1.Font = new Font(
                "Segoe UI Semibold",
                23F,
                FontStyle.Bold);

            // Filter
            this.label2.ForeColor = SecondaryText;
            this.label2.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            this.cbFilterItems.BackColor = SurfaceColor;
            this.cbFilterItems.ForeColor = DarkText;
            this.cbFilterItems.Font = new Font("Segoe UI", 9.5F);
            this.cbFilterItems.FlatStyle = FlatStyle.Flat;

            this.tbFilterBy.BackColor = SurfaceColor;
            this.tbFilterBy.ForeColor = DarkText;
            this.tbFilterBy.Font = new Font("Segoe UI", 9.5F);

            // DataGridView
            this.dgvListPeople.BackgroundColor = SurfaceColor;
            this.dgvListPeople.BorderStyle = BorderStyle.None;
            this.dgvListPeople.GridColor =
                Color.FromArgb(225, 228, 233);

            this.dgvListPeople.EnableHeadersVisualStyles = false;

            this.dgvListPeople.ColumnHeadersDefaultCellStyle.BackColor =
                HeaderColor;

            this.dgvListPeople.ColumnHeadersDefaultCellStyle.ForeColor =
                HeaderText;

            this.dgvListPeople.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI Semibold", 9F, FontStyle.Bold);

            this.dgvListPeople.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            this.dgvListPeople.DefaultCellStyle.BackColor =
                SurfaceColor;

            this.dgvListPeople.DefaultCellStyle.ForeColor =
                DarkText;

            this.dgvListPeople.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            this.dgvListPeople.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(255, 243, 205);

            this.dgvListPeople.DefaultCellStyle.SelectionForeColor =
                DarkText;

            this.dgvListPeople.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 249, 251);

            // Records
            this.label3.ForeColor = SecondaryText;
            this.label3.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            this.lblNumberOfRecord.ForeColor = Gold;
            this.lblNumberOfRecord.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            // Add Person Button
            this.button1.BackColor = Gold;
            this.button1.ForeColor = Color.White;
            this.button1.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = GoldHover;

            // Picture
            this.pictureBox1.BackColor = SurfaceColor;

            // Context Menu
            this.cmsPersonOptions.BackColor = SurfaceColor;
            this.cmsPersonOptions.ForeColor = DarkText;
            this.cmsPersonOptions.Font = new Font("Segoe UI", 9F);

            ApplyContextMenuTheme(
                this.cmsPersonOptions.Items,
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
                item.Font = new Font("Segoe UI", 9F);

                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem menuItem = (ToolStripMenuItem)item;

                    menuItem.DropDown.BackColor = BackgroundColor;

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
