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
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;

namespace PresentationLayer
{
    public partial class ctrlAddEditPersonInfo : UserControl
    {
        public enum enMode { AddNewPerson, UpdatePersonInfo };

        public enMode Mode;
        private clsPeople _Person;

        private DataTable _dtCountry;
        private string _ImagePath;

        public string NationalNumberTextBoxValue { set { tbNationalNoValue.Text = value; } get { return tbNationalNoValue.Text; } }

        public string LblPersonIDResult { set { lblPersonIDResult.Text = value; } get { return lblPersonIDResult.Text; } }
        //public string EmailValue { set { tbEmailValue.Text = value; } get { return tbEmailValue.Text ; } }
        //public string ImagePath { set { _ImagePath = value; } get { return _ImagePath; } }

        //public string FirstName { set { tbFirstName.Text = value; } get { return tbFirstName.Text; } }

        //public string LastName { set { tbLastName.Text = value; }  get { return tbLastName.Text; } }

        //public string ThirdName { set { tbThirdName.Text = value; } get { return tbThirdName.Text; } }

        //public string SecondName { set { tbSecondName.Text = value; } get { return tbSecondName.Text; } } 

        //public string Phone { set { tbPhoneValue.Text = value; } get { return tbPhoneValue.Text; } }

        //public string Address { set { tbAddressValue.Text = value; } get { return tbAddressValue.Text; } }

        //public DateTime DateOfBirth { set { dtDateOfBirth.Value = value; } get { return dtDateOfBirth.Value; } }




        public ctrlAddEditPersonInfo()
        {
            InitializeComponent();
            tbNationalNoValue.Validating += tbNationalNoValue_Validating;
        }

        private void _LoadDataOnForm()
        {
            _dtCountry = clsPeople.GetAllCountries();
            cbCountries.DisplayMember = "CountryName";
            cbCountries.ValueMember = "CountryID";
            cbCountries.DataSource = _dtCountry;
            cbCountries.SelectedValue = 90;


            rbMale.Checked = true;

            llRemoveImage.Visible = !string.IsNullOrEmpty(_ImagePath);




        }

        internal clsPeople GetPersonData()
        {
            _Person = new clsPeople();
            _Person.FirstName = tbFirstName.Text;
            _Person.LastName = tbLastName.Text;
            _Person.SecondName = tbSecondName.Text;

            if (!string.IsNullOrEmpty(tbThirdName.Text))
            {
                _Person.ThirdName = tbThirdName.Text;
            }
            _Person.Nationalno = tbNationalNoValue.Text;
            _Person.Address = tbAddressValue.Text;
            _Person.DateOfBirth = dtDateOfBirth.Value;

            if (rbFemale.Checked)
            {
                _Person.Gendor = 1;
            }
            else if(rbMale.Checked)
            {
                _Person.Gendor = 0;
            }
            _Person.Phone = tbPhoneValue.Text;
            if (!string.IsNullOrEmpty(tbEmailValue.Text))
            {
                _Person.Email = tbEmailValue.Text;
            }
            _Person.NationalityCountryID =  Convert.ToInt32(cbCountries.SelectedValue);
          
                _Person.ImagePath = _ImagePath;
            
            return _Person;

            

        

        }

        internal void GetPersonDataForUpdateMode(ref clsPeople Person)
        {
            Person.FirstName = tbFirstName.Text;
            Person.LastName = tbLastName.Text;
            Person.SecondName = tbSecondName.Text;

            if (!string.IsNullOrEmpty(tbThirdName.Text))
            {
                Person.ThirdName = tbThirdName.Text;
            }
            else
            {
                Person.ThirdName = "";
            }
            
            Person.Nationalno = tbNationalNoValue.Text;
            Person.Address = tbAddressValue.Text;
            Person.DateOfBirth = dtDateOfBirth.Value;

            if (rbFemale.Checked)
            {
                Person.Gendor = 1;
            }
            else if (rbMale.Checked)
            {
                Person.Gendor = 0;
            }
            Person.Phone = tbPhoneValue.Text;
            if (!string.IsNullOrEmpty(tbEmailValue.Text))
            {
                Person.Email = tbEmailValue.Text;
            }
            else
            {
                Person.Email = "";
            }
            Person.NationalityCountryID = Convert.ToInt32(cbCountries.SelectedValue);
           
                Person.ImagePath = _ImagePath;
            
           
        }
        internal void LoadDataOnControls(clsPeople Person)
        {
            tbFirstName.Text = Person.FirstName;
            tbSecondName.Text = Person.SecondName;
            tbThirdName.Text = Person.ThirdName;
            tbLastName.Text = Person.LastName;

            tbEmailValue.Text = Person.Email;
            tbPhoneValue.Text = Person.Phone;

            tbAddressValue.Text = Person.Address;

            dtDateOfBirth.Value = Person.DateOfBirth;
            if(Person.Gendor==0)
            {
                rbMale.Checked = true;
            }
            else if(Person.Gendor==1)
            {
                rbFemale.Checked = true;
            }
            tbNationalNoValue.Text = Person.Nationalno;
            lblPersonIDResult.Text = Person.PersonID.ToString();
            cbCountries.SelectedValue = Person.NationalityCountryID;
            if (!string.IsNullOrEmpty(Person.ImagePath) && File.Exists(Person.ImagePath))
            {
                _ImagePath = Person.ImagePath;
                pbForPerson.Image = Image.FromFile(Person.ImagePath);
                llRemoveImage.Visible = true;
            }
            else
            {
                _ImagePath = "";
                llRemoveImage.Visible = false;
            }




        }

        private void ctrlAddEditPersonInfo_Load(object sender, EventArgs e)
        {

            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            if (!DesignMode)
            {
                _LoadDataOnForm();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbEmailValue_TextChanged(object sender, EventArgs e)
        {
            if(tbEmailValue.Text!="")
            {
                if(tbEmailValue.Text.Contains("@"))
                {
                    epForAddEditPerson.SetError(tbEmailValue, "");
                }
                else
                {
                    epForAddEditPerson.SetError(tbEmailValue, "The email has to contain @ charachter");
                }
            }
        }


        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                llRemoveImage.Visible = true;
                string oldImagePath = _ImagePath;
                string imagePath = openFileDialog1.FileName;

                string destinationPath = Path.Combine(
                    @"C:\DVLDSystem",
                    Path.GetFileName(imagePath)
                );

                if (pbForPerson.Image != null)
                {
                    pbForPerson.Image.Dispose();
                    pbForPerson.Image = null;
                }

                if (!string.IsNullOrEmpty(oldImagePath) && File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }

                File.Copy(imagePath, destinationPath, true);

                _ImagePath = destinationPath;
                pbForPerson.ImageLocation = destinationPath;
                pbForPerson.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            
            pbForPerson.Image = Image.FromFile(@"C:\Images\Male.png");
                pbForPerson.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {

            pbForPerson.Image = Image.FromFile(@"C:\Images\Female.png");
                 pbForPerson.SizeMode = PictureBoxSizeMode.Zoom;

        }

     

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
           if(tbFirstName.Text=="")
            {
                epForAddEditPerson.SetError(tbFirstName, "This field isnt optional");
                e.Cancel = true;
            }
           else
            {
                epForAddEditPerson.SetError(tbFirstName, "");
                e.Cancel = false;
            }
        }

        private void tbNationalNoValue_Validating(object sender, CancelEventArgs e)
        {
            if (tbNationalNoValue.Text != "")
            {
                if (frmAddEditPersonInfo.CheckNationalNumberExist(tbNationalNoValue.Text)&&Mode==enMode.AddNewPerson)
                {
                    epForAddEditPerson.SetError(tbNationalNoValue, "The National Number already exists");
                    e.Cancel = true;
                }
                else
                {
                    epForAddEditPerson.SetError(tbNationalNoValue, "");
                    e.Cancel = false;
                }
            }
            else
            {
                epForAddEditPerson.SetError(tbNationalNoValue, "This field isnt optional");
                e.Cancel = true;
            }
        }

        private void tbSecondName_Validating(object sender, CancelEventArgs e)
        {
            if(tbSecondName.Text=="")
            {
                epForAddEditPerson.SetError(tbSecondName, "This fiels isnt optional");
                e.Cancel = true;
            }
            else
            {
                epForAddEditPerson.SetError(tbSecondName, "");
                e.Cancel = false;
            }
        }


        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            if(tbLastName.Text=="")
            {
                epForAddEditPerson.SetError(tbLastName, "This field isnt optional");
                e.Cancel = true;
            }
            else
            {
                epForAddEditPerson.SetError(tbLastName, "");
                e.Cancel = false;
            }
        }


        private void tbPhoneValue_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbPhoneValue.Text))
            {
                epForAddEditPerson.SetError(tbPhoneValue, "This field isnt optional");

                e.Cancel = true;

            }
            else
            {
                epForAddEditPerson.SetError(tbPhoneValue, "");
                e.Cancel = false;
            }
        }

        private void tbAddressValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbAddressValue.Text))
            {
                epForAddEditPerson.SetError(tbAddressValue, "This field isnt optional");

                e.Cancel = true;

            }
            else
            {
                epForAddEditPerson.SetError(tbAddressValue, "");
                e.Cancel = false;
            }
        }

        private void tbThirdName_TextChanged(object sender, EventArgs e)
        {

        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            _ImagePath = "";
            llRemoveImage.Visible = false;
            if (rbFemale.Checked)
            {
                pbForPerson.Image = Image.FromFile(@"C:\Images\Female.png");
              
                pbForPerson.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else if(rbMale.Checked)
            {
                pbForPerson.Image = Image.FromFile(@"C:\Images\Male.png");

                pbForPerson.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
