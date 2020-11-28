using Kiosk.mananger;
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
        private readonly DBManager manager;

        public FoodRepositoryImpl()
        {
            manager = new DBManager();
        }

        public List<Food> GetAllFood()
        {
            List<Food> foodList = new List<Food>();
            MySqlDataReader reader = manager.GetDBData("Select * from menu");

            while (reader.Read())
            {
                Food food = new Food();
                food.idx = int.Parse(reader["idxMenu"].ToString());
                food.name = reader["MenuName"].ToString();
                food.category = (Category)int.Parse(reader["category"].ToString());
                food.imagePath = reader["img"].ToString();
                food.page = int.Parse(reader["page"].ToString());
                food.isSoldOut = Convert.ToBoolean(int.Parse(reader["isSoldOut"].ToString()));
                food.sale = int.Parse(reader["sale"].ToString());
                food.originalPrice = int.Parse(reader["price"].ToString());
                food.price = food.originalPrice - food.sale;

                if (food.isSoldOut) food.state = "품절";
                else food.state = "구매 가능";

                foodList.Add(food);
            }
            return foodList;
        }

        public void SetFoodSale(Food food, int sale)
        {
            manager.SetDBData("update menu set sale = " + sale + " where idxMenu = " + food.idx + ";");
        }

        public void setFoodSoldOut(Food food, int isSoldOut)
        {
            manager.SetDBData("update menu set isSoldOut = " + isSoldOut + " where idxMenu = " + food.idx + ";");
        }
    }
}
