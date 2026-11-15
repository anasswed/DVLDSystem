using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class frmUserInfo : Form
    {
        private clsUsers _User;
        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            
            _User = clsUsers.FindUser(UserID);
            _User.Person = clsPeople.FindPerson(_User.PersonID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlUserInfo1_Load(object sender, EventArgs e)
        {

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

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserInfo1.LoadPersonDataOnControl(_User);
            ctrlUserInfo1.LoadUserDataOnControl(_User);
        }

        private void ApplyTheme()
        {
            Color MainBackground = Color.FromArgb(245, 247, 250);
            Color SurfaceColor = Color.White;
            Color DarkText = Color.FromArgb(35, 38, 45);
            Color Gold = Color.FromArgb(218, 165, 32);
            Color GoldHover = Color.FromArgb(235, 185, 55);
            Color ButtonColor = Color.FromArgb(45, 52, 62);
            Color ButtonHover = Color.FromArgb(65, 75, 88);

            // Form
            this.BackColor = MainBackground;
            this.ForeColor = DarkText;

            // User Info
            this.ctrlUserInfo1.BackColor = SurfaceColor;

            // Update Person Info
            this.linkLabel1.BackColor = Color.Transparent;
            this.linkLabel1.ForeColor = Gold;
            this.linkLabel1.LinkColor = Gold;
            this.linkLabel1.ActiveLinkColor = GoldHover;
            this.linkLabel1.VisitedLinkColor = Gold;
            this.linkLabel1.Font = new Font("Segoe UI", 9F);

            // Close
            this.button1.BackColor = ButtonColor;
            this.button1.ForeColor = Color.White;
            this.button1.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = ButtonHover;
        }
    }
}
