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
            this.monitor = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.fileSelectBt = new System.Windows.Forms.Button();
            this.dosyaSecTxb = new System.Windows.Forms.TextBox();
            this.drawTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // monitor
            // 
            this.monitor.AccumBits = ((byte)(0));
            this.monitor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monitor.AutoCheckErrors = false;
            this.monitor.AutoFinish = false;
            this.monitor.AutoMakeCurrent = true;
            this.monitor.AutoSwapBuffers = true;
            this.monitor.BackColor = System.Drawing.Color.Black;
            this.monitor.ColorBits = ((byte)(32));
            this.monitor.DepthBits = ((byte)(16));
            this.monitor.Location = new System.Drawing.Point(12, 12);
            this.monitor.Name = "monitor";
            this.monitor.Size = new System.Drawing.Size(760, 480);
            this.monitor.StencilBits = ((byte)(0));
            this.monitor.TabIndex = 0;
            // 
            // fileSelectBt
            // 
            this.fileSelectBt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fileSelectBt.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.fileSelectBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fileSelectBt.Location = new System.Drawing.Point(12, 498);
            this.fileSelectBt.Name = "fileSelectBt";
            this.fileSelectBt.Size = new System.Drawing.Size(115, 36);
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
            this.dosyaSecTxb.Location = new System.Drawing.Point(133, 498);
            this.dosyaSecTxb.Multiline = true;
            this.dosyaSecTxb.Name = "dosyaSecTxb";
            this.dosyaSecTxb.Size = new System.Drawing.Size(161, 36);
            this.dosyaSecTxb.TabIndex = 14;
            // 
            // drawTimer
            // 
            this.drawTimer.Interval = 25;
            this.drawTimer.Tick += new System.EventHandler(this.drawTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 546);
            this.Controls.Add(this.dosyaSecTxb);
            this.Controls.Add(this.fileSelectBt);
            this.Controls.Add(this.monitor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Triangle Mesh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl monitor;
        private System.Windows.Forms.Button fileSelectBt;
        private System.Windows.Forms.TextBox dosyaSecTxb;
        private System.Windows.Forms.Timer drawTimer;
    }
}

