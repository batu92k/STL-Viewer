/**
  ******************************************************************************
  * @file    AppAboutForm.cs
  * @author  Ali Batuhan KINDAN
  * @date    19.02.2020
  * @brief   This file is contains the functionality of application About window
  ******************************************************************************
  */

using System;
using System.Windows.Forms;

namespace STLViewer
{
    public partial class AppAboutForm : Form
    {
        public AppAboutForm()
        {
            InitializeComponent();
            CenterToScreen(); // open center of the screen
            AuthorNameLinkLb.LinkArea = new LinkArea(0, 22);
            AuthorNameLinkLb.Links.Add(24, 9, "https://github.com/batu92k");
            AuthorNameLinkLb.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkedLabelClicked);
        }

        private void CloseBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkedLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AuthorNameLinkLb.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/batu92k");
        }
    }
}
