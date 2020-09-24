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
using System.Windows.Threading;

namespace Kiosk
{
    /// <summary>
    /// OrderWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class OrderWindow : Page
    {
        public OrderWindow()
        {
            InitializeComponent();
            Color color = Color.FromRgb(255, 255, 255);
            SolidColorBrush brush = new SolidColorBrush(color);
            Background = brush;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToString();
        }
    }
}
