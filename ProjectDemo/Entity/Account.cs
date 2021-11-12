using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Account
    {
        public int account_id { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public DateTime date_of_birth { get; set; }
        public bool gender { get; set; }
    }
}
