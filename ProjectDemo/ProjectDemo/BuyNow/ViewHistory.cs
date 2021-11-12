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

namespace ProjectDemo.BuyNow
{
    public partial class ViewHistory : UserControl
    {
        OrderDetail OrderDetail;
        public ViewHistory(OrderDetail orderDetail)
        {
            InitializeComponent();
            this.OrderDetail = orderDetail;
            loadData();
        }
        private void loadData()
        {
            Product product = new OrderDetailDao().getProduct(OrderDetail.product_id);
            lblName.Text = product.product_name+" - " + product.store_name + " Store";
            lblAddress.Text = product.address;
            lblTotal.Text = (product.price * OrderDetail.quality).ToString();
            lblRecipient_address.Text = OrderDetail.recipient_address;
            lblRecipient_name.Text = OrderDetail.recipient_name;
            lblRecipient_phone.Text = OrderDetail.recipient_phone.ToString();
        }
    }
}
