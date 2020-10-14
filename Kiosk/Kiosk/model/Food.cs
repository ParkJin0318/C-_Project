using Prism.Mvvm;

namespace Kiosk
{
    public class Food : BindableBase
    {
        public Category category { get; set; }
        public string imagePath { get; set; }
        public string name { get; set; }
        public int price { get; set; }

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
    }
}