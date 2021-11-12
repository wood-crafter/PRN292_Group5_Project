using DAL;
using Entity;
using ProjectDemo.session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ProjectDemo.BuyNow
{
    public partial class PayControl : Form
    {
        List<Order> orders;
        float fee = 0;
        public PayControl(List<Order> orders)
        {
            InitializeComponent();
            this.orders = orders;
            loadData();
        }

        private void loadData()
        {
            float total = 0;
            int quality = 0;
            foreach(Order order in orders)
            {
                total += order.product.price * order.quality;
                quality += order.quality;
            }
            lblTotalNumber.Text = total.ToString();
            lblAllTotal.Text = (total + fee).ToString();
            lblTotal.Text = "Subtotal ("+quality+" Items)";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text == "" || txtName.Text == "" || txtProvince.Text == "" || txtDistrict.Text == "" || txtWard.Text == "" || (rdExpress.Checked == false & rdSaving.Checked == false))
            {
                i = 0;
                timer1.Enabled = true;
                pnFlyout.Visible = true;
            }
            else
            {
                lblAddress.Text = txtWard.Text + ", " + txtDistrict.Text + ", " + txtProvince.Text;
                lblPhone.Text = txtPhone.Text;
                if (rdExpress.Checked)
                {
                    fee = 2;
                }
                else
                {
                    fee = 1;
                }
                lblShipping.Text = fee.ToString();
                lblAllTotal.Text = (Convert.ToInt32(lblAllTotal.Text) + fee).ToString();
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (lblShipping.Text != "Not yet")
            {
                foreach(Order order in orders)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.account_id = SessionAccount.Session_Account.account_id;
                    orderDetail.recipient_name = txtName.Text;
                    orderDetail.recipient_address = lblAddress.Text;
                    orderDetail.recipient_phone = Convert.ToInt32(lblPhone.Text);
                    orderDetail.product_id = Convert.ToInt32(order.product.product_id);
                    orderDetail.quality = Convert.ToInt32(order.quality);
                    orderDetail.order_date = DateTime.Now;
                    new OrderDetailDao().addOrder(orderDetail);
                    new OrderDao().delete(order.order_id);
                }
                MessageBox.Show("Successfully purchase");
                this.Close();
            }
            else
            {
                i = 0;
                timer1.Enabled = true;
                pnFlyout.Visible = true;
            }
        }
    }
}
