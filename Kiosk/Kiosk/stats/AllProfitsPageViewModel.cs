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
    class AllProfitsPageViewModel : BindableBase
    {
        private StatsRepository repository;
        private AllProfitsData _data;

        public AllProfitsPageViewModel()
        {
            repository = new StatsRepositoryImpl();
            data = repository.GetAllProfitsData();
        }

        public AllProfitsData data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        public int[] GetRealProfitsValues()
        {
            List<int> values = new List<int>();
            values.Add(data.realProfits);
            values.Add(data.saledProfits);
            return values.ToArray();
        }

        public string[] GetRealProfitsNames()
        {
            string[] names = { "순이익", "할인 금액" };
            return names;
        }

        public int[] GetCashProfitsValues()
        {
            List<int> values = new List<int>();
            values.Add(data.cashProfits);
            values.Add(data.cardProfits);
            return values.ToArray();
        }

        public string[] GetCashProfitsNames()
        {
            string[] names = { "현금", "카드" };
            return names;
        }
    }
}