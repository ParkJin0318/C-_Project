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
    class MenuProfitsPageViewModel : BindableBase
    {
        private StatsRepository repository;
        private List<MenuProfitsData> _menuProfitsList = new List<MenuProfitsData>();

        public MenuProfitsPageViewModel()
        {
            repository = new StatsRepositoryImpl();
        }

        public List<MenuProfitsData> menuProfitsList
        {
            get => _menuProfitsList;
            set => SetProperty(ref _menuProfitsList, value);
        }

        public void SetData()
        {
            this.menuProfitsList = repository.GetMenuProfitsData(0, 9);
        }

        public void SetData(int talbeNumber)
        {
            this.menuProfitsList = repository.GetMenuProfitsData(talbeNumber, talbeNumber);
        }

        public double[] GetSumCount(int startPoint, int endPoint)
        {
            List<double> buffer = new List<double>();
            for (int i = startPoint; i < endPoint; i++)
            {
                buffer.Add(Convert.ToDouble(menuProfitsList.ElementAt(i).count));
            }
            return buffer.ToArray();
        }

        public double[] GetSumProfits(int startPoint, int endPoint)
        {
            List<double> buffer = new List<double>();
            for (int i = startPoint; i < endPoint; i++)
            {
                buffer.Add(Convert.ToDouble(menuProfitsList.ElementAt(i).sumProfits) / 10000.0);
            }
            return buffer.ToArray();
        }

        public string[] GetNames(int startPoint, int endPoint)
        {
            List<string> buffer = new List<string>();
            for (int i = startPoint; i < endPoint; i++)
            {
                buffer.Add(menuProfitsList.ElementAt(i).name);
            }
            return buffer.ToArray();
        }
    }
}