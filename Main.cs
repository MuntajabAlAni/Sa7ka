using IWshRuntimeLibrary;
using NLog;
using Sa7kaWin.Extensions;
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
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        #endregion

        private bool _start = true;
        private static readonly string _english = "`qwertyuiop[]asdfghjkl;'zxcvbnm,./";
        private static readonly string _arabic = "ذضصثقفغعهخحجدشسيبلاتنمكطئءؤرلىةوزظ";
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text += Application.ProductVersion;
                this.Hide();

                RegisterKeys();
                CbStartApplicationOnStartUp.Checked = CheckIfApplicationOnStartUp();

                NotifyIcon.Visible = true;
                NotifyIcon.PopUp("Sa7ka", "Sa7ka is running Minimized, \n You can open it by double click on the tray icon", 1000);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "An error occurred");
                MessageBox.Show("An error occurred. Please check the logs for more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void RegisterKeys()
        {
            RegisterHotKey(this.Handle, 0, 2/* For Control Key */, Keys.F1.GetHashCode());
            RegisterHotKey(this.Handle, 1, 2, Keys.F2.GetHashCode());
            RegisterHotKey(this.Handle, 2, 2, Keys.F3.GetHashCode());
        }
        private void UnregisterKeys()
        {
            UnregisterHotKey(this.Handle, 0);
            UnregisterHotKey(this.Handle, 1);
            UnregisterHotKey(this.Handle, 2);
        }
        private static string ConvertToEnglish(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                if (c == ' ' || !_arabic.Contains(c))
                    output += c;
                else
                    output += _english[_arabic.IndexOf(c)];
            }
            return output;
        }
        private static string ConvertToArabic(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                if (c == ' ' || !_english.Contains(c))
                    output += c;
                else
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
                        SendKeys.Flush();
                        SendKeys.SendWait("+{HOME}");
                        Thread.Sleep(500);

                        SendKeys.SendWait("^X");
                        Thread.Sleep(500);

                        if (Clipboard.ContainsText())
                        {
                            var test = Clipboard.GetText();
                            string converted = "";

                            if (key == Keys.F1)
                            {
                                converted = ConvertToArabic(test);
                            }
                            else if (key == Keys.F2)
                            {
                                converted = ConvertToEnglish(test);
                            }

                            Clipboard.SetText(converted);
                            Thread.Sleep(500);
                            SendKeys.SendWait("^V");
                            Thread.Sleep(500);
                            SendKeys.SendWait("%+");
                        }

                        NotifyIcon.PopUp("Converted !", "We Saved You .. \n Sa7ka Killed!", 1000);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "An error occurred");
                MessageBox.Show("An error occurred. Please check the logs for more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            UnregisterKeys();
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
                Logger.Error(ex, "An error occurred");
                MessageBox.Show("An error occurred. Please check the logs for more details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckIfApplicationOnStartUp()
        {
            string startUpFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            return System.IO.File.Exists(startUpFolderPath + "\\" + Application.ProductName + ".lnk");
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
