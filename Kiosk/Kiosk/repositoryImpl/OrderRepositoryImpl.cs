using Kiosk.model;
using Kiosk.mananger;
using Kiosk.repository;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Kiosk.util;

namespace Kiosk.repositoryImpl
{
    class OrderRepositoryImpl : OrderRepository
    {
        private readonly DBManager dbManager;

        public OrderRepositoryImpl()
        {
            dbManager = new DBManager();
        }

        public List<TableData> GetAllTableInfo(int marketIdx)
        {
            List<TableData> TableDataList = new List<TableData>();
            for (int i = 1; i < 10; i++)
            {
                TableData Td = new TableData();
                MySqlDataReader reader = dbManager.GetDBData("select * from orders where eatTable = " + i
                    + " and idxMarket = " + marketIdx + " order by idx desc");

                Td.myTableNumber = i;
                Td.TimeRemaining = 0;
                Td.useText = "이용가능";
                Td.canUse = true;
                Td.payTime = "";
                Td.TableColor = new SolidColorBrush(Colors.Red);

                if (reader.Read())
                {
                    string ReadTime = reader["payTime"].ToString();

                    DateTime lastEatStart = Convert.ToDateTime(ReadTime);
                    DateTime now = DateTime.Now;
                    TimeSpan dateDiff = now - lastEatStart;

                    int diffSec = Convert.ToInt32(dateDiff.TotalSeconds);

                    if (diffSec <= 60)
                    {
                        Td.TimeRemaining = 60 - diffSec;
                        Td.useText = "이용중 : " + Td.TimeRemaining;
                        Td.canUse = false;
                        Td.payTime = "결제된 시간: " + lastEatStart.ToString();
                        Td.TableColor = new SolidColorBrush(Colors.Yellow);
                        Td.MakeTimer();
                    }
                }
                TableDataList.Add(Td);
            }

            return TableDataList;
        }

        public int GetMaxIdx()
        {
            MySqlDataReader reader = dbManager.GetDBData("Select idx from orders "
                + "order by idx desc");

            while (reader.Read())
            {
                return int.Parse(reader["idx"].ToString());
            }
            return 0;
        }

        public int GetMaxOrderIdx()
        {
            MySqlDataReader reader = dbManager.GetDBData("Select idxOrder from orders "
               + "order by idxOrder desc");

            while (reader.Read())
            {
                return int.Parse(reader["idxOrder"].ToString());
            }
            return 0;
        }

        public void SendOrderInfo(ObservableCollection<Food> foodList, User user, string marketName, int orderIdx)
        {
            JObject json = new JObject();
            JArray menuList = new JArray();

            foreach (Food item in foodList)
            {
                JObject menu = new JObject();
                menu.Add("Name", item.name);
                menu.Add("Count", item.count);
                menu.Add("Price", item.totalPrice);

                menuList.Add(menu);
            }

            json.Add("MSGType", 2);
            json.Add("id", user.id);
            json.Add("Content", "");
            json.Add("ShopName", marketName);
            json.Add("OrderNumber", string.Format("{0:D3}", orderIdx));
            json.Add("Group", true);
            json.Add("Menus", menuList);

            String data = JsonConvert.SerializeObject(json);
            App.serverManager.SetServerData(data);
        }

        public void SetOrderList(ObservableCollection<Food> foodList, User user, Market market, int tableIdx, int payType)
        {
            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd HH:mm:ss");

            int idxOreder = this.GetMaxOrderIdx() + 1;

            foreach (Food item in foodList)
            {
                int idx = this.GetMaxIdx() + 1;
                dbManager.SetDBData("insert into orders (idx, idxOrder, idxMenu, idxUser, idxMarket, payTime, payType, count, eatTable, totalPrice, salePrice) "
                    + "values (" + idx + ", " + idxOreder + ", " + item.idx + ", "+ user.idx + ", "+ market.idx + ", '" + date + "', " + payType + ", " + item.count + ", " + tableIdx + ", " + item.totalPrice + ", " + item.totalSale + ");");
            }
            this.SendOrderInfo(foodList, user, market.name, idxOreder);
        }
    }
}
