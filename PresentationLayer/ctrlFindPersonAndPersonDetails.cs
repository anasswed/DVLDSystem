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
    
    public partial class ctrlFindPersonAndPersonDetails : UserControl
    {
        private clsPeople _Person;
        public ctrlFindPersonAndPersonDetails()
        {
            InitializeComponent();
        }

        private void ctrlFindPersonAndPersonDetails_Load(object sender, EventArgs e)
        {
            cbFindBy.Items.Add("NationalNo");
            cbFindBy.Items.Add("PersonID");
            cbFindBy.SelectedItem = "NationalNo";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbFindBy.Text))
            {
                if (cbFindBy.SelectedItem.ToString() == "NationalNo")
                {
                    _Person = clsPeople.FindPersonByNationalNo(tbFindBy.Text);
                }
                else
                {
                    _Person = clsPeople.FindPerson(Convert.ToInt32(tbFindBy.Text));
                }
                if (_Person != null)
                {

                    ctrlPersonDetails1._LoadDataOnControls(_Person);
                    linkLabel1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("The person isnt found", "Searching on person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have to enter a value to search");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(-1);
            frm.DataBack += frm_DataBack;
            frm.ShowDialog();

            cbFindBy.SelectedItem = "PersonID";
            tbFindBy.Text = _Person.PersonID.ToString();
        }
        private void frm_DataBack(clsPeople Person)
        {
            _Person = Person;
            ctrlPersonDetails1._LoadDataOnControls(_Person);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(_Person.PersonID);
            frm.ShowDialog();
            if (frm.IsSave)
            {
               _Person = clsPeople.FindPerson(_Person.PersonID);
                ctrlPersonDetails1._LoadDataOnControls(_Person);
            }
        }
        public  void LoadDataOnControls(clsPeople Person)
        {
            tbFindBy.Text = Person.PersonID.ToString();
            cbFindBy.SelectedItem = "PersonID";
            _Person = Person;
            ctrlPersonDetails1._LoadDataOnControls(Person);
        }
        public clsPeople GetDataOfPerson()
        {
            return _Person;
        }
        public void EnableUpdateLink()
        {
            linkLabel1.Enabled = true;
        }
        public void DisableUpdateLink()
        {
            linkLabel1.Enabled = false;
        }

      
        public void DisableFindBy()
        {
            gbFindBy.Enabled = false;
        }
    }
}
