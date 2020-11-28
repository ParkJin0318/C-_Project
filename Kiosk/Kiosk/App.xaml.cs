using Kiosk.util;
using Kiosk.mananger;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Kiosk.model;

namespace Kiosk
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static ServerManager serverManager = new ServerManager();

        public static List<User> userList { set; get; } = new List<User>();

        public static User loginUser { set; get; } = new User();

        public static Market market { get; set; } = new Market();

        public static ObservableCollection<Food> selectFoodList { set; get; } = new ObservableCollection<Food>();

        public static int totalPrice { set; get; }

        public static int tableIdx { set; get; }

        public static int payType { set; get; }
    }
}
