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
        private List<UserProfitsData> _data;

        public UserProfitsPageViewModel()
        {
            repository = new StatsRepositoryImpl();
            data = repository.GetUserProfitsData();
        }

        public List<UserProfitsData> data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        public void ReverseData(int index)
        {
            data.ElementAt(index).menuData.Reverse();
        }

        public List<MenuProfitsData> GetMenueProfitsData(int index)
        {
            return data.ElementAt(index).menuData;
        }
    }
}
