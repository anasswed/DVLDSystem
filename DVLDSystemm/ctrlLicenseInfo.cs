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
    public partial class ctrlLicenseInfo : UserControl
    {
        private clsLicenses _License;
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }
        public void LoadDataOnControl(clsLicenses License)
        {
            lblClassResult.Text = License.LicenseClass.ClassName;
            lblDateOfBirthResult.Text = License.Application.Person.DateOfBirth.ToString("dd/MM/yyyy");
            lblDriverID.Text = License.DriverID.ToString();
            lblIssueDate.Text = License.IssueDate.ToString("dd/MM/yyyy");
            lblExpirationDateResult.Text = License.ExpirationDate.ToString("dd/MM/yyyy");
            if (License.Application.Person.Gendor == 0)
            {
                lblGendorResult.Text = "Male";
            }
            else
            {
                lblGendorResult.Text = "Female";
            }
            if(License.IsActive)
            {
                lblIsActiveResult.Text = "Yes";
            }
            else
            {
                lblIsActiveResult.Text = "No";
            }
            lblIssueDate.Text = License.IssueDate.ToString("dd/MM/yyyy");
            lblIssueReasonResult.Text = License.IssueReason.ToString();
            lblLicenseIDResult.Text = License.LicenseID.ToString();
            lblNameResult.Text = License.Application.Person.GetFullName();
            lblNationalNoResult.Text = License.Application.Person.Nationalno;
            if(string.IsNullOrEmpty(License.Notes))
            {
                lblNotesResult.Text = "No Notes";
            }
            else
            {
                lblNotesResult.Text = License.Notes;
            }
            if (!string.IsNullOrEmpty(License.Application.Person.ImagePath)) {
                pbPersonImage.ImageLocation = License.Application.Person.ImagePath;
            }
            if(clsDetainedLicenses.IsLicenseDetained(License.LicenseID))
            {
                lblIsDetainedResult.Text = "Yes";
            }
            else
            {
                lblIsDetainedResult.Text = "No";
            }
             
        }
        private void ctrlLicenseInfo_Load(object sender, EventArgs e)
        {

        }
        public void UpdateStatusOfDetainedLicense(int LicenseID)
        {
            if (clsDetainedLicenses.IsLicenseDetained(LicenseID))
            {
                lblIsDetainedResult.Text = "Yes";

            }
            else
            {
                lblIsDetainedResult.Text = "No";
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
