
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
using Kiosk.model;
using Kiosk.model.Enum;

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
            DataContext = viewModel;

            listView.ItemsSource = App.selectFoodList;
            xCategory.SelectedIndex = 0;

            PreviousButton.IsEnabled = false;

            if (App.selectFoodList.Count > 0)
            {
                viewModel.isEnabled = true;
                viewModel.totalPrice = App.totalPrice;
            }
            else
            {
                viewModel.isEnabled = false;
            }
        }

        private void Order_Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectFoodList.Count > 0)
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
            if (App.selectFoodList.Count > 0)
            {
                NavigationService.Navigate(new PlacePage());
                App.totalPrice = viewModel.totalPrice;
            } else
            {
                MessageBox.Show("음식을 선택해주세요");
            }
        }

        private void Order_RemoveAll_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectFoodList.Count > 0)
            {
                if (MessageBox.Show("주문 삭제", "주문을 삭제 하실건가요?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    App.selectFoodList.Clear();
                    viewModel.totalPrice = 0;
                    viewModel.isEnabled = false;
                }
            }
        }

        private void xCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.PageControl(model.Enum.Control.RESET);
        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.currentPage == 1)
            {
                this.PageControl(model.Enum.Control.PAGE_NEXT);
                NextButton.IsEnabled = false;
                PreviousButton.IsEnabled = true;
            }
        }

        private void Previous_Button_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.currentPage == 2)
            {
                this.PageControl(model.Enum.Control.PAGE_PREB);
                NextButton.IsEnabled = true;
                PreviousButton.IsEnabled = false;
            }
        }

        private void Plus_Button_Click(object sender, RoutedEventArgs e)
        {
            this.FoodCountControl(sender, model.Enum.Control.PAGE_NEXT);
        }

        private void Down_Button_Click(object sender, RoutedEventArgs e)
        {
            this.FoodCountControl(sender, model.Enum.Control.PAGE_PREB);
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            this.FoodCountControl(sender, model.Enum.Control.RESET);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            Food item = (Food)listBox.SelectedItem;

            viewModel.SelectionChanged(item);
            xMenus.UnselectAll();
        }

        private void FoodCountControl(object sender, model.Enum.Control control)
        {
            Food selectedFood = (sender as Button).DataContext as Food;
            viewModel.FoodCountControl(selectedFood, control);
        }

        private void PageControl(model.Enum.Control control)
        {
            Category category = (Category)xCategory.SelectedIndex;
            xMenus.ItemsSource = viewModel.PageControl(category, control);
        }
    }
}