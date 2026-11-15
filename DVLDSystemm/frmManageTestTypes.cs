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
    public partial class frmManageTestTypes : Form
    {
        private DataTable _dtTestTypes;
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _dtTestTypes = clsTestTypes.GetAllTestTypes();
            dgvListAllTestTypes.DataSource = _dtTestTypes;
            dgvListAllTestTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            lblRecordResult.Text = _dtTestTypes.Rows.Count.ToString();
        }

        private void editTestTypesInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestTypeID = Convert.ToInt32(dgvListAllTestTypes.CurrentRow.Cells[0].Value);
            frmEditTestTypesInfo frm = new frmEditTestTypesInfo(TestTypeID);
            frm.ShowDialog();
            if(frm.IsUpdated)
            {
                _dtTestTypes = clsTestTypes.GetAllTestTypes();
                dgvListAllTestTypes.DataSource = _dtTestTypes;
            }
        }
    }
}
