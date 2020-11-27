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
    class DayProfitsDataViewModel : BindableBase
    {
        private StatsRepository repository;
        private DayProfitsData _data;

        public void SetData(DateTime checkDay) //true : Menu, false : Category
        {
            repository = new StatsRepositoryImpl();
            data = repository.GetDayProfitsData(checkDay);

        }

        public DayProfitsData data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        public double[] GetHoursProfits(int startPoint, int endPoint)
        {
            List<double> buffer = new List<double>();
            for (int i = startPoint; i < endPoint; i++)
            {
                buffer.Add(Convert.ToDouble(data.hoursProfits.ElementAt(i)) / 10000.0);
            }
            return buffer.ToArray();
        }

        public string[] GetNames(int startPoint, int endPoint)
        {
            List<string> buffer = new List<string>();
            for (int i = startPoint; i < endPoint; i++)
            {
                buffer.Add(i + "시");
            }
            return buffer.ToArray();
        }
    }
}
