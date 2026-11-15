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
    
    public partial class ctrlDetainLicenseInfo : UserControl
    {
        
        public ctrlDetainLicenseInfo()
        {
            InitializeComponent();
        }
        public void LoadDefaultDataOnControl()
        {
            lblDetainDate.Text = DateTime.Now.ToString("dd,MMM,yyy");
            lblCreatedByResult.Text = clsCurrentUser.CurrentUser.UserName;
            
        }
        public decimal GetFineFees()
        {
            return Convert.ToDecimal(textBox1.Text);
        }

        public string GetFineFeesTextBox()
        {
            return textBox1.Text;
        }
        public void LoadLicenseID(int LicenseID)
        {
            lblLicenseID.Text = LicenseID.ToString();
        }

        public void LoadDetainID(int DetainID)
        {
            lblDetainID.Text = DetainID.ToString();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
