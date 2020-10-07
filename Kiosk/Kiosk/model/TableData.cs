using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Kiosk.model
{
    class TableData
    {
        public Button button = new Button();
        public DateTime lastEatStart;
        public int myTableNumber = 0;

        public TableData(Button buttons, int tableNum)
        {
            this.button = buttons;
            this.myTableNumber = tableNum;
        }

        public void CheckLastEatStart()
        {

        }

        public void SetButtonColor()
        {
            DateTime now = DateTime.Now;
            TimeSpan dateDiff = now - lastEatStart;
            int MinuteDiff = (dateDiff.Days * 24 + dateDiff.Hours) * 60 + dateDiff.Minutes;
            if (MinuteDiff < 1)
            {
                SolidColorBrush yellow = (SolidColorBrush)new BrushConverter().ConvertFromString("#F7FF00");
                this.button.Background = yellow;
            }
        }
    }
}
