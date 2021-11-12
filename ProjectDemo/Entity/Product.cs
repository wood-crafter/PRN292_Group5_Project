using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Product
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string _abstract { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public float price { get; set; }
        public string store_name { get; set; }
        public string address { get; set; }
        public string time_open { get; set; }
        public string time_close { get; set; }
    }
}
