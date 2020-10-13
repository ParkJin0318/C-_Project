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

namespace Kiosk
{
    /// <summary>
    /// TablePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TablePage : Page
    {
        TableData[] TData = new TableData[9];

        public TablePage()
        {
            InitializeComponent();
            checkTable();
        }

        public void checkTable()
        {

        }

        private void Table_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PayPage());
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlacePage());
        }
    }
}
