using BusinessLayer;
using PresentationLayer;
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
    public partial class frmChangePassword : Form
    {
        private clsUsers _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            
            _User = clsUsers.FindUser(UserID);
            _User.Person = clsPeople.FindPerson(_User.PersonID);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(_User.PersonID);
            frm.ShowDialog();
            if (frm.IsSave)
            {
                _User.Person = clsPeople.FindPerson(_User.PersonID);
                ctrlUserInfo1.LoadPersonDataOnControl(_User);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserInfo1.LoadPersonDataOnControl(_User);
            ctrlUserInfo1.LoadUserDataOnControl(_User);
        }

        private void tbCurrentPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbCurrentPassword.Text)&&tbCurrentPassword.Text!=_User.Password)
            {
                errorProvider1.SetError(tbCurrentPassword, "The cuurent password is wrong");
                e.Cancel = true;
            }
           else if(string.IsNullOrEmpty(tbCurrentPassword.Text))
            {
                errorProvider1.SetError(tbCurrentPassword, "The cuurent password is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbCurrentPassword, "");
                e.Cancel = false;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNewPassword.Text))
            {
                if (!string.IsNullOrEmpty(tbConfirmPassword.Text) && tbConfirmPassword.Text != tbNewPassword.Text)
                {
                    errorProvider1.SetError(tbConfirmPassword, "The Confirmation doesnt match new password");
                    e.Cancel = true;
                }
                else if (string.IsNullOrEmpty(tbConfirmPassword.Text))
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _User.Password = tbNewPassword.Text;
            if(_User.SaveUser())
            {
                MessageBox.Show("The password updated successfully", "Changing Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The password wasnt updated ", "Changing Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Color ButtonColor = Color.FromArgb(45, 52, 62);
            Color ButtonHover = Color.FromArgb(65, 75, 88);

            // Form
            this.BackColor = MainBackground;
            this.ForeColor = DarkText;

            // User Info
            this.ctrlUserInfo1.BackColor = SurfaceColor;

            // Update Person Info Link
            this.linkLabel1.BackColor = Color.Transparent;
            this.linkLabel1.ForeColor = Gold;
            this.linkLabel1.LinkColor = Gold;
            this.linkLabel1.ActiveLinkColor = GoldHover;
            this.linkLabel1.VisitedLinkColor = Gold;
            this.linkLabel1.Font = new Font("Segoe UI", 9F);

            // Labels
            this.label1.ForeColor = SecondaryText;
            this.label2.ForeColor = SecondaryText;
            this.label3.ForeColor = SecondaryText;

            this.label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            // Password TextBoxes
            this.tbCurrentPassword.BackColor = SurfaceColor;
            this.tbCurrentPassword.ForeColor = DarkText;
            this.tbCurrentPassword.Font = new Font("Segoe UI", 9.5F);

            this.tbNewPassword.BackColor = SurfaceColor;
            this.tbNewPassword.ForeColor = DarkText;
            this.tbNewPassword.Font = new Font("Segoe UI", 9.5F);

            this.tbConfirmPassword.BackColor = SurfaceColor;
            this.tbConfirmPassword.ForeColor = DarkText;
            this.tbConfirmPassword.Font = new Font("Segoe UI", 9.5F);

            // Close Button
            this.button1.BackColor = ButtonColor;
            this.button1.ForeColor = Color.White;
            this.button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = ButtonHover;

            // Save Button
            this.button2.BackColor = Gold;
            this.button2.ForeColor = Color.White;
            this.button2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.button2.FlatStyle = FlatStyle.Flat;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = GoldHover;
        }
    }
}
