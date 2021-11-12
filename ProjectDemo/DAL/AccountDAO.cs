using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class AccountDAO : DBContext
    {
        public Account login(string email, string password)
        {
            string sql = "SELECT account_id, full_name, email, password, address, date_of_birth, gender " +
                "FROM Account " +
                "WHERE email = @email AND password = @password";
            Account account = null;
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@email", email));
                command.Parameters.Add(new SqlParameter("@password", password));
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    account = new Account();
                    account.account_id = Convert.ToInt32(reader["account_id"].ToString());
                    account.full_name = reader["full_name"].ToString();
                    account.email = reader["email"].ToString();
                    account.password = reader["password"].ToString();
                    account.address = reader["address"].ToString();
                    account.date_of_birth = DateTime.Parse(reader["date_of_birth"].ToString());
                    account.gender = bool.Parse(reader["gender"].ToString());
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
            return account;
        }



        public string findNameByEmail(string email)
        {
            String sql = "SELECT [full_name] FROM [Account] WHERE [email] = @email";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@email", email));
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return reader["full_name"].ToString();
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

        public bool register(Account account)
        {
            string sql = "INSERT INTO [dbo].[Account]([full_name],[email],[password],[address],[date_of_birth],[gender]) " +
                "VALUES(@full_name,@email,@password,@address,@date_of_birth,@gender)";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@full_name", account.full_name));
                command.Parameters.Add(new SqlParameter("@email", account.email));
                command.Parameters.Add(new SqlParameter("@password", account.password));
                command.Parameters.Add(new SqlParameter("@address", account.address));
                command.Parameters.Add(new SqlParameter("@date_of_birth", account.date_of_birth));
                command.Parameters.Add(new SqlParameter("@gender", account.gender));
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

        public bool resetPassword(string email, string password)
        {
            string sql = "UPDATE [dbo].[Account] SET [password] = @password WHERE email= @email";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.Add(new SqlParameter("@password", password));
                command.Parameters.Add(new SqlParameter("@email", email));
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
    }
}
