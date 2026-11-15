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
    public partial class frmListAllDetainedLicenses : Form
    {
        private DataTable _dtListAllDetainedLicenses;

   
        public frmListAllDetainedLicenses()
        {
            InitializeComponent();
            
        }
        private void _LoadDataOnControls()
        {
            _dtListAllDetainedLicenses = clsDetainedLicenses.GetListForAllDetainedLicenses();
            dgvListAllDetainedLicenses.DataSource = _dtListAllDetainedLicenses;
            dgvListAllDetainedLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lblRecordResult.Text = _dtListAllDetainedLicenses.Rows.Count.ToString();

            dgvListAllDetainedLicenses.Columns["Detain ID"].HeaderText = "D.ID";
            dgvListAllDetainedLicenses.Columns["License ID"].HeaderText = "L.ID";
            
            dgvListAllDetainedLicenses.Columns["Fine Fees"].HeaderText = "Fine Fees";
          
            dgvListAllDetainedLicenses.Columns["Release Date"].HeaderText = "Release Date";
            dgvListAllDetainedLicenses.Columns["National No"].HeaderText = "N.No";
  
            dgvListAllDetainedLicenses.Columns["Release Application ID"].HeaderText = "Release App ID";

           foreach(DataColumn column in _dtListAllDetainedLicenses.Columns)
            {
                cbFilterBy.Items.Add(column.ColumnName);
            }

            cbFilterBy.Items.Remove("License ID");
            cbFilterBy.Items.Remove("Release Date");
            cbFilterBy.Items.Remove("Detain Date");
            cbFilterBy.Items.Remove("Fine Fees");
            cbFilterBy.Items.Add("None");
            cbFilterBy.SelectedItem = "None";
            tbFilterBy.Visible = false;



        }
        private void frmListAllDetainedLicenses_Load(object sender, EventArgs e)
        {
            _LoadDataOnControls();
        }

        private void nToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvListAllDetainedLicenses.CurrentRow.Cells[1].Value);
            frmDrivingLicenseInfo frm = new frmDrivingLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() != "None")
            {
                tbFilterBy.Visible = true;
            }
            else
            {
                tbFilterBy.Visible = false;
            }
        }
        private void _FilterData()
        {
            DataColumn column = _dtListAllDetainedLicenses.Columns[cbFilterBy.Text];

            if (column.DataType == typeof(string))
            {
                _dtListAllDetainedLicenses.DefaultView.RowFilter = $"[{cbFilterBy.Text}] LIKE '%{tbFilterBy.Text}%'";
                lblRecordResult.Text = _dtListAllDetainedLicenses.DefaultView.Count.ToString();
            }
            else if (column.DataType == typeof(int))
            {
                if (int.TryParse(tbFilterBy.Text, out int value)) {
                    _dtListAllDetainedLicenses.DefaultView.RowFilter = $"[{cbFilterBy.Text}]={value}";
                    lblRecordResult.Text = _dtListAllDetainedLicenses.DefaultView.Count.ToString();
                }
            }
            else if (column.DataType == typeof(bool))
            {
              if(tbFilterBy.Text.ToLower()=="yes")
                {
                    _dtListAllDetainedLicenses.DefaultView.RowFilter = $"{cbFilterBy.Text}=1";

                }
              else if(tbFilterBy.Text.ToLower()=="no")
                {
                    _dtListAllDetainedLicenses.DefaultView.RowFilter = $"{cbFilterBy.Text}=0";
                }
               lblRecordResult.Text= _dtListAllDetainedLicenses.DefaultView.Count.ToString();
            }
            
        }
        
        
        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tbFilterBy.Text))
            {
                _FilterData();
            }
            else
            {
                _dtListAllDetainedLicenses.DefaultView.RowFilter = "";
                lblRecordResult.Text = _dtListAllDetainedLicenses.Rows.Count.ToString();
            }
        }

        private void showPersoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsPeople.GetPersonIDByNationalNo(dgvListAllDetainedLicenses.CurrentRow.Cells[6].Value.ToString());
            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int PersonID = clsPeople.GetPersonIDByNationalNo(dgvListAllDetainedLicenses.CurrentRow.Cells[6].Value.ToString());
            frmHistoryLicenses frm = new frmHistoryLicenses(PersonID);
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (Convert.ToBoolean(dgvListAllDetainedLicenses.CurrentRow.Cells[3].Value))
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            }
            else
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = true;
            }
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvListAllDetainedLicenses.CurrentRow.Cells[1].Value);
            frmReleaseDetainedLicenses frm = new frmReleaseDetainedLicenses(LicenseID);
            frm.ShowDialog();
            if (frm.IsDataUpdated)
            {
                _dtListAllDetainedLicenses = clsDetainedLicenses.GetListForAllDetainedLicenses();
                dgvListAllDetainedLicenses.DataSource = _dtListAllDetainedLicenses;
                lblRecordResult.Text = _dtListAllDetainedLicenses.Rows.Count.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            if (frm.IsDataUpdated)
            {
                _dtListAllDetainedLicenses = clsDetainedLicenses.GetListForAllDetainedLicenses();
                dgvListAllDetainedLicenses.DataSource = _dtListAllDetainedLicenses;
                lblRecordResult.Text = _dtListAllDetainedLicenses.Rows.Count.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            frmReleaseDetainedLicenses frm = new frmReleaseDetainedLicenses(-1);
            frm.ShowDialog();
            if (frm.IsDataUpdated)
            {
                _dtListAllDetainedLicenses = clsDetainedLicenses.GetListForAllDetainedLicenses();
                dgvListAllDetainedLicenses.DataSource = _dtListAllDetainedLicenses;
                lblRecordResult.Text = _dtListAllDetainedLicenses.Rows.Count.ToString();
            }
        }

   






   
    }
}
