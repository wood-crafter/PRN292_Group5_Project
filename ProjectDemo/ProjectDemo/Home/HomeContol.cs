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
using ProjectDemo.LoginRegistration;
using ProjectDemo.BuyNow;

namespace ProjectDemo.Home
{
    public partial class HomeContol : UserControl
    {
        List<Product> products;
        int index;
        int product_id;
        public HomeContol()
        {
            InitializeComponent();
            products = new ProductDao().productAdvertisement();
            index = 0;
            if (products.Count != 0)
            {
                loadDataOfAdvertisement(products[0]);
            }
            pnFlyout.Visible = false;
        }
        public void loadDataOfAdvertisement(Product product)
        {
            lblPrice.Text = "$" + product.price.ToString();
            lblNameFood.Text = product.product_name;
            lblStoreName.Text = product.store_name + " Store";
            lblAddress.Text = product.address;
            lblDescription.Text = product.description;
            pictureBox.Image = Image.FromFile(Application.StartupPath + "\\images\\" + product.image);
            product_id = product.product_id;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            index = index == products.Count - 1 ? 0 : index + 1;
            loadDataOfAdvertisement(products[index]);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            index = index == 0 ? products.Count - 1 : index - 1;
            loadDataOfAdvertisement(products[index]);
        }

        private void btnOrderNow_Click(object sender, EventArgs e)
        {
            if (SessionAccount.Session_Account == null)
            {
                LoginChild loginChild = new LoginChild();
                loginChild.ShowDialog();
            }
            else
            {
                List<int> orderID_Quality = new OrderDao().checkDuplicate(SessionAccount.Session_Account.account_id, products[index].product_id);
                if (orderID_Quality.Count != 0)
                {
                    new OrderDao().update(orderID_Quality[0], orderID_Quality[1] + 1);
                }
                else
                {
                    new OrderDao().addFood(SessionAccount.Session_Account.account_id, products[index]);
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
