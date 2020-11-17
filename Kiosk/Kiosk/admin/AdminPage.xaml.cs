using Kiosk.remote;
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
    /// AdminPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AdminPage : Page
    {
        private readonly AdminViewModel viewModel;

        public AdminPage()
        {
            InitializeComponent();
            viewModel = new AdminViewModel();

            DataContext = viewModel;
        }

        private void Stats_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StatsPage());
        }

        private void Sale_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SalePage());
        }

        private void Message_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MessagePage());
        }
    }
}
