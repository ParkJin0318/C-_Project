using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model.Stats
{
    class SeatData : BindableBase
    {
        private List<MenuCategoryData> _menuData;
        private List<MenuCategoryData> _categoryData;
        private int _tableNumber = 0;

        public List<MenuCategoryData> menuData
        {
            get { return _menuData; }
            set { SetProperty(ref _menuData, value); }
        }

        public List<MenuCategoryData> categoryData
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
