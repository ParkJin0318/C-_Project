using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiosk.stats;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kiosk.stats
{
    /// <summary>
    /// SeatDataPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TableProfitsPage : Page
    {
        private int beforeTableNum = 1;
        private bool ViewMode = true;

        private SolidColorBrush red = new SolidColorBrush(Colors.Red);
        private SolidColorBrush yellow = new SolidColorBrush(Colors.Yellow);
        private TableProfitsViewModel viewModel;

        public TableProfitsPage(int tableNumber, bool mode)//mode = true : Menu, false : Category
        {
            InitializeComponent();

            this.beforeTableNum = tableNumber;
            this.ViewMode = mode;

            viewModel = new TableProfitsViewModel();
            xTable.ItemsSource = viewModel.tableDatas;

            ChartFrame.NavigationService.Navigate(new MenuProfitsPageFrame(beforeTableNum));
            xMenu.Background = yellow;
        }

        private void Table_Click(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            model.TableData item = (model.TableData)listBox.SelectedItem;
            if (item.myTableNumber != beforeTableNum)
            {
                viewModel.tableDatas.ElementAt(beforeTableNum - 1).TableColor = red;
                beforeTableNum = item.myTableNumber;
                viewModel.tableDatas.ElementAt(beforeTableNum - 1).TableColor = yellow;

                if (this.ViewMode)
                {
                    ChartFrame.NavigationService.Navigate(new MenuProfitsPageFrame(this.beforeTableNum));
                }
                else
                {
                    ChartFrame.NavigationService.Navigate(new CategoryProfitsPage(this.beforeTableNum));
                }
            }
        }

        private void BTN_MenuClicked(object sender, RoutedEventArgs e)
        {
            if (this.ViewMode != true)
            {
                ChartFrame.NavigationService.Navigate(new MenuProfitsPageFrame(this.beforeTableNum));
                this.ViewMode = true;
                xCategory.Background = red;
                xMenu.Background = yellow;
            }
        }

        private void BTN_CategoryClicked(object sender, RoutedEventArgs e)
        {
            if (this.ViewMode != false)
            {
                ChartFrame.NavigationService.Navigate(new CategoryProfitsPage(this.beforeTableNum));
                this.ViewMode = false;
                xMenu.Background = red;
                xCategory.Background = yellow;
            }
        }
    }
}
