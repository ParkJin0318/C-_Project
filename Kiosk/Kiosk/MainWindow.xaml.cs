using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Kiosk.auth;
using Kiosk.intro;
using Kiosk.repository;
using Kiosk.repositoryImpl;
using Kiosk.util;

namespace Kiosk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AuthRepository authRepository;

        public MainWindow()
        {
            InitializeComponent();
            authRepository = new AuthRepositoryImpl();

            this.SetConnectTime();
            this.SetTime();

            this.StartServerConnectThread();
            this.StartGetServerMessageThread();
        }

        private void SetConnectTime()
        {
            if (App.serverManager.isConnected)
            {
                CurrentTime.Text = "최근 접속 시간: " + DateTime.Now.ToString();
            }
            else
            {
                CurrentTime.Text = "접속 실패 했습니다";
            }
        }

        private void StartServerConnectThread()
        {
            Thread thread = new Thread(SetServerConnectState);
            thread.IsBackground = true;
            thread.Start();
        }

        private void StartGetServerMessageThread()
        {
            Thread thread = new Thread(App.serverManager.ReciveServerMessage);
            thread.IsBackground = true;
            thread.Start();
        }

        private void SetServerConnectState()
        {
            while (true)
            {
                if (App.serverManager.isConnected)
                {
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                    {
                        ConnectButton.Content = "연결 중";
                        ConnectButton.Background = new SolidColorBrush(Colors.LightGreen);
                    }));
                }
                else
                {
                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                    {
                        ConnectButton.Content = "연결 실패";
                        ConnectButton.Background = new SolidColorBrush(Colors.Red);
                    }));

                    App.serverManager.ServerConnect();
                    if (App.serverManager.isConnected)
                    {
                        authRepository.SetLogin(App.loginUser.id);
                        StartGetServerMessageThread();
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                        {
                            CurrentTime.Text = "최근 접속 시간: " + DateTime.Now.ToString();
                        }));
                    }
                }
            }
        }

        private void SetTime()
        {
            App.totalRunTime = App.market.time;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            App.totalRunTime++;
            Time.Text = DateTime.Now.ToString();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {

            if (App.selectFoodList.Count > 0)
            {
                if (MessageBox.Show("홈으로 이동", "홈으로 이동하실건가요?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    App.selectFoodList.Clear();
                    FrameLayout.NavigationService.Navigate(new IntroPage());
                }
            } else
            {
                FrameLayout.NavigationService.Navigate(new IntroPage());
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            authRepository.SetLogin(App.loginUser.id);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                FrameLayout.Source = new Uri("admin/AdminPage.xaml", UriKind.Relative);
            }
        }
    }
}
