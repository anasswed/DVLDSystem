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
    public partial class ctrlListDriverLicenses : UserControl
    {
        public ctrlListDriverLicenses()
        {
            InitializeComponent();
        }
        
        public void LoadDataOnDataGridViewForLocalLicense(DataTable dtListLocalLicense)
        {
            dgvListAllLocalLicenses.DataSource = dtListLocalLicense;
            dgvListAllLocalLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void LoadDataOnDataGridViewForInternationalLicense(DataTable dtListAllInternationalLicense)
        {
            dgvListAllInterLicenses.DataSource = dtListAllInternationalLicense;
            dgvListAllInterLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void ChangeRecordLableForLocalLicense(DataTable dtListAllLocalLicense)
        {
            lblRescordResultForLocalLicense.Text = dtListAllLocalLicense.Rows.Count.ToString();
        }
        public void ChangeRecordLableForInternationalLicense(DataTable dtListAllInternationalLicense)
        {
            lblRescordResultForInterLicense.Text = dtListAllInternationalLicense.Rows.Count.ToString();
        }
        private void ctrlListDriverLicenses_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
