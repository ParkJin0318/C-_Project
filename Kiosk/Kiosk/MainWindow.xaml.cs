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
using Kiosk.remote;

namespace Kiosk
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RemoteConnection remoteConnection;

        public MainWindow()
        {
            InitializeComponent();
            remoteConnection = new RemoteConnection();
            
            SetTime();

            Thread thread = new Thread(remoteConnection.GetServerMessage);
            thread.Start();
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
                if (MessageBox.Show("주문 취소", "주문 취소 하실건가요?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    App.selectFoodList.Clear();
                    FrameLayout.NavigationService.Navigate(new IntroPage());
                }
            } else
            {
                FrameLayout.NavigationService.Navigate(new IntroPage());
            }
        }
    }
}
