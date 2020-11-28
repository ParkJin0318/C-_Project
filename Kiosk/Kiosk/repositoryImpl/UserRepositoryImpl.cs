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
                user.qrCode = reader["QRCode"].ToString();
                user.barCode = reader["BaCode"].ToString();

                Console.WriteLine(user.name);

                userList.Add(user);
            }
            return userList;
        }

        public void SetMessage(string message, bool isGroup)
        {
            JObject json = new JObject();
            json.Add("MSGType", 1);
            json.Add("id", "2210");
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
