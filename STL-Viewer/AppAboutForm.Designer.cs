namespace STLViewer
{
    partial class AppAboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppAboutForm));
            this.AppLogoPicBx = new System.Windows.Forms.PictureBox();
            this.AppNameLb = new System.Windows.Forms.Label();
            this.AuthorEMailLb = new System.Windows.Forms.Label();
            this.AppVersionLb = new System.Windows.Forms.Label();
            this.AuthorTitleLb = new System.Windows.Forms.Label();
            this.CloseBt = new System.Windows.Forms.Button();
            this.AuthorNameLinkLb = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.AppLogoPicBx)).BeginInit();
            this.SuspendLayout();
            // 
            // AppLogoPicBx
            // 
            this.AppLogoPicBx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppLogoPicBx.BackgroundImage = global::STLViewer.Properties.Resources.stl_viewer_iconpng;
            this.AppLogoPicBx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AppLogoPicBx.Location = new System.Drawing.Point(196, 15);
            this.AppLogoPicBx.Name = "AppLogoPicBx";
            this.AppLogoPicBx.Size = new System.Drawing.Size(120, 120);
            this.AppLogoPicBx.TabIndex = 1;
            this.AppLogoPicBx.TabStop = false;
            // 
            // AppNameLb
            // 
            this.AppNameLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppNameLb.BackColor = System.Drawing.Color.Transparent;
            this.AppNameLb.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AppNameLb.ForeColor = System.Drawing.Color.Gainsboro;
            this.AppNameLb.Location = new System.Drawing.Point(186, 145);
            this.AppNameLb.Name = "AppNameLb";
            this.AppNameLb.Size = new System.Drawing.Size(139, 32);
            this.AppNameLb.TabIndex = 2;
            this.AppNameLb.Text = "STL Viewer";
            this.AppNameLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AuthorEMailLb
            // 
            this.AuthorEMailLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthorEMailLb.BackColor = System.Drawing.Color.Transparent;
            this.AuthorEMailLb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AuthorEMailLb.ForeColor = System.Drawing.Color.Gainsboro;
            this.AuthorEMailLb.Location = new System.Drawing.Point(122, 290);
            this.AuthorEMailLb.Name = "AuthorEMailLb";
            this.AuthorEMailLb.Size = new System.Drawing.Size(270, 28);
            this.AuthorEMailLb.TabIndex = 3;
            this.AuthorEMailLb.Text = "batuhan.kindan@gmail.com";
            this.AuthorEMailLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AppVersionLb
            // 
            this.AppVersionLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppVersionLb.BackColor = System.Drawing.Color.Transparent;
            this.AppVersionLb.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AppVersionLb.ForeColor = System.Drawing.Color.Gainsboro;
            this.AppVersionLb.Location = new System.Drawing.Point(173, 180);
            this.AppVersionLb.Name = "AppVersionLb";
            this.AppVersionLb.Size = new System.Drawing.Size(163, 32);
            this.AppVersionLb.TabIndex = 4;
            this.AppVersionLb.Text = "Version 2.4.5";
            this.AppVersionLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AuthorTitleLb
            // 
            this.AuthorTitleLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthorTitleLb.BackColor = System.Drawing.Color.Transparent;
            this.AuthorTitleLb.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AuthorTitleLb.ForeColor = System.Drawing.Color.Gainsboro;
            this.AuthorTitleLb.Location = new System.Drawing.Point(121, 230);
            this.AuthorTitleLb.Name = "AuthorTitleLb";
            this.AuthorTitleLb.Size = new System.Drawing.Size(270, 28);
            this.AuthorTitleLb.TabIndex = 5;
            this.AuthorTitleLb.Text = "Author";
            this.AuthorTitleLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CloseBt
            // 
            this.CloseBt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBt.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.CloseBt.FlatAppearance.BorderSize = 0;
            this.CloseBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBt.Location = new System.Drawing.Point(206, 335);
            this.CloseBt.Name = "CloseBt";
            this.CloseBt.Size = new System.Drawing.Size(100, 35);
            this.CloseBt.TabIndex = 6;
            this.CloseBt.Text = "Close";
            this.CloseBt.UseVisualStyleBackColor = false;
            this.CloseBt.Click += new System.EventHandler(this.CloseBt_Click);
            // 
            // AuthorNameLinkLb
            // 
            this.AuthorNameLinkLb.ActiveLinkColor = System.Drawing.Color.Gainsboro;
            this.AuthorNameLinkLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthorNameLinkLb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AuthorNameLinkLb.LinkColor = System.Drawing.Color.Gainsboro;
            this.AuthorNameLinkLb.Location = new System.Drawing.Point(122, 262);
            this.AuthorNameLinkLb.Name = "AuthorNameLinkLb";
            this.AuthorNameLinkLb.Size = new System.Drawing.Size(270, 28);
            this.AuthorNameLinkLb.TabIndex = 7;
            this.AuthorNameLinkLb.TabStop = true;
            this.AuthorNameLinkLb.Text = "Ali Batuhan KINDAN";
            this.AuthorNameLinkLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AuthorNameLinkLb.VisitedLinkColor = System.Drawing.Color.Gainsboro;
            // 
            // AppAboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(512, 384);
            this.Controls.Add(this.AuthorNameLinkLb);
            this.Controls.Add(this.CloseBt);
            this.Controls.Add(this.AuthorTitleLb);
            this.Controls.Add(this.AppVersionLb);
            this.Controls.Add(this.AuthorEMailLb);
            this.Controls.Add(this.AppNameLb);
            this.Controls.Add(this.AppLogoPicBx);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AppAboutForm";
            this.Text = "AppAboutForm";
            ((System.ComponentModel.ISupportInitialize)(this.AppLogoPicBx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox AppLogoPicBx;
        private System.Windows.Forms.Label AppNameLb;
        private System.Windows.Forms.Label AuthorEMailLb;
        private System.Windows.Forms.Label AppVersionLb;
        private System.Windows.Forms.Label AuthorTitleLb;
        private System.Windows.Forms.Button CloseBt;
        private System.Windows.Forms.LinkLabel AuthorNameLinkLb;
    }
}