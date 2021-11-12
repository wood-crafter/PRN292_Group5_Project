using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectDemo.ForgotPassword
{
    public partial class EnterCode : UserControl
    {
        string codeReset;
        Panel pnControl;
        public EnterCode(Panel pnControl, string email, string codeReset)
        {
            InitializeComponent();
            lblEmail.Text = email;
            this.pnControl = pnControl;
            this.codeReset = codeReset;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            string textCode = txtCode.Text;
            if (textCode != null)
            {
                if (codeReset.Equals(textCode))
                {
                    NewPassword newPassword = new NewPassword(lblEmail.Text);
                    pnControl.Controls.Clear();
                    pnControl.Controls.Add(newPassword);
                }
                else
                {
                    MessageBox.Show("The number you entered does not match the code. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("You cannot leave the code blank.");
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
