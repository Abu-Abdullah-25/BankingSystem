using BankingSystem_Business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginUser();
        }

        private void LoginUser()
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool rememberMe = ckbRemeberMe.Checked;

            clsUser user = clsUser.FindByUsernameAndPassword(username, password);

            if (user != null)
            {
                if (rememberMe)
                {
                    SaveCredentialsToRegistry(username, password);
                }
                else
                {
                    ClearCredentialsFromRegistry();
                    txtUserName.Clear();
                    txtPassword.Clear();
                }

                if (!user.IsActive)
                {
                    HandleInactiveAccount();
                    return;
                }


                ProceedWithLoggedInUser(user);
            }
            else
            {
                HandleInvalidCredentials();
            }
        }

        private void SaveCredentialsToRegistry(string username, string password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";

            try
            {
                Registry.SetValue(keyPath, "Username", username, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", password, RegistryValueKind.String);
                //Console.WriteLine("Username and password successfully written to the Registry.");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"An error occurred while writing to the Registry: {ex.Message}");
            }
        }

        private void ClearCredentialsFromRegistry()
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";

            try
            {
                Registry.SetValue(keyPath, "Username", "", RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", "", RegistryValueKind.String);
                //Console.WriteLine("Username and password cleared from the Registry.");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"An error occurred while clearing data from the Registry: {ex.Message}");
            }
        }

        private void HandleInactiveAccount()
        {
            txtUserName.Focus();
            MessageBox.Show("Your account is not active. Please contact the admin.", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ProceedWithLoggedInUser(clsUser user)
        {
            clsGlobal.CurrentUser = user;
            //Here will log the credentails of user into db table
            clsGlobal.CurrentUser.RegisterLogIn();
            frmMain frm = new frmMain(this);
            this.Hide();
            frm.ShowDialog();
            ckbRemeberMe.Checked = true;
        }

        private void HandleInvalidCredentials()
        {
            txtUserName.Focus();
            MessageBox.Show("Invalid Username/Password.", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
