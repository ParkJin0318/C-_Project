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
    /// AllProfitsPageFrame.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AllProfitsPageFrame : Page
    {
        private AllProfitsPageViewModel viewModel;

        public AllProfitsPageFrame()
        {
            InitializeComponent();
            viewModel = new AllProfitsPageViewModel();

            allProfits.Text = "총 수익 : " + viewModel.data.allProfits.ToString() + "원";

            realProfits.NavigationService.Navigate(new Kiosk.stats.AllProfitsPage(viewModel.GetRealProfitsValues(), viewModel.GetRealProfitsNames()));
            cashProfits.NavigationService.Navigate(new Kiosk.stats.AllProfitsPage(viewModel.GetCashProfitsValues(), viewModel.GetCashProfitsNames()));
        }
    }
}
