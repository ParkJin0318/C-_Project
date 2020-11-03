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

        private int GetMaxOrderIdx()
        {
            MySqlDataReader reader = connection.GetData("Select idxOrders from orders " 
                + "order by idxOrders desc");

            while (reader.Read())
            {
                Console.WriteLine(int.Parse(reader["idxOrders"].ToString()));
                return int.Parse(reader["idxOrders"].ToString());
            }
            connection.con.Close();
            return 0;
        }

        public void SetOrderList(ObservableCollection<Food> foodList, int tableIdx, int payType)
        {
            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd HH:mm:ss");

            foreach (Food item in foodList)
            {
                int idxOrder = this.GetMaxOrderIdx() + 1;

                connection.SetData("insert into orders (idxOrders, idxMenu, idxUser, idxMarket, payTime, payType, howMany, eatTable) "
                    + "values (" + idxOrder + ", " + item.idx + ", 1, 1, '" + date + "', 1, " + item.count + ", " + tableIdx + ");");
            }
            connection.con.Close();
        }
    }
}
