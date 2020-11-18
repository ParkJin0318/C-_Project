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

        static bool isSend = false;

        public void SetServerData(string data)
        {
            if (App.client != null)
            {
                byte[] sendData = Encoding.UTF8.GetBytes(data);

                try
                {
                    NetworkStream networkStream = App.client.GetStream();
                    networkStream.Write(sendData, 0, sendData.Length);
                    isSend = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void GetServerMessage()
        {
            if (App.client != null)
            {
                try
                {
                    NetworkStream stream = App.client.GetStream();
                    
                    byte[] bytes = new byte[256];
                    string data = null;
                    

                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = Encoding.UTF8.GetString(bytes, 0, i);

                        if (isSend == false)
                        {
                            ToastMessage toast = new ToastMessage();
                            toast.ShowNotification("서버 메세지", data);
                        }
                        isSend = false;
                    }
                } 
                catch(Exception e)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
