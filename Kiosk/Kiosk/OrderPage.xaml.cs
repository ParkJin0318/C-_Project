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
        }

        private List<Food> lstFood = new List<Food>()
        {


        };

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
