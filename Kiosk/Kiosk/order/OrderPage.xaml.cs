
using Kiosk.order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Kiosk.place;
using System.Collections.Specialized;

namespace Kiosk.order
{
    /// <summary>
    /// OrderPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrderPage : Page
    {
        private readonly OrderViewModel viewModel;

        public OrderPage()
        {
            InitializeComponent();
            viewModel = new OrderViewModel();

            listView.ItemsSource = viewModel.selectFoodList;
            xCategory.SelectedIndex = 0;

            DataContext = viewModel;
        }

        private void Order_Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.selectFoodList.Count > 0)
            {
                if (MessageBox.Show("주문 취소", "주문 취소 하실건가요?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    NavigationService.GoBack();
                }
            } else
            {
                NavigationService.GoBack();
            }
        }

        private void Order_Button_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.selectFoodList.Count > 0)
            {
                NavigationService.Navigate(new PlacePage());
            } else
            {
                MessageBox.Show("음식을 선택해주세요");
            }
        }

        private void Order_RemoveAll_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.selectFoodList.Count > 0)
            {
                if (MessageBox.Show("주문 삭제", "주문을 삭제 하실건가요?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    viewModel.selectFoodList.Clear();
                    viewModel.totalPrice = 0;
                }
            }
            else
            {
                viewModel.selectFoodList.Clear();
                viewModel.totalPrice = 0;
            }
        }

        private void xCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.DirectionControl(0);
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

        private void Plus_Button_Click(object sender, RoutedEventArgs e)
        {
            this.FoodCountControl(sender, 0);
        }

        private void Down_Button_Click(object sender, RoutedEventArgs e)
        {
            this.FoodCountControl(sender, 1);
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            this.FoodCountControl(sender, 2);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            Food item = (Food)listBox.SelectedItem;

            viewModel.SelectionChanged(item);
            xMenus.UnselectAll();
        }

        private void FoodCountControl(object sender, int control)
        {
            Food selectedFood = (sender as Button).DataContext as Food;
            viewModel.FoodCountControl(selectedFood, control);
        }

        private void DirectionControl(int control)
        {
            Category category = (Category)xCategory.SelectedIndex;
            xMenus.ItemsSource = viewModel.PageControl(category, control);
        }
    }
}