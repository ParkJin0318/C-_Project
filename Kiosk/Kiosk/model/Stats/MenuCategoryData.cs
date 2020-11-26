using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model.Stats
{
    class MenuCategoryData : BindableBase
    {
        private int _count = 0;
        private int _sumProfits = 0;
        private string _name = "";

        public int count
        {
            get { return _count; }
            set { SetProperty(ref _count, value); }
        }

        public int sumProfits
        {
            get { return _sumProfits; }
            set { SetProperty(ref _sumProfits, value); }
        }

        public string name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}
