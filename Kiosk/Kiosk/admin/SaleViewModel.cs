﻿using Kiosk.model;
using Kiosk.model.Enum;
using Kiosk.repository;
using Kiosk.repositoryImpl;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.admin
{
    class SaleViewModel: BindableBase
    {
        private readonly FoodRepository repository;

        public SaleViewModel()
        {
            repository = new FoodRepositoryImpl();
            SetFoods();
        }

        public int currentPage = 1;

        private string _imagePath;
        public string imagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }

        private string _name;
        public string name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private List<Food> _foodList;
        public List<Food> foodList
        {
            get => _foodList;
            set => SetProperty(ref _foodList, value);
        }

        private bool _isEnabled;
        public bool isEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public void SetFoods()
        {
            this.foodList = repository.GetAllFood();
        }

        public void SetSale(Food food, int sale)
        {
            repository.SetFoodSale(food, sale);
        }

        public void SetSoldOut(Food food, bool isSoldOut)
        {
            if (isSoldOut)
            {
                repository.SetFoodSoldOut(food, 1);
            }
            else
            {
                repository.SetFoodSoldOut(food, 0);
            }
        }

        public List<Food> PageControl(Category category, Control control)
        {
            switch (control)
            {
                case Control.RESET: // 카테고리 변경시 페이지 초기화
                    this.currentPage = 1;
                    break;

                case Control.PAGE_NEXT: // 다음 페이지
                    this.currentPage++;
                    break;

                case Control.PAGE_PREB: // 이전 페이지
                    this.currentPage--;
                    break;
            }
            return this.foodList.Where(x => x.category == category && x.page == this.currentPage).ToList();
        }
    }
}
