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
    public partial class ctrlApplicationInfoForReplacment : UserControl
    {
        public ctrlApplicationInfoForReplacment()
        {
            InitializeComponent();
        }
        public void LoadDataOfApplication(clsApplicationType applicationType)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd,MM,yyy");
            lblApplicationFees.Text = applicationType.Fees.ToString();
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.UserName;
        }

        public void LoadOldLicenseID(clsLicenses license)
        {
            lblOldLicenseID.Text = license.LicenseID.ToString();
        }

        public void LoadReplacementLicenseApplicationIDAndReplacedLicenseID(int ReplacementLicenseApplicationID,int ReplacedLicenseID)
        {
            lblApplicationID.Text = ReplacementLicenseApplicationID.ToString();
            lblReplacedLicenseID.Text = ReplacedLicenseID.ToString();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
