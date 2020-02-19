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
            this.CloseBt = new System.Windows.Forms.Button();
            this.MinimizeBt = new System.Windows.Forms.Button();
            this.AppTitleSymbolPicBx = new System.Windows.Forms.PictureBox();
            this.MaximizeBt = new System.Windows.Forms.Button();
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
            this.GL_Monitor.BackColor = System.Drawing.Color.Black;
            this.GL_Monitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GL_Monitor.Location = new System.Drawing.Point(0, 40);
            this.GL_Monitor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GL_Monitor.Name = "GL_Monitor";
            this.GL_Monitor.Size = new System.Drawing.Size(1045, 632);
            this.GL_Monitor.TabIndex = 15;
            this.GL_Monitor.VSync = false;
            this.GL_Monitor.Load += new System.EventHandler(this.GL_Monitor_Load);
            this.GL_Monitor.Paint += new System.Windows.Forms.PaintEventHandler(this.GL_Monitor_Paint);
            // 
            // AppToolBarMStp
            // 
            this.AppToolBarMStp.AutoSize = false;
            this.AppToolBarMStp.BackColor = System.Drawing.Color.Firebrick;
            this.AppToolBarMStp.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.AppToolBarMStp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AppToolBarMStp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolBarFileMenuBt});
            this.AppToolBarMStp.Location = new System.Drawing.Point(0, 0);
            this.AppToolBarMStp.Name = "AppToolBarMStp";
            this.AppToolBarMStp.Size = new System.Drawing.Size(1045, 40);
            this.AppToolBarMStp.TabIndex = 16;
            this.AppToolBarMStp.Text = "AppToolBar";
            this.AppToolBarMStp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AppToolBarMStp_MouseDoubleClick);
            this.AppToolBarMStp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AppToolBarMStp_MouseDown);
            this.AppToolBarMStp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AppToolBarMStp_MouseUp);
            // 
            // ToolBarFileMenuBt
            // 
            this.ToolBarFileMenuBt.BackColor = System.Drawing.Color.Firebrick;
            this.ToolBarFileMenuBt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuImportBt,
            this.FileMenuExitBt});
            this.ToolBarFileMenuBt.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ToolBarFileMenuBt.Margin = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.ToolBarFileMenuBt.Name = "ToolBarFileMenuBt";
            this.ToolBarFileMenuBt.Size = new System.Drawing.Size(49, 36);
            this.ToolBarFileMenuBt.Text = "File";
            // 
            // FileMenuImportBt
            // 
            this.FileMenuImportBt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FileMenuImportBt.Name = "FileMenuImportBt";
            this.FileMenuImportBt.Size = new System.Drawing.Size(224, 28);
            this.FileMenuImportBt.Text = "Import";
            this.FileMenuImportBt.Click += new System.EventHandler(this.FileMenuImportBt_Click);
            // 
            // FileMenuExitBt
            // 
            this.FileMenuExitBt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FileMenuExitBt.Name = "FileMenuExitBt";
            this.FileMenuExitBt.Size = new System.Drawing.Size(224, 28);
            this.FileMenuExitBt.Text = "Exit";
            this.FileMenuExitBt.Click += new System.EventHandler(this.FileMenuExitBt_Click);
            // 
            // CloseBt
            // 
            this.CloseBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBt.BackColor = System.Drawing.Color.Firebrick;
            this.CloseBt.FlatAppearance.BorderSize = 0;
            this.CloseBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CloseBt.ForeColor = System.Drawing.Color.Black;
            this.CloseBt.Location = new System.Drawing.Point(1005, 0);
            this.CloseBt.Name = "CloseBt";
            this.CloseBt.Size = new System.Drawing.Size(40, 40);
            this.CloseBt.TabIndex = 18;
            this.CloseBt.Text = "X";
            this.CloseBt.UseVisualStyleBackColor = false;
            this.CloseBt.Click += new System.EventHandler(this.CloseBt_Click);
            // 
            // MinimizeBt
            // 
            this.MinimizeBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeBt.BackColor = System.Drawing.Color.Firebrick;
            this.MinimizeBt.FlatAppearance.BorderSize = 0;
            this.MinimizeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MinimizeBt.ForeColor = System.Drawing.Color.Black;
            this.MinimizeBt.Location = new System.Drawing.Point(913, 0);
            this.MinimizeBt.Name = "MinimizeBt";
            this.MinimizeBt.Size = new System.Drawing.Size(40, 40);
            this.MinimizeBt.TabIndex = 19;
            this.MinimizeBt.Text = "-";
            this.MinimizeBt.UseVisualStyleBackColor = false;
            this.MinimizeBt.Click += new System.EventHandler(this.MinimizeBt_Click);
            // 
            // AppTitleSymbolPicBx
            // 
            this.AppTitleSymbolPicBx.BackColor = System.Drawing.Color.Firebrick;
            this.AppTitleSymbolPicBx.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AppTitleSymbolPicBx.BackgroundImage")));
            this.AppTitleSymbolPicBx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AppTitleSymbolPicBx.ImageLocation = "";
            this.AppTitleSymbolPicBx.Location = new System.Drawing.Point(8, 5);
            this.AppTitleSymbolPicBx.Name = "AppTitleSymbolPicBx";
            this.AppTitleSymbolPicBx.Size = new System.Drawing.Size(30, 30);
            this.AppTitleSymbolPicBx.TabIndex = 20;
            this.AppTitleSymbolPicBx.TabStop = false;
            // 
            // MaximizeBt
            // 
            this.MaximizeBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximizeBt.BackColor = System.Drawing.Color.Firebrick;
            this.MaximizeBt.FlatAppearance.BorderSize = 0;
            this.MaximizeBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MaximizeBt.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBt.Location = new System.Drawing.Point(959, 0);
            this.MaximizeBt.Name = "MaximizeBt";
            this.MaximizeBt.Size = new System.Drawing.Size(40, 40);
            this.MaximizeBt.TabIndex = 21;
            this.MaximizeBt.Text = "▭";
            this.MaximizeBt.UseVisualStyleBackColor = false;
            this.MaximizeBt.Click += new System.EventHandler(this.MaximizeBt_Click);
            // 
            // AppMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 672);
            this.Controls.Add(this.MaximizeBt);
            this.Controls.Add(this.AppTitleSymbolPicBx);
            this.Controls.Add(this.MinimizeBt);
            this.Controls.Add(this.CloseBt);
            this.Controls.Add(this.GL_Monitor);
            this.Controls.Add(this.AppToolBarMStp);
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
    }
}

