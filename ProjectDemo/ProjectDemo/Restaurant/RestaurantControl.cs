using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectDemo.Food;

namespace ProjectDemo.Restaurant
{
    public partial class RestaurantControl : UserControl
    {
        public RestaurantControl()
        {
            InitializeComponent();
            pnContain.Controls.Add(new RestaurantContent());
        }
    }
}
