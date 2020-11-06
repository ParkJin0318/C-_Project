using Kiosk.model;
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
using Kiosk.place;
using Kiosk.pay;
using System.Windows.Threading;

namespace Kiosk.place
{
    /// <summary>
    /// TablePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TablePage : Page
    {
        private readonly TableViewModel viewModel;
        private int chooseTable = 0;

        public TablePage()
        {
            InitializeComponent();
            viewModel = new TableViewModel();
            xTable.ItemsSource = viewModel.TableDataList;
        }

        private void Table_Click(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            TableData item = (TableData)listBox.SelectedItem;
            if (item.canUse)
            {
                chooseTable = item.myTableNumber;
                App.tableIdx = chooseTable;
                MessageBox.Show("choose Table : " + chooseTable);
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            viewModel.stopAllTimer();
            NavigationService.Navigate(new PayPage());
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            viewModel.stopAllTimer();
            NavigationService.Navigate(new PlacePage());
        }
    }
}
