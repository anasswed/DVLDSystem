using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class ctrlUserInfo : UserControl
    {
        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlUserInfo_Load(object sender, EventArgs e)
        {

        }

        public void LoadUserDataOnControl(clsUsers User)
        {
            lblUserNameResult .Text = User.UserName;
            lblUserIDResult.Text = User.UserID.ToString();
            lblIsActive.Text = User.IsActive.ToString();

        }
        public void LoadPersonDataOnControl(clsUsers User)
        {
            ctrlPersonDetails1._LoadDataOnControls(User.Person);
        }

        private void lblUserNameResult_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
