﻿using Kiosk.mananger;
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
        private readonly DBManager dbManager;

        public AuthRepositoryImpl()
        {
            dbManager = new DBManager();
        }

        public bool IsAutoLogin(string id)
        {
            MySqlDataReader reader = dbManager.GetDBData("Select * from user where id = '" + id + "';");

            while (reader.Read())
            {
                if (reader["isAuto"].ToString() == "1")
                {
                    return true;
                }
            }

            return false;
        }

        public void SetAutoLogin(string id)
        {
            dbManager.SetDBData("update user set isAuto = 1 where id = '" + id + "';");
        }

        public void SetLogin(string id)
        {
            JObject json = new JObject();
            json.Add("MSGType", 0);
            json.Add("id", id);
            json.Add("Content", "");
            json.Add("ShopName", "");
            json.Add("OrderNumber", "");
            json.Add("Menus", "");

            String data = JsonConvert.SerializeObject(json);
            App.serverManager.SendServerMessage(data);
        }

    }
}
