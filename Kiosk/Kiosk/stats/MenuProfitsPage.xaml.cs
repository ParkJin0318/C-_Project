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
    /// MenuDataPae.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuProfitsPage : Page
    {

        public MenuProfitsPage(double[] counts, double[] profits, string[] names)
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "판매 총 수량",
                    Values = new ChartValues<double> (counts)
                }
            };

            SeriesCollection.Add(new RowSeries
            {
                Title = "판매 총 총액(0.01 = 100원)",
                Values = new ChartValues<double>(profits)
            });


            Labels = names;
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}
