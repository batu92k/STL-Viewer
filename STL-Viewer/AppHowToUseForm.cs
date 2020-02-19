/**
  ******************************************************************************
  * @file    AppHowToUseForm.cs
  * @author  Ali Batuhan KINDAN
  * @date    19.02.2020
  * @brief   This file is contains the functionality of application How to Use window
  ******************************************************************************
  */

using System;
using System.Windows.Forms;

namespace STLViewer
{
    public partial class AppHowToUseForm : Form
    {
        public AppHowToUseForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void CloseBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
