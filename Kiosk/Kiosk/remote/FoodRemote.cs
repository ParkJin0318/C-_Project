using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiosk.remote;
using Kiosk.util;
using MySql.Data.MySqlClient;

namespace Kiosk.database
{
    class FoodRemote
    {
        private readonly RemoteConnection connection;

        public FoodRemote()
        {
            connection = new RemoteConnection();
        }

        public List<Food> GetAllFood()
        {
            List<Food> foodList = new List<Food>();
            MySqlDataReader reader = connection.GetData("Select * from menu");

            while (reader.Read())
            {
                Food food = new Food();
                food.idx = int.Parse(reader["idxMenu"].ToString());
                food.name = reader["MenuName"].ToString();
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
                food.price = int.Parse(reader["price"].ToString());
                food.imagePath = reader["img"].ToString();
                food.page = int.Parse(reader["page"].ToString());
                string sale = reader["sale"].ToString();

                foodList.Add(food);
            }

            connection.con.Close();
            return foodList;
        }
    }
}
