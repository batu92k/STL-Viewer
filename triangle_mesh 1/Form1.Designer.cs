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
            this.dosyaSecTxb = new System.Windows.Forms.TextBox();
            this.drawTimer = new System.Windows.Forms.Timer(this.components);
            this.GL_Monitor = new OpenTK.GLControl();
            this.SuspendLayout();
            // 
            // fileSelectBt
            // 
            this.fileSelectBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fileSelectBt.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.fileSelectBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fileSelectBt.Location = new System.Drawing.Point(16, 613);
            this.fileSelectBt.Margin = new System.Windows.Forms.Padding(4);
            this.fileSelectBt.Name = "fileSelectBt";
            this.fileSelectBt.Size = new System.Drawing.Size(153, 44);
            this.fileSelectBt.TabIndex = 13;
            this.fileSelectBt.Text = "Select Stl File";
            this.fileSelectBt.UseVisualStyleBackColor = false;
            this.fileSelectBt.Click += new System.EventHandler(this.fileSelectBt_Click);
            // 
            // dosyaSecTxb
            // 
            this.dosyaSecTxb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dosyaSecTxb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dosyaSecTxb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dosyaSecTxb.Location = new System.Drawing.Point(177, 613);
            this.dosyaSecTxb.Margin = new System.Windows.Forms.Padding(4);
            this.dosyaSecTxb.Multiline = true;
            this.dosyaSecTxb.Name = "dosyaSecTxb";
            this.dosyaSecTxb.Size = new System.Drawing.Size(214, 44);
            this.dosyaSecTxb.TabIndex = 14;
            // 
            // drawTimer
            // 
            this.drawTimer.Interval = 25;
            this.drawTimer.Tick += new System.EventHandler(this.drawTimer_Tick);
            // 
            // GL_Monitor
            // 
            this.GL_Monitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GL_Monitor.BackColor = System.Drawing.Color.Black;
            this.GL_Monitor.Location = new System.Drawing.Point(13, 13);
            this.GL_Monitor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GL_Monitor.Name = "GL_Monitor";
            this.GL_Monitor.Size = new System.Drawing.Size(1019, 592);
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
            this.Controls.Add(this.dosyaSecTxb);
            this.Controls.Add(this.fileSelectBt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STL Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button fileSelectBt;
        private System.Windows.Forms.TextBox dosyaSecTxb;
        private System.Windows.Forms.Timer drawTimer;
        private OpenTK.GLControl GL_Monitor;
    }
}

