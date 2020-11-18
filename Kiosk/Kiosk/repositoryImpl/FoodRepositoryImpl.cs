using Kiosk.remote;
using Kiosk.repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.repositoryImpl
{
    class FoodRepositoryImpl : FoodRepository
    {
        private readonly RemoteConnection connection;

        public FoodRepositoryImpl()
        {
            connection = new RemoteConnection();
        }

        public List<Food> GetAllFood()
        {
            List<Food> foodList = new List<Food>();
            MySqlDataReader reader = connection.GetDBData("Select * from menu");

            while (reader.Read())
            {
                Food food = new Food();
                food.idx = int.Parse(reader["idxMenu"].ToString());
                food.name = reader["MenuName"].ToString();
                food.category = (Category)int.Parse(reader["category"].ToString());
                food.imagePath = reader["img"].ToString();
                food.page = int.Parse(reader["page"].ToString());
                food.sale = int.Parse(reader["sale"].ToString());
                food.originalPrice = int.Parse(reader["price"].ToString());
                food.price = food.originalPrice - food.sale;

                foodList.Add(food);
            }
            return foodList;
        }

        public void SetFoodSale(Food food, int sale)
        {
            connection.SetDBData("update menu set sale = " + sale + " where idxMenu = " + food.idx + ";");
        }
    }
}
