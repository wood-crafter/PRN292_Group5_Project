using DAL;
using Entity;
using ProjectDemo.Cart;
using ProjectDemo.Food;
using ProjectDemo.Home;
using ProjectDemo.LoginRegistration;
using ProjectDemo.Restaurant;
using ProjectDemo.session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectDemo
{
    public partial class Form1 : Form
    {
        HomeContol homeContol;
        public static Button btnSiginSession;
        public Form1()
        {
            InitializeComponent();
            displayChoice(btnHome);
            homeContol = new HomeContol();
            pnContain.Controls.Add(new HomeContol());
            btnSiginSession = btnSigin;
        }
        public void displayChoice(Button btnChoice)
        {
            if (pnChoice.Top != btnChoice.Top || pnChoice.Visible == false)
            {
                pnChoice.Visible = true;
                pnChoice.Top = btnChoice.Top;
                pnContain.Controls.Clear();
            }
                btnSigin.Visible = true;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            displayChoice(btnHome);
            if (homeContol == null)
            {
                homeContol = new HomeContol();
            }
            pnContain.Controls.Add(homeContol);   
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            displayChoice(btnFood);
            pnContain.Controls.Add(new FoodControl());
        }

        private void btnRestaurant_Click(object sender, EventArgs e)
        {
            displayChoice(btnRestaurant);
            pnContain.Controls.Add(new RestaurantControl());
        }

        private void btnDrink_Click(object sender, EventArgs e)
        {
            displayChoice(btnLiquor);
            pnContain.Controls.Add(new LiquorControl());
        }

        private void btnMyCart_Click(object sender, EventArgs e)
        {
            displayChoice(btnMyCart);
            if (SessionAccount.Session_Account == null)
            {
                LoginChild loginChild = new LoginChild();
                loginChild.ShowDialog();
                if(SessionAccount.Session_Account != null)
                {
                    pnContain.Controls.Add(new CartControl());
                }
            }
            else
            {
                pnContain.Controls.Add(new CartControl());
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            displayChoice(btnMore);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void btnSigin_Click(object sender, EventArgs e)
        {
            if (btnSigin.Text.Trim() == "Sign in")
            {
                pnContain.Controls.Clear();
                pnContain.Controls.Add(new Login(pnContain, homeContol, pnChoice));
                pnChoice.Visible = false;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Confirm to Logout?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SessionAccount.Session_Account = null;
                    btnSigin.Text = "Sign in";
                    btnHome_Click(null, null);
                }
            }
        }
    }
}
