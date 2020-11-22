using Kiosk.model;
using Kiosk.remote;
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

namespace Kiosk.repositoryImpl
{
    class OrderRepositoryImpl : OrderRepository
    {
        private readonly RemoteConnection connection;

        public OrderRepositoryImpl()
        {
            connection = new RemoteConnection();
        }

        public List<TableData> GetAllTableInfo()
        {
            List<TableData> TableDataList = new List<TableData>();
            for (int i = 1; i < 10; i++)
            {
                TableData Td = new TableData();
                MySqlDataReader reader = connection.GetDBData("select * from orders where eatTable = " + i
                    + " and idxMarket = " + 1 + " order by idx desc");

                Td.myTableNumber = i;
                Td.TimeRemaining = 0;
                Td.useText = "이용가능";
                Td.canUse = true;
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
            MySqlDataReader reader = connection.GetDBData("Select idx from orders "
                + "order by idx desc");

            while (reader.Read())
            {
                return int.Parse(reader["idx"].ToString());
            }
            return 0;
        }

        public int GetMaxOrderIdx()
        {
            MySqlDataReader reader = connection.GetDBData("Select idxOrder from orders "
               + "order by idxOrder desc");

            while (reader.Read())
            {
                return int.Parse(reader["idxOrder"].ToString());
            }
            return 0;
        }

        public void SendOrderInfo(ObservableCollection<Food> foodList, int orderIdx)
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
            json.Add("id", "2210");
            json.Add("Content", "");
            json.Add("ShopName", "맥도날드");
            json.Add("OrderNumber", orderIdx);
            json.Add("Menus", menuList);

            String data = JsonConvert.SerializeObject(json);
            connection.SetServerData(data);
        }

        public void SetOrderList(ObservableCollection<Food> foodList, int userIdx, int marketIdx, int tableIdx, int payType)
        {
            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd HH:mm:ss");

            int idxOreder = this.GetMaxOrderIdx() + 1;

            foreach (Food item in foodList)
            {
                int idx = this.GetMaxIdx() + 1;
                connection.SetDBData("insert into orders (idx, idxOrder, idxMenu, idxUser, idxMarket, payTime, payType, count, eatTable, totalPrice, salePrice) "
                    + "values (" + idx + ", " + idxOreder + ", " + item.idx + ", "+ userIdx + ", "+ marketIdx + ", '" + date + "', " + payType + ", " + item.count + ", " + tableIdx + ", " + item.totalPrice + ", " + item.totalSale + ");");
            }
            this.SendOrderInfo(foodList, idxOreder);
        }
    }
}
