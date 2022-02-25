
namespace Sa7kaWin
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.BtnStart = new System.Windows.Forms.Button();
            this.LblState = new System.Windows.Forms.Label();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LblStateTitle = new System.Windows.Forms.Label();
            this.TxtKey1 = new System.Windows.Forms.TextBox();
            this.LblShortcutTitle = new System.Windows.Forms.Label();
            this.BtnSaveShortcuts = new System.Windows.Forms.Button();
            this.LblSaved = new System.Windows.Forms.Label();
            this.CbStartApplicationOnStartUp = new System.Windows.Forms.CheckBox();
            this.TxtKey2 = new System.Windows.Forms.TextBox();
            this.TxtKey3 = new System.Windows.Forms.TextBox();
            this.TxtKeyModifier1 = new System.Windows.Forms.TextBox();
            this.TxtKeyModifier2 = new System.Windows.Forms.TextBox();
            this.TxtKeyModifier3 = new System.Windows.Forms.TextBox();
            this.LblPlus1 = new System.Windows.Forms.Label();
            this.LblPlus2 = new System.Windows.Forms.Label();
            this.LblPlus3 = new System.Windows.Forms.Label();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.BtnStart.ForeColor = System.Drawing.Color.Crimson;
            this.BtnStart.Location = new System.Drawing.Point(17, 222);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(116, 48);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "STOP";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // LblState
            // 
            this.LblState.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.LblState.ForeColor = System.Drawing.Color.ForestGreen;
            this.LblState.Location = new System.Drawing.Point(48, 298);
            this.LblState.Name = "LblState";
            this.LblState.Size = new System.Drawing.Size(128, 16);
            this.LblState.TabIndex = 1;
            this.LblState.Text = "Started";
            this.LblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.ContextMenuStrip;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Sa7ka";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowToolStripMenuItem,
            this.AboutToolStripMenuItem,
            this.QuitToolStripMenuItem});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(108, 70);
            // 
            // ShowToolStripMenuItem
            // 
            this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
            this.ShowToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.ShowToolStripMenuItem.Text = "Show";
            this.ShowToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            this.QuitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.QuitToolStripMenuItem.Text = "Quit";
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // LblStateTitle
            // 
            this.LblStateTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.LblStateTitle.ForeColor = System.Drawing.Color.Black;
            this.LblStateTitle.Location = new System.Drawing.Point(12, 298);
            this.LblStateTitle.Name = "LblStateTitle";
            this.LblStateTitle.Size = new System.Drawing.Size(42, 16);
            this.LblStateTitle.TabIndex = 1;
            this.LblStateTitle.Text = "State:";
            this.LblStateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtKey1
            // 
            this.TxtKey1.BackColor = System.Drawing.Color.White;
            this.TxtKey1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtKey1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.TxtKey1.Location = new System.Drawing.Point(178, 47);
            this.TxtKey1.Name = "TxtKey1";
            this.TxtKey1.ReadOnly = true;
            this.TxtKey1.Size = new System.Drawing.Size(92, 34);
            this.TxtKey1.TabIndex = 2;
            this.TxtKey1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtKey1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_KeyDown);
            // 
            // LblShortcutTitle
            // 
            this.LblShortcutTitle.AutoSize = true;
            this.LblShortcutTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.LblShortcutTitle.ForeColor = System.Drawing.Color.Black;
            this.LblShortcutTitle.Location = new System.Drawing.Point(12, 9);
            this.LblShortcutTitle.Name = "LblShortcutTitle";
            this.LblShortcutTitle.Size = new System.Drawing.Size(104, 28);
            this.LblShortcutTitle.TabIndex = 1;
            this.LblShortcutTitle.Text = "Shortcuts:";
            this.LblShortcutTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSaveShortcuts
            // 
            this.BtnSaveShortcuts.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.BtnSaveShortcuts.ForeColor = System.Drawing.Color.Black;
            this.BtnSaveShortcuts.Location = new System.Drawing.Point(17, 184);
            this.BtnSaveShortcuts.Name = "BtnSaveShortcuts";
            this.BtnSaveShortcuts.Size = new System.Drawing.Size(128, 32);
            this.BtnSaveShortcuts.TabIndex = 0;
            this.BtnSaveShortcuts.Text = "Save Shortcuts";
            this.BtnSaveShortcuts.UseVisualStyleBackColor = true;
            this.BtnSaveShortcuts.Click += new System.EventHandler(this.BtnChangeShortcut_Click);
            // 
            // LblSaved
            // 
            this.LblSaved.AutoSize = true;
            this.LblSaved.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblSaved.ForeColor = System.Drawing.Color.ForestGreen;
            this.LblSaved.Location = new System.Drawing.Point(151, 192);
            this.LblSaved.Name = "LblSaved";
            this.LblSaved.Size = new System.Drawing.Size(56, 19);
            this.LblSaved.TabIndex = 1;
            this.LblSaved.Text = "Saved ..";
            this.LblSaved.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblSaved.Visible = false;
            // 
            // CbStartApplicationOnStartUp
            // 
            this.CbStartApplicationOnStartUp.AutoSize = true;
            this.CbStartApplicationOnStartUp.Location = new System.Drawing.Point(17, 276);
            this.CbStartApplicationOnStartUp.Name = "CbStartApplicationOnStartUp";
            this.CbStartApplicationOnStartUp.Size = new System.Drawing.Size(177, 19);
            this.CbStartApplicationOnStartUp.TabIndex = 3;
            this.CbStartApplicationOnStartUp.Text = "Start Application On StartUp";
            this.CbStartApplicationOnStartUp.UseVisualStyleBackColor = true;
            this.CbStartApplicationOnStartUp.CheckedChanged += new System.EventHandler(this.CbStartApplicationOnStartUp_CheckedChanged);
            // 
            // TxtKey2
            // 
            this.TxtKey2.BackColor = System.Drawing.Color.White;
            this.TxtKey2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtKey2.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.TxtKey2.Location = new System.Drawing.Point(178, 91);
            this.TxtKey2.Name = "TxtKey2";
            this.TxtKey2.ReadOnly = true;
            this.TxtKey2.Size = new System.Drawing.Size(92, 34);
            this.TxtKey2.TabIndex = 2;
            this.TxtKey2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtKey2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_KeyDown);
            // 
            // TxtKey3
            // 
            this.TxtKey3.BackColor = System.Drawing.Color.White;
            this.TxtKey3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtKey3.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.TxtKey3.Location = new System.Drawing.Point(178, 135);
            this.TxtKey3.Name = "TxtKey3";
            this.TxtKey3.ReadOnly = true;
            this.TxtKey3.Size = new System.Drawing.Size(92, 34);
            this.TxtKey3.TabIndex = 2;
            this.TxtKey3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtKey3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_KeyDown);
            // 
            // TxtKeyModifier1
            // 
            this.TxtKeyModifier1.BackColor = System.Drawing.Color.White;
            this.TxtKeyModifier1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtKeyModifier1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.TxtKeyModifier1.Location = new System.Drawing.Point(45, 47);
            this.TxtKeyModifier1.Name = "TxtKeyModifier1";
            this.TxtKeyModifier1.ReadOnly = true;
            this.TxtKeyModifier1.Size = new System.Drawing.Size(92, 34);
            this.TxtKeyModifier1.TabIndex = 2;
            this.TxtKeyModifier1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtKeyModifier1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyModifier_KeyDown);
            // 
            // TxtKeyModifier2
            // 
            this.TxtKeyModifier2.BackColor = System.Drawing.Color.White;
            this.TxtKeyModifier2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtKeyModifier2.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.TxtKeyModifier2.Location = new System.Drawing.Point(45, 91);
            this.TxtKeyModifier2.Name = "TxtKeyModifier2";
            this.TxtKeyModifier2.ReadOnly = true;
            this.TxtKeyModifier2.Size = new System.Drawing.Size(92, 34);
            this.TxtKeyModifier2.TabIndex = 2;
            this.TxtKeyModifier2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtKeyModifier2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyModifier_KeyDown);
            // 
            // TxtKeyModifier3
            // 
            this.TxtKeyModifier3.BackColor = System.Drawing.Color.White;
            this.TxtKeyModifier3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtKeyModifier3.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.TxtKeyModifier3.Location = new System.Drawing.Point(45, 135);
            this.TxtKeyModifier3.Name = "TxtKeyModifier3";
            this.TxtKeyModifier3.ReadOnly = true;
            this.TxtKeyModifier3.Size = new System.Drawing.Size(92, 34);
            this.TxtKeyModifier3.TabIndex = 2;
            this.TxtKeyModifier3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtKeyModifier3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyModifier_KeyDown);
            // 
            // LblPlus1
            // 
            this.LblPlus1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.LblPlus1.ForeColor = System.Drawing.Color.Black;
            this.LblPlus1.Location = new System.Drawing.Point(143, 49);
            this.LblPlus1.Name = "LblPlus1";
            this.LblPlus1.Size = new System.Drawing.Size(29, 28);
            this.LblPlus1.TabIndex = 1;
            this.LblPlus1.Text = "+";
            this.LblPlus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPlus2
            // 
            this.LblPlus2.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.LblPlus2.ForeColor = System.Drawing.Color.Black;
            this.LblPlus2.Location = new System.Drawing.Point(143, 93);
            this.LblPlus2.Name = "LblPlus2";
            this.LblPlus2.Size = new System.Drawing.Size(29, 28);
            this.LblPlus2.TabIndex = 1;
            this.LblPlus2.Text = "+";
            this.LblPlus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPlus3
            // 
<<<<<<< HEAD
            this.LblPlus3.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.LblPlus3.ForeColor = System.Drawing.Color.Black;
            this.LblPlus3.Location = new System.Drawing.Point(143, 137);
            this.LblPlus3.Name = "LblPlus3";
            this.LblPlus3.Size = new System.Drawing.Size(29, 28);
            this.LblPlus3.TabIndex = 1;
            this.LblPlus3.Text = "+";
            this.LblPlus3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
=======
            this.TxtTest.BackColor = System.Drawing.Color.White;
            this.TxtTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTest.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.TxtTest.Location = new System.Drawing.Point(83, 95);
            this.TxtTest.Name = "TxtTest";
            this.TxtTest.Size = new System.Drawing.Size(200, 34);
            this.TxtTest.TabIndex = 2;
            this.TxtTest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtTest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtShortcut_KeyDown);
>>>>>>> noHookTest
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(296, 320);
            this.Controls.Add(this.CbStartApplicationOnStartUp);
            this.Controls.Add(this.TxtKey3);
            this.Controls.Add(this.TxtKey2);
            this.Controls.Add(this.TxtKeyModifier3);
            this.Controls.Add(this.TxtKeyModifier2);
            this.Controls.Add(this.TxtKeyModifier1);
            this.Controls.Add(this.TxtKey1);
            this.Controls.Add(this.LblSaved);
            this.Controls.Add(this.LblState);
            this.Controls.Add(this.LblShortcutTitle);
            this.Controls.Add(this.LblPlus3);
            this.Controls.Add(this.LblPlus2);
            this.Controls.Add(this.LblPlus1);
            this.Controls.Add(this.LblStateTitle);
            this.Controls.Add(this.BtnSaveShortcuts);
            this.Controls.Add(this.BtnStart);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sa7ka";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label LblState;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.Label LblStateTitle;
        private new System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
        private System.Windows.Forms.TextBox TxtKey1;
        private System.Windows.Forms.Label LblShortcutTitle;
        private System.Windows.Forms.Button BtnSaveShortcuts;
        private System.Windows.Forms.Label LblSaved;
        private System.Windows.Forms.CheckBox CbStartApplicationOnStartUp;
        private System.Windows.Forms.TextBox TxtKey2;
        private System.Windows.Forms.TextBox TxtKey3;
        private System.Windows.Forms.TextBox TxtKeyModifier1;
        private System.Windows.Forms.TextBox TxtKeyModifier2;
        private System.Windows.Forms.TextBox TxtKeyModifier3;
        private System.Windows.Forms.Label LblPlus1;
        private System.Windows.Forms.Label LblPlus2;
        private System.Windows.Forms.Label LblPlus3;
    }
}

