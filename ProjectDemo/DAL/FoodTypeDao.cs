using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FoodTypeDao : DBContext
    {
        public List<FoodType> getTypeOfFood()
        {
            List<FoodType> foodTypes = new List<FoodType>();
            string sql = "SELECT * FROM FoodType";
            try
            {
                SqlCommand command = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    FoodType foodType = new FoodType();
                    foodType.type_id = Convert.ToInt32(reader["type_id"]);
                    foodType.type_name = reader["type_name"].ToString();
                    foodTypes.Add(foodType);
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
            return foodTypes;
        }
    }
}
