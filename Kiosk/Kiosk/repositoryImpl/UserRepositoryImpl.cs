using Kiosk.model;
using Kiosk.mananger;
using Kiosk.repository;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiosk.util;

namespace Kiosk.repositoryImpl
{
    class UserRepositoryImpl : UserRepository
    {
        private readonly DBManager dbManager;

        public UserRepositoryImpl()
        {
            dbManager = new DBManager();
        }

        public List<User> GetAllUser()
        {
            List<User> userList = new List<User>();
            MySqlDataReader reader = dbManager.GetDBData("Select * from user");

            while (reader.Read())
            {
                User user = new User();

                user.idx = int.Parse(reader["idxUser"].ToString());
                user.name = reader["name"].ToString();
                user.id = reader["id"].ToString();
                user.isAuto = Convert.ToBoolean(int.Parse(reader["isAuto"].ToString()));
                user.qrCode = reader["QRCode"].ToString();
                user.barCode = reader["BaCode"].ToString();

                userList.Add(user);
            }
            return userList;
        }

        public Market GetMarket(int idx)
        {
            Market market = new Market();
            MySqlDataReader reader = dbManager.GetDBData("Select * from market where idxmarket = " + idx + ";");

            if (reader.Read())
            {
                market.idx = int.Parse(reader["idxmarket"].ToString());
                market.name = reader["name"].ToString();
                market.totalTime = reader["time"].ToString();
                Console.WriteLine(market.totalTime);
            }

            return market;
        }

        public void SetMessage(User user, string message, bool isGroup)
        {
            JObject json = new JObject();
            json.Add("MSGType", 1);
            json.Add("id", user.id);
            json.Add("Content", message);
            json.Add("ShopName", "");
            json.Add("OrderNumber", "");
            json.Add("Group", isGroup);
            json.Add("Menus", "");

            String data = JsonConvert.SerializeObject(json);
            App.serverManager.SetServerData(data);
        }
    }
}
