using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;

namespace ProjectDemo.ForgotPassword
{
    public partial class NewPassword : UserControl
    {
        string email;
        public NewPassword(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            string message = new AccountDAO().resetPassword(email, txtPassword.Text)? "Password changed successfully" : "Password change failed";
            MessageBox.Show(message);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            email = "";
        }
    }
}
