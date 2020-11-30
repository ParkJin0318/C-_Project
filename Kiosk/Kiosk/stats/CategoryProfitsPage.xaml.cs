using LiveCharts;
using LiveCharts.Wpf;
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
    /// CategoryDataPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CategoryProfitsPage : Page
    {
        private CategoryProfitsPageViewModel viewModel;

        public CategoryProfitsPage(int tableNumber)
        {
            InitializeComponent();
            viewModel = new CategoryProfitsPageViewModel();
            if (tableNumber == 0)
                viewModel.SetData();
            else
                viewModel.SetData(tableNumber);

            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "판매 총 수량",
                    Values = new ChartValues<double> (viewModel.GetSumCount(0, 3))
                }
            };

            SeriesCollection.Add(new RowSeries
            {
                Title = "판매 총 총액(0.01 = 100원)",
                Values = new ChartValues<double>(viewModel.GetSumProfits(0, 3))
            });


            Labels = viewModel.GetNames(0, 3);
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private void File_Click(object sender, RoutedEventArgs e)
        {
            viewModel.CreateFile();
        }
    }
}
