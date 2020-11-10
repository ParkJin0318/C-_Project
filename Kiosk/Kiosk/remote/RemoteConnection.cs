using System;
using System.Collections.Generic;
using System.Linq;
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
        public TcpClient client;

        public RemoteConnection()
        {
            con = new MySqlConnection(Constants.DEFAULT_HOST);
            client = new TcpClient(Constants.SERVER_HOST, Constants.SERVER_PORT);
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

        public void SetServerData(string data)
        {
            NetworkStream networkStream = null;
            byte[] sendData = Encoding.UTF8.GetBytes(data);

            try
            {
                networkStream = client.GetStream();
                networkStream.Write(sendData, 0, sendData.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("실패");
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
