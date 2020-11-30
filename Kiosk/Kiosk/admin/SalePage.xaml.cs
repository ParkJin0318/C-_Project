using Kiosk.model;
using Kiosk.model.Enum;
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

        private Food food { get; set; }

        public SalePage()
        {
            InitializeComponent();
            viewModel = new SaleViewModel();
            DataContext = viewModel;

            xCategory.SelectedIndex = 0;
        }

        private void xCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.PageControl(model.Enum.Control.RESET);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            Food item = (Food)listBox.SelectedItem;

            if (item != null)
            {
                this.food = item;
                viewModel.isEnabled = true;
                viewModel.imagePath = this.food.imagePath;
                viewModel.name = this.food.name;
                SaleInput.Text = this.food.sale.ToString();
            }
        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.currentPage == 1)
            {
                this.PageControl(model.Enum.Control.PAGE_NEXT);
            }
        }

        private void Preb_Button_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.currentPage == 2)
            {
                this.PageControl(model.Enum.Control.PAGE_PREB);
            }
        }

        private void OrderCancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Sale_Button_Click(object sender, RoutedEventArgs e)
        {
            int sale = int.Parse(SaleInput.Text);
            viewModel.SetSale(this.food, sale);

            SaleInput.Text = "";
            viewModel.SetFoods();
            MessageBox.Show("할인 적용 되었습니다");
        }

        private void SoldOut_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!this.food.isSoldOut)
            {
                viewModel.SetSoldOut(this.food, true);
                viewModel.SetFoods();
                MessageBox.Show("품절 적용 되었습니다");
            }
            else
            {
                MessageBox.Show("이미 품절 상태입니다");
            }
        }

        private void SoldOut_Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.food.isSoldOut)
            {
                viewModel.SetSoldOut(this.food, false);
                viewModel.SetFoods();
                MessageBox.Show("품절 적용 취소 했습니다");
            }
            else
            {
                MessageBox.Show("이미 구매가능 상태입니다");
            }
        }

        private void PageControl(model.Enum.Control control)
        {
            Category category = (Category)xCategory.SelectedIndex;
            xMenus.ItemsSource = viewModel.PageControl(category, control);
        }
    }
}
