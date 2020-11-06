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

namespace Kiosk.admin
{
    /// <summary>
    /// SalePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SalePage : Page
    {
        private readonly SaleViewModel viewModel;

        private Food food;

        public SalePage()
        {
            InitializeComponent();
            viewModel = new SaleViewModel();

            DataContext = viewModel;
        }

        private void xCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.DirectionControl(0);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            Food item = (Food)listBox.SelectedItem;

            if (item != null)
            {
                this.food = item;
                viewModel.imagePath = this.food.imagePath;
                viewModel.name = this.food.name;
                SaleInput.Text = this.food.sale.ToString();
            }
        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.currentPage == 1)
            {
                this.DirectionControl(1);
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.currentPage == 2)
            {
                this.DirectionControl(2);
            }
        }

        private void Sale_Button_Click(object sender, RoutedEventArgs e)
        {
            int sale = int.Parse(SaleInput.Text);
            viewModel.SetSale(this.food, sale);

            SaleInput.Text = "";
            MessageBox.Show("할인 적용되었습니다");
            viewModel.SetFoods();
        }

        private void DirectionControl(int control)
        {
            Category category = (Category)xCategory.SelectedIndex;
            xMenus.ItemsSource = viewModel.PageControl(category, control);
        }
    }
}
