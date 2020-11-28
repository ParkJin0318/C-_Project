using Kiosk.repository;
using Kiosk.repositoryImpl;
using Kiosk.util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.mananger
{
    public class ServerManager
    {
        public TcpClient client;

        private readonly StatsRepository statsRepository;
        private readonly UserRepository userRepository;

        static bool isSend = false;
        public bool isConnected;

        public ServerManager()
        {
            statsRepository = new StatsRepositoryImpl();
            userRepository = new UserRepositoryImpl();
        }

        public void ServerConnect()
        {
            try
            {
                client = new TcpClient();
                var result = client.BeginConnect(Constants.SERVER_HOST, Constants.SERVER_PORT, null, null);
                bool success = result.AsyncWaitHandle.WaitOne(1000, true);

                if (success)
                {
                    client.EndConnect(result);
                    isConnected = true;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("실패");
                Console.WriteLine(e.ToString());
                isConnected = false;
            }
        }

        public void SetServerData(string data)
        {
            if (isConnected)
            {
                byte[] sendData = Encoding.UTF8.GetBytes(data);

                try
                {
                    NetworkStream networkStream = client.GetStream();
                    networkStream.Write(sendData, 0, sendData.Length);
                    isSend = true;
                    isConnected = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(e.ToString());
                    isConnected = false;
                }
            }
        }

        public void GetServerMessage()
        {
            if (isConnected)
            {
                try
                {
                    NetworkStream stream = client.GetStream();

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
                        isConnected = true;

                        if (data.Contains("총 매출액"))
                        {
                            int totalPrice = statsRepository.GetAllProfitsData().allProfits;
                            userRepository.SetMessage(App.loginUser, totalPrice + "원", true);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(e.ToString());
                    isConnected = false;
                }
            }
        }
    }
}
