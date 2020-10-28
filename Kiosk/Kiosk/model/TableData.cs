using Kiosk.remote;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Kiosk.model
{
    class TableData
    {
        public Button button = new Button();
        public int myTableNumber = 0;
        public int TimeRemaining = 0;
        public bool canUse = true;

        public TableData(Button buttons, int tableNum)
        {
            this.button = buttons;
            this.myTableNumber = tableNum;
            CheckLastEatStart();
        }

        public void CheckLastEatStart()
        {
            TableDataRemote ReadDBResult = new TableDataRemote(myTableNumber);
            string ReadTime = ReadDBResult.GetOrderTime();
            if ("".Equals(ReadTime))
            {
                canUse = true;
            }
            else
            {
                SetRemainingTime(ReadTime);
            }
        }

        public void SetRemainingTime(String ReadTime)
        {
            DateTime lastEatStart = Convert.ToDateTime(ReadTime);
            DateTime now = DateTime.Now;
            TimeSpan dateDiff = now - lastEatStart;
            int diffSec = Convert.ToInt32(dateDiff.TotalSeconds);
            Console.WriteLine("Min " + dateDiff.Minutes);
            Console.WriteLine("Sec " + dateDiff.Seconds);
            Console.WriteLine("TSec " + diffSec);
            if (diffSec <= 60)
            {
                Console.WriteLine("Setting TRemming");
                TimeRemaining = 60 - diffSec;
                canUse = false;
            }
        }

        public void SetButtonColor(SolidColorBrush color)
        {
            this.button.Background = color;
        }
    }
}
