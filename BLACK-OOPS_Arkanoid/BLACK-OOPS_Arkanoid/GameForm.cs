using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public int speedY = -4;
        //POINTS SCORED
        public int point = 0;

        private CustomPictureBox[,] cpb;

        public GameForm()
        {
            
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            
            DoubleBuffered = true;
            
            timer1.Enabled = true;
            Cursor.Hide();

            FormBorderStyle = FormBorderStyle.None;     //REMOVES ANY BORDER
            TopMost = true;                             //BRINGS THE FORM TO THE FRONT
            Bounds = Screen.PrimaryScreen.Bounds;       //MAKES IT FULL SCREEN

            //SETS PLAYER POSITION
            player.Top = playground.Bottom - (playground.Bottom / 10);    
            player.Left = (playground.Width / 2) - (player.Width/2);
            
            //SETS THE BALL POSITION
            ball.Top = player.Top - ball.Height;
            ball.Left = player.Left + (player.Width / 2) - (ball.Width / 2);
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
                Close();                //ESC TO QUIT
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            LoadTiles();
        }

        private void LoadTiles()
        {
            int xAxis = 10;
            int yAxis = 5;

            int pbHeight = (int)(Height * 0.3) / yAxis;
            int pbWidth = (Width - (xAxis - 5)) / xAxis;
            
            cpb = new CustomPictureBox[yAxis,xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    cpb[i,j] = new CustomPictureBox();

                    if (i == 0)
                        cpb[i, j].Golpes = 2;
                    else
                        cpb[i, j].Golpes = 1;
                    

                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth;
                    
                    //POSICION DE LEFT Y TOP

                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight;

                    cpb[i, j].BackgroundImage = Image.FromFile("../../Img/" + (i+1) + ".png");    
                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch; 

                    cpb[i, j].Tag = "tileTag";
                    
                    //Controls.Add(cpb[i,j]);
                    playground.Controls.Add(cpb[i,j]);
                    
                }
            }
        }
    }
}