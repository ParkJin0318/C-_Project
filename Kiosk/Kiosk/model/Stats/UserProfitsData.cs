using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model.Stats
{
    class UserProfitsData : BindableBase
    {
        private int _sumProfits = 0;
        private List<MenuProfitsData> _menuData;

        public int sumProfits
        {
            get { return _sumProfits; }
            set { SetProperty(ref _sumProfits, value); }
        }

        public List<MenuProfitsData> menuData
        {
            get { return _menuData; }
            set { SetProperty(ref _menuData, value); }
        }
    }
}
