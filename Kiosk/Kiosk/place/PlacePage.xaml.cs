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
using Kiosk.order;
using Kiosk.pay;

namespace Kiosk.place
{
    /// <summary>
    /// PlacePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PlacePage : Page
    {
        public PlacePage()
        {
            InitializeComponent();
        }

        private void InMarket_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TablePage());
        }

        private void OutMarket_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PayPage());
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage());
        }
    }
}
