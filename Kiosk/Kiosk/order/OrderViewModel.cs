﻿using Kiosk.database;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.order
{
    public class OrderViewModel : BindableBase
    {
        public OrderViewModel() {
            SetFoods();
        }

        public int currentPage = 1;

        public ObservableCollection<Food> selectFoodList = App.selectFoodList;

        private int _totalPrice = 0;
        public int totalPrice
        {
            get => _totalPrice;
            set => SetProperty(ref _totalPrice, value);
        }

        private List<Food> _foodList;
        public List<Food> foodList
        {
            get => _foodList;
            set => SetProperty(ref _foodList, value);
        }

        private void SetFoods()
        {
            FoodRemote remote = new FoodRemote();
            this.foodList = remote.GetAllFood();
        }

        public void SelectionChanged(Food food)
        {
            if (food != null)
            {
                if (!this.selectFoodList.Contains(food)) // 메뉴가 중복이 아니라면
                {
                    food.currentPrice = food.price;
                    this.selectFoodList.Add(food);
                    this.totalPrice += food.price;
                }
                else // 메뉴가 중복이라면
                {
                    int index = this.selectFoodList.IndexOf(food);
                    this.selectFoodList[index].PlusCount();
                    this.totalPrice += food.price;
                }
            }
        }

        public void PageControl(Food selectedFood, int control)
        {
            int index = this.selectFoodList.IndexOf(selectedFood);

            switch (control)
            {
                case 0: // 증가
                    this.selectFoodList[index].PlusCount();
                    this.totalPrice += selectedFood.price;
                    break;

                case 1: // 감소
                    if (this.selectFoodList[index].count > 1)  // 메뉴가 1개 초과라면 감소
                    {
                        this.selectFoodList[index].MinusCount();
                        this.totalPrice -= selectedFood.price;
                    }
                    else // 메뉴가 1개 이하라면 삭제
                    {
                        this.selectFoodList.Remove(selectedFood);
                        this.totalPrice -= selectedFood.currentPrice;
                    }
                    break;

                case 2: // 삭제
                    this.selectFoodList.Remove(selectedFood);
                    this.totalPrice -= selectedFood.currentPrice;
                    break;
            }
        }

        public List<Food> PageControl(Category category, int control)
        {
            switch (control)
            {
                case 0: // 카테고리 변경시 페이지 초기화
                    this.currentPage = 1;
                    break;

                case 1: // 다음 페이지
                    this.currentPage++;
                    break;

                case 2: // 이전 페이지
                    this.currentPage--;
                    break;
            }

            return this.foodList.Where(x => x.category == category && x.page == this.currentPage).ToList();
        }
    }
}