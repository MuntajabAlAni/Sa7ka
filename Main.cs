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

namespace Sa7kaWin
{
    public partial class Main : Form
    {
        #region ImportDlls
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
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        #endregion

        private bool _start = true;
        private static readonly string _english = "`qwertyuiop[]asdfghjkl;'zxcvbnm,./";
        private static readonly string _arabic = "ذضصثقفغعهخحجدشسيبلاتنمكطئءؤرلىةوزظ";

        private readonly SettingRepository _settingRepository;
        private SettingInfo _settings;

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static readonly LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        public Main()
        {
            InitializeComponent();
            _settingRepository = new SettingRepository();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text += Application.ProductVersion;
                this.Hide();

                //LoadSettings();
                //RegisterKeys();

                _hookID = SetHook(_proc);
                NotifyIcon.Visible = true;
                NotifyIcon.PopUp("Sa7ka", "Sa7ka is running Minimized, \n You can open it by double click on the tray icon", 1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        private delegate IntPtr LowLevelKeyboardProc(
       int nCode, IntPtr wParam, IntPtr lParam);
        private static IntPtr HookCallback(
        int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if ((Keys)vkCode == Keys.Oem5/* && ModifierKeys == Keys.Shift*/)
                {
                    SendKeys.Flush();
                    SendKeys.SendWait("^{HOME}");
                    SendKeys.SendWait("^+{END}");
                    //Thread.Sleep(800);

                    SendKeys.SendWait("^X");
                    Thread.Sleep(100);

                    if (Clipboard.ContainsText())
                    {
                        var convertedText = Convert(Clipboard.GetText());

                        //ChangeLanguage(InputLanguage.CurrentInputLanguage);
                        SendKeys.SendWait("%+");
                        SendKeys.SendWait(convertedText);
                    }
                }
                //Console.WriteLine((Keys)vkCode);
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
    LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private async void LoadSettings()
        {
            _settings = await _settingRepository.GetSettings();

            CbStartApplicationOnStartUp.Checked = _settings.OnStartUp;

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
        private void RegisterKeys()
        {
            if (_settings.Key1 is string && _settings.Key1 != string.Empty)
                RegisterHotKey(this.Handle, 0, (int)_settings.KeyModifier1Value, _settings.Key1Value.GetHashCode());

            if (_settings.Key2 is string && _settings.Key2 != string.Empty)
                RegisterHotKey(this.Handle, 1, (int)_settings.KeyModifier2Value, _settings.Key2Value.GetHashCode());

            if (_settings.Key3 is string && _settings.Key3 != string.Empty)
                RegisterHotKey(this.Handle, 2, (int)_settings.KeyModifier3Value, _settings.Key3Value.GetHashCode());
        }
        private void UnregisterKeys()
        {
            UnregisterHotKey(this.Handle, 0);
            UnregisterHotKey(this.Handle, 1);
            UnregisterHotKey(this.Handle, 2);
        }
        private static string Convert(string input)
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
        private static void ChangeLanguage(InputLanguage inputLanguage)
        {
            if (inputLanguage.Culture.Name.StartsWith("ar"))
            {
                var englishLanguage = InputLanguage.InstalledInputLanguages.OfType<InputLanguage>().Where(l => l.Culture.Name.StartsWith("en")).FirstOrDefault();
                if (englishLanguage != null)
                {
                    InputLanguage.CurrentInputLanguage = englishLanguage;
                }
            }
            else
            {
                var arabicLanguage = InputLanguage.InstalledInputLanguages.OfType<InputLanguage>().Where(l => l.Culture.Name.StartsWith("ar")).FirstOrDefault();
                if (arabicLanguage != null)
                {
                    InputLanguage.CurrentInputLanguage = arabicLanguage;
                }
            }
        }
        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                NotifyIcon.Visible = true;
            }
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
                    //Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    if (_start)
                    {
                        if (GetTextFromFocusedControl() == string.Empty)
                        {
                            SendKeys.SendWait("^{HOME}");
                            Thread.Sleep(800);
                        }

                        SendKeys.SendWait("^X");
                        Thread.Sleep(100);

                        if (Clipboard.ContainsText())
                        {
                            var test = GetTextFromFocusedControl();
                            var converted = Convert(test);

                            SendKeys.SendWait(converted);
                            SendKeys.SendWait("%+");
                        }

                        NotifyIcon.PopUp("Converted !", "We Saved You .. \n Sa7ka Killed!", 1000);
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
                return;
            }

            UnhookWindowsHookEx(_hookID);
            UnregisterKeys();
        }
        private void TxtShortcut_KeyDown(object sender, KeyEventArgs e)
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
                _settings = new SettingInfo()
                {
                    Key1 = TxtKey1.Text,
                    Key2 = TxtKey2.Text,
                    Key3 = TxtKey3.Text,
                    KeyModifier1 = TxtKeyModifier1.Text,
                    KeyModifier2 = TxtKeyModifier2.Text,
                    KeyModifier3 = TxtKeyModifier3.Text,
                    OnStartUp = CbStartApplicationOnStartUp.Checked,
                };

                UpdateSettings();
                UnregisterKeys();
                RegisterKeys();

                Task.Run(() =>
                {
                    LblSaved.Invoke(async () =>
                    {
                        LblSaved.Visible = true;
                        await Task.Delay(2500);
                        LblSaved.Visible = false;
                    });
                });
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
                _settings.OnStartUp = CbStartApplicationOnStartUp.Checked;
                UpdateSettings();

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
        private async void UpdateSettings()
        {
            await _settingRepository.UpdateSettings(_settings);
        }
        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            NotifyIcon.Visible = false;
        }
    }
}

//todo: add translate dll (1)
//todo: ctrl+ delete to delete word
//todo: fix Sa7ka only the selected text
//todo: Salam to سلام can be done by (1)
//todo: not working on all programs ???
//todo: put all characters with and without shift in my Arrays
//todo: 1-ar to en .. 2-en to ar .. 3-each char from another .. 4-Translate
//todo: ظ   and   ض
