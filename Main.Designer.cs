
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
            this.CbStartApplicationOnStartUp = new System.Windows.Forms.CheckBox();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.BtnStart.ForeColor = System.Drawing.Color.Crimson;
            this.BtnStart.Location = new System.Drawing.Point(12, 12);
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
            this.LblState.Location = new System.Drawing.Point(43, 88);
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
            this.NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
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
            this.LblStateTitle.Location = new System.Drawing.Point(7, 88);
            this.LblStateTitle.Name = "LblStateTitle";
            this.LblStateTitle.Size = new System.Drawing.Size(42, 16);
            this.LblStateTitle.TabIndex = 1;
            this.LblStateTitle.Text = "State:";
            this.LblStateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CbStartApplicationOnStartUp
            // 
            this.CbStartApplicationOnStartUp.AutoSize = true;
            this.CbStartApplicationOnStartUp.Location = new System.Drawing.Point(12, 66);
            this.CbStartApplicationOnStartUp.Name = "CbStartApplicationOnStartUp";
            this.CbStartApplicationOnStartUp.Size = new System.Drawing.Size(177, 19);
            this.CbStartApplicationOnStartUp.TabIndex = 3;
            this.CbStartApplicationOnStartUp.Text = "Start Application On StartUp";
            this.CbStartApplicationOnStartUp.UseVisualStyleBackColor = true;
            this.CbStartApplicationOnStartUp.CheckedChanged += new System.EventHandler(this.CbStartApplicationOnStartUp_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(296, 127);
            this.Controls.Add(this.CbStartApplicationOnStartUp);
            this.Controls.Add(this.LblState);
            this.Controls.Add(this.LblStateTitle);
            this.Controls.Add(this.BtnStart);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sa7ka ";
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
        private System.Windows.Forms.CheckBox CbStartApplicationOnStartUp;
    }
}

