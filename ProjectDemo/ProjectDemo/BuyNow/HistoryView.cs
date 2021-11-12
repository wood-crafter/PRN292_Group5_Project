using DAL;
using Entity;
using ProjectDemo.session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectDemo.BuyNow
{
    public partial class HistoryView : Form
    {
        public HistoryView()
        {
            InitializeComponent();
            pnControl.Controls.Clear();
            List<OrderDetail> orderDetails = new OrderDetailDao().getAllOrderDetail(SessionAccount.Session_Account.account_id);
            if (orderDetails.Count != 0)
            {
                foreach (OrderDetail orderDetail in orderDetails)
                {
                    pnControl.Controls.Add(new ViewHistory(orderDetail));
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
