using System;
using System.Collections.Generic;
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

            listView.ItemsSource = foodList;
        }

        private List<Food> foodList = new List<Food>()
        {
             new Food(){ category = Category.BURGER, name = "1955 버거", imagePath = @"res/burger/1955.png" },
             new Food(){ category = Category.BURGER, name = "베이컨\n토마토 디럭스 버거", imagePath = @"res/burger/baconTomatoDeluxe.png" },
             new Food(){ category = Category.BURGER, name = "빅맥 버거", imagePath = @"res/burger/BIgMac.png" },
             new Food(){ category = Category.BURGER, name = "빅맥 베이컨 버거", imagePath = @"res/burger/bigMacBacon.png" },
             new Food(){ category = Category.BURGER, name = "불고기 버거", imagePath = @"res/burger/bulgogi.png" },
             new Food(){ category = Category.BURGER, name = "치즈 버거", imagePath = @"res/burger/cheese.png" },
             new Food(){ category = Category.BURGER, name = "더블 1955 버거", imagePath = @"res/burger/double1955.png" },
             new Food(){ category = Category.BURGER, name = "더블 불고기 버거", imagePath = @"res/burger/doubleBulgogi.png" },
             new Food(){ category = Category.BURGER, name = "더블 치즈 버거", imagePath = @"res/burger/doubleCheese.png" },
             new Food(){ category = Category.BURGER, name = "더블 쿼터파운더 치즈 버거", imagePath = @"res/burger/doubleQuarterPounterCheese.png" },
             new Food(){ category = Category.BURGER, name = "에그 불고기 버거", imagePath = @"res/burger/eggBulgogi.png" },
             new Food(){ category = Category.BURGER, name = "햄버거", imagePath = @"res/burger/ham.png" },
             new Food(){ category = Category.BURGER, name = "맥치킨 버거", imagePath = @"res/burger/mcChicken.png" },
             new Food(){ category = Category.BURGER, name = "맥치킨 모짜렐라 버거", imagePath = @"res/burger/mcChickenMozzarella.png" },
             new Food(){ category = Category.BURGER, name = "맥스파이시 상하이 버거", imagePath = @"res/burger/mcSpicyShanghai.png" },
             new Food(){ category = Category.BURGER, name = "쿼터 파운드 치즈 버거", imagePath = @"res/burger/quarterPounderCheese.png" },
             new Food(){ category = Category.BURGER, name = "슈비 버거", imagePath = @"res/burger/shrimpBeef.png" },
             new Food(){ category = Category.BURGER, name = "슈슈 버거", imagePath = @"res/burger/supremeShrimp.png" },

             new Food(){ category = Category.DRINK, name = "아메리카노", imagePath = @"res/drink/americano.png" },
             new Food(){ category = Category.DRINK, name = "카페라떼", imagePath = @"res/drink/cafeLatte.png" },
             new Food(){ category = Category.DRINK, name = "카푸치노", imagePath = @"res/drink/cappuccino.png" },
             new Food(){ category = Category.DRINK, name = "디카페인 아메리카노", imagePath = @"res/drink/decaffeineAmericano.jpg" },
             new Food(){ category = Category.DRINK, name = "디카페인 카페라떼", imagePath = @"res/drink/decaffeineCafeLatte.jpg" },
             new Food(){ category = Category.DRINK, name = "디카페인 카푸치노", imagePath = @"res/drink/decaffeineCappuccino.jpg" },
             new Food(){ category = Category.DRINK, name = "디카페인 에스프레소", imagePath = @"res/drink/decaffeineEspresso.jpg" },
             new Food(){ category = Category.DRINK, name = "디카페인 아이스 아메리카노", imagePath = @"res/drink/decaffeineIcedAmericano.jpg" },
             new Food(){ category = Category.DRINK, name = "디카페인 아이스 카페라떼", imagePath = @"res/drink/decaffeineIcedCafeLatte.jpg" },
             new Food(){ category = Category.DRINK, name = "에스프레소", imagePath = @"res/drink/espresso.png" },
             new Food(){ category = Category.DRINK, name = "아이스 아메리카노", imagePath = @"res/drink/icedAmericano.jpg" },
             new Food(){ category = Category.DRINK, name = "아이스 카페라떼", imagePath = @"res/drink/icedCafeLatte.png" },
             new Food(){ category = Category.DRINK, name = "아이스 커피", imagePath = @"res/drink/icedCoffee.png" },
             new Food(){ category = Category.DRINK, name = "배 칠러", imagePath = @"res/drink/pearChiller.png" },
             new Food(){ category = Category.DRINK, name = "자두 칠러", imagePath = @"res/drink/plumChiller.png" },
             new Food(){ category = Category.DRINK, name = "프리미엄 로스트 원두커피", imagePath = @"res/drink/premiumRoastCoffee.png" },

             new Food(){ category = Category.SIDE, name = "애플파이", imagePath = @"res/side/applePie.png" },
             new Food(){ category = Category.SIDE, name = "후렌치 후라이", imagePath = @"res/side/frenchFries.png" },
             new Food(){ category = Category.SIDE, name = "골든 모짜렐라 치즈스틱", imagePath = @"res/side/GoldenMazzarellaCheeseSticks.png" },
             new Food(){ category = Category.SIDE, name = "해시브라운", imagePath = @"res/side/hashBrown.jpg" },
             new Food(){ category = Category.SIDE, name = "맥너겟", imagePath = @"res/side/mcNuggets.jpg" },
             new Food(){ category = Category.SIDE, name = "맥스파이시 치킨텐더", imagePath = @"res/side/mcSpicyChickenTenders.png" },
             new Food(){ category = Category.SIDE, name = "맥스파이시 상하이 치킨 스낵랩", imagePath = @"res/side/mcSpicyShanghaiChickenSnackWrap.png" },
             new Food(){ category = Category.SIDE, name = "스트링 치즈", imagePath = @"res/side/stringCheese.png" },
             new Food(){ category = Category.SIDE, name = "타로파이", imagePath = @"res/side/taroPie.png" },
             new Food(){ category = Category.SIDE, name = "웨지 후라이", imagePath = @"res/side/wedgeFries.png" },
        };

        private void xCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category category = (Category)xCategory.SelectedIndex;
            xMenus.ItemsSource = foodList.Where(x => x.category == category).ToList();
        }

        private void Order_Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new IntroPage());
        }

        private void Order_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlacePage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
