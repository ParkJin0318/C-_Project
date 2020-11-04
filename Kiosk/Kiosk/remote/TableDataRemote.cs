
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
        private int checkedTable;
        private int currentMarketIdx = 1;

        public TableDataRemote(int checkedTable)
        {
            connection = new RemoteConnection();
            this.checkedTable = checkedTable;
        }

        public string GetOrderTime()
        {
            MySqlDataReader reader = connection.GetData("select * from orders where eatTable = " + this.checkedTable
                + " and idxMarket = " + currentMarketIdx + " order by idxOrder desc");
            if (reader.Read())
            {
                return reader["payTime"].ToString();
            }
            connection.con.Close();
            return "";
        }
    }
}
