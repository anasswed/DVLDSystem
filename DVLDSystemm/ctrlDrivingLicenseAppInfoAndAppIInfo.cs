using BusinessLayer;
using PresentationLayer;
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
    public partial class ctrlDrivingLicenseAppInfoAndAppIInfo : UserControl
    {
        public clsLocalDrivingLicense _LocalLicense { set; get; }
        public ctrlDrivingLicenseAppInfoAndAppIInfo()
        {
            InitializeComponent();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void UpdatePassedTest()
        {
            lblPassedTestsResult.Text = clsTests.GetNumberOfPassedTests(_LocalLicense.LocalDrivingLicenseID).ToString() + "/" + clsTestTypes.GetNumberOfTestType(); ;
        }
  

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_LocalLicense.Application.Person.PersonID);
            frm.ShowDialog();
        }
        public void _LoadDataOnControls(clsLocalDrivingLicense LocalLicense)
        {
            _LocalLicense =LocalLicense ;
            lblLocalDrivingLicenseAppResult.Text = _LocalLicense.LocalDrivingLicenseID.ToString();
            lblLicenseClassResult.Text = _LocalLicense.LicenseClass.ClassName.ToString();
            lblPassedTestsResult.Text = clsTests.GetNumberOfPassedTests(_LocalLicense.LocalDrivingLicenseID).ToString() + "/" + clsTestTypes.GetNumberOfTestType();

            lblIDResult.Text = _LocalLicense.Application.ApplicationID.ToString();
            lblStatusResult.Text = _LocalLicense.Application.ApplicationStatus.ToString();
            lblFeesResult.Text = _LocalLicense.Application.ApplicationType.Fees.ToString();
            lblApplicantResult.Text = _LocalLicense.Application.Person.GetFullName();
            lblDateResult.Text = _LocalLicense.Application.ApplicationDate.ToString("dd/MM/yyyy");
            lblStatusDate.Text = _LocalLicense.Application.LastStatusDate.ToString("dd/MM/yyyy");
            lblCreatedByResult.Text = _LocalLicense.Application.User.UserName;
            lblTypeOfApp.Text = _LocalLicense.Application.ApplicationType.Title;

        }

        private void ctrlDrivingLicenseAppInfoAndAppIInfo_Load(object sender, EventArgs e)
        {


        }
    }
}
