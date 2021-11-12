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

namespace ProjectDemo.Food
{
    public partial class LiquorControl : UserControl
    {
        List<FoodItem> foodItems = new List<FoodItem>();
        public LiquorControl()
        {
            InitializeComponent();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            pnResultSearch.Controls.Clear();
            List<Product> products = new List<Product>();
            products = new ProductDao().productByTypes(15);
            foreach (Product product in products)
            {
                FoodItem foodItem = new FoodItem(product);
                pnResultSearch.Controls.Add(foodItem);
                foodItems.Add(foodItem);
            }
            List<Product> productss = new List<Product>();
            products = new ProductDao().productByTypes(16);
            foreach (Product product in productss)
            {
                FoodItem foodItem = new FoodItem(product);
                pnResultSearch.Controls.Add(foodItem);
                foodItems.Add(foodItem);
            }
        }

        private void btnBeer_Click(object sender, EventArgs e)
        {
            pnResultSearch.Controls.Clear();
            List<Product> products = new List<Product>();
            products = new ProductDao().productByTypes(15);
            foreach (Product product in products)
            {
                FoodItem foodItem = new FoodItem(product);
                pnResultSearch.Controls.Add(foodItem);
                foodItems.Add(foodItem);
            }
        }

        private void btnWine_Click(object sender, EventArgs e)
        {
            pnResultSearch.Controls.Clear();
            List<Product> products = new List<Product>();
            products = new ProductDao().productByTypes(16);
            foreach (Product product in products)
            {
                FoodItem foodItem = new FoodItem(product);
                pnResultSearch.Controls.Add(foodItem);
                foodItems.Add(foodItem);
            }
        }
    }
}
