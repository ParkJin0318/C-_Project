using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.remote
{
    class OrderRemote
    {
        private readonly RemoteConnection connection;

        public OrderRemote()
        {
            connection = new RemoteConnection();
        }

        private int GetMaxIdx()
        {
            MySqlDataReader reader = connection.GetData("Select idx from orders " 
                + "order by idx desc");

            while (reader.Read())
            {
                return int.Parse(reader["idx"].ToString());
            }
            connection.con.Close();
            return 0;
        }

        public int GetMaxOrderIdx()
        {
            MySqlDataReader reader = connection.GetData("Select idxOrder from orders "
                + "order by idxOrder desc");

            while (reader.Read())
            {
                return int.Parse(reader["idxOrder"].ToString());
            }
            connection.con.Close();
            return 0;
        }

        public void SetOrderList(ObservableCollection<Food> foodList, int tableIdx, int payType)
        {
            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd HH:mm:ss");

            int idxOreder = this.GetMaxOrderIdx() + 1;

            foreach (Food item in foodList)
            {
                int idx = this.GetMaxIdx() + 1;

                connection.SetData("insert into orders (idx, idxOrder, idxMenu, idxUser, idxMarket, payTime, payType, count, eatTable, totalPrice, salePrice) "
                    + "values (" + idx + ", " + idxOreder + ", " + item.idx + ", 1, 1, '" + date + "', 1, " + item.count + ", " + tableIdx + ", " + item.totalPrice + ", " + item.totalSale + ");");
            }
            connection.con.Close();
        }
    }
}
