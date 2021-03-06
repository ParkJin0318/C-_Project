﻿using Kiosk.model;
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

        private readonly OrderRepository orderRepository;

        public CardPage()
        {
            InitializeComponent();
            userName.Content = "회원명: " + App.loginUser.name;
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
            foreach (User item in App.userList)
            {
                if (item.qrCode == qrcode)
                {
                    orderRepository.SetOrderList(App.selectFoodList, App.loginUser, App.market, App.tableIdx, App.payType);

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
            order_price.Content = "총 주문 금액 : " + App.totalPrice + "원";
        }
    }
}
