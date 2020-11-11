using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Kiosk.util;
using MySql.Data.MySqlClient;

namespace Kiosk.remote
{
    class RemoteConnection
    {
        public MySqlConnection con;

        public RemoteConnection()
        {
            con = new MySqlConnection(Constants.DEFAULT_HOST);
        }

        public MySqlDataReader GetDBData(string sql)
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;

            try
            {
                con.Close();
                con.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            MySqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public void SetDBData(string sql)
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;

            try
            {
                con.Close();
                con.Open();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            cmd.ExecuteNonQuery();
        }

        public bool SetServerData(string data)
        {
            if (App.client != null)
            {
                byte[] sendData = Encoding.UTF8.GetBytes(data);

                try
                {
                    NetworkStream networkStream = App.client.GetStream();
                    networkStream.Write(sendData, 0, sendData.Length);

                    Int32 bytes = networkStream.Read(sendData, 0, sendData.Length);
                    String responseData = Encoding.ASCII.GetString(sendData, 0, bytes);

                    if (responseData == "200")
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }

            }
            return false;
        }
    }
}
