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
    public partial class frmEditTestTypesInfo : Form
    {
        private clsTestTypes _TestType;

        public bool IsUpdated = false;
        public frmEditTestTypesInfo(int TestTypeID)
        {
            InitializeComponent();
            _TestType = clsTestTypes.FindTestTypeByID(TestTypeID);
        }

        private void frmEditTestTypesInfo_Load(object sender, EventArgs e)
        {
            lblResultID.Text = _TestType.TestTypeID.ToString();
            tbDescription.Text = _TestType.Description.ToString();
            tbFees.Text = _TestType.Fees.ToString();
            tbTitle.Text = _TestType.Title.ToString();
        }
        private void _GetDataFromControls(clsTestTypes TestType)
        {
            TestType.Fees = Convert.ToDecimal(tbFees.Text);
            TestType.Title = tbTitle.Text;
            TestType.Description = tbDescription.Text;
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _GetDataFromControls(_TestType);
            if(_TestType.Save())
            {
                IsUpdated = true;
                MessageBox.Show("The data of test type updated successfully", "Updating data of test type", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The data of test type wasnt updated successfully", "Updating data of test type", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
