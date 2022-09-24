using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sa7kaWin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!File.Exists(Application.StartupPath + "\\SQLite.Interop.dll"))
            {
                File.WriteAllBytes(Application.StartupPath + "\\SQLite.Interop.dll", Properties.Resources.SQLite_Interop);
            }

            Application.Run(new Main());
        }
    }
}
