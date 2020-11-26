using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Kiosk.admin
{
    /// <summary>
    /// StatsPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StatsPage : Page
    {
        public StatsPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameLayout1.NavigationService.Navigate(new Kiosk.data.AllProfitsDataPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameLayout1.NavigationService.Navigate(new data.MenuDataPage_F(0));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FrameLayout1.NavigationService.Navigate(new Kiosk.data.CategoryDataPage(0));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            FrameLayout1.NavigationService.Navigate(new Kiosk.data.SeatDataPage(1, true));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FrameLayout1.NavigationService.Navigate(new Kiosk.data.DayProfitsPage_M());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            FrameLayout1.NavigationService.Navigate(new Kiosk.data.UserDataPage());
        }
    }
}
