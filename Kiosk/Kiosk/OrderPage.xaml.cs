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
        }

        private List<Food> foodList = new List<Food>()
        {
             new Food(){ category = Category.BURGER, name = "1955", imagePath = @"res/burger/1955.png" },
             new Food(){ category = Category.BURGER, name = "치즈", imagePath = @"res/burger/cheese.png" },

             new Food(){ category = Category.CHICKEN, name = "ham", imagePath = @"res/burger/ham.png" },
             new Food(){ category = Category.CHICKEN, name = "mcChicken", imagePath = @"res/burger/1955.png" },

             new Food(){ category = Category.DRINK, name = "BigMac", imagePath = @"res/burger/BIgMac.png" },
             new Food(){ category = Category.DRINK, name = "double1955", imagePath = @"res/burger/double1955.png" },
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
    }
}
