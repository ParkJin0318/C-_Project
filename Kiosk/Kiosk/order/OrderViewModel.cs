using Kiosk.database;
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

        private List<Food> _foodList;
        public List<Food> foodList
        {
            get => _foodList;
            set => SetProperty(ref _foodList, value);
        }
        public ObservableCollection<Food> selectFoodList = new ObservableCollection<Food>();

        /* private List<Food> foodList = new List<Food>()
        {
             new Food(){ idx = 0, category = Category.BURGER, name = "1955 버거", price = 5000, imagePath = @"/res/burger/1955.png", page = 1 },
             new Food(){ idx = 1, category = Category.BURGER, name = "베이컨 토마토 디럭스 버거", price = 4000, imagePath = @"/res/burger/baconTomatoDeluxe.png", page = 1 },
             new Food(){ idx = 2, category = Category.BURGER, name = "빅맥 버거", price = 6000, imagePath = @"/res/burger/BIgMac.png", page = 1 },
             new Food(){ idx = 3, category = Category.BURGER, name = "빅맥 베이컨 버거", price = 7000, imagePath = @"/res/burger/bigMacBacon.png", page = 1 },
             new Food(){ idx = 4, category = Category.BURGER, name = "불고기 버거", price = 2000, imagePath = @"/res/burger/bulgogi.png", page = 1 },
             new Food(){ idx = 5, category = Category.BURGER, name = "치즈 버거", price = 3000, imagePath = @"/res/burger/cheese.png", page = 1 },
             new Food(){ idx = 6, category = Category.BURGER, name = "더블 1955 버거", price = 4000, imagePath = @"/res/burger/double1955.png", page = 1 },
             new Food(){ idx = 7, category = Category.BURGER, name = "더블 불고기 버거", price = 5000, imagePath = @"/res/burger/doubleBulgogi.png", page = 1 },
             new Food(){ idx = 8, category = Category.BURGER, name = "더블 치즈 버거", price = 7000, imagePath = @"/res/burger/doubleCheese.png", page = 1 },
             new Food(){ idx = 9, category = Category.BURGER, name = "더블 쿼터파운더 치즈 버거", price = 5000, imagePath = @"/res/burger/doubleQuarterPounterCheese.png", page = 2 },
             new Food(){ idx = 10, category = Category.BURGER, name = "에그 불고기 버거", price = 4000, imagePath = @"/res/burger/eggBulgogi.png", page = 2 },
             new Food(){ idx = 11, category = Category.BURGER, name = "햄버거", price = 9000, imagePath = @"/res/burger/ham.png", page = 2 },
             new Food(){ idx = 12, category = Category.BURGER, name = "맥치킨 버거", price = 1000, imagePath = @"/res/burger/mcChicken.png", page = 2 },
             new Food(){ idx = 13, category = Category.BURGER, name = "맥치킨 모짜렐라 버거", price = 4000, imagePath = @"/res/burger/mcChickenMozzarella.png", page = 2 },
             new Food(){ idx = 14, category = Category.BURGER, name = "맥스파이시 상하이 버거", price = 3000, imagePath = @"/res/burger/mcSpicyShanghai.png", page = 2 },
             new Food(){ idx = 15, category = Category.BURGER, name = "쿼터 파운드 치즈 버거", price = 6000, imagePath = @"/res/burger/quarterPounderCheese.png", page = 2 },
             new Food(){ idx = 16, category = Category.BURGER, name = "슈비 버거", price = 7000, imagePath = @"/res/burger/shrimpBeef.png", page = 2 },
             new Food(){ idx = 17, category = Category.BURGER, name = "슈슈 버거", price = 4000, imagePath = @"/res/burger/supremeShrimp.png", page = 2 },

             new Food(){ idx = 18, category = Category.DRINK, name = "아메리카노", price = 10000, imagePath = @"/res/drink/americano.png", page = 1 },
             new Food(){ idx = 19, category = Category.DRINK, name = "카페라떼", price = 10000, imagePath = @"/res/drink/cafeLatte.png", page = 1 },
             new Food(){ idx = 20, category = Category.DRINK, name = "카푸치노", price = 10000, imagePath = @"/res/drink/cappuccino.png", page = 1 },
             new Food(){ idx = 21, category = Category.DRINK, name = "디카페인 아메리카노", price = 10000, imagePath = @"/res/drink/decaffeineAmericano.jpg", page = 1 },
             new Food(){ idx = 22, category = Category.DRINK, name = "디카페인 카페라떼", price = 10000, imagePath = @"/res/drink/decaffeineCafeLatte.jpg", page = 1 },
             new Food(){ idx = 23, category = Category.DRINK, name = "디카페인 카푸치노", price = 10000, imagePath = @"/res/drink/decaffeineCappuccino.jpg", page = 1 },
             new Food(){ idx = 24, category = Category.DRINK, name = "디카페인 에스프레소", price = 10000, imagePath = @"/res/drink/decaffeineEspresso.jpg", page = 1 },
             new Food(){ idx = 25, category = Category.DRINK, name = "디카페인 아이스 아메리카노", price = 10000, imagePath = @"/res/drink/decaffeineIcedAmericano.jpg", page = 1 },
             new Food(){ idx = 26, category = Category.DRINK, name = "디카페인 아이스 카페라떼", price = 10000, imagePath = @"/res/drink/decaffeineIcedCafeLatte.jpg", page = 1 },
             new Food(){ idx = 27, category = Category.DRINK, name = "에스프레소", price = 10000, imagePath = @"/res/drink/espresso.png", page = 2 },
             new Food(){ idx = 28, category = Category.DRINK, name = "아이스 아메리카노", price = 10000, imagePath = @"/res/drink/icedAmericano.jpg", page = 2 },
             new Food(){ idx = 29, category = Category.DRINK, name = "아이스 카페라떼", price = 10000, imagePath = @"/res/drink/icedCafeLatte.png", page = 2 },
             new Food(){ idx = 30, category = Category.DRINK, name = "아이스 커피", price = 10000, imagePath = @"/res/drink/icedCoffee.png", page = 2 },
             new Food(){ idx = 31, category = Category.DRINK, name = "배 칠러", price = 10000, imagePath = @"/res/drink/pearChiller.png", page = 2 },
             new Food(){ idx = 32, category = Category.DRINK, name = "자두 칠러", price = 10000, imagePath = @"/res/drink/plumChiller.png", page = 2 },
             new Food(){ idx = 33, category = Category.DRINK, name = "프리미엄 로스트 원두커피", price = 10000, imagePath = @"/res/drink/premiumRoastCoffee.png", page = 2 },

             new Food(){ idx = 34, category = Category.SIDE, name = "애플파이", price = 10000, imagePath = @"/res/side/applePie.png", page = 1 },
             new Food(){ idx = 35, category = Category.SIDE, name = "후렌치 후라이", price = 10000, imagePath = @"/res/side/frenchFries.png", page = 1  },
             new Food(){ idx = 36, category = Category.SIDE, name = "골든 모짜렐라 치즈스틱", price = 10000, imagePath = @"/res/side/GoldenMazzarellaCheeseSticks.png", page = 1 },
             new Food(){ idx = 37, category = Category.SIDE, name = "해시브라운", price = 10000, imagePath = @"/res/side/hashBrown.jpg", page = 1 },
             new Food(){ idx = 38, category = Category.SIDE, name = "맥너겟", price = 10000, imagePath = @"/res/side/mcNuggets.jpg", page = 1 },
             new Food(){ idx = 39, category = Category.SIDE, name = "맥스파이시 치킨텐더", price = 10000, imagePath = @"/res/side/mcSpicyChickenTenders.png", page = 1 },
             new Food(){ idx = 40, category = Category.SIDE, name = "맥스파이시 상하이 치킨 스낵랩", price = 10000, imagePath = @"/res/side/mcSpicyShanghaiChickenSnackWrap.png", page = 1 },
             new Food(){ idx = 41, category = Category.SIDE, name = "스트링 치즈", price = 10000, imagePath = @"/res/side/stringCheese.png", page = 1 },
             new Food(){ idx = 42, category = Category.SIDE, name = "타로파이", price = 10000, imagePath = @"/res/side/taroPie.png", page = 1 },
             new Food(){ idx = 43, category = Category.SIDE, name = "웨지 후라이", price = 10000, imagePath = @"/res/side/wedgeFries.png", page = 2 },
        }; */

        private void SetFoods()
        {
            FoodRemote cache = new FoodRemote();
            this.foodList = cache.GetAllFood();
        }

        public void SelectionChanged(Food food)
        {
            if (food != null)
            {
                if (!this.selectFoodList.Contains(food)) // 메뉴가 중복이 아니라면
                {
                    food.currentPrice = food.price;
                    this.selectFoodList.Add(food);
                }
                else // 메뉴가 중복이라면
                {
                    int index = this.selectFoodList.IndexOf(food);
                    this.selectFoodList[index].PlusCount();
                }
            }
        }

        public void FoodControl(Food selectedFood, int control)
        {
            int index = this.selectFoodList.IndexOf(selectedFood);

            switch (control)
            {
                case 0: // 증가
                    this.selectFoodList[index].PlusCount();
                    break;

                case 1: // 감소
                    if (this.selectFoodList[index].count > 1)  // 메뉴가 1개 초과라면 감소
                    {
                        this.selectFoodList[index].MinusCount();
                    }
                    else // 메뉴가 1개 이하라면 삭제
                    {
                        this.selectFoodList.Remove(selectedFood);
                    }
                    break;

                case 2: // 삭제
                    this.selectFoodList.Remove(selectedFood);
                    break;
            }
        }

        public List<Food> FoodControl(Category category, int control)
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