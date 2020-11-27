using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model.Stats
{
    class TableProfitsData : BindableBase
    {
        private List<MenuProfitsData> _menuData;
        private List<MenuProfitsData> _categoryData;
        private int _tableNumber = 0;

        public List<MenuProfitsData> menuData
        {
            get { return _menuData; }
            set { SetProperty(ref _menuData, value); }
        }

        public List<MenuProfitsData> categoryData
        {
            get { return _categoryData; }
            set { SetProperty(ref _categoryData, value); }
        }

        public int tableNumber
        {
            get { return _tableNumber; }
            set { SetProperty(ref _tableNumber, value); }
        }
    }
}
