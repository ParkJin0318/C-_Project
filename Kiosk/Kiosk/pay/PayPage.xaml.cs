using Kiosk.pay;
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
using Kiosk.place;
using System.Collections.ObjectModel;

namespace Kiosk.pay
{
    /// <summary>
    /// PayPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PayPage : Page
    {
        public PayPage()
        {
            InitializeComponent();
            listView.ItemsSource = App.selectFoodList;

            orderTotalPrice();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlacePage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CardPage());
            App.payType = 0;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CashPage());
            App.payType = 1;
        }

        private void orderTotalPrice()
        {
            order_price.Content = "총 주문 금액 : " + App.totalPrice;
        }
    }
}
