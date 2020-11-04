using Prism.Mvvm;

namespace Kiosk
{
    public class Food : BindableBase
    {
        public int idx { get; set; }
        private string _name;
        public string name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public int price { get; set; }
        public int sale { get; set; }
        public string imagePath { get; set; }
        public Category category { get; set; }

        private int _currentPrice = 0;
        public int currentPrice
        {
            get => _currentPrice;
            set => SetProperty(ref _currentPrice, value);
        }

        private int _count = 1;
        public int count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }
        public int page { get; set; }

        public void PlusCount()
        {
            count++;
            currentPrice += price;
        }

        public void MinusCount()
        {
            count--;
            currentPrice -= price;
        }
    }
}