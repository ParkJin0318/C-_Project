using Kiosk.model.Stats;
using Kiosk.repository;
using Kiosk.repositoryImpl;
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
        private StatsRepository repository;
        private List<MenuProfitsData> _data = new List<MenuProfitsData>();

        public CategoryProfitsPageViewModel()
        {
            repository = new StatsRepositoryImpl();
        }

        public List<MenuProfitsData> data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        public void SetData()
        {
            this.data = repository.GetCategoryProfitsData(0, 9);
        }

        public void SetData(int talbeNumber)
        {
            this.data = repository.GetCategoryProfitsData(talbeNumber, talbeNumber);
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
    }
}