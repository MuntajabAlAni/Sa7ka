using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sa7kaWin.Extensions
{
    public static class ControlExtensions
    {
        public static void Invoke(this Control Control, Action Action)
        {
            if (Control.InvokeRequired && !Control.IsDisposed)
            {
                Control.Invoke(Action);
            }
            else if (!Control.IsDisposed)
            {
                Action();
            }
        }
    }
}
