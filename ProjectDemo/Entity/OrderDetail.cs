using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int account_id { get; set; }
        public string recipient_name { get; set; }
        public string recipient_address { get; set; }
        public int recipient_phone { get; set; }
        public int product_id { get; set; }
        public int quality { get; set; }
        public DateTime order_date { get; set; }
    }
}
