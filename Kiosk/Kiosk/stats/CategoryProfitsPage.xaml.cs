using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kiosk.stats
{
    /// <summary>
    /// CategoryDataPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CategoryProfitsPage : Page
    {
        private CategoryProfitsPageViewModel viewModel;

        public CategoryProfitsPage(int tableNumber)
        {
            InitializeComponent();
            viewModel = new CategoryProfitsPageViewModel();
            viewModel.SetData(tableNumber);

            xLoading.Visibility = Visibility.Hidden;

            DataContext = viewModel;
        }

        private void File_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CreateFile();
        }
    }
}
