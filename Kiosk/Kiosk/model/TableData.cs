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
        public DateTime lastEatStart = DateTime.Now;
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
            if (ReadDBResult.Equals("false"))
            {
                canUse = true;
            }
            else
            {
                SetRemainingTime();
            }
        }

        public void SetRemainingTime()
        {
            DateTime now = DateTime.Now;
            TimeSpan dateDiff = now - lastEatStart;
            int MinuteDiff = (dateDiff.Days * 24 + dateDiff.Hours) * 60 + dateDiff.Minutes;
            if (MinuteDiff < 2)
            {
                TimeRemaining = (MinuteDiff - 1) * 60 + dateDiff.Seconds;
                canUse = false;
            }
        }

        public void SetButtonColor(SolidColorBrush color)
        {
            this.button.Background = color;
        }
    }
}
