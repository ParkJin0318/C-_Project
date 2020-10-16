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
        public DateTime lastEatStart;
        public int myTableNumber = 0;
        public DispatcherTimer timer = new DispatcherTimer(); //타이머 객체생성
        public int TimeRemaining = 0;

        public TableData(Button buttons, int tableNum)
        {
            this.button = buttons;
            this.myTableNumber = tableNum;
        }

        public void CheckLastEatStart()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand sqlcomm = new SqlCommand();
            SqlDataReader sd;
            String sql = "select max(select * from orders where idxMarket = A and eatTable = B) from order; ";
            try
            {
                String connectionString = "Server=10.80.162.216;"
                                        + "database=kiosk"
                                        + "uid=root"
                                        + "pwd=NFSedge2020";
                conn.ConnectionString = connectionString;
                conn.Open();
                sqlcomm.CommandText = sql;
                sqlcomm.Connection = conn;
                sd = sqlcomm.ExecuteReader();

                if (sd.Read())
                {
                    isNowUse();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("DB Error : " + e);
            }

        }

        public void isNowUse()
        {
            DateTime now = DateTime.Now;
            TimeSpan dateDiff = now - lastEatStart;
            int MinuteDiff = (dateDiff.Days * 24 + dateDiff.Hours) * 60 + dateDiff.Minutes;
            if (MinuteDiff < 5)
            {
                //버튼 색상 변경
                SolidColorBrush yellow = (SolidColorBrush)new BrushConverter().ConvertFromString("#F7FF00");
                this.button.Background = yellow;

                //타이머 동작
                timer.Interval = TimeSpan.FromSeconds(1); //시간간격 설정
                timer.Tick += new EventHandler(timer_Tick); //이벤트 추가
                TimeRemaining = dateDiff.Minutes * 60 + dateDiff.Seconds;
                timer.Start(); //타이머 시작
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeRemaining--;
            button.Content = TimeRemaining.ToString();
            if (TimeRemaining == 0)
            {
                //버튼 색깔, 숫자 원래대로
                SolidColorBrush yellows = (SolidColorBrush)new BrushConverter().ConvertFromString("#F7FF00");
                this.button.Background = yellows;

                button.Content = myTableNumber.ToString();

                timer.Stop(); //타이머 종료
            }
        }
    }
}
