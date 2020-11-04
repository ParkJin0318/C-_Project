using Kiosk.remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Kiosk.pay
{
    /// <summary>
    /// CompletePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CompletePage : Page
    {
        public CompletePage()
        {
            InitializeComponent();

            orderNumber();
            orderTotalPrice();
        }

        private void orderNumber()
        {
            OrderRemote remote = new OrderRemote();

            order_Num.Content = "주문번호 : " + remote.GetMaxOrderIdx().ToString();
        }

        private void orderTotalPrice()
        {
            ObservableCollection<Food> foodList = App.selectFoodList;

            int totalPrice = 0;

            foreach (Food item in foodList)
            {
                totalPrice += item.currentPrice;
            }

            order_price.Content = "총 주문 금액 : " + totalPrice;
        }
    }
}
