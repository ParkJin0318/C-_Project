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
        TableData[] TData = new TableData[9];
        DispatcherTimer timer = new DispatcherTimer(); //타이머 객체생성
        int choose_eat_Table = -1;
        SolidColorBrush red = new SolidColorBrush(Colors.Red);
        SolidColorBrush yellow = new SolidColorBrush(Colors.Yellow);

        public TablePage()
        {
            InitializeComponent();
            SetTable();
            MakeTimer();
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
            for (int i = 0; i < TData.Length; i++)
            {
                if (TData[i].canUse)
                {
                    TData[i].SetButtonColor(red);
                }
                else
                {
                    TData[i].SetButtonColor(yellow);
                }
            }
        }

        private void Table_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            char[] buffer = button.Name.ToCharArray();
            int buttonNumber = Convert.ToInt32(buffer[buffer.Length - 1]) - 49;
            if (TData[buttonNumber].canUse)
            {
                choose_eat_Table = buttonNumber + 1;
                MessageBox.Show("Choosed Table" + choose_eat_Table);
                App.tableIdx = choose_eat_Table;

                Console.WriteLine(DateTime.Now);
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new PayPage());
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new PlacePage());
        }

        public void MakeTimer()
        {
            //타이머 동작
            timer.Interval = TimeSpan.FromSeconds(1); //시간간격 설정
            timer.Tick += new EventHandler(timer_Tick); //이벤트 추가
            timer.Start(); //타이머 시작
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                if (!TData[i].canUse)
                {
                    if (TData[i].TimeRemaining <= 1)
                    {
                        TData[i].canUse = true;
                        char[] buffer = TData[i].button.Name.ToCharArray();
                        TData[i].button.Content = buffer[buffer.Length - 1].ToString();
                        TData[i].SetButtonColor(red);
                    }
                    else
                    {
                        TData[i].TimeRemaining -= 1;
                        TData[i].button.Content = TData[i].TimeRemaining.ToString();
                    }
                }

            }
        }
    }
}
