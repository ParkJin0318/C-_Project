using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Kiosk.database
{
    class MenuCache
    {
        string server = "Server=10.80.162.216;uid=root;pwd=NFSedge2020;database=Kiosk;";

        public List<Food> GetAllFood()
        {
            List<Food> foodList = new List<Food>();
            MySqlConnection con = new MySqlConnection(server);
            MySqlCommand cmd = con.CreateCommand();

            string sql = "Select * from menu";
            cmd.CommandText = sql;

            con.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string sale = reader["sale"].ToString();
                
                Food food = new Food();
                switch (int.Parse(reader["category"].ToString()))
                {
                    case 1:
                        food.category = Category.BURGER;
                        break;
                    case 2:
                        food.category = Category.DRINK;
                        break;
                    case 3:
                        food.category = Category.SIDE;
                        break;
                }
                food.idx = int.Parse(reader["idxMenu"].ToString());
                food.name = reader["MenuName"].ToString();
                food.price = int.Parse(reader["price"].ToString());
                food.imagePath = reader["img"].ToString();
                food.page = int.Parse(reader["page"].ToString());

                foodList.Add(food);
            }

            return foodList;
        }
    }
}
