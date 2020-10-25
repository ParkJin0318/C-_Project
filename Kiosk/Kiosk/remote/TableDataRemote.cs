
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.remote
{
    class TableDataRemote
    {
        private readonly RemoteConnection connection;
        private int CheckingTable;
        int ThisMarketIdx = 1;

        public TableDataRemote(int CheckingTable)
        {
            connection = new RemoteConnection();
            this.CheckingTable = CheckingTable;
        }

        public string CheckLastEatStart()
        {
            MySqlDataReader reader = connection.GetData("select * from orders where eatTable = " + this.CheckingTable
                + " and idxMarket = " + ThisMarketIdx + " order by idxOrders desc");
            if (reader.Read())
            {
                return reader["payTime"].ToString();
            }
            return "";
        }
    }
}
