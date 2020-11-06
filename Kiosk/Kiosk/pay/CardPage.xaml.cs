using Kiosk.model;
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
    /// CardPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CardPage : Page
    {
        public CardPage()
        {
            InitializeComponent();

            webcam.CameraIndex = 0;

            orderTotalPrice();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PayPage());
        }

        private void UserQrCodeSearch(String qrcode)
        {
            UserRemote UserRemote = new UserRemote();
            OrderRemote OrderRemote = new OrderRemote();
            List<User> users = UserRemote.GetAllUser();

            foreach (User item in users)
            {
                if (item.qrCode == qrcode)
                {
                    OrderRemote.SetOrderList(App.selectFoodList, App.tableIdx, App.payType);

                    NavigationService.Navigate(new CompletePage());
                }
                else
                {
                    MessageBox.Show("존재하지 않는 유저입니다");
                }
            }
        }

        private void webcam_QrDecoded(object sender, string e)
        {
            tbRecog.Text = e;

            UserQrCodeSearch(tbRecog.Text);
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
