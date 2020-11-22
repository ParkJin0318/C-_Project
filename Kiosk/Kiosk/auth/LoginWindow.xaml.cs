using Kiosk.remote;
using Kiosk.repository;
using Kiosk.repositoryImpl;
using Kiosk.util;
using MySql.Data.MySqlClient.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kiosk.auth
{
    /// <summary>
    /// LoginPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly AuthRepository repository;

        public LoginWindow()
        {
            InitializeComponent();

            if (NetworkInterface.GetIsNetworkAvailable() == true)
            {
                try
                {
                    App.client = new TcpClient(Constants.SERVER_HOST, Constants.SERVER_PORT);
                } catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            repository = new AuthRepositoryImpl();

            if (repository.IsAutoLogin()) {
                repository.SetLogin();
                this.ShowMainWindow();
            }
        }

        public void SetLogin()
        {
            if (userId.Text == "2210" && userPw.Text == "123")
            {
                repository.SetLogin();
                if (AutoCheck.IsChecked == true)
                {
                    repository.SetAutoLogin();
                }
                
                this.ShowMainWindow();
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호가 틀렸습니다");
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.SetLogin();
        }

        private void ShowMainWindow()
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
