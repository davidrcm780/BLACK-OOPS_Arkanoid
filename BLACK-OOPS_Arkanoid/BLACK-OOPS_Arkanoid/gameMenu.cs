﻿using System;
using System.Windows.Forms;

namespace BLACK_OOPS_Arkanoid
{
    public partial class gameMenu : Form
    {
        
        public gameMenu()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Hide();
            new nicknameReg().Show();
        }
    }
}