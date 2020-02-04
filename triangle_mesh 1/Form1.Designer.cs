namespace triangle_mesh_1
{
    partial class Form1
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
            this.fileSelectBt = new System.Windows.Forms.Button();
            this.drawTimer = new System.Windows.Forms.Timer(this.components);
            this.GL_Monitor = new OpenTK.GLControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // fileSelectBt
            // 
            this.fileSelectBt.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.fileSelectBt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileSelectBt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fileSelectBt.Location = new System.Drawing.Point(0, 628);
            this.fileSelectBt.Margin = new System.Windows.Forms.Padding(4);
            this.fileSelectBt.Name = "fileSelectBt";
            this.fileSelectBt.Size = new System.Drawing.Size(1045, 44);
            this.fileSelectBt.TabIndex = 13;
            this.fileSelectBt.Text = "Select STL File";
            this.fileSelectBt.UseVisualStyleBackColor = false;
            this.fileSelectBt.Click += new System.EventHandler(this.fileSelectBt_Click);
            // 
            // drawTimer
            // 
            this.drawTimer.Interval = 25;
            this.drawTimer.Tick += new System.EventHandler(this.drawTimer_Tick);
            // 
            // GL_Monitor
            // 
            this.GL_Monitor.BackColor = System.Drawing.Color.Black;
            this.GL_Monitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GL_Monitor.Location = new System.Drawing.Point(0, 0);
            this.GL_Monitor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GL_Monitor.Name = "GL_Monitor";
            this.GL_Monitor.Size = new System.Drawing.Size(1045, 628);
            this.GL_Monitor.TabIndex = 15;
            this.GL_Monitor.VSync = false;
            this.GL_Monitor.Load += new System.EventHandler(this.GL_Monitor_Load);
            this.GL_Monitor.Paint += new System.Windows.Forms.PaintEventHandler(this.GL_Monitor_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 672);
            this.Controls.Add(this.GL_Monitor);
            this.Controls.Add(this.fileSelectBt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STL Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button fileSelectBt;
        private System.Windows.Forms.Timer drawTimer;
        private OpenTK.GLControl GL_Monitor;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

