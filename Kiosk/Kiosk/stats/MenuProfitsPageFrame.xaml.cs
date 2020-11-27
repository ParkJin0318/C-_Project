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

namespace Kiosk.stats
{
    /// <summary>
    /// MenuDataPage_F.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MenuProfitsPageFrame : Page
    {
        int seatChecker = 0;
        public MenuProfitsPageFrame(int seatChecker)
        {
            InitializeComponent();
            this.seatChecker = seatChecker;
            MenuChartFrame.NavigationService.Navigate(new Kiosk.stats.MenuProfitsPage(0, 11, seatChecker));
        }

        public void UpdateData(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            int nowIndex = (cb.SelectedIndex + 1) * 11;
            if (MenuChartFrame != null)
                MenuChartFrame.NavigationService.Navigate(new Kiosk.stats.MenuProfitsPage(nowIndex - 11, nowIndex, seatChecker));
        }
    }
}
