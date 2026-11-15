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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.DirectoryServices.ActiveDirectory;
using System.Windows;
using Microsoft.Win32;

namespace PresentationLayer
{
    public partial class frmLogin : Form
    {
    
        public frmLogin()
        {
            
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tbUserName.Text)&&!string.IsNullOrEmpty(tbPassword.Text))
            {
                clsUsers User = clsUsers.FindUserByUserNameAndPassword(tbUserName.Text, tbPassword.Text);
                if (User == null)
                {
                    MessageBox.Show("Invalide userName/Password please try again", "Logging", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (User.IsActive == false)
                {
                    MessageBox.Show("The User isnt active please call your admin", "Logging", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if(cbRememberMe.Checked)
                    {

                        string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";

                        string ValueOfUserName = "User Name";

                        string ValueOfPassword = "Password";

                        string DataOfUserName = tbUserName.Text;
                        string DataOfPassword = tbPassword.Text;

                        try
                        {
                            Registry.SetValue(keyPath, ValueOfUserName, DataOfUserName, RegistryValueKind.String);
                            Registry.SetValue(keyPath, ValueOfPassword, DataOfPassword, RegistryValueKind.String);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                       
                    }
                    else
                    {
                        string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";

                        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true))
                        {
                            if (key != null)
                            {
                                key.DeleteValue("User Name", false);
                                key.DeleteValue("Password", false);
                            }
                        }
                    }
                   
                    clsCurrentUser.CurrentUser = User;
                    frmMain frm = new frmMain();
                    frm.ShowDialog();


                }
            }
            else
            {
                MessageBox.Show("Please enter a user name and password to login");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           
          string keyPath= @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";

            string UserNameData = Registry.GetValue(keyPath, "User Name", null) as string;
            string PasswordData = Registry.GetValue(keyPath, "Password", null) as string;

            if (UserNameData != null && PasswordData != null)
            {
                tbPassword.Text = PasswordData;
                tbUserName.Text = UserNameData;
            }



        }

        private void cbRememberMe_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
