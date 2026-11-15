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
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void ctrlInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }
        public void LoadDataOnInternationalLicenseOnControl(clsInternationalLicenses InternationalLicense)
        {
            lblNameResult.Text = InternationalLicense.Application.Person.GetFullName();
            lblInterLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            lblApplicationIDResult.Text = InternationalLicense.ApplicationID.ToString();
            lblDateOfBirthResult.Text = InternationalLicense.Application.Person.DateOfBirth.ToString("ddd,MMM,yyy");
            lblDriverIDResult.Text = InternationalLicense.DriverID.ToString();
            lblExpirationDateResult.Text = InternationalLicense.ExpirationDate.ToString("ddd,MMM,yyy");
           if(InternationalLicense.Application.Person.Gendor==0)
            {
                lblGendorResult.Text = "Male";
            }
           else
            {
                lblGendorResult.Text = "Female";
            }
           if(InternationalLicense.IsActive)
            {
                lblIsActiveResult.Text = "Yes";
            }
           else
            {
                lblIsActiveResult.Text = "No";
            }
            lblIssueDateResult.Text = InternationalLicense.IssueDate.ToString("ddd,MMM,yyy");
            lblLicenseIDResult.Text = InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNoResult.Text = InternationalLicense.Application.Person.Nationalno.ToString();
            if (!string.IsNullOrEmpty(InternationalLicense.Application.Person.ImagePath))
            {
                pbImaegOfPerson.ImageLocation = InternationalLicense.Application.Person.ImagePath;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
