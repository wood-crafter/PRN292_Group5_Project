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

namespace ProjectDemo
{
    public partial class Registration : UserControl
    {
        public Registration()
        {
            InitializeComponent();
        }

        ErrorProvider errorProvider = new ErrorProvider();
        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != null)
            {
                errorProvider.SetError(textBox, "");
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                errorProvider.SetError(textBox, "Please enter " +textBox.Name);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            string message = "";
            if (txtName.Text != "" && txtEmail.Text != "" && txtAddress.Text != "" && txtPassword.Text != "")
            {
                string email = txtEmail.Text;
                if (IsValidEmail(email))
                {
                    string password = txtPassword.Text;
                    if (password.Length >= 6)
                    {
                        if (rdFemale.Checked || rdMale.Checked)
                        {
                            Account account = new Account();
                            account.full_name = txtName.Text;
                            account.email = txtEmail.Text;
                            account.password = txtPassword.Text;
                            account.address = txtAddress.Text;
                            account.date_of_birth = dateTimePicker1.Value;
                            bool gender = rdMale.Checked ? true : false;
                            account.gender = gender;
                            MessageBox.Show(new AccountDAO().register(account) ? "Sign Up Success" : "registration failed");
                        }
                        else
                        {
                            message = "Please select a gender.";
                            errorProvider.SetError(rdFemale, message);
                        }
                    }
                    else
                    {
                        message = "Your password must be at least 6 characters long. Please try another password.";
                        errorProvider.SetError(txtPassword, message);
                    }
                }
                else
                {
                    message = "Please enter a valid email address. Please try another email.";
                    errorProvider.SetError(txtEmail, message);
                }
            }
            else
            {
                message = "Please enter all your information";
            }
            MessageBox.Show(message);
        }
    }
}
