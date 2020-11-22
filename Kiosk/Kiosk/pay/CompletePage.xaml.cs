using Kiosk.remote;
using Kiosk.repository;
using Kiosk.repositoryImpl;
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
        private readonly OrderRepository repository;

        public CompletePage()
        {
            InitializeComponent();
            repository = new OrderRepositoryImpl();

            orderNumber();
            orderTotalPrice();
        }

        private void orderNumber()
        {
            order_Num.Content = "주문번호 : " + repository.GetMaxOrderIdx().ToString();
        }

        private void orderTotalPrice()
        {
            ObservableCollection<Food> foodList = App.selectFoodList;

            int totalPrice = 0;

            foreach (Food item in foodList)
            {
                totalPrice += item.totalPrice;
            }

            order_price.Content = "총 주문 금액 : " + totalPrice;
        }
    }
}
