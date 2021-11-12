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
    public partial class FoodControl : UserControl
    {
        List<FoodType> foodTypes;
        List<Button> listButton = new List<Button>();
        List<FoodItem> foodItems = new List<FoodItem>();

        public FoodControl()
        {
            InitializeComponent();
            foodTypes = new FoodTypeDao().getTypeOfFood();
            loadDataType();
            foreach (Button button in listButton)
            {
                button.Click += new System.EventHandler(this.btnAll_Click);
            }
        }
        public void loadDataType()
        {
            if (foodTypes.Count != 0)
            {
                foreach (FoodType foodType in foodTypes)
                {
                    Button button = new Button();
                    button.Text = foodType.type_name;
                    button.Name = foodType.type_id.ToString();
                    setupButton(button);
                    listButton.Add(button);
                    pnType.Controls.Add(button);
                }
            }
        }

        public void setupButton(Button button)
        {
            button.AutoSize = true;
            button.Cursor = System.Windows.Forms.Cursors.Hand;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            button.Size = new System.Drawing.Size(69, 29);
            button.TabIndex = 0;
            button.UseVisualStyleBackColor = true;
        }
        Button button;
        private void btnAll_Click(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>();
            Button buttonClick = (Button)sender;
            if (button != buttonClick)
            {
                button = buttonClick;
                if (buttonClick.Name == "btnAll")
                {
                    products = new ProductDao().productByTypes(-1);
                }
                else
                {
                    products = new ProductDao().productByTypes(Convert.ToInt32(((Button)sender).Name));
                }
                pnResultSearch.Controls.Clear();
                foreach (Product product in products)
                {
                    FoodItem foodItem = new FoodItem(product);
                    pnResultSearch.Controls.Add(foodItem);
                    foodItems.Add(foodItem);
                }
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "Please enter the food name.")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Please enter the food name.";
                txtSearch.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>();
            products = new ProductDao().search(txtSearch.Text);
            pnResultSearch.Controls.Clear();
            foreach (Product product in products)
            {
                FoodItem foodItem = new FoodItem(product);
                pnResultSearch.Controls.Add(foodItem);
                foodItems.Add(foodItem);
            }
        }
    }
}
