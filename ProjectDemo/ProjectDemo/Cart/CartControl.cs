using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using Entity;
using ProjectDemo.session;
using ProjectDemo.BuyNow;

namespace ProjectDemo.Cart
{
    public partial class CartControl : UserControl
    {
        List<CheckBox> checkBoxes;
        List<Order> orders;
        public CartControl()
        {
            InitializeComponent();
            checkBoxes = new List<CheckBox>();
            orders = new List<Order>();
            loadData();
        }
        public void loadData()
        {
            pnContainCart.Controls.Clear();
            int account_id = SessionAccount.Session_Account.account_id;
            orders = new OrderDao().getAllOrder(account_id);
            if (orders.Count != 0)
            {
                checkBoxes = new List<CheckBox>();
                foreach (Order order in orders)
                {
                    FoodItiemCart foodItiemCart = new FoodItiemCart(order, checkBoxes, pnContainCart);
                    pnContainCart.Controls.Add(foodItiemCart);
                }
            }
            else
            {
                pnContainCart.Controls.Add(new Message());
            }
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAll.Checked == true)
            {
                foreach (CheckBox checkBox in checkBoxes)
                {
                    checkBox.Checked = true;
                }
            }
            else
            {
                foreach (CheckBox checkBox in checkBoxes)
                {
                    checkBox.Checked = false;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message="";
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                if (checkBoxes[i].Checked == true)
                {
                    message = new OrderDao().delete(orders[i].order_id) ? "Delete successful" : "Delete failed";
                }
            }
            if (message != "")
            {
                MessageBox.Show(message);
                loadData();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            List<Order> ordersChoice = new List<Order>();
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                if (checkBoxes[i].Checked == true)
                {
                    ordersChoice.Add(orders[i]);
                }
            }
            if (ordersChoice.Count != 0)
            {
                PayControl payControl = new PayControl(ordersChoice);
                payControl.ShowDialog();
                loadData();
                cbAll.Checked = false;
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            HistoryView historyView = new HistoryView();
            historyView.ShowDialog();
        }
    }
}
