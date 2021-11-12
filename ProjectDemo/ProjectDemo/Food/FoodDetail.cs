using DAL;
using Entity;
using ProjectDemo.LoginRegistration;
using ProjectDemo.session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ProjectDemo.Food
{
    public partial class FoodDetail : Form
    {
        Product product;
        public FoodDetail(Product product)
        {
            InitializeComponent();
            this.product = product;
            loadData();
            pnFlyout.Visible = false;
        }
        public void loadData()
        {
            ptImage.Image = Image.FromFile(Application.StartupPath + "\\images\\" + product.image);
            lblName.Text = product.product_name + " - " + product.store_name;
            lblOpenTime.Text = product.time_open + " - " + product.time_close;
            lblPrice.Text = product.price + "$";
            lblAbstract.Text = product._abstract;
            lblAddress.Text = product.address;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuyNow_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (SessionAccount.Session_Account == null)
            {
                LoginChild loginChild = new LoginChild();
                loginChild.ShowDialog();
            }
            else
            {
                List<int> orderID_Quality = new OrderDao().checkDuplicate(SessionAccount.Session_Account.account_id, product.product_id);
                if (orderID_Quality.Count != 0)
                {
                    new OrderDao().update(orderID_Quality[0], orderID_Quality[1] + 1);
                }
                else
                {
                    new OrderDao().addFood(SessionAccount.Session_Account.account_id, product);
                }
                timer1.Enabled = true;
                pnFlyout.Visible = true;
                i = 0;
            }
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 4)
            {
                timer1.Enabled = false;
                pnFlyout.Visible = false;
            }
        }
    }
}
