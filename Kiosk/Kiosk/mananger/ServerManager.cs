using Kiosk.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.mananger
{
    class ServerManager
    {
        static bool isSend = false;
        public void SetServerData(string data)
        {
            if (App.client.Connected)
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
            if (App.client.Connected)
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
                catch (Exception e)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
