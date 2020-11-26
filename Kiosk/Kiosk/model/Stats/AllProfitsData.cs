using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.model.Stats
{
    class AllProfitsData : BindableBase
    {
        private int _allProfits = 0;
        private int _realProfits = 0;
        private int _saledProfits = 0;
        private int _cashProfits = 0;
        private int _cardProfits = 0;

        public int allProfits
        {
            get { return _allProfits; }
            set { SetProperty(ref _allProfits, value); }
        }

        public int realProfits
        {
            get { return _realProfits; }
            set { SetProperty(ref _realProfits, value); }
        }

        public int saledProfits
        {
            get { return _saledProfits; }
            set { SetProperty(ref _saledProfits, value); }
        }

        public int cashProfits
        {
            get { return _cashProfits; }
            set { SetProperty(ref _cashProfits, value); }
        }

        public int cardProfits
        {
            get { return _cardProfits; }
            set { SetProperty(ref _cardProfits, value); }
        }
    }
}
