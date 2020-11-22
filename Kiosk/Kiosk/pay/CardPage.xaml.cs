using Kiosk.model;
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
    /// CardPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CardPage : Page
    {

        private readonly UserRepository userRepository;
        private readonly OrderRepository orderRepository;

        public CardPage()
        {
            InitializeComponent();
            userRepository = new UserRepositoryImpl();
            orderRepository = new OrderRepositoryImpl();
            webcam.CameraIndex = 0;

            orderTotalPrice();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PayPage());
        }

        private void UserQrCodeSearch(String qrcode)
        {
            List<User> users = userRepository.GetAllUser();

            foreach (User item in users)
            {
                if (item.qrCode == qrcode)
                {
                    orderRepository.SetOrderList(App.selectFoodList, 1, 1, App.tableIdx, App.payType);

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
