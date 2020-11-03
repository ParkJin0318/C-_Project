using Kiosk.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.remote
{
    class UserRemote
    {
        private readonly RemoteConnection connection;

        public UserRemote()
        {
            connection = new RemoteConnection();
        }
        
        public List<User> GetAllUser()
        {
            List<User> userList = new List<User>();
            MySqlDataReader reader = connection.GetData("Select * from user");

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

            connection.con.Close();
            return userList;
        }
    }
}
