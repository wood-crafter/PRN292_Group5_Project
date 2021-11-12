using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProductDao:DBContext
    {
        public List<Product> productAdvertisement()
        {
            List<Product> products = new List<Product>();
            string sql = "SELECT p.product_id, product_name, description, image, price, store_name, address " +
                "FROM Product p,Store s, Advertisement a " +
                "WHERE p.product_id=a.product_id";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.product_id = Convert.ToInt32(reader["product_id"]);
                    product.product_name = reader["product_name"].ToString();
                    product.description = reader["description"].ToString();
                    product.image = reader["image"].ToString();
                    product.price = float.Parse(reader["price"].ToString());
                    product.store_name = reader["store_name"].ToString();
                    product.address = reader["address"].ToString();                
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return products;
        }

        public List<Product> productByTypes(int type_id)
        {
            List<Product> products = new List<Product>();
            string sql = "SELECT product_id, product_name, abstract, description, image, price, store_name, address, time_open, time_close " +
                "FROM Product, Store WHERE Product.store_id=Store.store_id ";
            if (type_id != -1)
            {
                sql += "AND type_id = @type_id";
            }
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                if (type_id != -1)
                {
                    command.Parameters.Add(new SqlParameter("@type_id", type_id));
                }
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.product_id = Convert.ToInt32(reader["product_id"]);
                    product._abstract= reader["abstract"].ToString();
                    product.product_name = reader["product_name"].ToString();
                    product.description = reader["description"].ToString();
                    product.image = reader["image"].ToString();
                    product.price = float.Parse(reader["price"].ToString());
                    product.store_name = reader["store_name"].ToString();
                    product.address = reader["address"].ToString();
                    product.time_open = reader["time_open"].ToString();
                    product.time_close = reader["time_close"].ToString();
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return products;
        }
        public List<Product> search(string txtSearch)
        {
            List<Product> products = new List<Product>();
            string sql = "SELECT product_id, product_name, abstract, description, image, price, store_name, address, time_open, time_close " +
                "FROM Product, Store " +
                "WHERE Product.store_id=Store.store_id AND product_name like @txtSearch or store_name like @txtSearch";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@txtSearch", "%"+txtSearch+"%"));
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.product_id = Convert.ToInt32(reader["product_id"]);
                    product._abstract = reader["abstract"].ToString();
                    product.product_name = reader["product_name"].ToString();
                    product.description = reader["description"].ToString();
                    product.image = reader["image"].ToString();
                    product.price = float.Parse(reader["price"].ToString());
                    product.store_name = reader["store_name"].ToString();
                    product.address = reader["address"].ToString();
                    product.time_open = reader["time_open"].ToString();
                    product.time_close = reader["time_close"].ToString();
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return products;
        }
    }
}
