using IWshRuntimeLibrary;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sa7kaWin
{
    public partial class Main : Form
    {
        private bool _start = true;
        private string _keyString;
        private Keys _selectedKey;
        private static readonly string _english = "`qwertyuiop[]asdfghjkl;'zxcvbnm,./";
        private static readonly string _arabic = "ذضصثقفغعهخحجدشسيبلاتنمكطئءؤرلىةوزظ";

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point pt);

        [DllImport("user32.dll", EntryPoint = "WindowFromPoint", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr WindowFromPoint(Point pt);

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessageW([InAttribute] System.IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
        public const int WM_GETTEXT = 13;

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern IntPtr GetFocus();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetWindowThreadProcessId(int handle, out int processId);

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        internal static extern int AttachThreadInput(int idAttach, int idAttachTo, bool fAttach);
        [DllImport("kernel32.dll")]
        internal static extern int GetCurrentThreadId();

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetWindowText(IntPtr hWnd, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Main()
        {
            InitializeComponent();
        }

        private void NotifyIconBalloonPopUp(string title, string text, int timeout)
        {
            NotifyIcon.BalloonTipTitle = title;
            NotifyIcon.BalloonTipText = text;
            NotifyIcon.ShowBalloonTip(timeout);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                NotifyIcon.Visible = true;
                NotifyIconBalloonPopUp("Sa7ka", "Sa7ka is running Minimized, \n You can open it by double click on the tray icon", 1000);

                this.Text += " " + Application.ProductVersion;
                _keyString = TxtShortcut.Text = Properties.Settings.Default.KeyString;
                _selectedKey = (Keys)Enum.Parse(typeof(Keys), _keyString);
                CbStartApplicationOnStartUp.Checked = System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" +
                        Application.ProductName + ".lnk");
                RegisterHotKey(this.Handle, 0, (int)KeyModifier.Shift, _selectedKey.GetHashCode());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (_start)
            {
                LblState.Text = "Stopped";
                LblState.ForeColor = Color.Crimson;
                BtnStart.Text = "START";
                BtnStart.ForeColor = Color.ForestGreen;
                _start = false;
            }
            else
            {
                LblState.Text = "Started";
                LblState.ForeColor = Color.ForestGreen;
                BtnStart.Text = "STOP";
                BtnStart.ForeColor = Color.Crimson;
                _start = true;
            }
        }
        static string Convert(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                if (c == ' ')
                    output += c;
                else if (_arabic.Contains(c))
                    output += _english[_arabic.IndexOf(c)];
                else if (_english.Contains(c))
                    output += _arabic[_english.IndexOf(c)];
            }
            return output;
        }
        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                NotifyIcon.Visible = true;
            }
        }
        private void NotifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            NotifyIcon.Visible = false;
        }
        private string GetTextFromFocusedControl()
        {
            try
            {
                int activeWinPtr = GetForegroundWindow().ToInt32();
                int activeThreadId = 0;
                activeThreadId = GetWindowThreadProcessId(activeWinPtr, out int processId);
                int currentThreadId = GetCurrentThreadId();
                if (activeThreadId != currentThreadId)
                    AttachThreadInput(activeThreadId, currentThreadId, true);
                IntPtr activeCtrlId = GetFocus();

                return GetText(activeCtrlId);
            }
            catch (Exception exp)
            {
                return exp.Message;
            }
        }
        private string GetText(IntPtr handle)
        {
            int maxLength = 100;
            IntPtr buffer = Marshal.AllocHGlobal((maxLength + 1) * 2);
            SendMessageW(handle, WM_GETTEXT, maxLength, buffer);
            string w = Marshal.PtrToStringUni(buffer);
            Marshal.FreeHGlobal(buffer);
            return w;
        }
        protected override void WndProc(ref Message m)
        {
            try
            {
                base.WndProc(ref m);

                if (m.Msg == 0x0312)
                {
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    if (_start)
                    {
                        if (key == _selectedKey)
                        {
                            //SendKeys.SendWait("+{HOME}");
                            SendKeys.SendWait("\x1");
                            string selectedText = GetTextFromFocusedControl();
                            //if (string.IsNullOrEmpty(selectedText))
                            
                            
                            //SendKeys.SendWait("^A");
                            //SendKeys.SendWait("^X");
                            //SendKeyDown(KeyCode.CONTROL);
                            //SendKeyPress(KeyCode.KEY_A);
                            Clipboard.SetText(Convert(/*Clipboard.GetText()*/selectedText));
                            SendKeys.SendWait("^{V}");
                            SendKeys.Send("%+");
                            NotifyIconBalloonPopUp("Converted !", "We Saved You .. \n Sa7ka Killed!", 1000);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 0);
        }
        private void TxtShortcut_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                    TxtShortcut.Text = string.Empty;
                    break;
                case Keys.ShiftKey:
                    break;
                case Keys.ControlKey:
                    break;
                case Keys.Capital:
                    break;
                case Keys.Alt:
                    break;
                case Keys.Delete:
                    TxtShortcut.Text = string.Empty;
                    break;
                case Keys.Return:
                    break;
                case Keys.Menu:
                    break;
                case Keys.LWin:
                    break;
                default:
                    TxtShortcut.Text = _keyString = e.KeyCode.ToString();
                    break;
            }
        }
        private void BtnChangeShortcut_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtShortcut.Text == string.Empty)
                    return;

                Properties.Settings.Default.KeyString = _keyString;
                Properties.Settings.Default.Save();

                _selectedKey = (Keys)Enum.Parse(typeof(Keys), _keyString);

                Task.Run(() =>
                {
                    LblChanged.Invoke(async () =>
                    {
                        LblChanged.Visible = true;
                        await Task.Delay(2500);
                        LblChanged.Visible = false;
                    });
                });
                UnregisterHotKey(this.Handle, 0);
                RegisterHotKey(this.Handle, 0, (int)KeyModifier.Shift, _selectedKey.GetHashCode());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" experimental version under test .. \n ", " About ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            NotifyIcon.Visible = false;
        }
        private void CbStartApplicationOnStartUp_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string startUpFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

                if (CbStartApplicationOnStartUp.Checked)
                {
                    WshShell wshShell = new WshShell();
                    IWshShortcut shortcut;

                    shortcut =
                      (IWshShortcut)wshShell.CreateShortcut(
                        startUpFolderPath + "\\" +
                        Application.ProductName + ".lnk");

                    shortcut.TargetPath = Application.ExecutablePath;
                    shortcut.WorkingDirectory = Application.StartupPath;
                    shortcut.Description = "Launch My Application";
                    shortcut.Save();
                }
                else
                {
                    System.IO.File.Delete(startUpFolderPath + "\\" +
                        Application.ProductName + ".lnk");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

//todo: add translate dll (1)
//todo: ctrl+ delete to delete word
//todo: fix Sa7ka only the selected text
//todo: Salam to سلام can be done by (1)
//todo: not working on all programs ???
//todo: put in all characters with and without shift
//todo: 1-ar to en .. 2-en to ar .. 3-each char from another .. 4-Translate
//todo: convert to .NET Core