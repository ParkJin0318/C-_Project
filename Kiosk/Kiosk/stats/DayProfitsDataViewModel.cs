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
        private DayProfitsData _dayProfits;

        public void SetData(DateTime checkDay) //true : Menu, false : Category
        {
            repository = new StatsRepositoryImpl();
            dayProfits = repository.GetDayProfitsData(checkDay);

        }

        public DayProfitsData dayProfits
        {
            get => _dayProfits;
            set => SetProperty(ref _dayProfits, value);
        }

        public double[] GetHoursProfits(int startPoint, int endPoint)
        {
            List<double> buffer = new List<double>();
            for (int i = startPoint; i < endPoint; i++)
            {
                buffer.Add(Convert.ToDouble(dayProfits.hoursProfits.ElementAt(i)) / 10000.0);
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
