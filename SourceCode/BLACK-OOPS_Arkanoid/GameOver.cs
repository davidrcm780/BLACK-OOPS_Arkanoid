using System;
using System.Windows.Forms;

namespace BLACK_OOPS_Arkanoid
{
    public partial class GameOver : Form
    {
        private int wol;
        private int Score;
        public GameOver(int x, int score)
        {
            InitializeComponent();
            wol = x;
            Score = score;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new GameMenu().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            if (wol == 0)
            {
                label1.Text = "GAME OVER :(";
            }
            else if (wol == 1)
            {
                label1.Text = "CONGRATULATIONS :)!!";
            }

            label3.Text = Score.ToString();
        }
    }
}