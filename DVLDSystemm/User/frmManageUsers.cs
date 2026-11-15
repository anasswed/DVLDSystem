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
    public partial class frmManageUsers : Form
    {
        private DataTable _dtUsers;
        public frmManageUsers()
        {
            InitializeComponent();
            
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            this.UseWaitCursor = false;
            Cursor.Current = Cursors.Default;
            _dtUsers = clsUsers.GetAllUsers();
            dgvUsersList.DataSource = _dtUsers;
            
           dgvUsersList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            lblRecordResult.Text = _dtUsers.Rows.Count.ToString();

            cbFilterBy.Items.Add("None");
            cbFilterBy.SelectedItem = "None";

            tbFilterBy.Visible = false;
            cbIsActive.Visible = false;
          
            foreach(DataColumn column in _dtUsers.Columns)
            {
                cbFilterBy.Items.Add(column.ColumnName);
            }
            cbIsActive.Items.Add("All");
            cbIsActive.Items.Add("Yes");
            cbIsActive.Items.Add("No");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void _CheckTypeOfFiltering()
        {

            if (cbFilterBy.SelectedItem.ToString() == "UserID")
            {
                _dtUsers.DefaultView.RowFilter = $"UserID={Convert.ToUInt32(tbFilterBy.Text)}";

                lblRecordResult.Text = _dtUsers.DefaultView .Count.ToString();
            }
            else if (cbFilterBy.SelectedItem.ToString() == "PersonID")
            {
                _dtUsers.DefaultView.RowFilter = $"PersonID={Convert.ToUInt32(tbFilterBy.Text)}";

                lblRecordResult.Text = _dtUsers.DefaultView.Count.ToString();
            }
            else if(cbFilterBy.SelectedItem.ToString()=="UserName")
            {
                _dtUsers.DefaultView.RowFilter = $"UserName= LIKE'%{tbFilterBy.Text}%'";

                lblRecordResult.Text = _dtUsers.DefaultView.Count.ToString();
            }
            else if(cbFilterBy.SelectedItem.ToString()=="FullName")
            {
                _dtUsers.DefaultView.RowFilter = $"FullName LIKE '%{tbFilterBy.Text}%'";

                lblRecordResult.Text = _dtUsers.DefaultView.Count.ToString();
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
                _dtUsers = clsUsers.GetAllUsers();
                dgvUsersList.DataSource = _dtUsers;
                lblRecordResult.Text = _dtUsers.Rows.Count.ToString();
            }
        }

        private void tbFilterBy_Validating(object sender, CancelEventArgs e)
        {

        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "UserID"|| cbFilterBy.SelectedItem.ToString() == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }
        }
        private void _CheckFilteringOfIsActive()
        {
            if (cbIsActive.SelectedItem.ToString() == "Yes")
            {
                _dtUsers.DefaultView.RowFilter = "IsActive=1";

                lblRecordResult.Text = _dtUsers.DefaultView.Count.ToString();
            }
            else if(cbIsActive.SelectedItem.ToString()=="No")
            {
                _dtUsers.DefaultView.RowFilter = "IsActive=0";

                lblRecordResult.Text = _dtUsers.DefaultView.Count.ToString();
            }
            else
            {
              _dtUsers.DefaultView.RowFilter="";
                dgvUsersList.DataSource = _dtUsers;
                lblRecordResult.Text = _dtUsers.Rows.Count.ToString();
               
            }
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedItem.ToString()!="None"&&cbFilterBy.SelectedItem.ToString()!="IsActive")
            {
                tbFilterBy.Visible =true;
                cbIsActive.Visible = false;
            }
            else if (cbFilterBy.SelectedItem.ToString() == "IsActive")
            {
                tbFilterBy.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedItem = "All";
                
            }
            else
            {
                tbFilterBy.Visible = false;
                cbIsActive.Visible = false;
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CheckFilteringOfIsActive();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmEditAddNewUser frm = new frmEditAddNewUser(-1);
            frm.ShowDialog();
            if(frm.IsDataUpdated)
            {
                _dtUsers = clsUsers.GetAllUsers();
                dgvUsersList.DataSource = _dtUsers;
                lblRecordResult.Text = _dtUsers.Rows.Count.ToString();
            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            frmEditAddNewUser frm = new frmEditAddNewUser(-1);
            frm.ShowDialog();
            if (frm.IsDataUpdated)
            {
                _dtUsers = clsUsers.GetAllUsers();
                dgvUsersList.DataSource = _dtUsers;
                lblRecordResult.Text = _dtUsers.Rows.Count.ToString();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsersList.CurrentRow.Cells[1].Value);
            if(clsUsers.IsUserExist(UserID))
            {
                frmEditAddNewUser frm = new frmEditAddNewUser(UserID);
                frm.ShowDialog();
                if(frm.IsDataUpdated)
                {
                    _dtUsers = clsUsers.GetAllUsers();
                    dgvUsersList.DataSource = _dtUsers;
                }
            }
            else
            {
                MessageBox.Show("The User isnt exist!");
            }
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsersList.CurrentRow.Cells[1].Value);
            if(clsUsers.IsUserExist(UserID))
            {
                if(clsUsers.DeleteUser(UserID))
                {
                    MessageBox.Show("The user deleted sucessfully", "Deleting user", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    _dtUsers = clsUsers.GetAllUsers();
                    dgvUsersList.DataSource = _dtUsers;
                    lblRecordResult.Text =  _dtUsers.Rows.Count.ToString();
                }
                else
                {
                    MessageBox.Show("The user wasnt deleted", "Deleting user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("User isnt exist!");
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsersList.CurrentRow.Cells[1].Value);
            if (clsUsers.IsUserExist(UserID)) {
                frmChangePassword frm = new frmChangePassword(UserID);
                frm.ShowDialog();
                }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsersList.CurrentRow.Cells[1].Value);
            frmUserInfo frm = new frmUserInfo(UserID);
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

            // Form
            this.BackColor = MainBackground;
            this.ForeColor = DarkText;

            // Title
            this.label1.ForeColor = Gold;
            this.label1.Font = new Font(
                "Segoe UI Semibold",
                24F,
                FontStyle.Bold);

            this.label1.UseWaitCursor = false;

            // Picture
            this.pictureBox1.BackColor = SurfaceColor;
            this.pictureBox1.UseWaitCursor = false;

            // Filter label
            this.label2.ForeColor = SecondaryText;
            this.label2.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            this.label2.UseWaitCursor = false;

            // Filter ComboBox
            this.cbFilterBy.BackColor = SurfaceColor;
            this.cbFilterBy.ForeColor = DarkText;
            this.cbFilterBy.Font = new Font("Segoe UI", 9.5F);
            this.cbFilterBy.FlatStyle = FlatStyle.Flat;
            this.cbFilterBy.UseWaitCursor = false;

            // Filter TextBox
            this.tbFilterBy.BackColor = SurfaceColor;
            this.tbFilterBy.ForeColor = DarkText;
            this.tbFilterBy.Font = new Font("Segoe UI", 9.5F);
            this.tbFilterBy.UseWaitCursor = false;

            // Active Filter ComboBox
            this.cbIsActive.BackColor = SurfaceColor;
            this.cbIsActive.ForeColor = DarkText;
            this.cbIsActive.Font = new Font("Segoe UI", 9.5F);
            this.cbIsActive.FlatStyle = FlatStyle.Flat;
            this.cbIsActive.UseWaitCursor = false;

            // DataGridView
            this.dgvUsersList.BackgroundColor = SurfaceColor;
            this.dgvUsersList.BorderStyle = BorderStyle.None;
            this.dgvUsersList.GridColor = Color.FromArgb(225, 228, 233);
            this.dgvUsersList.EnableHeadersVisualStyles = false;
            this.dgvUsersList.UseWaitCursor = false;

            this.dgvUsersList.ColumnHeadersDefaultCellStyle.BackColor = HeaderColor;
            this.dgvUsersList.ColumnHeadersDefaultCellStyle.ForeColor = HeaderText;
            this.dgvUsersList.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.dgvUsersList.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            this.dgvUsersList.DefaultCellStyle.BackColor = SurfaceColor;
            this.dgvUsersList.DefaultCellStyle.ForeColor = DarkText;
            this.dgvUsersList.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            this.dgvUsersList.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(255, 243, 205);

            this.dgvUsersList.DefaultCellStyle.SelectionForeColor = DarkText;

            this.dgvUsersList.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 249, 251);

            // Records
            this.label3.ForeColor = SecondaryText;
            this.label3.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            this.label3.UseWaitCursor = false;

            this.lblRecordResult.ForeColor = Gold;
            this.lblRecordResult.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            this.lblRecordResult.UseWaitCursor = false;

            // Add User
            this.btnAddNewUser.BackColor = Gold;
            this.btnAddNewUser.ForeColor = Color.White;
            this.btnAddNewUser.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);
            this.btnAddNewUser.FlatStyle = FlatStyle.Flat;
            this.btnAddNewUser.FlatAppearance.BorderSize = 0;
            this.btnAddNewUser.FlatAppearance.MouseOverBackColor = GoldHover;
            this.btnAddNewUser.UseWaitCursor = false;

            // Close
            this.btnClose.BackColor = ButtonColor;
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = ButtonHover;
            this.btnClose.UseWaitCursor = false;

            // Context Menu
            this.cmsForManageUsers.BackColor = SurfaceColor;
            this.cmsForManageUsers.ForeColor = DarkText;
            this.cmsForManageUsers.Font = new Font("Segoe UI", 9F);

            ApplyContextMenuTheme(
                this.cmsForManageUsers.Items,
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
                    ToolStripMenuItem menuItem =
                        (ToolStripMenuItem)item;

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
