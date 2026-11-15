using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class ctrlSearchOnInternattionalLicense : UserControl
    {
        public delegate void DataBackEventHandler(clsLicenses LocalLicense);
        public event DataBackEventHandler DataBack;
        private clsLicenses LocalLicense;
     
        public ctrlSearchOnInternattionalLicense()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tbLicenseID.Text))
            {
                

                 LocalLicense = clsLicenses.FindLicenseByID(Convert.ToInt32(tbLicenseID.Text));
               
                if (LocalLicense != null&&LocalLicense.IsActive)
                {
                    DataBack?.Invoke(LocalLicense);

                   

                 
                }
                else if (LocalLicense == null)
                {
                    MessageBox.Show("The license wasnt found!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(LocalLicense.IsActive==false)
                {
                    DataBack?.Invoke(LocalLicense);
                    MessageBox.Show("Selected license isnt active choose another license", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             
            

            }
            else
            {
                MessageBox.Show("You have to enter a value in the box", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
           
        }

        private void ctrlSearchOnInternattionalLicense_Load(object sender, EventArgs e)
        {

        }
        
       public void LoadLicenseIDOnTextBox(int LicenseID)
        {
            tbLicenseID.Text = LicenseID.ToString();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
