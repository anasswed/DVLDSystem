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
    public partial class frmManageApplicationTypes : Form
    {
        private DataTable _dtApplicationType;
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtApplicationType = clsApplicationType.GetAllApplicationTypes();
            dgvListApplicationTypes.DataSource = _dtApplicationType;
            dgvListApplicationTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            lblRecordResult.Text = _dtApplicationType.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationTypeID = Convert.ToInt32(dgvListApplicationTypes.CurrentRow.Cells[0].Value);
            frmEditApplicationTypes frm = new frmEditApplicationTypes(ApplicationTypeID);
            frm.ShowDialog();
            if(frm.IsDataUpdated)
            {
                _dtApplicationType = clsApplicationType.GetAllApplicationTypes();
                dgvListApplicationTypes.DataSource = _dtApplicationType;
            }
        }
    }
}
