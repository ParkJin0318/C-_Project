using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.util
{
    class ToastMessage
    {
        private readonly NotifyIcon _notifyIcon;

        public ToastMessage()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            _notifyIcon.BalloonTipClosed += (s, e) => _notifyIcon.Visible = false;
        }

        public void ShowNotification(string title, string message)
        {
            _notifyIcon.Visible = true;
            _notifyIcon.ShowBalloonTip(500, title, message, ToolTipIcon.Info);
        }
    }
}
