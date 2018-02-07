using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class LoginUI : Form
    {
        LoginManager aLoginManager = new LoginManager();
        public LoginUI()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            User aUser = new User();
            aUser.UserName = userNameTextBox.Text;
            aUser.Password = passwordTextBox.Text;
            if (userNameTextBox.Text == String.Empty)
            {
                messageLabel.Text = "Enter username.";
            }
            else if (passwordTextBox.Text == String.Empty)
            {
                messageLabel.Text = "Enter password.";
            }
            else
            {
                bool isLoginOk = aLoginManager.CheckLogin(aUser);
                if (isLoginOk)
                {
                    MessageBox.Show("Welcome " + aUser.UserName);
                    this.Hide();
                    HomeUI aHomeUi = new HomeUI(aUser.UserName);
                    aHomeUi.Show();

                }
                else
                {
                    messageLabel.Text = "Username or Password incorrect";
                }
            }

        }
    }
}
