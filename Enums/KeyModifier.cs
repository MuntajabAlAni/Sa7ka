using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sa7kaWin.Enums
{
    [Flags]
    public enum KeyModifier
    {
        None = 0,
        Alt, Menu = 1,
        Control, ControlKey = 2,
        Shift, ShiftKey = 4,
        Win = 8
    }
}