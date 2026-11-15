using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PresentationLayer
{
    public partial class frmAddEditPersonInfo : Form
    {
        public delegate void DataBackEventHandler(clsPeople Person);
        public event DataBackEventHandler DataBack;
        public enum enMode { UpdatePerson, AddNewPerson };
        public  enMode _Mode;
        private clsPeople _Person;

        private bool _IsSave = false;
        public bool IsSave { get { return _IsSave; } }

     
        public frmAddEditPersonInfo(int PersonID)
        {

            InitializeComponent();
            
            if (PersonID == -1)
            {
               
                _Mode = enMode.AddNewPerson;
                ctrlAddEditPersonInfo1.Mode = ctrlAddEditPersonInfo.enMode.AddNewPerson;
            }
            else
            {
                lblAddOrUpdate.Text = "Update Person Info";
                _Person = clsPeople.FindPerson(PersonID);
                _Mode = enMode.UpdatePerson;
                ctrlAddEditPersonInfo1.Mode = ctrlAddEditPersonInfo.enMode.UpdatePersonInfo;
             

            }
        }
        private void _CheckOnMode()
        {
          if(_Mode==enMode.UpdatePerson)
          {
                ctrlAddEditPersonInfo1.LoadDataOnControls(_Person);
           }
        }
        private void frmAddEditPersonInfo_Load(object sender, EventArgs e)
        {
            _CheckOnMode();
        }

       

        internal static bool CheckNationalNumberExist(string NationalNo)
        {
            return (clsPeople.IsNationalNumberExist(NationalNo));
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ctrlAddEditPersonInfo1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            switch (_Mode)
            {
                case enMode.AddNewPerson:
                    {

                        _Person = ctrlAddEditPersonInfo1.GetPersonData();
                        if (_Person.SavePerson())
                        {
                            MessageBox.Show("Data saved successfully", "Saving Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mode = enMode.UpdatePerson;
                            lblAddOrUpdate.Text = "Update Person Info";
                            _IsSave = true;
                            ctrlAddEditPersonInfo1.LblPersonIDResult = _Person.PersonID.ToString();
                            DataBack?.Invoke(_Person);
                           

                        }
                        else
                        {
                            MessageBox.Show("There is an error occur data isnt saved", "Saving Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           
                        }

                    }
                    break;
                case enMode.UpdatePerson:
                    {
                        ctrlAddEditPersonInfo1.GetPersonDataForUpdateMode(ref _Person);
                        if(_Person.SavePerson())
                        {
                            MessageBox.Show("The person info updated successfully","Updating Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            _IsSave = true;
                          
                        }
                        else
                        {
                            MessageBox.Show("The person info isnt updated","Updating Info",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }

                    }
                    break;
            }
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
            this.lblAddOrUpdate.ForeColor = Gold;
            this.lblAddOrUpdate.Font = new Font(
                "Segoe UI Semibold",
                22F,
                FontStyle.Bold);

            // UserControl
            this.ctrlAddEditPersonInfo1.BackColor = SurfaceColor;

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

            // Save Button
            this.button2.BackColor = Gold;
            this.button2.ForeColor = Color.White;
            this.button2.Font = new Font(
                "Segoe UI Semibold",
                9F,
                FontStyle.Bold);

            this.button2.FlatStyle = FlatStyle.Flat;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = GoldHover;
        }


    }
}
