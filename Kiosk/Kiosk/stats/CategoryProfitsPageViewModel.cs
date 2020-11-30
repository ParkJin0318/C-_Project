using Kiosk.model.Stats;
using Kiosk.repository;
using Kiosk.repositoryImpl;
using LiveCharts;
using LiveCharts.Wpf;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.stats
{
    class CategoryProfitsPageViewModel : BindableBase
    {
        private StatsRepository statsRepository;
        private FileRepository fileRepository;

        private List<MenuProfitsData> _data = new List<MenuProfitsData>();
        private bool _isEnabled;

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public CategoryProfitsPageViewModel()
        {
            statsRepository = new StatsRepositoryImpl();
            fileRepository = new FileRepositoryImpl();
        }

        public List<MenuProfitsData> data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        public bool isEnabled
        {
            set => SetProperty(ref _isEnabled, value);
            get => _isEnabled;
        }

        public void SetData(int tableNumber)
        {
            if (tableNumber == 0)
                this.data = statsRepository.GetCategoryProfitsData(0, 9);
            else
                this.data = statsRepository.GetCategoryProfitsData(tableNumber, tableNumber);

            SeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "판매 총 수량",
                    Values = new ChartValues<double> (this.GetSumCount(0, 3))
                }
            };

            SeriesCollection.Add(new RowSeries
            {
                Title = "판매 총 총액(0.01 = 100원)",
                Values = new ChartValues<double>(this.GetSumProfits(0, 3))
            });


            Labels = this.GetNames(0, 3);
            Formatter = value => value.ToString("N");
            isEnabled = true;
        }

        public double[] GetSumCount(int startPoint, int endPoint)
        {
            List<double> buffer = new List<double>();
            for (int i = startPoint; i < endPoint; i++)
            {
                buffer.Add(Convert.ToDouble(data.ElementAt(i).count));
            }
            return buffer.ToArray();
        }

        public double[] GetSumProfits(int startPoint, int endPoint)
        {
            List<double> buffer = new List<double>();
            for (int i = startPoint; i < endPoint; i++)
            {
                buffer.Add(Convert.ToDouble(data.ElementAt(i).sumProfits) / 10000.0);
            }
            return buffer.ToArray();
        }

        public string[] GetNames(int startPoint, int endPoint)
        {
            List<string> buffer = new List<string>();
            for (int i = startPoint; i < endPoint; i++)
            {
                buffer.Add(data.ElementAt(i).name);
            }
            return buffer.ToArray();
        }

        public void CreateFile()
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.SelectedPath;
                fileRepository.CreateFileStats(path, this.data);
            }
        }
    }
}