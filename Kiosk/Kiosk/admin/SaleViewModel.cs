using Kiosk.database;
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
        public SaleViewModel()
        {
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

        private void SetFoods()
        {
            FoodRemote remote = new FoodRemote();
            this.foodList = remote.GetAllFood();
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
