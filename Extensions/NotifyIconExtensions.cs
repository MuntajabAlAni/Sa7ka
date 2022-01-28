using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sa7kaWin.Extensions
{
    public static class NotifyIconExtensions
    {
        public static void PopUp(this NotifyIcon notifyIcon, string title, string text, int timeout)
        {
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = text;
            notifyIcon.ShowBalloonTip(timeout);
        }
    }
}
