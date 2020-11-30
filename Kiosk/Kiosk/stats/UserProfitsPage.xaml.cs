using Kiosk.admin;
using Kiosk.model;
using Kiosk.model.Stats;
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
    /// UserDataPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserProfitsPage : Page
    {
        private readonly AdminViewModel userViewModel;
        private UserProfitsPageViewModel dataViewModel;
        private List<MenuProfitsData> bindingData;

        public UserProfitsPage()
        {
            InitializeComponent();
            userViewModel = new AdminViewModel();
            dataViewModel = new UserProfitsPageViewModel();

            userListView.DataContext = userViewModel;
            dataListView.ItemsSource = bindingData;
            UpdateData(0);
        }

        public void UpdateData(int index)
        {
            if (dataViewModel != null)
            {
                dataListView.ItemsSource = bindingData;
                dataListView.ItemsSource = dataViewModel.GetMenueProfitsData(index);
            }
        }

        public void UpdateData(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            UpdateData(lv.SelectedIndex);
            dataViewModel.SortData(lv.SelectedIndex);
            if(xComboBox.SelectedIndex == 1)
            {
                dataViewModel.ReverseData(lv.SelectedIndex);
            }
            dataListView.ItemsSource = dataViewModel.GetMenueProfitsData(lv.SelectedIndex);
            Profits.Text = "총 매출액 : " + dataViewModel.userProfitsList.ElementAt(lv.SelectedIndex).sumProfits + "원";
        }

        public void ReverseData(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (dataViewModel != null)
            {
                dataViewModel.ReverseData(userListView.SelectedIndex);
                UpdateData(userListView.SelectedIndex);
            }
        }
    }
}
