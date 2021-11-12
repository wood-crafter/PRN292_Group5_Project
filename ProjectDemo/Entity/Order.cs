using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Order
    {
        public int order_id { get; set; }
        public int quality { get; set; }
        public bool status { get; set; }
        public Product product { get; set; }
    }
}
