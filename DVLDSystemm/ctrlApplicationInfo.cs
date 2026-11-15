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
    public partial class ctrlApplicationInfo : UserControl
    {
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

        private void ctrlApplicationInfo_Load(object sender, EventArgs e)
        {

        }
        public void LoadDataOnControl()
        {
            lblApplicationDateResult.Text = DateTime.Now.ToString("dd,MMM,yyy");
            lblCreatedByResult.Text = clsCurrentUser.CurrentUser.UserName;
            lblIssueDateResult.Text = DateTime.Today.ToString("dd,MMM,yyy");
            lblExpirationDateResult.Text = DateTime.Today.AddYears(1).ToString("dd,MMM,yyy");
            clsApplicationType applicationType = clsApplicationType.FindApplicationTypeByID(Convert.ToInt32(clsApplicationType.enApplicationType.NewInternationalLicense));
            lblFeesResult.Text = applicationType.Fees.ToString();

        }
        public void LoadInternationalLicenseIDAndApplicationID(clsInternationalLicenses internationalLicenses)
        {
            lblInternationalApplicationIDResult.Text = internationalLicenses.ApplicationID.ToString();
            lblInternationalLicenseID.Text = internationalLicenses.InternationalLicenseID.ToString();
        }
        public void LoadLicneseIDOnControl(int LicenseID)
        {
            lblLocalLicenseIDResult.Text = LicenseID.ToString();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
