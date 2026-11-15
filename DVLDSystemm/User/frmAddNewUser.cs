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
    public partial class frmEditAddNewUser : Form
    {
        private clsPeople _Person;

        private clsUsers _User;

        public bool IsDataUpdated = false;

        private enum enMode { UpdateUser,AddNewUser};

        private enMode _Mode;
        public frmEditAddNewUser(int UserID)
        {
            InitializeComponent();
            
            if(UserID==-1)
            {
                _Mode = enMode.AddNewUser;
                
            }
            else
            {
                _Mode = enMode.UpdateUser;
                lblAddEditUser.Text = "Update User";
                gbFindBy.Enabled = false;
                linkLabel1.Enabled = true;
                _User = clsUsers.FindUser(UserID);
            }
        }

       
        private void _LoadDataOnControls(clsUsers User)
        {
            ctrlPersonDetails1._LoadDataOnControls(User.Person);
            tbUserName.Text = User.UserName;
            lblUserID.Text = User.UserID.ToString();
            tbPassword.Text = User.Password;
            tbConfirmPassword.Text = User.Password;
            cbIsActive.Checked = User.IsActive;
        }
        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            this.UseWaitCursor = false;
            Cursor.Current = Cursors.Default;
            cbFindBy.Items.Add("NationalNo");
            cbFindBy.Items.Add("PersonID");
            cbFindBy.SelectedItem = "NationalNo";
            if (_Mode == enMode.UpdateUser)
            {
                linkLabel1.Enabled = true;
                _LoadDataOnControls(_User);
            }
            else
            {
                linkLabel1.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
         
            if (cbFindBy.SelectedItem.ToString() == "NationalNo")
            {
                _Person= clsPeople.FindPersonByNationalNo(tbFindBy.Text);
            }
            else
            {
                _Person = clsPeople.FindPerson(Convert.ToInt32(tbFindBy.Text));
            }
            if (_Person!=null)
            {
                
                ctrlPersonDetails1._LoadDataOnControls(_Person);
                linkLabel1.Enabled = true;
            }
            else
            {
                MessageBox.Show("The person isnt found", "Searching on person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonDetails1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNewUser && _Person != null)
            {
                if (clsUsers.IsPersonUser(_Person.PersonID))
                {
                    MessageBox.Show("Selected Person is already user , choose another one", "Connecting person and user", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else
                {
                    tabControl1.SelectedTab = tapLoginInfo;
                }
            }
            else if(_Mode==enMode.UpdateUser)
            {
                tabControl1.SelectedTab = tapLoginInfo;
            }
            else
            {
                MessageBox.Show("You didnt search on person");
            }
            
        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbUserName.Text))
            {
                errorProvider1.SetError(tbUserName, "This field is obligatory");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbUserName, "");
                e.Cancel = false;
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbPassword.Text))
            {
                errorProvider1.SetError(tbPassword, "This field is obligatory");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbPassword, "");
                e.Cancel = false;
            }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
          
                if(tbConfirmPassword.Text!=tbPassword.Text&&!string.IsNullOrEmpty(tbConfirmPassword.Text))
                {
                    errorProvider1.SetError(tbConfirmPassword, "The password confirmation doesnt match the password");
                    e.Cancel = true;
                }
                else
                {
                if (string.IsNullOrEmpty(tbConfirmPassword.Text))
                {
                    errorProvider1.SetError(tbConfirmPassword, "This field is obligatory");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(tbConfirmPassword, "");
                    e.Cancel = false;
                }
                }
            
        }

        private clsUsers _GetUserDataFromControls()
        {
            clsUsers User = new clsUsers();
            User.Person = _Person;
            if (cbIsActive.Checked)
            {
                User.IsActive = true;
            }
            else
            {
                User.IsActive = false;
            }
            User.PersonID = _Person.PersonID;
            User.UserName = tbUserName.Text;
            User.Password = tbPassword.Text;
            return User;
        }

        private void _GetUserDataFromControlsForUpdateMode(clsUsers User)
        {
            User.UserName = tbUserName.Text;
            User.Password = tbPassword.Text;
            if(cbIsActive.Checked)
            {
                User.IsActive = true;

            }
            else
            {
                User.IsActive = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (_Mode)
            {
                case enMode.AddNewUser:
                    {
                        _User = _GetUserDataFromControls();
                        if(_User.SaveUser())
                        {
                            _Mode = enMode.UpdateUser;
                            lblAddEditUser.Text = "Update User Info";
                            lblUserID.Text = _User.UserID.ToString();
                            IsDataUpdated = true;
                            MessageBox.Show("The user added successfully", "Adding User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                        }
                        else
                        {
                            MessageBox.Show("There is an error occur !", "Adding User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                
                        }

                    }break;
                case enMode.UpdateUser:
                    {
                        _GetUserDataFromControlsForUpdateMode(_User);
                        if(_User.SaveUser())
                        {
                            IsDataUpdated = true;
                            MessageBox.Show("The user info updated successfully", "Updating User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The user info isnt updated", "Updating User ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }break;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(_User.PersonID);
            frm.ShowDialog();
            if (frm.IsSave)
            {
                _User.Person = clsPeople.FindPerson(_User.Person.PersonID);
                ctrlPersonDetails1._LoadDataOnControls(_User.Person);
            }

        }
        private void frm_DataBack(clsPeople Person)
        {
            if (Person != null)
            {
                _Person = Person;

                ctrlPersonDetails1._LoadDataOnControls(_Person);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(-1);
            frm.DataBack += frm_DataBack;
            frm.ShowDialog();

            if (_Person != null)
            {
                cbFindBy.SelectedItem = "PersonID";
                tbFindBy.Text = _Person.PersonID.ToString();
            }
                

            
            
        }

        private void button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
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

            this.BackColor = MainBackground;
            this.ForeColor = DarkText;

            // Title
            this.lblAddEditUser.ForeColor = Gold;
            this.lblAddEditUser.Font = new Font(
                "Segoe UI Semibold",
                24F,
                FontStyle.Bold);

            // Tabs
            this.tabControl1.BackColor = SurfaceColor;
            this.tabControl1.ForeColor = DarkText;

            this.tabPersonalInfo.BackColor = SurfaceColor;
            this.tabPersonalInfo.ForeColor = DarkText;

            this.tapLoginInfo.BackColor = SurfaceColor;
            this.tapLoginInfo.ForeColor = DarkText;

            // Find Person GroupBox
            this.gbFindBy.BackColor = SurfaceColor;
            this.gbFindBy.ForeColor = DarkText;
            this.gbFindBy.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            // Find By Label
            this.label2.ForeColor = SecondaryText;
            this.label2.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            // Find By ComboBox
            this.cbFindBy.BackColor = SurfaceColor;
            this.cbFindBy.ForeColor = DarkText;
            this.cbFindBy.Font = new Font("Segoe UI", 9.5F);
            this.cbFindBy.FlatStyle = FlatStyle.Flat;

            // Find By TextBox
            this.tbFindBy.BackColor = SurfaceColor;
            this.tbFindBy.ForeColor = DarkText;
            this.tbFindBy.Font = new Font("Segoe UI", 9.5F);

            // Search Button
            this.btnSearch.BackColor = ButtonColor;
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = ButtonHover;

            // Add Person Button
            this.btnAdd.BackColor = Gold;
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = GoldHover;

            // Update Person Info Link
            this.linkLabel1.BackColor = Color.Transparent;
            this.linkLabel1.ForeColor = Gold;
            this.linkLabel1.LinkColor = Gold;
            this.linkLabel1.ActiveLinkColor = GoldHover;
            this.linkLabel1.VisitedLinkColor = Gold;
            this.linkLabel1.Font = new Font(
                "Segoe UI",
                9F);

            // Login Labels
            this.label3.ForeColor = SecondaryText;
            this.label4.ForeColor = SecondaryText;
            this.label5.ForeColor = SecondaryText;
            this.label6.ForeColor = SecondaryText;

            this.label3.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            this.label4.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            this.label5.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            this.label6.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            // User ID
            this.lblUserID.ForeColor = Gold;
            this.lblUserID.Font = new Font(
                "Segoe UI Semibold",
                10F,
                FontStyle.Bold);

            // Login TextBoxes
            this.tbUserName.BackColor = SurfaceColor;
            this.tbUserName.ForeColor = DarkText;
            this.tbUserName.Font = new Font("Segoe UI", 9.5F);

            this.tbPassword.BackColor = SurfaceColor;
            this.tbPassword.ForeColor = DarkText;
            this.tbPassword.Font = new Font("Segoe UI", 9.5F);

            this.tbConfirmPassword.BackColor = SurfaceColor;
            this.tbConfirmPassword.ForeColor = DarkText;
            this.tbConfirmPassword.Font = new Font("Segoe UI", 9.5F);

            // Is Active
            this.cbIsActive.BackColor = Color.Transparent;
            this.cbIsActive.ForeColor = DarkText;
            this.cbIsActive.Font = new Font(
                "Segoe UI",
                9F);

            // Close Button
            this.button.BackColor = ButtonColor;
            this.button.ForeColor = Color.White;
            this.button.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.button.FlatStyle = FlatStyle.Flat;
            this.button.FlatAppearance.BorderSize = 0;
            this.button.FlatAppearance.MouseOverBackColor = ButtonHover;

            // Save Button
            this.btnSave.BackColor = Gold;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = GoldHover;

            // UserControl
            this.ctrlPersonDetails1.BackColor = SurfaceColor;
        }
    }
}
