using IWshRuntimeLibrary;
using Sa7kaWin.Enums;
using Sa7kaWin.Extensions;
using Sa7kaWin.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using Sa7kaWin.Extensions;
using Sa7kaWin.Enums;

namespace Sa7kaWin
{
    public partial class Main : Form
    {
<<<<<<< HEAD
        private bool _start = true;

        private SettingInfo _settings;

        private static readonly string _english = "`qwertyuiop[]asdfghjkl;'zxcvbnm,./";
        private static readonly string _arabic = "ذضصثقفغعهخحجدشسيبلاتنمكطئءؤرلىةوزظ";

        private readonly GlobalKeyboardHook _hook;
        private readonly SettingRepository _settingRepository;

        #region DLL Imports
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point pt);

        [DllImport("user32.dll", EntryPoint = "WindowFromPoint", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr WindowFromPoint(Point pt);

=======
>>>>>>> noHookTest
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


        private bool _start = true;
        private string _keyString;
        private Keys _selectedKey;
        private static readonly string _english = "`qwertyuiop[]asdfghjkl;'zxcvbnm,./";
        private static readonly string _arabic = "ذضصثقفغعهخحجدشسيبلاتنمكطئءؤرلىةوزظ";

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        #endregion

        public Main()
        {
            InitializeComponent();
            _settingRepository = new SettingRepository();
            _hook = new GlobalKeyboardHook();
        }

<<<<<<< HEAD
        void KeyPressed(object sender, KeyPressedEventArgs e)
        {
            try
            {
                if (_start)
                {
                    if (e.Modifier.ToString() == _settings.KeyModifier1 ||
                        e.Modifier.ToString() == _settings.KeyModifier2 ||
                        e.Modifier.ToString() == _settings.KeyModifier3)
                    {
                        //SendKeys.SendWait("+{HOME}");
                        //SendKeys.SendWait("\x1");
                        SendKeys.SendWait("^{HOME}");
                        SendKeys.SendWait("^+{END}");
                        //Thread.Sleep(100);
                        string selectedText = GetTextFromFocusedControl();
                        //Thread.Sleep(100);
                        //if (string.IsNullOrEmpty(selectedText))
                        //SendKeys.SendWait("^A");
                        
                        //Thread.Sleep(100);
                        //SendKeyDown(KeyCode.CONTROL);
                        //SendKeyPress(KeyCode.KEY_A);
                        Clipboard.SetText(Convert(/*Clipboard.GetText()*/selectedText));
                        Thread.Sleep(100);
                        SendKeys.SendWait("{BS}");
                        SendKeys.SendWait("^{V}");
                        //Thread.Sleep(100);
                        SendKeys.Send("%+");
                        NotifyIcon.PopUp("Converted !", "We Saved You .. \n Sa7ka Killed!", 1000);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void Main_Load(object sender, EventArgs e)
=======
        private void Main_Load(object sender, EventArgs e)
>>>>>>> noHookTest
        {
            try
            {
                this.Hide();
<<<<<<< HEAD

                _settings = await _settingRepository.GetSettings();

                if (_settings is null)
                {
                    _settings = new SettingInfo()
                    {
                        Key1 = "D1",
                        Key2 = "D2",
                        Key3 = "D3",

                        KeyModifier1 = "Shift",
                        KeyModifier2 = "Shift",
                        KeyModifier3 = "Shift",

                        OnStartUp = true
                    };

                    await _settingRepository.InsertSettings(_settings);
                }
=======
                NotifyIcon.Visible = true;
                NotifyIcon.PopUp("Sa7ka", "Sa7ka is running Minimized, \n You can open it by double click on the tray icon", 1000);
>>>>>>> noHookTest

                this.Text += " " + Application.ProductVersion;

                CbStartApplicationOnStartUp.Checked = System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" +
        Application.ProductName + ".lnk");

                LoadSettings();
                UpdateHookedKeys();

                _hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(KeyPressed);

                NotifyIcon.Visible = true;
                NotifyIcon.PopUp("Sa7ka", "Sa7ka is running Minimized, \n You can open it by double click on the tray icon", 1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateHookedKeys()
        {

            _hook.HookedKeys.Clear();
            _hook.HookedKeys.Add(_settings.Key1Value);
            _hook.HookedKeys.Add(_settings.Key2Value);
            _hook.HookedKeys.Add(_settings.Key3Value);
        }
        private void LoadSettings()
        {
            TxtKey1.Text = _settings.Key1;
            TxtKey2.Text = _settings.Key2;
            TxtKey3.Text = _settings.Key3;

            TxtKeyModifier1.Text = _settings.KeyModifier1;
            TxtKeyModifier2.Text = _settings.KeyModifier2;
            TxtKeyModifier3.Text = _settings.KeyModifier3;
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
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
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
<<<<<<< HEAD
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void Key_KeyDown(object sender, KeyEventArgs e)
=======
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
                            if (GetTextFromFocusedControl() == string.Empty)
                            {
                                SendKeys.Send("^{HOME}");
                                Thread.Sleep(800);
                            }

                            SendKeys.Send("^x");
                            Thread.Sleep(100);

                            if (Clipboard.ContainsText())
                            {
                                SendKeys.SendWait(Convert(Clipboard.GetText()));
                                SendKeys.Send("%+");
                            }

                            NotifyIcon.PopUp("Converted !", "We Saved You .. \n Sa7ka Killed!", 1000);
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
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
            else
                UnregisterHotKey(this.Handle, 0);
        }
        private void TxtShortcut_KeyDown(object sender, KeyEventArgs e)
>>>>>>> noHookTest
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                    TxtKey1.Text = string.Empty;
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
                    TxtKey1.Text = string.Empty;
                    break;
                case Keys.Return:
                    break;
                case Keys.Menu:
                    break;
                case Keys.LWin:
                    break;
                default:
                    (sender as TextBox).Text = e.KeyCode.ToString();
                    break;
            }
        }
        private void KeyModifier_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                    (sender as TextBox).Text = string.Empty;
                    break;
                case Keys.ShiftKey:
                    (sender as TextBox).Text = e.KeyCode.ToString();
                    break;
                case Keys.ControlKey:
                    (sender as TextBox).Text = e.KeyCode.ToString();
                    break;
                case Keys.Alt:
                    (sender as TextBox).Text = e.KeyCode.ToString();
                    break;
                case Keys.Delete:
                    (sender as TextBox).Text = string.Empty;
                    break;
                case Keys.Menu:
                    (sender as TextBox).Text = e.KeyCode.ToString();
                    break;
                case Keys.LWin:
                    (sender as TextBox).Text = e.KeyCode.ToString();
                    break;
                default:
                    break;
            }
        }
        private void BtnChangeShortcut_Click(object sender, EventArgs e)
        {
            try
            {
                //if (TxtKey1.Text == string.Empty)
                //    return;

                //Properties.Settings.Default.KeyString = _keyString;
                //Properties.Settings.Default.Save();

                //_selectedKey = (Keys)Enum.Parse(typeof(Keys), _keyString);

                //Task.Run(() =>
                //{
                //    LblSaved.Invoke(async () =>
                //    {
                //        LblSaved.Visible = true;
                //        await Task.Delay(2500);
                //        LblSaved.Visible = false;
                //    });
                //});
                //UnregisterHotKey(this.Handle, 0);
                //RegisterHotKey(this.Handle, 0, (int)KeyModifier.Shift, _selectedKey.GetHashCode());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
<<<<<<< HEAD
//todo: put in all characters with and without shift
//todo: 1-ar to en .. 2-en to ar .. 3-each char from another .. 4-Translate
=======
//todo: put all characters with and without shift in my Arrays
//todo: 1-ar to en .. 2-en to ar .. 3-each char from another .. 4-Translate
//todo: ظ   and   ض
>>>>>>> noHookTest
