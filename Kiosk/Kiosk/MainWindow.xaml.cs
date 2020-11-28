using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Kiosk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AuthRepository repository;

        public MainWindow()
        {
            InitializeComponent();
            repository = new AuthRepositoryImpl();
            SetTime();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.client.Connected == true)
            {
                    ConnectButton.Content = "연결 중";
                    ConnectButton.Background = new SolidColorBrush(Colors.LightGreen);
            }
            if (App.client.Connected == false)
            {
                    ConnectButton.Content = "연결 실패";
                    ConnectButton.Background = new SolidColorBrush(Colors.Red);
                
                repository.SetLogin();
            }
        }

        private void SetTime()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
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
            repository.SetLogin();
        }
    }
}
