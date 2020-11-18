using Kiosk.remote;
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
    class AuthRepositoryImpl : AuthRepository
    {
        private readonly RemoteConnection connection;

        public AuthRepositoryImpl()
        {
            connection = new RemoteConnection();
        }

        public bool IsAutoLogin()
        {
            String id = "2210";
            MySqlDataReader reader = connection.GetDBData("Select * from user where id = '" + id + "';");

            while (reader.Read())
            {
                if (reader["isAuto"].ToString() == "1")
                {
                    return true;
                }
            }

            return false;
        }

        public void SetAutoLogin()
        {
            String id = "2210";
            connection.SetDBData("update user set isAuto = 1 where id = '" + id + "';");
        }

        public void SetLogin()
        {
            JObject json = new JObject();
            json.Add("MSGType", 0);
            json.Add("id", "2210");
            json.Add("Content", "");
            json.Add("ShopName", "");
            json.Add("OrderNumber", "");
            json.Add("Menus", "");

            String data = JsonConvert.SerializeObject(json);
            connection.SetServerData(data);
        }

    }
}
