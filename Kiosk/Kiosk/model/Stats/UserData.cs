using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model.Stats
{
    class UserData : BindableBase
    {
        private int _sumProfits = 0;
        private List<MenuCategoryData> _menuData;

        public int sumProfits
        {
            get { return _sumProfits; }
            set { SetProperty(ref _sumProfits, value); }
        }

        public List<MenuCategoryData> menuData
        {
            get { return _menuData; }
            set { SetProperty(ref _menuData, value); }
        }
    }
}
