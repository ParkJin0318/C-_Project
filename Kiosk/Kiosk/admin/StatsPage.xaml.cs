﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Kiosk.stats;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kiosk.repository;
using Kiosk.repositoryImpl;
using Kiosk.util;
using System.Windows.Threading;
using System.Threading;

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
            FrameLayout1.NavigationService.Navigate(new AllProfitsPageFrame());
            SetTime();
        }

        private void SetTime()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            int temp = App.totalRunTime;
            int hour = temp / 3600;
            temp = temp % 3600;
            int min = temp / 60;
            temp = temp % 60;

            RunTime.Content = "총 구동시간: " + hour + ":" + min + ":" + temp;
        }

        private void AllProfits_Click(object sender, RoutedEventArgs e)
        {
            FrameLayout1.NavigationService.Navigate(new AllProfitsPageFrame());
        }

        private void MenuProfits_Click(object sender, RoutedEventArgs e)
        {
            FrameLayout1.NavigationService.Navigate(new MenuProfitsPageFrame(0));
        }

        private void CategoryProfits_Click(object sender, RoutedEventArgs e)
        {
            FrameLayout1.NavigationService.Navigate(new CategoryProfitsPage(0));
        }

        private void TableProfits_Click(object sender, RoutedEventArgs e)
        {
            FrameLayout1.NavigationService.Navigate(new TableProfitsPage(1, true));
        }

        private void DayProfits_Click(object sender, RoutedEventArgs e)
        {
            FrameLayout1.NavigationService.Navigate(new DayProfitsPageMain());
        }

        private void UserProfits_Click(object sender, RoutedEventArgs e)
        {
            FrameLayout1.NavigationService.Navigate(new UserProfitsPage());
        }
    }
}
