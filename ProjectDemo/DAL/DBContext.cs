using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DBContext
    {
        protected SqlConnection con;
        public DBContext()
        {
            con = new SqlConnection(
                ConfigurationManager.ConnectionStrings["strCon"].ToString()
                );
        }
    }
}
