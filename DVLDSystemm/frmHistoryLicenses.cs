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
    public partial class frmHistoryLicenses : Form
    {

        private DataTable _dtListAllLocalLicenseForPerson;

        private DataTable _dtListAllInternationalLicenseForPerson;

        private clsDrivers _Driver;
        public frmHistoryLicenses(int PersonID)
        {
            InitializeComponent();
            
            _Driver = clsDrivers.FindDriverByPersonID(PersonID);
            _Driver.Person = clsPeople.FindPerson(PersonID);

        }
        private void _LoadDataOnControl()
        {
            ctrlFindPersonAndPersonDetails1.LoadDataOnControls(_Driver.Person);
            ctrlFindPersonAndPersonDetails1.DisableFindBy();

            _dtListAllLocalLicenseForPerson = clsLicenses.ListAllLocalLicenseForDriver(_Driver.DriverID);
            ctrlListDriverLicenses1.LoadDataOnDataGridViewForLocalLicense(_dtListAllLocalLicenseForPerson);
            ctrlListDriverLicenses1.ChangeRecordLableForLocalLicense(_dtListAllLocalLicenseForPerson);

            _dtListAllInternationalLicenseForPerson = clsInternationalLicenses.ListAllInternationalLicenseForDriver( _Driver.DriverID);
            ctrlListDriverLicenses1.LoadDataOnDataGridViewForInternationalLicense(_dtListAllInternationalLicenseForPerson);
            ctrlListDriverLicenses1.ChangeRecordLableForInternationalLicense(_dtListAllInternationalLicenseForPerson);



        }
        private void frmHistoryLicenses_Load(object sender, EventArgs e)
        {
            _LoadDataOnControl();

        }

        private void ApplyTheme()
        {
            Color MainBackground = Color.FromArgb(245, 247, 250);
            Color SurfaceColor = Color.White;

            Color DarkText = Color.FromArgb(35, 38, 45);
            Color Gold = Color.FromArgb(218, 165, 32);
            Color GoldHover = Color.FromArgb(235, 185, 55);

            Color ButtonColor = Color.FromArgb(45, 52, 62);
            Color ButtonHover = Color.FromArgb(65, 75, 88);

            this.BackColor = MainBackground;
            this.ForeColor = DarkText;

            // Title
            this.label1.ForeColor = Gold;
            this.label1.Font = new Font(
                "Segoe UI Semibold",
                24F,
                FontStyle.Bold);

            // UserControls
            this.ctrlFindPersonAndPersonDetails1.BackColor = SurfaceColor;
            this.ctrlListDriverLicenses1.BackColor = SurfaceColor;

            // Close Button
            this.button1.BackColor = ButtonColor;
            this.button1.ForeColor = Color.White;
            this.button1.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = ButtonHover;
        }
    }
}
