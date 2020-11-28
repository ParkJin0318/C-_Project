using LiveCharts;
using LiveCharts.Defaults;
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
    /// AllProfitsDataPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AllProfitsPage : Page
    {
        public AllProfitsPage(int[] profits, string[] names)
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection { };
            AddSeries(profits, names);

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }

        private void AddSeries(int[] profits, string[] names)
        {
            for (var i = 0; i < profits.Length; i++)
            {
                SeriesCollection.Add(new PieSeries
                {
                    Title = names[i],
                    Values = new ChartValues<ObservableValue> { new ObservableValue(profits[i]) },
                    DataLabels = true
                });
            }

        }
    }
}
