using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using System.Net.Mail;
using System.Net;
using ProjectDemo.ForgotPassword;

namespace ProjectDemo
{
    public partial class ForgotAccount : UserControl
    {
        Registration registration;
        Panel pnContain;
        public ForgotAccount(Panel pnContain, Registration registration)
        {
            InitializeComponent();
            this.registration = registration;
            this.pnContain = pnContain;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnContain.Controls.Clear();
            pnContain.Controls.Add(registration);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string codeReset = new System.Random().Next().ToString();
            string email = txtName.Text;
            AccountDAO accountDao = new AccountDAO();
            string name = accountDao.findNameByEmail(email);
            if (name == null)
            {
                MessageBox.Show("There are no search results\n"
                    + "Search returned no results.Please try again with other information.");
            }
            else
            {
                string body = "Hello " + name
                    + "<br>We have received your request to reset your password."
                    + "<br>Enter the following password reset code:<br>"
                    + codeReset;
                if(sendEmail(email, "Reset Account", body))
                {
                    EnterCode enterCode = new EnterCode(panelC,email, codeReset);
                    panelC.Controls.Clear();
                    panelC.Controls.Add(enterCode);
                }
                else
                {
                    MessageBox.Show("An error occurred. Please try again");
                }
            }
        }
        private bool sendEmail(string to_address, string subject, string body)
        {
            string from_address = "namlcphe130442fptu@gmail.com";
            string from_password = "lecongphuongnam123";
            try
            {
                MailMessage msg = new MailMessage(from_address, to_address, subject, body);
                msg.IsBodyHtml = true;
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                NetworkCredential cre = new NetworkCredential(from_address, from_password);//your mail password
                sc.Credentials = cre;
                sc.EnableSsl = true;
                sc.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
