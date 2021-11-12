using DAL;
using Entity;
using ProjectDemo.session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectDemo.LoginRegistration
{
    public partial class LoginChild : Form
    {
        public LoginChild()
        {
            InitializeComponent();
            pnMessage.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            Account account = new AccountDAO().login(email, password);
            i = 0;
            if (account == null)
            {
                lblMessage.Text = "The email you entered does not match any accounts.";
            }
            else
            {
                SessionAccount.Session_Account = account;
                lblMessage.Text = "Logged in successfully";
                Form1.btnSiginSession.Text = "Sign out";
            }
            pnMessage.Visible = true;
            timer1.Enabled = true;
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 4)
            {
                timer1.Enabled = false;
                pnMessage.Visible = false;
                if (SessionAccount.Session_Account != null)
                {
                    this.Close();
                }
            }
        }
    }
}
