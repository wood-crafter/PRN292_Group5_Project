using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class OrderDao :DBContext
    {
        public List<Order> getAllOrder(int account_id)
        {
            List<Order> orders = new List<Order>();
            string sql = "SELECT order_id, quality, status, p.product_id, product_name, " +
                "description, image, price, store_name, address " +
                "FROM [Order] o , Product p, Store s " +
                "WHERE o.product_id = p.product_id " +
                "AND s.store_id=p.store_id AND account_id = @account_id";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@account_id", account_id));
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
                    Order order = new Order();
                    order.order_id= Convert.ToInt32(reader["order_id"]);
                    order.quality = Convert.ToInt32(reader["quality"]);
                    order.status = (bool)reader["status"];
                    order.product = product;
                    orders.Add(order);
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
            return orders;
        }
        public bool delete(int order_id)
        {
            string sql = "DELETE FROM [dbo].[Order] WHERE order_id = @order_id";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@order_id", order_id));
                con.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
            return true;
        }

        public void update(int order_id, int quality)
        {
            string sql = "UPDATE [dbo].[Order] SET [quality] = @quality WHERE order_id = @order_id";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@quality", quality));
                command.Parameters.Add(new SqlParameter("@order_id", order_id));
                con.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public void addFood(int account_id, Product product)
        {
            string sql = "INSERT INTO [dbo].[Order]([account_id],[product_id],[quality],[order_date],[status]) " +
                "VALUES(@account_id,@product_id,@quality,@order_date,@status)";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@account_id", account_id));
                command.Parameters.Add(new SqlParameter("@product_id", product.product_id));
                command.Parameters.Add(new SqlParameter("@quality", 1));
                command.Parameters.Add(new SqlParameter("@order_date", DateTime.Now));
                command.Parameters.Add(new SqlParameter("@status", false));
                con.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public List<int> checkDuplicate(int account_id, int product_id)
        {
            List<int> vs = new List<int>();
            string sql = "SELECT order_id, quality FROM[Order] WHERE account_id = @account_id AND product_id = @product_id";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@account_id", account_id));
                command.Parameters.Add(new SqlParameter("@product_id", product_id));
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    vs.Add(Convert.ToInt32(reader["order_id"]));
                    vs.Add(Convert.ToInt32(reader["quality"]));
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
            return vs;
        }
    }
}
