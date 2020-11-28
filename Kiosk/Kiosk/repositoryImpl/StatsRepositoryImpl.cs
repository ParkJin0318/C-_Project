using Kiosk.model.Stats;
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
    class StatsRepositoryImpl : StatsRepository
    {
        private readonly DBManager manager;

        public StatsRepositoryImpl()
        {
            manager = new DBManager();
        }

        public AllProfitsData GetAllProfitsData()
        {
            AllProfitsData newAllPorfitsData = new AllProfitsData();
            MySqlDataReader reader = manager.GetDBData("select payType, count, totalPrice, salePrice from orders");
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

        public List<MenuProfitsData> GetCategoryProfitsData(int startTableIdx, int endTableIdx)
        {
            string[] categoryName = { "햄버거", "드링크", "사이드 메뉴" };
            List<MenuProfitsData> categoryData = new List<MenuProfitsData>();

            for (int i = 1, check = 1; i < 4; i++)
            {
                int totalPrice = 0;
                int totalCount = 0;
                
                int menuIdx = 0;
                MenuProfitsData menuProfits = new MenuProfitsData();

                MySqlDataReader reader = manager.GetDBData("select category, idxMenu from menu where category = "
                    + i + " order by idxMenu desc");
                if (reader.Read())
                {
                    menuIdx = Int32.Parse(reader["idxMenu"].ToString());
                }

                reader = manager.GetDBData("select idxMenu, count, totalPrice, salePrice, eatTable from orders "
                    + " where idxMenu >= " + check + " and idxMenu  <= " + menuIdx
                    + " and eatTable >= " + startTableIdx + " and eatTable <= " + endTableIdx + ";");
                check = ++menuIdx;

                while (reader.Read())
                {
                    int count = Int32.Parse(reader["count"].ToString());
                    totalCount += count;
                    totalPrice += (Int32.Parse(reader["totalPrice"].ToString()) * count
                        + Int32.Parse(reader["salePrice"].ToString()) * count);
                }
                menuProfits.count = totalCount;
                menuProfits.sumProfits = totalPrice;
                menuProfits.name = categoryName[(i - 1)];
                categoryData.Add(menuProfits);
            }

            return categoryData;
        }

        public DayProfitsData GetDayProfitsData(DateTime checkDay)
        {
            DayProfitsData dayProfit = new DayProfitsData();
            int[] hourProfit = new int[24];

            MySqlDataReader reader = manager.GetDBData("select payTime, count, totalPrice, salePrice from orders");

            while (reader.Read())
            {
                DateTime readTime = DateTime.Parse(reader["payTime"].ToString());
                if (readTime.Year == checkDay.Year && readTime.Month == checkDay.Month && readTime.Day == checkDay.Day)
                {
                    int sumPrice = (Int32.Parse(reader["totalPrice"].ToString())
                        + Int32.Parse(reader["salePrice"].ToString()))
                        * Int32.Parse(reader["count"].ToString());
                    hourProfit[readTime.Hour] += sumPrice;
                    dayProfit.sumProfits += sumPrice;
                }
            }
            dayProfit.hoursProfits = hourProfit.ToList();
            return dayProfit;
        }

        public DateTime GetKioskRunTimeData()
        {
            DateTime runTime = new DateTime();
            MySqlDataReader reader = manager.GetDBData("select idxMarket, totalTime from market where idxMarket = " + 1);
            if (reader.Read())
                runTime = DateTime.Parse(reader["totalTime"].ToString());
            return runTime;
        }

        public List<MenuProfitsData> GetMenuProfitsData(int startTableIdx, int endTableIdx)
        {
            List<MenuProfitsData> menuData = new List<MenuProfitsData>();

            for (int i = 1; i < 45; i++)
            {
                int totalPrice = 0;
                int totalCount = 0;
                MenuProfitsData buffer = new MenuProfitsData();
                MySqlDataReader reader = manager.GetDBData("select idxMenu, count, totalPrice, salePrice, eatTable from orders"
                    + " where idxMenu = " + i + " and eatTable >= " + startTableIdx + " and eatTable <= " + endTableIdx + ";");
                while (reader.Read())
                {
                    int count = Int32.Parse(reader["count"].ToString());
                    totalCount += count;
                    totalPrice += (Int32.Parse(reader["totalPrice"].ToString()) * count
                        + Int32.Parse(reader["salePrice"].ToString()) * count);
                }
                buffer.count = totalCount;
                buffer.sumProfits = totalPrice;

                reader = manager.GetDBData("select idxMenu, MenuName from menu where idxMenu = " + i);
                if (reader.Read())
                {
                    buffer.name = reader["menuName"].ToString();
                }
                menuData.Add(buffer);
            }

            return menuData;
        }

        public List<UserProfitsData> GetUserProfitsData()
        {
            List<UserProfitsData> usersData = new List<UserProfitsData>();

            MySqlDataReader reader = manager.GetDBData("select max(idxUser) as MaxIdx from user");
            if (reader.Read())
            {
                int userNumbers = Int32.Parse(reader["MaxIdx"].ToString()) + 1;
                for (int i = 1; i < userNumbers; i++)
                {
                    int profits = 0;
                    UserProfitsData bufferUserData = new UserProfitsData();
                    List<MenuProfitsData> bufferMenuData = new List<MenuProfitsData>();
                    for (int j = 1; j < 45; j++)
                    {
                        MenuProfitsData buffer = new MenuProfitsData();
                        reader = manager.GetDBData("select idxMenu, count, totalPrice from orders where idxMenu = " + j);
                        while (reader.Read())
                        {
                            buffer.count += Int32.Parse(reader["count"].ToString());
                            profits += (Int32.Parse(reader["count"].ToString()) * Int32.Parse(reader["totalPrice"].ToString()));
                        }
                        reader = manager.GetDBData("select idxMenu, MenuName from menu where idxMenu = " + j);
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
    }
}
