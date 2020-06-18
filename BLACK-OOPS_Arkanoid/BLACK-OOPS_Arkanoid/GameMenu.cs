using System;
using System.Windows.Forms;

namespace BLACK_OOPS_Arkanoid
{
    public partial class GameMenu : Form
    {
        
        public GameMenu()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Hide();
            new NicknameReg().Show();
        }
    }
}