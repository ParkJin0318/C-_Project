﻿using Kiosk.remote;
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
    /// MessagePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MessagePage : Page
    {
        private UserRemote remote;
        public MessagePage()
        {
            InitializeComponent();
            remote = new UserRemote();
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            remote.SetMessage(InputBox.Text, false);
            InputBox.Text = "";
        }

        private void Group_Input_Click(object sender, RoutedEventArgs e)
        {
            remote.SetMessage(InputBox.Text, true);
            InputBox.Text = "";
        }
    }
}