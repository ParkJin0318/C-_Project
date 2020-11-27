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

namespace Kiosk.stats
{
    /// <summary>
    /// DayProfitsPage_M.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DayProfitsPageMain : Page
    {
        private DateTime chekingDay;

        public DayProfitsPageMain()
        {
            InitializeComponent();
            chekingDay = DateTime.Now;
            UpdateTimeText();
        }

        public void UpdateTimeText()
        {
            xCheckDay.Text = chekingDay.Year + "년 " + chekingDay.Month + "월 " + chekingDay.Day + "일";
            chartFrame.NavigationService.Navigate(new Kiosk.stats.DayProfitsPageFrame(chekingDay));
        }

        private void tomorrowClick(object sender, RoutedEventArgs e)
        {
            chekingDay = chekingDay.AddDays(1);
            UpdateTimeText();
        }

        private void yesterdayClick(object sender, RoutedEventArgs e)
        {
            chekingDay = chekingDay.AddDays(-1);
            UpdateTimeText();
        }
    }
}
