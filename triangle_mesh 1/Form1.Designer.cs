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
            this.simEkran = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.rotXBt = new System.Windows.Forms.Button();
            this.rotZBt = new System.Windows.Forms.Button();
            this.rotXeksiBt = new System.Windows.Forms.Button();
            this.rotZeksiBt = new System.Windows.Forms.Button();
            this.zoomoutBt = new System.Windows.Forms.Button();
            this.zoominBt = new System.Windows.Forms.Button();
            this.timerA = new System.Windows.Forms.Timer(this.components);
            this.timerD = new System.Windows.Forms.Timer(this.components);
            this.timerW = new System.Windows.Forms.Timer(this.components);
            this.timerS = new System.Windows.Forms.Timer(this.components);
            this.rotYBt = new System.Windows.Forms.Button();
            this.rotYeksiBt = new System.Windows.Forms.Button();
            this.timerQ = new System.Windows.Forms.Timer(this.components);
            this.timerE = new System.Windows.Forms.Timer(this.components);
            this.timerArti = new System.Windows.Forms.Timer(this.components);
            this.timerEksi = new System.Windows.Forms.Timer(this.components);
            this.panLeftBt = new System.Windows.Forms.Button();
            this.PanRightBt = new System.Windows.Forms.Button();
            this.PanUpBt = new System.Windows.Forms.Button();
            this.PanDownBt = new System.Windows.Forms.Button();
            this.dosyaSecBt = new System.Windows.Forms.Button();
            this.dosyaSecTxb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // simEkran
            // 
            this.simEkran.AccumBits = ((byte)(0));
            this.simEkran.AutoCheckErrors = false;
            this.simEkran.AutoFinish = false;
            this.simEkran.AutoMakeCurrent = true;
            this.simEkran.AutoSwapBuffers = true;
            this.simEkran.BackColor = System.Drawing.Color.Black;
            this.simEkran.ColorBits = ((byte)(32));
            this.simEkran.DepthBits = ((byte)(16));
            this.simEkran.Location = new System.Drawing.Point(12, 12);
            this.simEkran.Name = "simEkran";
            this.simEkran.Size = new System.Drawing.Size(640, 480);
            this.simEkran.StencilBits = ((byte)(0));
            this.simEkran.TabIndex = 0;
            this.simEkran.KeyDown += new System.Windows.Forms.KeyEventHandler(this.simEkran_KeyDown);
            this.simEkran.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.simEkran_KeyPress);
            this.simEkran.KeyUp += new System.Windows.Forms.KeyEventHandler(this.simEkran_KeyUp);
            // 
            // rotXBt
            // 
            this.rotXBt.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rotXBt.Location = new System.Drawing.Point(724, 376);
            this.rotXBt.Name = "rotXBt";
            this.rotXBt.Size = new System.Drawing.Size(51, 38);
            this.rotXBt.TabIndex = 1;
            this.rotXBt.Text = "RotX+";
            this.rotXBt.UseVisualStyleBackColor = false;
            this.rotXBt.Click += new System.EventHandler(this.rotXBt_Click);
            // 
            // rotZBt
            // 
            this.rotZBt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.rotZBt.Location = new System.Drawing.Point(667, 449);
            this.rotZBt.Name = "rotZBt";
            this.rotZBt.Size = new System.Drawing.Size(51, 38);
            this.rotZBt.TabIndex = 2;
            this.rotZBt.Text = "RotZ+";
            this.rotZBt.UseVisualStyleBackColor = false;
            this.rotZBt.Click += new System.EventHandler(this.rotZBt_Click);
            // 
            // rotXeksiBt
            // 
            this.rotXeksiBt.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rotXeksiBt.Location = new System.Drawing.Point(724, 420);
            this.rotXeksiBt.Name = "rotXeksiBt";
            this.rotXeksiBt.Size = new System.Drawing.Size(51, 38);
            this.rotXeksiBt.TabIndex = 3;
            this.rotXeksiBt.Text = "RotX-";
            this.rotXeksiBt.UseVisualStyleBackColor = false;
            this.rotXeksiBt.Click += new System.EventHandler(this.rotXeksiBt_Click);
            // 
            // rotZeksiBt
            // 
            this.rotZeksiBt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.rotZeksiBt.Location = new System.Drawing.Point(781, 449);
            this.rotZeksiBt.Name = "rotZeksiBt";
            this.rotZeksiBt.Size = new System.Drawing.Size(51, 38);
            this.rotZeksiBt.TabIndex = 4;
            this.rotZeksiBt.Text = "RotZ-";
            this.rotZeksiBt.UseVisualStyleBackColor = false;
            this.rotZeksiBt.Click += new System.EventHandler(this.rotZeksiBt_Click);
            // 
            // zoomoutBt
            // 
            this.zoomoutBt.BackColor = System.Drawing.Color.Tomato;
            this.zoomoutBt.Location = new System.Drawing.Point(781, 359);
            this.zoomoutBt.Name = "zoomoutBt";
            this.zoomoutBt.Size = new System.Drawing.Size(51, 38);
            this.zoomoutBt.TabIndex = 5;
            this.zoomoutBt.Text = "Zoom  (-)";
            this.zoomoutBt.UseVisualStyleBackColor = false;
            this.zoomoutBt.Click += new System.EventHandler(this.zoomoutBt_Click);
            // 
            // zoominBt
            // 
            this.zoominBt.BackColor = System.Drawing.Color.Tomato;
            this.zoominBt.Location = new System.Drawing.Point(667, 359);
            this.zoominBt.Name = "zoominBt";
            this.zoominBt.Size = new System.Drawing.Size(51, 40);
            this.zoominBt.TabIndex = 6;
            this.zoominBt.Text = "Zoom  (+)";
            this.zoominBt.UseVisualStyleBackColor = false;
            this.zoominBt.Click += new System.EventHandler(this.zoominBt_Click);
            // 
            // timerA
            // 
            this.timerA.Interval = 10;
            this.timerA.Tick += new System.EventHandler(this.timerA_Tick);
            // 
            // timerD
            // 
            this.timerD.Interval = 10;
            this.timerD.Tick += new System.EventHandler(this.timerD_Tick);
            // 
            // timerW
            // 
            this.timerW.Interval = 10;
            this.timerW.Tick += new System.EventHandler(this.timerW_Tick);
            // 
            // timerS
            // 
            this.timerS.Interval = 10;
            this.timerS.Tick += new System.EventHandler(this.timerS_Tick);
            // 
            // rotYBt
            // 
            this.rotYBt.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rotYBt.Location = new System.Drawing.Point(667, 405);
            this.rotYBt.Name = "rotYBt";
            this.rotYBt.Size = new System.Drawing.Size(51, 38);
            this.rotYBt.TabIndex = 7;
            this.rotYBt.Text = "RotY+";
            this.rotYBt.UseVisualStyleBackColor = false;
            this.rotYBt.Click += new System.EventHandler(this.rotYBt_Click);
            // 
            // rotYeksiBt
            // 
            this.rotYeksiBt.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rotYeksiBt.Location = new System.Drawing.Point(781, 405);
            this.rotYeksiBt.Name = "rotYeksiBt";
            this.rotYeksiBt.Size = new System.Drawing.Size(51, 38);
            this.rotYeksiBt.TabIndex = 8;
            this.rotYeksiBt.Text = "RotY-";
            this.rotYeksiBt.UseVisualStyleBackColor = false;
            this.rotYeksiBt.Click += new System.EventHandler(this.rotYeksiBt_Click);
            // 
            // timerQ
            // 
            this.timerQ.Interval = 10;
            this.timerQ.Tick += new System.EventHandler(this.timerQ_Tick);
            // 
            // timerE
            // 
            this.timerE.Interval = 10;
            this.timerE.Tick += new System.EventHandler(this.timerE_Tick);
            // 
            // timerArti
            // 
            this.timerArti.Interval = 10;
            this.timerArti.Tick += new System.EventHandler(this.timerArti_Tick);
            // 
            // timerEksi
            // 
            this.timerEksi.Interval = 10;
            this.timerEksi.Tick += new System.EventHandler(this.timerEksi_Tick);
            // 
            // panLeftBt
            // 
            this.panLeftBt.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panLeftBt.Location = new System.Drawing.Point(667, 296);
            this.panLeftBt.Name = "panLeftBt";
            this.panLeftBt.Size = new System.Drawing.Size(51, 40);
            this.panLeftBt.TabIndex = 9;
            this.panLeftBt.Text = "Pan  Left";
            this.panLeftBt.UseVisualStyleBackColor = false;
            this.panLeftBt.Click += new System.EventHandler(this.panLeftBt_Click);
            // 
            // PanRightBt
            // 
            this.PanRightBt.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PanRightBt.Location = new System.Drawing.Point(781, 296);
            this.PanRightBt.Name = "PanRightBt";
            this.PanRightBt.Size = new System.Drawing.Size(51, 40);
            this.PanRightBt.TabIndex = 10;
            this.PanRightBt.Text = "Pan  Right";
            this.PanRightBt.UseVisualStyleBackColor = false;
            this.PanRightBt.Click += new System.EventHandler(this.PanRightBt_Click);
            // 
            // PanUpBt
            // 
            this.PanUpBt.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PanUpBt.Location = new System.Drawing.Point(724, 275);
            this.PanUpBt.Name = "PanUpBt";
            this.PanUpBt.Size = new System.Drawing.Size(51, 40);
            this.PanUpBt.TabIndex = 11;
            this.PanUpBt.Text = "Pan   Up";
            this.PanUpBt.UseVisualStyleBackColor = false;
            this.PanUpBt.Click += new System.EventHandler(this.PanUpBt_Click);
            // 
            // PanDownBt
            // 
            this.PanDownBt.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PanDownBt.Location = new System.Drawing.Point(724, 321);
            this.PanDownBt.Name = "PanDownBt";
            this.PanDownBt.Size = new System.Drawing.Size(51, 40);
            this.PanDownBt.TabIndex = 12;
            this.PanDownBt.Text = "Pan  Down";
            this.PanDownBt.UseVisualStyleBackColor = false;
            this.PanDownBt.Click += new System.EventHandler(this.PanDownBt_Click);
            // 
            // dosyaSecBt
            // 
            this.dosyaSecBt.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.dosyaSecBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dosyaSecBt.Location = new System.Drawing.Point(12, 498);
            this.dosyaSecBt.Name = "dosyaSecBt";
            this.dosyaSecBt.Size = new System.Drawing.Size(115, 27);
            this.dosyaSecBt.TabIndex = 13;
            this.dosyaSecBt.Text = "Select Stl File";
            this.dosyaSecBt.UseVisualStyleBackColor = false;
            this.dosyaSecBt.Click += new System.EventHandler(this.dosyaSecBt_Click);
            // 
            // dosyaSecTxb
            // 
            this.dosyaSecTxb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dosyaSecTxb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dosyaSecTxb.Location = new System.Drawing.Point(133, 498);
            this.dosyaSecTxb.Multiline = true;
            this.dosyaSecTxb.Name = "dosyaSecTxb";
            this.dosyaSecTxb.Size = new System.Drawing.Size(161, 27);
            this.dosyaSecTxb.TabIndex = 14;
            this.dosyaSecTxb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dosyaSecTxb_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 531);
            this.Controls.Add(this.dosyaSecTxb);
            this.Controls.Add(this.dosyaSecBt);
            this.Controls.Add(this.PanDownBt);
            this.Controls.Add(this.PanUpBt);
            this.Controls.Add(this.PanRightBt);
            this.Controls.Add(this.panLeftBt);
            this.Controls.Add(this.rotYeksiBt);
            this.Controls.Add(this.rotYBt);
            this.Controls.Add(this.zoominBt);
            this.Controls.Add(this.zoomoutBt);
            this.Controls.Add(this.rotZeksiBt);
            this.Controls.Add(this.rotXeksiBt);
            this.Controls.Add(this.rotZBt);
            this.Controls.Add(this.rotXBt);
            this.Controls.Add(this.simEkran);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Triangle Mesh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simEkran;
        private System.Windows.Forms.Button rotXBt;
        private System.Windows.Forms.Button rotZBt;
        private System.Windows.Forms.Button rotXeksiBt;
        private System.Windows.Forms.Button rotZeksiBt;
        private System.Windows.Forms.Button zoomoutBt;
        private System.Windows.Forms.Button zoominBt;
        private System.Windows.Forms.Timer timerA;
        private System.Windows.Forms.Timer timerD;
        private System.Windows.Forms.Timer timerW;
        private System.Windows.Forms.Timer timerS;
        private System.Windows.Forms.Button rotYBt;
        private System.Windows.Forms.Button rotYeksiBt;
        private System.Windows.Forms.Timer timerQ;
        private System.Windows.Forms.Timer timerE;
        private System.Windows.Forms.Timer timerArti;
        private System.Windows.Forms.Timer timerEksi;
        private System.Windows.Forms.Button panLeftBt;
        private System.Windows.Forms.Button PanRightBt;
        private System.Windows.Forms.Button PanUpBt;
        private System.Windows.Forms.Button PanDownBt;
        private System.Windows.Forms.Button dosyaSecBt;
        private System.Windows.Forms.TextBox dosyaSecTxb;
    }
}

