using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class OrderDetailDao : DBContext
    {
        public void addOrder(OrderDetail orderDetail)
        {
            string sql = "INSERT INTO [dbo].[OrderDetail]([account_id],[recipient_name],[recipient_address]," +
                "[recipient_phone],[product_id],[quality],[order_date]) " +
                "VALUES(@account_id,@recipient_name,@recipient_address,@recipient_phone,@product_id,@quality,@order_date)";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@account_id", orderDetail.account_id));
                command.Parameters.Add(new SqlParameter("@recipient_name", orderDetail.recipient_name));
                command.Parameters.Add(new SqlParameter("@recipient_address", orderDetail.recipient_address));
                command.Parameters.Add(new SqlParameter("@recipient_phone", orderDetail.recipient_phone));
                command.Parameters.Add(new SqlParameter("@product_id", orderDetail.product_id));
                command.Parameters.Add(new SqlParameter("@quality", orderDetail.quality));
                command.Parameters.Add(new SqlParameter("@order_date", orderDetail.order_date));
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

        public Product getProduct(int product_id)
        {
            string sql = "SELECT product_id, product_name, abstract, description, image, price, store_name, address, time_open, time_close " +
                "FROM Product, Store WHERE Product.store_id=Store.store_id AND product_id = @product_id";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@product_id", product_id));
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
                    return product;
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
            return null;
        }

        public List<OrderDetail> getAllOrderDetail(int account_id)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            string sql = "SELECT id, account_id, recipient_name, recipient_address, recipient_phone, product_id, quality, order_date " +
                "FROM OrderDetail WHERE account_id = @account_id";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@account_id", account_id));
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.id = Convert.ToInt32(reader["id"]);
                    orderDetail.account_id = Convert.ToInt32(reader["account_id"]);
                    orderDetail.recipient_name = reader["recipient_name"].ToString();
                    orderDetail.recipient_address = reader["recipient_address"].ToString();
                    orderDetail.recipient_phone = Convert.ToInt32(reader["recipient_phone"].ToString());
                    orderDetail.product_id = Convert.ToInt32(reader["product_id"]);
                    orderDetail.quality = Convert.ToInt32(reader["quality"]);
                    orderDetail.order_date = DateTime.Parse(reader["order_date"].ToString());
                    orderDetails.Add(orderDetail);
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
            return orderDetails;
        }
    }
}
