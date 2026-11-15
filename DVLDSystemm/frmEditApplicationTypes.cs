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
    public partial class frmEditApplicationTypes : Form
    {
        private clsApplicationType _ApplicationType;
        public bool IsDataUpdated = false;
        public frmEditApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationType = clsApplicationType.FindApplicationTypeByID(ApplicationTypeID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditApplicationTypes_Load(object sender, EventArgs e)
        {
            lblIDResult.Text = _ApplicationType.ApplicationTypeID.ToString();
            tbTitleOfApplicationType.Text = _ApplicationType.Title;
            tbFeesForApplicationType.Text = _ApplicationType.Fees.ToString();
        }
        private void _GetDataFromControls(ref clsApplicationType ApplicationType)
        {
            ApplicationType.Title = tbTitleOfApplicationType.Text;
            ApplicationType.Fees =Convert.ToDecimal(tbFeesForApplicationType.Text);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _GetDataFromControls(ref _ApplicationType);
            if(_ApplicationType.Save())
            {
                IsDataUpdated = true;
                MessageBox.Show("The data updated successfully", "Updating Application Type info", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            else
            {
                MessageBox.Show("The data wasnt updated successfully", "Updating Application Type info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
