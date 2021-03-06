﻿using Kiosk.model.Enum;
using Prism.Mvvm;
using System.Windows.Markup;

namespace Kiosk.model
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

        public string imagePath { get; set; }

        public Category category { get; set; }

        public int price { get; set; }

        private int _originalPrice = 0;

        public int originalPrice
        {
            get => _originalPrice;
            set => SetProperty(ref _originalPrice, value);
        }

        public int sale { get; set; }

        public int totalSale { get; set; }

        private int _totalPrice = 0;

        public int totalPrice
        {
            get => _totalPrice;
            set => SetProperty(ref _totalPrice, value);
        }

        private int _count = 1;

        public int count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        public int page { get; set; }

        public bool isSoldOut { get; set; }


        private string _state;
        public string state
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        public void PlusCount()
        {
            count += 1;
            totalPrice += price;
            totalSale += sale;
        }

        public void MinusCount()
        {
            count -= 1;
            totalPrice -= price;
            totalSale -= sale;
        }
    }
}