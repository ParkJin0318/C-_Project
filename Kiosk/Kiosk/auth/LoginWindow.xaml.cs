using Kiosk.mananger;
using Kiosk.model;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Kiosk.auth
{
    /// <summary>
    /// LoginPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly AuthRepository authRepository;
        private readonly UserRepository userRepository;

        public LoginWindow()
        {
            InitializeComponent();

            App.serverManager.ServerConnect();
            this.OnErrorNotifiy();

            authRepository = new AuthRepositoryImpl();
            userRepository = new UserRepositoryImpl();

            this.SetUserList();
            this.AutoLoginCheck();
        }

        private void OnErrorNotifiy()
        {
            if (!App.serverManager.isConnected)
            {
                ToastMessage toast = new ToastMessage();
                toast.ShowNotification("서버 에러", "서버가 연결되어 있지 않습니다");
            }
        }

        private void SetUserList()
        {
            App.userList = userRepository.GetAllUser();
            App.market = userRepository.GetMarket(Constants.TEST_MARKET_IDX);
        }

        private void AutoLoginCheck()
        {
            if (authRepository.IsAutoLogin(Constants.SAVE_ID))
            {
                userId.Text = Constants.SAVE_ID;
                userPw.Text = "123";
                SetLogin();
            }
        }

        private bool IsUser()
        {
            foreach (User item in App.userList)
            {
                if (userId.Text == item.id && userPw.Text == "123")
                {
                    App.loginUser = item;
                    return true;
                }
            }

            return false;
        }

        public void SetLogin()
        {
            if (IsUser())
            {
                authRepository.SetLogin(App.loginUser.id);

                if (AutoCheck.IsChecked == true)
                {
                    authRepository.SetAutoLogin(App.loginUser.id);
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
