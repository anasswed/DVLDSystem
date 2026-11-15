using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class ctrlPersonDetails : UserControl
    {
        

        public ctrlPersonDetails()
        {
            InitializeComponent();
        }




        public void _LoadDataOnControls(clsPeople _Person)
        {
            lblPersonIDResult.Text = _Person.PersonID.ToString();
            lblAddressResult.Text = _Person.Address;
            lblCountryResult.Text = clsPeople.GetCountryName(_Person.NationalityCountryID);
            lblDateOfBirthResult.Text = _Person.DateOfBirth.ToString("dd/MM/yyyy");
            lblEmailResult.Text = _Person.Email;
            if (_Person.Gendor == 0)
            {
                lblGendorResult.Text = "Male";
            }
            else
            {
                lblGendorResult.Text = "Female";
            }

            lblNameResult.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
            lblPhoneResult.Text = _Person.Phone;
            if (!string.IsNullOrEmpty(_Person.ImagePath)&& File.Exists(_Person.ImagePath))
            {
                pbPersonImage.Image = Image.FromFile(_Person.ImagePath);
                pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                if (_Person.Gendor == 0)
                {
                    pbPersonImage.Image = Image.FromFile(@"C:\Images\Male.png");
                    pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pbPersonImage.Image = Image.FromFile(@"C:\Images\Female.png");
                    pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
                }

            }
            lblNationalNoResult.Text = _Person.Nationalno;

        }

       
        private void ctrlPersonDetails_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblNationalNoResult_Click(object sender, EventArgs e)
        {

        }
    }
}
