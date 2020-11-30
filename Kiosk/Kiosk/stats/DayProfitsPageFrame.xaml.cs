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
    /// DayProfitsPage_F.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DayProfitsPageFrame : Page
    {
        private DayProfitsDataViewModel viewModel = new DayProfitsDataViewModel();
        public DayProfitsPageFrame(DateTime checkingDay)
        {
            InitializeComponent();
            viewModel.SetData(checkingDay);
            xLoading.Visibility = Visibility.Hidden;
            livChartFrame.NavigationService.Navigate(new Kiosk.stats.DayProfitsPageChart(viewModel.GetHoursProfits(0, 12), viewModel.GetNames(0, 12)));
            Profits.Text = "총 매출액 : " + viewModel.data.sumProfits + "원";
        }

        public void UpdateData(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            int nowIndex = (cb.SelectedIndex + 1) * 12;
            if (livChartFrame != null)
                livChartFrame.NavigationService.Navigate(new Kiosk.stats.DayProfitsPageChart(viewModel.GetHoursProfits(nowIndex - 12, nowIndex), viewModel.GetNames(nowIndex - 12, nowIndex)));
        }
    }
}
