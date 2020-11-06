using Kiosk.remote;
using Prism.Mvvm;
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
    class TableData : BindableBase
    {
        private int _TimeRemaining;

        public int TimeRemaining
        {
            get
            {
                return _TimeRemaining;
            }
            set
            {
                SetProperty(ref _TimeRemaining, value);
            }
        }

        private int _myTableNumber;

        public int myTableNumber
        {
            get
            {
                return _myTableNumber;
            }
            set
            {
                SetProperty(ref _myTableNumber, value);
            }
        }

        private bool _canUse = true;

        public bool canUse
        {
            get
            {
                return _canUse;
            }
            set
            {
                SetProperty(ref _canUse, value);
            }
        }

        private SolidColorBrush _TableColor = new SolidColorBrush(Colors.Red);

        public SolidColorBrush TableColor
        {
            get
            {
                return _TableColor;
            }
            set
            {
                SetProperty(ref _TableColor, value);
            }
        }

        private string _useText = "이용가능";

        public string useText
        {
            get
            {
                return _useText;
            }
            set
            {
                SetProperty(ref _useText, value);
            }
        }

        private DispatcherTimer timer = new DispatcherTimer();

        public void MakeTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(1); //시간간격 설정
            timer.Tick += new EventHandler(timer_Tick); //이벤트 추가
            timer.Start(); //타이머 시작
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!this.canUse)
            {
                if (this.TimeRemaining <= 1)
                {
                    this.canUse = true;
                    this.useText = "이용가능";
                    this.TableColor = new SolidColorBrush(Colors.Red);
                    stopTimer();
                }
                else
                {
                    this.TimeRemaining--;
                    this.useText = "이용중 : " + this.TimeRemaining;
                }
            }
        }

        public void stopTimer()
        {
            timer.Stop();
        }
    }
}
