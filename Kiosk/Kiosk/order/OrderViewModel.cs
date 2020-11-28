
using Kiosk.repository;
using Kiosk.repositoryImpl;
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
            repository = new FoodRepositoryImpl();
            SetFoods();
        }

        private readonly FoodRepository repository;

        public int currentPage = 1;

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

        private bool _isEnabled;
        public bool isEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private void SetFoods()
        {
            this.foodList = repository.GetAllFood();
        }

        public void SelectionChanged(Food food)
        {
            if (food != null)
            {
                List<int> idxList = new List<int>();
                foreach (Food item in App.selectFoodList)
                {
                    idxList.Add(item.idx);
                }

                if (!idxList.Contains(food.idx)) // 메뉴가 중복이 아니라면
                {
                    food.count = 1;
                    food.totalPrice = food.price;
                    food.totalSale = food.sale;

                    App.selectFoodList.Add(food);
                    this.totalPrice += food.price;
                    this.isEnabled = true;
                }
                else // 메뉴가 중복이라면
                {
                    int index = idxList.IndexOf(food.idx);
                    App.selectFoodList[index].PlusCount();
                    this.totalPrice += food.price;
                }
            }
        }

        public void FoodCountControl(Food selectedFood, int control)
        {
            int index = App.selectFoodList.IndexOf(selectedFood);

            switch (control)
            {
                case 0: // 증가
                    App.selectFoodList[index].PlusCount();
                    this.totalPrice += selectedFood.price;
                    break;

                case 1: // 감소
                    if (App.selectFoodList[index].count > 1)  // 메뉴가 1개 초과라면 감소
                    {
                        App.selectFoodList[index].MinusCount();
                        this.totalPrice -= selectedFood.price;
                    }
                    else // 메뉴가 1개 이하라면 삭제
                    {
                        App.selectFoodList.Remove(selectedFood);
                        this.totalPrice -= selectedFood.totalPrice;
                    }
                    break;

                case 2: // 삭제
                    App.selectFoodList.Remove(selectedFood);
                    this.totalPrice -= selectedFood.totalPrice;
                    break;
            }

            if (App.selectFoodList.Count == 0) isEnabled = false;
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