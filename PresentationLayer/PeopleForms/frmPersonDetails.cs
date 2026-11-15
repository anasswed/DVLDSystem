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
    public partial class frmPersonDetails : Form
    {
        private clsPeople _Person;
        private DataTable _dataTable;
        
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            
            _Person = clsPeople.FindPerson(PersonID);
        }
      
        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonDetails1._LoadDataOnControls(_Person);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(_Person.PersonID);
            frm.ShowDialog();
           
            
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void ctrlPersonDetails1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(_Person.PersonID);
            frm.ShowDialog();
            _Person = clsPeople.FindPerson(_Person.PersonID);
            ctrlPersonDetails1._LoadDataOnControls(_Person);
            

        }

        private void ApplyTheme()
        {
            Color MainBackground = Color.FromArgb(245, 247, 250);
            Color SurfaceColor = Color.White;

            Color DarkText = Color.FromArgb(35, 38, 45);

            Color Gold = Color.FromArgb(218, 165, 32);
            Color GoldHover = Color.FromArgb(235, 185, 55);

            this.BackColor = MainBackground;
            this.ForeColor = DarkText;

            // Title
            this.label1.ForeColor = Gold;
            this.label1.Font = new Font(
                "Segoe UI Semibold",
                24F,
                FontStyle.Bold);

            // UserControl
            this.ctrlPersonDetails1.BackColor = SurfaceColor;

            // Edit Person Data
            this.linkLabel1.BackColor = Color.Transparent;
            this.linkLabel1.ForeColor = Gold;
            this.linkLabel1.LinkColor = Gold;
            this.linkLabel1.ActiveLinkColor = GoldHover;
            this.linkLabel1.VisitedLinkColor = Gold;
            this.linkLabel1.Font = new Font(
                "Segoe UI",
                9F);
        }
    }
}
