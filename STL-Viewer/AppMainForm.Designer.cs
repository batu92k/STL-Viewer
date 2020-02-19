namespace STLViewer
{
    partial class AppMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppMainForm));
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            this.GL_Monitor = new OpenTK.GLControl();
            this.AppToolBarMStp = new System.Windows.Forms.MenuStrip();
            this.ToolBarFileMenuBt = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuImportBt = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuExitBt = new System.Windows.Forms.ToolStripMenuItem();
            this.AppTitleBar = new System.Windows.Forms.MenuStrip();
            this.AppToolBarMStp.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawTimer
            // 
            this.DrawTimer.Enabled = true;
            this.DrawTimer.Interval = 25;
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
            // 
            // GL_Monitor
            // 
            this.GL_Monitor.BackColor = System.Drawing.Color.Black;
            this.GL_Monitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GL_Monitor.Location = new System.Drawing.Point(0, 70);
            this.GL_Monitor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GL_Monitor.Name = "GL_Monitor";
            this.GL_Monitor.Size = new System.Drawing.Size(1045, 602);
            this.GL_Monitor.TabIndex = 15;
            this.GL_Monitor.VSync = false;
            this.GL_Monitor.Load += new System.EventHandler(this.GL_Monitor_Load);
            this.GL_Monitor.Paint += new System.Windows.Forms.PaintEventHandler(this.GL_Monitor_Paint);
            // 
            // AppToolBarMStp
            // 
            this.AppToolBarMStp.AutoSize = false;
            this.AppToolBarMStp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AppToolBarMStp.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.AppToolBarMStp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AppToolBarMStp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolBarFileMenuBt});
            this.AppToolBarMStp.Location = new System.Drawing.Point(0, 35);
            this.AppToolBarMStp.Name = "AppToolBarMStp";
            this.AppToolBarMStp.Size = new System.Drawing.Size(1045, 35);
            this.AppToolBarMStp.TabIndex = 16;
            this.AppToolBarMStp.Text = "AppToolBar";
            // 
            // ToolBarFileMenuBt
            // 
            this.ToolBarFileMenuBt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuImportBt,
            this.FileMenuExitBt});
            this.ToolBarFileMenuBt.Name = "ToolBarFileMenuBt";
            this.ToolBarFileMenuBt.Size = new System.Drawing.Size(56, 31);
            this.ToolBarFileMenuBt.Text = "File";
            // 
            // FileMenuImportBt
            // 
            this.FileMenuImportBt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.FileMenuImportBt.Name = "FileMenuImportBt";
            this.FileMenuImportBt.Size = new System.Drawing.Size(158, 32);
            this.FileMenuImportBt.Text = "Import";
            this.FileMenuImportBt.Click += new System.EventHandler(this.FileMenuImportBt_Click);
            // 
            // FileMenuExitBt
            // 
            this.FileMenuExitBt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.FileMenuExitBt.Name = "FileMenuExitBt";
            this.FileMenuExitBt.Size = new System.Drawing.Size(158, 32);
            this.FileMenuExitBt.Text = "Exit";
            this.FileMenuExitBt.Click += new System.EventHandler(this.FileMenuExitBt_Click);
            // 
            // AppTitleBar
            // 
            this.AppTitleBar.AutoSize = false;
            this.AppTitleBar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AppTitleBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AppTitleBar.Location = new System.Drawing.Point(0, 0);
            this.AppTitleBar.Name = "AppTitleBar";
            this.AppTitleBar.Size = new System.Drawing.Size(1045, 35);
            this.AppTitleBar.TabIndex = 17;
            this.AppTitleBar.Text = "menuStrip1";
            this.AppTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AppTitleBar_MouseDown);
            this.AppTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AppTitleBar_MouseUp);
            // 
            // AppMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 672);
            this.Controls.Add(this.GL_Monitor);
            this.Controls.Add(this.AppToolBarMStp);
            this.Controls.Add(this.AppTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.AppToolBarMStp;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AppMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STL Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AppToolBarMStp.ResumeLayout(false);
            this.AppToolBarMStp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer DrawTimer;
        private OpenTK.GLControl GL_Monitor;
        private System.Windows.Forms.MenuStrip AppToolBarMStp;
        private System.Windows.Forms.ToolStripMenuItem ToolBarFileMenuBt;
        private System.Windows.Forms.ToolStripMenuItem FileMenuImportBt;
        private System.Windows.Forms.ToolStripMenuItem FileMenuExitBt;
        private System.Windows.Forms.MenuStrip AppTitleBar;
    }
}

