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
    public partial class ctrlApplicationNewLicenseInfo : UserControl
    {
        public ctrlApplicationNewLicenseInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void LoadDataRelatedToLicense(clsLicenses License)
        {
            lblOldLicenseID.Text = License.LicenseID.ToString();
            lblExpirationDateResult.Text = License.ExpirationDate.ToString("dd,MMM,yyy");
            lblLicenseFeesResult.Text = License.LicenseClass.ClassFess.ToString();
            lblTotalFeesResult.Text = (Convert.ToDecimal(lblApplicationfeesResult.Text) + Convert.ToDecimal(lblLicenseFeesResult.Text)).ToString();
        }

        public string GetNoteReletedToNewLicense()
        {
            return tbNotesResult.Text;
        }

        public void LoadDataOfRenewApplication()
        {
            lblApplicationDateResult.Text = DateTime.Now.ToString("dd,MM,yyy");
            lblIssueDateResult.Text= DateTime.Now.ToString("dd,MM,yyy");
            clsApplicationType ApplicationType = clsApplicationType.FindApplicationTypeByID(Convert.ToInt32(clsApplicationType.enApplicationType.RenewDrivingLicense));
            lblApplicationfeesResult.Text = ApplicationType.Fees.ToString();
            lblCreatedByResult.Text = clsCurrentUser.CurrentUser.UserName;
        }
    }
}
