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
    public partial class ctrlDetainInfoForReleaseLicenseForm : UserControl
    {
        public ctrlDetainInfoForReleaseLicenseForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void LoadDataOfDetainedLicenseOnControls(clsDetainedLicenses DetainedLicense)
        {
            clsApplicationType ApplicationType = clsApplicationType.FindApplicationTypeByID(Convert.ToInt32(clsApplicationType.enApplicationType.ReleaseDetainedLicense));
            lblApplicationFees.Text = ApplicationType.Fees.ToString();
            DetainedLicense.User = clsUsers.FindUser(DetainedLicense.CreatedByUserID);
            lblCreatedBy.Text = DetainedLicense.User.UserName;
            lblDetainDate.Text = DetainedLicense.DetainDate.ToString("ddd,MM,yyy");
            lblDetainID.Text = DetainedLicense.DetainID.ToString();
            lblFineFees.Text = DetainedLicense.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToDecimal(lblApplicationFees.Text) + Convert.ToDecimal(lblFineFees.Text)).ToString();
            
        }

        public void LoadReleaseID(int ReleaseID)
        {
            lblReleaseID.Text = ReleaseID.ToString();
        }
        public void LoadLicenseID(int LocalLicenseID)
        {
            lblLicenseID.Text = LocalLicenseID.ToString();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
