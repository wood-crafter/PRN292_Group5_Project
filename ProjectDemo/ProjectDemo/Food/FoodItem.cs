using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;

namespace ProjectDemo.Food
{
    public partial class FoodItem : UserControl
    {
        Product product;
        FoodDetail foodDetail;
        public FoodItem(Product product)
        {
            InitializeComponent();
            this.product = product;
            lblAddress.Text = product.address;
            lblStoreName.Text = product.store_name +" Store";
            lblNameFood.Text = product.product_name;
            ptBox.Image = Image.FromFile(Application.StartupPath + "\\images\\" + product.image);
        }

        private void ptBox_Click(object sender, EventArgs e)
        {
            foodDetail = new FoodDetail(product);
            foodDetail.ShowDialog();
        }
    }
}
