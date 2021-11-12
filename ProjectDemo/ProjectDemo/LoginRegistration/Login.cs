using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;
using DAL;
using ProjectDemo.session;
using ProjectDemo.Home;

namespace ProjectDemo
{
    public partial class Login : UserControl
    {
        Registration registration;
        ForgotAccount forgotAccount;
        Panel panel;
        HomeContol homeContol;
        Panel pnChoice;
        public Login(Panel panel, HomeContol homeContol, Panel pnChoice)
        {
            InitializeComponent();
            registration = new Registration();
            pnContain.Controls.Add(registration);
            Form1.btnSiginSession.Visible = false;
            this.homeContol = homeContol;
            this.panel = panel;
            this.pnChoice = pnChoice;
            pnMessage.Visible = false;
        }

        private void btnForgotAccount_Click(object sender, EventArgs e)
        {
            pnContain.Controls.Clear();
            pnContain.Controls.Remove(forgotAccount);
            forgotAccount = new ForgotAccount(pnContain,registration);
            pnContain.Controls.Add(forgotAccount);
        }

        int i = 0;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            i = 0;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            Account account = new AccountDAO().login(email, password);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 4)
            {
                timer1.Enabled = false;
                pnMessage.Visible = false;
                if (SessionAccount.Session_Account != null)
                {
                    panel.Controls.Clear();
                    panel.Controls.Add(homeContol);
                    pnChoice.Visible = true;
                    pnChoice.Location = new System.Drawing.Point(0, 74);
                    Form1.btnSiginSession.Visible = true;
                }
            }
        }
    }
}
