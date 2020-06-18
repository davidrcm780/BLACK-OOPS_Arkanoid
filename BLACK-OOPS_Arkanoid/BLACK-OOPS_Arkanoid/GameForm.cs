using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BLACK_OOPS_Arkanoid
{
    public partial class GameForm : Form
    {
        //BALL SPEED
        public int speedX = 5; 
        public int speedY = 4;
        //POINTS SCORED
        public int point = 0;

        private CustomPictureBox[,] cpb;
        
        public GameForm()
        {
            InitializeComponent();
            
            DoubleBuffered = true;
            
            timer1.Enabled = true;
            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None;     //REMOVES ANY BORDER
            this.TopMost = true;                             //BRINGS THE FORM TO THE FRONT
            this.Bounds = Screen.PrimaryScreen.Bounds;       //MAKES IT FULL SCREEN

            player.Top = playground.Bottom - (playground.Bottom / 10);    //SETS PLAYER POSITION

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player.Left = Cursor.Position.X - (player.Width / 2);    //THIS CENTERS THE PLAYER AROUND THE CURSOR
            
            //BALL MOVEMENT
            ball.Left += speedX;
            ball.Top += speedY;
            
            //COLLISION OF BALL AND PLAYER
            if (ball.Bottom >= player.Top && ball.Bottom <= player.Bottom && ball.Left >= player.Left && ball.Right <= player.Right)
            {
                //speed_top += 2;
                //speed_left += 2;
                speedY = -speedY; //DIRECTION CHANGE
                point += 1; //TO SAVE SCORE
            }
            
            //COLLISIONS OF BALL AND PLAYGROUND
            if (ball.Left <= playground.Left)
            {
                speedX = -speedX;
            }

            if (ball.Right >= playground.Right)
            {
                speedX = -speedX;
            }

            if (ball.Top <= playground.Top)
            {
                speedY = -speedY;
            }

            if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;     //BALL IS OUT SO GAME STOPS
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();                //ESC TO QUIT
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void LoadTiles()
        {
            int xAxis = 10;
            int yAxis = 5;
            
            cpb = new CustomPictureBox[yAxis,xAxis];
        }
    }
}