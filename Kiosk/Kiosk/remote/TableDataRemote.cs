
using Kiosk.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Kiosk.remote
{
    class TableDataRemote
    {
        private readonly RemoteConnection connection;
        private int currentMarketIdx = 1;

        public TableDataRemote()
        {
            connection = new RemoteConnection();
        }

        public List<TableData> GetLastOrderTimes()
        {
            List<TableData> TableDataList = new List<TableData>();
            for (int i = 1; i < 10; i++)
            {
                TableData Td = new TableData();
                MySqlDataReader reader = connection.GetData("select * from orders where eatTable = " + i
                    + " and idxMarket = " + currentMarketIdx + " order by idxOrder desc");

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

            connection.con.Close();

            return TableDataList;
        }
    }
}
