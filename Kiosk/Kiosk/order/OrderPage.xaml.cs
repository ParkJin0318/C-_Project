using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Kiosk
{
    /// <summary>
    /// OrderPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            xCategory.SelectedIndex = 0;

            listView.ItemsSource = selectFoodList;
        }

        private void PlaceholdersListBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            MessageBox.Show(listBox.SelectedItem.ToString());
        }

        private int currentPage = 1;

        private List<Food> foodList = new List<Food>()
        {
             new Food(){ category = Category.BURGER, name = "1955 버거", price = 10000, imagePath = @"/res/burger/1955.png", page = 1 },
             new Food(){ category = Category.BURGER, name = "베이컨 토마토 디럭스 버거", price = 10000, imagePath = @"/res/burger/baconTomatoDeluxe.png", page = 1 },
             new Food(){ category = Category.BURGER, name = "빅맥 버거", price = 10000, imagePath = @"/res/burger/BIgMac.png", page = 1 },
             new Food(){ category = Category.BURGER, name = "빅맥 베이컨 버거", price = 10000, imagePath = @"/res/burger/bigMacBacon.png", page = 1 },
             new Food(){ category = Category.BURGER, name = "불고기 버거", price = 10000, imagePath = @"/res/burger/bulgogi.png", page = 1 },
             new Food(){ category = Category.BURGER, name = "치즈 버거", price = 10000, imagePath = @"/res/burger/cheese.png", page = 1 },
             new Food(){ category = Category.BURGER, name = "더블 1955 버거", price = 10000, imagePath = @"/res/burger/double1955.png", page = 1 },
             new Food(){ category = Category.BURGER, name = "더블 불고기 버거", price = 10000, imagePath = @"/res/burger/doubleBulgogi.png", page = 1 },
             new Food(){ category = Category.BURGER, name = "더블 치즈 버거", price = 10000, imagePath = @"/res/burger/doubleCheese.png", page = 1 },
             new Food(){ category = Category.BURGER, name = "더블 쿼터파운더 치즈 버거", price = 10000, imagePath = @"/res/burger/doubleQuarterPounterCheese.png", page = 2 },
             new Food(){ category = Category.BURGER, name = "에그 불고기 버거", price = 10000, imagePath = @"/res/burger/eggBulgogi.png", page = 2 },
             new Food(){ category = Category.BURGER, name = "햄버거", price = 10000, imagePath = @"/res/burger/ham.png", page = 2 },
             new Food(){ category = Category.BURGER, name = "맥치킨 버거", price = 10000, imagePath = @"/res/burger/mcChicken.png", page = 2 },
             new Food(){ category = Category.BURGER, name = "맥치킨 모짜렐라 버거", price = 10000, imagePath = @"/res/burger/mcChickenMozzarella.png", page = 2 },
             new Food(){ category = Category.BURGER, name = "맥스파이시 상하이 버거", price = 10000, imagePath = @"/res/burger/mcSpicyShanghai.png", page = 2 },
             new Food(){ category = Category.BURGER, name = "쿼터 파운드 치즈 버거", price = 10000, imagePath = @"/res/burger/quarterPounderCheese.png", page = 2 },
             new Food(){ category = Category.BURGER, name = "슈비 버거", price = 10000, imagePath = @"/res/burger/shrimpBeef.png", page = 2 },
             new Food(){ category = Category.BURGER, name = "슈슈 버거", price = 10000, imagePath = @"/res/burger/supremeShrimp.png", page = 2 },


             new Food(){ category = Category.DRINK, name = "아메리카노", price = 10000, imagePath = @"/res/drink/americano.png", page = 1 },
             new Food(){ category = Category.DRINK, name = "카페라떼", price = 10000, imagePath = @"/res/drink/cafeLatte.png", page = 1 },
             new Food(){ category = Category.DRINK, name = "카푸치노", price = 10000, imagePath = @"/res/drink/cappuccino.png", page = 1 },
             new Food(){ category = Category.DRINK, name = "디카페인 아메리카노", price = 10000, imagePath = @"/res/drink/decaffeineAmericano.jpg", page = 1 },
             new Food(){ category = Category.DRINK, name = "디카페인 카페라떼", price = 10000, imagePath = @"/res/drink/decaffeineCafeLatte.jpg", page = 1 },
             new Food(){ category = Category.DRINK, name = "디카페인 카푸치노", price = 10000, imagePath = @"/res/drink/decaffeineCappuccino.jpg", page = 1 },
             new Food(){ category = Category.DRINK, name = "디카페인 에스프레소", price = 10000, imagePath = @"/res/drink/decaffeineEspresso.jpg", page = 1 },
             new Food(){ category = Category.DRINK, name = "디카페인 아이스 아메리카노", price = 10000, imagePath = @"/res/drink/decaffeineIcedAmericano.jpg", page = 1 },
             new Food(){ category = Category.DRINK, name = "디카페인 아이스 카페라떼", price = 10000, imagePath = @"/res/drink/decaffeineIcedCafeLatte.jpg", page = 1 },
             new Food(){ category = Category.DRINK, name = "에스프레소", price = 10000, imagePath = @"/res/drink/espresso.png", page = 2 },
             new Food(){ category = Category.DRINK, name = "아이스 아메리카노", price = 10000, imagePath = @"/res/drink/icedAmericano.jpg", page = 2 },
             new Food(){ category = Category.DRINK, name = "아이스 카페라떼", price = 10000, imagePath = @"/res/drink/icedCafeLatte.png", page = 2 },
             new Food(){ category = Category.DRINK, name = "아이스 커피", price = 10000, imagePath = @"/res/drink/icedCoffee.png", page = 2 },
             new Food(){ category = Category.DRINK, name = "배 칠러", price = 10000, imagePath = @"/res/drink/pearChiller.png", page = 2 },
             new Food(){ category = Category.DRINK, name = "자두 칠러", price = 10000, imagePath = @"/res/drink/plumChiller.png", page = 2 },
             new Food(){ category = Category.DRINK, name = "프리미엄 로스트 원두커피", price = 10000, imagePath = @"/res/drink/premiumRoastCoffee.png", page = 2 },

             new Food(){ category = Category.SIDE, name = "애플파이", price = 10000, imagePath = @"/res/side/applePie.png", page = 1 },
             new Food(){ category = Category.SIDE, name = "후렌치 후라이", price = 10000, imagePath = @"/res/side/frenchFries.png", page = 1  },
             new Food(){ category = Category.SIDE, name = "골든 모짜렐라 치즈스틱", price = 10000, imagePath = @"/res/side/GoldenMazzarellaCheeseSticks.png", page = 1 },
             new Food(){ category = Category.SIDE, name = "해시브라운", price = 10000, imagePath = @"/res/side/hashBrown.jpg", page = 1 },
             new Food(){ category = Category.SIDE, name = "맥너겟", price = 10000, imagePath = @"/res/side/mcNuggets.jpg", page = 1 },
             new Food(){ category = Category.SIDE, name = "맥스파이시 치킨텐더", price = 10000, imagePath = @"/res/side/mcSpicyChickenTenders.png", page = 1 },
             new Food(){ category = Category.SIDE, name = "맥스파이시 상하이 치킨 스낵랩", price = 10000, imagePath = @"/res/side/mcSpicyShanghaiChickenSnackWrap.png", page = 1 },
             new Food(){ category = Category.SIDE, name = "스트링 치즈", price = 10000, imagePath = @"/res/side/stringCheese.png", page = 1 },
             new Food(){ category = Category.SIDE, name = "타로파이", price = 10000, imagePath = @"/res/side/taroPie.png", page = 1 },
             new Food(){ category = Category.SIDE, name = "웨지 후라이", price = 10000, imagePath = @"/res/side/wedgeFries.png", page = 2 },
        };
        private ObservableCollection<Food> selectFoodList = new ObservableCollection<Food>();

        private void xCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category category = (Category)xCategory.SelectedIndex;
            this.currentPage = 1;
            xMenus.ItemsSource = foodList.Where(x => x.category == category && x.page == this.currentPage).ToList();
        }

        private void Order_Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new IntroPage());
        }

        private void Order_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlacePage());
        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.currentPage > 0 && this.currentPage < 2)
            {
                Category category = (Category)xCategory.SelectedIndex;
                this.currentPage++;
                xMenus.ItemsSource = foodList.Where(x => x.category == category && x.page == this.currentPage).ToList();
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.currentPage > 1 && this.currentPage < 3)
            {
                Category category = (Category)xCategory.SelectedIndex;
                this.currentPage--;
                xMenus.ItemsSource = foodList.Where(x => x.category == category && x.page == this.currentPage).ToList();
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var food = (Food)item.SelectedItem;
            selectFoodList.Add(food);
        }

    }
}
