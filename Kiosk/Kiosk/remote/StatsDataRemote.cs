using Kiosk.model.Stats;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.remote
{
    class StatsDataRemote
    {
        private readonly RemoteConnection connection;

        public StatsDataRemote()
        {
            connection = new RemoteConnection();
        }

        public List<MenuCategoryData> GetMenuData(int sTableNumber, int eTableNumber)
        {
            List<MenuCategoryData> menuData = new List<MenuCategoryData>();

            for (int i = 1; i < 45; i++)
            {
                int totalPrice = 0;
                int totalCount = 0;
                MenuCategoryData buffer = new MenuCategoryData();
                MySqlDataReader reader = connection.GetDBData("select idxMenu, count, totalPrice, salePrice, eatTable from orders"
                    + " where idxMenu = " + i + " and eatTable >= " + sTableNumber + " and eatTable <= " + eTableNumber + ";");
                while (reader.Read())
                {
                    int count = Int32.Parse(reader["count"].ToString());
                    totalCount += count;
                    totalPrice += (Int32.Parse(reader["totalPrice"].ToString()) * count
                        + Int32.Parse(reader["salePrice"].ToString()) * count);
                }
                buffer.count = totalCount;
                buffer.sumProfits = totalPrice;

                reader = connection.GetDBData("select idxMenu, MenuName from menu where idxMenu = " + i);
                if (reader.Read())
                {
                    buffer.name = reader["menuName"].ToString();
                }
                menuData.Add(buffer);
            }

            return menuData;
        }

        public List<MenuCategoryData> GetCategoryData(int sTableNumber, int eTableNumber)
        {
            string[] categoryName = { "햄버거", "드링크", "사이드 메뉴" };
            List<MenuCategoryData> categoryData = new List<MenuCategoryData>();

            for (int i = 1, checking = 1; i < 4; i++)
            {
                int totalPrice = 0;
                int totalCount = 0;
                int Nchecking = 0;
                MenuCategoryData buffer = new MenuCategoryData();

                MySqlDataReader reader = connection.GetDBData("select category, idxMenu from menu where category = "
                    + i + " order by idxMenu desc");
                if (reader.Read())
                {
                    Nchecking = Int32.Parse(reader["idxMenu"].ToString());
                }

                reader = connection.GetDBData("select idxMenu, count, totalPrice, salePrice, eatTable from orders "
                    + " where idxMenu >= " + checking + " and idxMenu  <= " + Nchecking
                    + " and eatTable >= " + sTableNumber + " and eatTable <= " + eTableNumber + ";");
                checking = ++Nchecking;

                while (reader.Read())
                {
                    int count = Int32.Parse(reader["count"].ToString());
                    totalCount += count;
                    totalPrice += (Int32.Parse(reader["totalPrice"].ToString()) * count
                        + Int32.Parse(reader["salePrice"].ToString()) * count);
                }
                buffer.count = totalCount;
                buffer.sumProfits = totalPrice;
                buffer.name = categoryName[(i - 1)];
                categoryData.Add(buffer);
            }

            return categoryData;
        }

        public DayProfits GetDayData(DateTime checkDay)
        {
            DayProfits dayProfit = new DayProfits();
            int[] hourProfit = new int[24];

            MySqlDataReader reader = connection.GetDBData("select payTime, count, totalPrice, salePrice from orders");

            while (reader.Read())
            {
                string readTime = reader["payTime"].ToString();
                if (Int32.Parse(readTime.Substring(0, 4)) == checkDay.Year
                    && Int32.Parse(readTime.Substring(5, 2)) == checkDay.Month
                    && Int32.Parse(readTime.Substring(8, 2)) == checkDay.Month)
                {
                    int sumPrice = (Int32.Parse(reader["totalPrice"].ToString())
                        + Int32.Parse(reader["salePrice"].ToString()))
                        * Int32.Parse(reader["count"].ToString());
                    hourProfit[(Int32.Parse(readTime.Substring(11, 2)))] += sumPrice;
                    dayProfit.sumProfits += sumPrice;
                }
            }
            dayProfit.hoursProfits = hourProfit.ToList();
            return dayProfit;
        }

        public List<UserData> GetUserData()
        {
            List<UserData> usersData = new List<UserData>();

            MySqlDataReader reader = connection.GetDBData("select max(idxUser) as MaxIdx from user");
            if (reader.Read())
            {
                int userNumbers = Int32.Parse(reader["MaxIdx"].ToString()) + 1;
                for (int i = 1; i < userNumbers; i++)
                {
                    int profits = 0;
                    UserData bufferUserData = new UserData();
                    List<MenuCategoryData> bufferMenuData = new List<MenuCategoryData>();
                    for (int j = 1; j < 45; j++)
                    {
                        MenuCategoryData buffer = new MenuCategoryData();
                        reader = connection.GetDBData("select idxMenu, count, totalPrice from orders where idxMenu = " + j);
                        while (reader.Read())
                        {
                            buffer.count += Int32.Parse(reader["count"].ToString());
                            profits += (Int32.Parse(reader["count"].ToString()) * Int32.Parse(reader["totalPrice"].ToString()));
                        }
                        reader = connection.GetDBData("select idxMenu, MenuName from menu where idxMenu = " + j);
                        if (reader.Read())
                        {
                            buffer.name = reader["MenuName"].ToString();
                        }
                        bufferMenuData.Add(buffer);
                    }
                    bufferUserData.menuData = bufferMenuData;
                    bufferUserData.sumProfits = profits;
                    usersData.Add(bufferUserData);
                }
            }

            return usersData;
        }

        public AllProfitsData GetAllProfitsData()
        {
            AllProfitsData newAllPorfitsData = new AllProfitsData();
            MySqlDataReader reader = connection.GetDBData("select payType, count, totalPrice, salePrice form orders");
            while (reader.Read())
            {
                int count = Int32.Parse(reader["count"].ToString());
                int totalPrice = Int32.Parse(reader["totalPrice"].ToString());
                int salePrice = Int32.Parse(reader["salePrice"].ToString());
                bool payType = (Int32.Parse(reader["payType"].ToString()) == 0) ? true : false; //true : 현금, false : 카드

                if (payType)
                    newAllPorfitsData.cashProfits += (count * (totalPrice + salePrice));
                else
                    newAllPorfitsData.cardProfits += (count * (totalPrice + salePrice));

                newAllPorfitsData.realProfits += (count * totalPrice);
                newAllPorfitsData.saledProfits += (count * salePrice);
                newAllPorfitsData.allProfits += (count * (totalPrice + salePrice));
            }
            return newAllPorfitsData;
        }

        public DateTime GetKioskRunTime()
        {
            DateTime runTime = new DateTime();
            MySqlDataReader reader = connection.GetDBData("select idxMarket, totalTime from market where idxMarket = " + 1);
            if (reader.Read())
                runTime = DateTime.Parse(reader["totalTime"].ToString());
            return runTime;
        }
    }
}
