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


namespace Kiosk.place
{
    /// <summary>
    /// TablePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TablePage : Page
    {
        TableData[] TData = new TableData[9];
        int chooseTable = 0;

        public TablePage()
        {
            InitializeComponent();
            SetTable();
        }

        public void SetTable()
        {
            TData[0] = new TableData(Table1, 1);
            TData[1] = new TableData(Table2, 2);
            TData[2] = new TableData(Table3, 3);
            TData[3] = new TableData(Table4, 4);
            TData[4] = new TableData(Table5, 5);
            TData[5] = new TableData(Table6, 6);
            TData[6] = new TableData(Table7, 7);
            TData[7] = new TableData(Table8, 8);
            TData[8] = new TableData(Table9, 9);
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
