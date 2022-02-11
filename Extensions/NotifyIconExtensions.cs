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
        public static void PopUp(this NotifyIcon notify, string title, string text, int timeout)
        {
            notify.BalloonTipTitle = title;
            notify.BalloonTipText = text;
            notify.ShowBalloonTip(timeout);
        }
    }
}
