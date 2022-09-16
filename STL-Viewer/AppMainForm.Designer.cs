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
            this.ToolBarHelpMenuBt = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuHowToUseBt = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuAboutBt = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseBt = new System.Windows.Forms.Button();
            this.MinimizeBt = new System.Windows.Forms.Button();
            this.AppTitleSymbolPicBx = new System.Windows.Forms.PictureBox();
            this.MaximizeBt = new System.Windows.Forms.Button();
            this.AppTitleLb = new System.Windows.Forms.Label();
            this.AppToolBarMStp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppTitleSymbolPicBx)).BeginInit();
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
            this.GL_Monitor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GL_Monitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GL_Monitor.Location = new System.Drawing.Point(0, 32);
            this.GL_Monitor.Name = "GL_Monitor";
            this.GL_Monitor.Size = new System.Drawing.Size(784, 514);
            this.GL_Monitor.TabIndex = 15;
            this.GL_Monitor.VSync = false;
            this.GL_Monitor.Load += new System.EventHandler(this.GL_Monitor_Load);
            this.GL_Monitor.DragDrop += new System.Windows.Forms.DragEventHandler(this.GL_Monitor_DragDrop);
            this.GL_Monitor.DragEnter += new System.Windows.Forms.DragEventHandler(this.GL_Monitor_DragEnter);
            this.GL_Monitor.Paint += new System.Windows.Forms.PaintEventHandler(this.GL_Monitor_Paint);
            // 
            // AppToolBarMStp
            // 
            this.AppToolBarMStp.AutoSize = false;
            this.AppToolBarMStp.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.AppToolBarMStp.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.AppToolBarMStp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AppToolBarMStp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolBarFileMenuBt,
            this.ToolBarHelpMenuBt});
            this.AppToolBarMStp.Location = new System.Drawing.Point(0, 0);
            this.AppToolBarMStp.Name = "AppToolBarMStp";
            this.AppToolBarMStp.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.AppToolBarMStp.Size = new System.Drawing.Size(784, 32);
            this.AppToolBarMStp.TabIndex = 16;
            this.AppToolBarMStp.Text = "AppToolBar";
            this.AppToolBarMStp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AppToolBarMStp_MouseDoubleClick);
            this.AppToolBarMStp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AppToolBarMStp_MouseDown);
            this.AppToolBarMStp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AppToolBarMStp_MouseUp);
            // 
            // ToolBarFileMenuBt
            // 
            this.ToolBarFileMenuBt.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ToolBarFileMenuBt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuImportBt,
            this.FileMenuExitBt});
            this.ToolBarFileMenuBt.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ToolBarFileMenuBt.Margin = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.ToolBarFileMenuBt.Name = "ToolBarFileMenuBt";
            this.ToolBarFileMenuBt.Size = new System.Drawing.Size(41, 28);
            this.ToolBarFileMenuBt.Text = "File";
            // 
            // FileMenuImportBt
            // 
            this.FileMenuImportBt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FileMenuImportBt.Name = "FileMenuImportBt";
            this.FileMenuImportBt.Size = new System.Drawing.Size(120, 24);
            this.FileMenuImportBt.Text = "Import";
            this.FileMenuImportBt.Click += new System.EventHandler(this.FileMenuImportBt_Click);
            // 
            // FileMenuExitBt
            // 
            this.FileMenuExitBt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FileMenuExitBt.Name = "FileMenuExitBt";
            this.FileMenuExitBt.Size = new System.Drawing.Size(120, 24);
            this.FileMenuExitBt.Text = "Exit";
            this.FileMenuExitBt.Click += new System.EventHandler(this.FileMenuExitBt_Click);
            // 
            // ToolBarHelpMenuBt
            // 
            this.ToolBarHelpMenuBt.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ToolBarHelpMenuBt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpMenuHowToUseBt,
            this.HelpMenuAboutBt});
            this.ToolBarHelpMenuBt.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.ToolBarHelpMenuBt.Name = "ToolBarHelpMenuBt";
            this.ToolBarHelpMenuBt.Size = new System.Drawing.Size(49, 28);
            this.ToolBarHelpMenuBt.Text = "Help";
            // 
            // HelpMenuHowToUseBt
            // 
            this.HelpMenuHowToUseBt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.HelpMenuHowToUseBt.Name = "HelpMenuHowToUseBt";
            this.HelpMenuHowToUseBt.Size = new System.Drawing.Size(150, 24);
            this.HelpMenuHowToUseBt.Text = "How to Use";
            this.HelpMenuHowToUseBt.Click += new System.EventHandler(this.HelpMenuHowToUseBt_Click);
            // 
            // HelpMenuAboutBt
            // 
            this.HelpMenuAboutBt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.HelpMenuAboutBt.Name = "HelpMenuAboutBt";
            this.HelpMenuAboutBt.Size = new System.Drawing.Size(150, 24);
            this.HelpMenuAboutBt.Text = "About";
            this.HelpMenuAboutBt.Click += new System.EventHandler(this.HelpMenuAboutBt_Click);
            // 
            // CloseBt
            // 
            this.CloseBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBt.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.CloseBt.FlatAppearance.BorderSize = 0;
            this.CloseBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CloseBt.ForeColor = System.Drawing.Color.Black;
            this.CloseBt.Location = new System.Drawing.Point(754, 0);
            this.CloseBt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CloseBt.Name = "CloseBt";
            this.CloseBt.Size = new System.Drawing.Size(30, 32);
            this.CloseBt.TabIndex = 18;
            this.CloseBt.Text = "X";
            this.CloseBt.UseVisualStyleBackColor = false;
            this.CloseBt.Click += new System.EventHandler(this.CloseBt_Click);
            // 
            // MinimizeBt
            // 
            this.MinimizeBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeBt.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.MinimizeBt.FlatAppearance.BorderSize = 0;
            this.MinimizeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MinimizeBt.ForeColor = System.Drawing.Color.Black;
            this.MinimizeBt.Location = new System.Drawing.Point(685, 0);
            this.MinimizeBt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimizeBt.Name = "MinimizeBt";
            this.MinimizeBt.Size = new System.Drawing.Size(30, 32);
            this.MinimizeBt.TabIndex = 19;
            this.MinimizeBt.Text = "-";
            this.MinimizeBt.UseVisualStyleBackColor = false;
            this.MinimizeBt.Click += new System.EventHandler(this.MinimizeBt_Click);
            // 
            // AppTitleSymbolPicBx
            // 
            this.AppTitleSymbolPicBx.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.AppTitleSymbolPicBx.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AppTitleSymbolPicBx.BackgroundImage")));
            this.AppTitleSymbolPicBx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AppTitleSymbolPicBx.ImageLocation = "";
            this.AppTitleSymbolPicBx.Location = new System.Drawing.Point(6, 4);
            this.AppTitleSymbolPicBx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AppTitleSymbolPicBx.Name = "AppTitleSymbolPicBx";
            this.AppTitleSymbolPicBx.Size = new System.Drawing.Size(22, 24);
            this.AppTitleSymbolPicBx.TabIndex = 20;
            this.AppTitleSymbolPicBx.TabStop = false;
            // 
            // MaximizeBt
            // 
            this.MaximizeBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximizeBt.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.MaximizeBt.FlatAppearance.BorderSize = 0;
            this.MaximizeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MaximizeBt.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBt.Location = new System.Drawing.Point(719, 0);
            this.MaximizeBt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBt.Name = "MaximizeBt";
            this.MaximizeBt.Size = new System.Drawing.Size(30, 32);
            this.MaximizeBt.TabIndex = 21;
            this.MaximizeBt.Text = "▭";
            this.MaximizeBt.UseVisualStyleBackColor = false;
            this.MaximizeBt.Click += new System.EventHandler(this.MaximizeBt_Click);
            // 
            // AppTitleLb
            // 
            this.AppTitleLb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AppTitleLb.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.AppTitleLb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AppTitleLb.Location = new System.Drawing.Point(300, 0);
            this.AppTitleLb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AppTitleLb.Name = "AppTitleLb";
            this.AppTitleLb.Size = new System.Drawing.Size(180, 32);
            this.AppTitleLb.TabIndex = 22;
            this.AppTitleLb.Text = "STL Viewer v2.4.5";
            this.AppTitleLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AppTitleLb.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AppTitleLb_MouseDoubleClick);
            this.AppTitleLb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AppTitleLb_MouseDown);
            this.AppTitleLb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AppTitleLb_MouseUp);
            // 
            // AppMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 546);
            this.Controls.Add(this.AppTitleLb);
            this.Controls.Add(this.MaximizeBt);
            this.Controls.Add(this.AppTitleSymbolPicBx);
            this.Controls.Add(this.MinimizeBt);
            this.Controls.Add(this.CloseBt);
            this.Controls.Add(this.GL_Monitor);
            this.Controls.Add(this.AppToolBarMStp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.AppToolBarMStp;
            this.Name = "AppMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STL Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AppToolBarMStp.ResumeLayout(false);
            this.AppToolBarMStp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppTitleSymbolPicBx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer DrawTimer;
        private OpenTK.GLControl GL_Monitor;
        private System.Windows.Forms.MenuStrip AppToolBarMStp;
        private System.Windows.Forms.ToolStripMenuItem ToolBarFileMenuBt;
        private System.Windows.Forms.ToolStripMenuItem FileMenuImportBt;
        private System.Windows.Forms.ToolStripMenuItem FileMenuExitBt;
        private System.Windows.Forms.Button CloseBt;
        private System.Windows.Forms.Button MinimizeBt;
        private System.Windows.Forms.PictureBox AppTitleSymbolPicBx;
        private System.Windows.Forms.Button MaximizeBt;
        private System.Windows.Forms.ToolStripMenuItem ToolBarHelpMenuBt;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuHowToUseBt;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuAboutBt;
        private System.Windows.Forms.Label AppTitleLb;
    }
}

