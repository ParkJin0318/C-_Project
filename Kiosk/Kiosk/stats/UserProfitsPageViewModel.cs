using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiosk.model.Stats;
using Kiosk.repository;
using Kiosk.repositoryImpl;
using Prism.Mvvm;

namespace Kiosk.stats
{
    class UserProfitsPageViewModel : BindableBase
    {
        private StatsRepository repository;
        private List<UserProfitsData> _userProfitsList;

        public UserProfitsPageViewModel()
        {
            repository = new StatsRepositoryImpl();
            userProfitsList = repository.GetUserProfitsData();
        }

        public List<UserProfitsData> userProfitsList
        {
            get => _userProfitsList;
            set => SetProperty(ref _userProfitsList, value);
        }

        public void ReverseData(int index)
        {
            userProfitsList.ElementAt(index).menuData.Reverse();
        }

        public void SortData(int index)
        {
            userProfitsList.ElementAt(index).menuData.Sort();
        }

        public List<MenuProfitsData> GetMenueProfitsData(int index)
        {
            return userProfitsList.ElementAt(index).menuData;
        }
    }
}
