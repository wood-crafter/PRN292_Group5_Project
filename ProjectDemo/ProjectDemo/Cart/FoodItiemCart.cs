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

namespace ProjectDemo.Cart
{
    public partial class FoodItiemCart : UserControl
    {
        Order order;
        List<CheckBox> checkBoxes;
        FlowLayoutPanel panel;
        public FoodItiemCart(Order order, List<CheckBox> checkBoxes, FlowLayoutPanel panel)
        {
            InitializeComponent();
            this.order = order;
            this.checkBoxes = checkBoxes;
            this.panel = panel;
            loadData();
        }
        public void loadData()
        {
            Product product = order.product;
            ptFood.Image = Image.FromFile(Application.StartupPath + "\\images\\" + product.image);
            lblName.Text = product.product_name + " - " + product.store_name+" Store";
            lblAddress.Text = product.address;
            lblPrice.Text = product.price + "$";
            txtQuality.Text = order.quality.ToString();
            checkBoxes.Add(cbChoice);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string message = new OrderDao().delete(order.order_id)? "Delete successful" : "Delete failed";
            MessageBox.Show(message);
            panel.Controls.Remove(this);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(txtQuality.Text);
            if (value == 1)
            {
                MessageBox.Show("The number of products must be greater than 1");
            }
            else
            {
                new OrderDao().update(order.order_id, value - 1);
                txtQuality.Text = (value - 1).ToString();
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(txtQuality.Text) + 1;
            new OrderDao().update(order.order_id, value);
            txtQuality.Text = value.ToString();
        }
    }
}
