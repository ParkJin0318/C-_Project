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
        private AllProfitsData _allProfits;

        public AllProfitsPageViewModel()
        {
            repository = new StatsRepositoryImpl();
            allProfits = repository.GetAllProfitsData();
        }

        public AllProfitsData allProfits
        {
            get => _allProfits;
            set => SetProperty(ref _allProfits, value);
        }

        public int[] GetRealProfitsValues()
        {
            List<int> values = new List<int>();
            values.Add(allProfits.realProfits);
            values.Add(allProfits.saledProfits);
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
            values.Add(allProfits.cashProfits);
            values.Add(allProfits.cardProfits);
            return values.ToArray();
        }

        public string[] GetCashProfitsNames()
        {
            string[] names = { "현금", "카드" };
            return names;
        }
    }
}