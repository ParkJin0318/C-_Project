using Kiosk.util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;

namespace Kiosk
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static TcpClient client { set; get; }
        public static ObservableCollection<Food> selectFoodList { get; } = new ObservableCollection<Food>();

        public static int tableIdx { set; get; }

        public static int payType { set; get; }
    }
}
