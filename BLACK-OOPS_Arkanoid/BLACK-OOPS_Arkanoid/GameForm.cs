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
        public int speedX = 0; 
        public int speedY = 0;
        //POINTS SCORED
        public int point = 0;

        private int remainingPb = 0;
        
        private Label remainingLifes, score;
        public Action FinishGame, WinningGame;



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

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //player.Left = Cursor.Position.X - (player.Width / 2);    //THIS CENTERS THE PLAYER AROUND THE CURSOR
            
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
            
            // Rutina de colisiones con cpb
            for (int i = 5; i >= 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (cpb[i, j] != null && ball.Bounds.IntersectsWith(cpb[i, j].Bounds))
                    {   
                        //GameData.score += (int)(cpb[i, j].Hits * GameData.ticksCount);
                        cpb[i, j].Hits--;

                        if (cpb[i, j].Hits == 0)
                        {
                            playground.Controls.Remove(cpb[i, j]);
                            cpb[i, j] = null;

                            //remainingPb--;
                        }
                        else if(cpb[i, j].Tag.Equals("blinded"))
                            cpb[i, j].BackgroundImage = Image.FromFile("../../Img/11.png");

                        speedY = -speedY;

                        //score.Text = GameData.score.ToString();
                        /*
                        if (remainingPb == 0)
                            WinningGame?.Invoke();
                        */
                        return;
                    }
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                GameData.gameStarted = true;
                //BALL SPEED
                speedX = 5; 
                speedY = -4;
            }

            if (e.KeyCode == Keys.Escape)
                Close();                //ESC TO QUIT
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            //playground.BackgroundImage = Image.FromFile("../../Img/GameBackground.png");
            //playground.BackgroundImageLayout = ImageLayout.Stretch;
            LoadTiles();
        }

        private void LoadTiles()
        {
            int xAxis = 10;
            int yAxis = 6;

            int pbHeight = (int)(Height * 0.3) / yAxis;
            int pbWidth = (Width - xAxis) / xAxis;
            
            cpb = new CustomPictureBox[yAxis,xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    cpb[i,j] = new CustomPictureBox();

                    
                    

                    cpb[i, j].Height = pbHeight;
                    cpb[i, j].Width = pbWidth; 
                    
                    //POSICION DE LEFT Y TOP

                    cpb[i, j].Left = j * pbWidth;
                    cpb[i, j].Top = i * pbHeight;
                    if (i == 5)
                    {
                        cpb[i, j].BackgroundImage = Image.FromFile("../../Img/12.png");
                        cpb[i, j].Tag = "blinded";
                        cpb[i, j].Hits = 2;
                    }
                    else
                    {
                        cpb[i, j].BackgroundImage = Image.FromFile("../../Img/" + (i+1) + ".png");
                        cpb[i, j].Tag = "tileTag";
                        cpb[i, j].Hits = 1;
                    }
                        
                    cpb[i, j].BackgroundImageLayout = ImageLayout.Stretch; 
                    
                    //Controls.Add(cpb[i,j]);
                    playground.Controls.Add(cpb[i,j]);
                    
                }
            }
        }

        private void playground_MouseMove(object sender, MouseEventArgs e)
        {
            player.Left = e.X - (player.Width/2);
            
            if (GameData.gameStarted == false)
            {
                ball.Top = player.Top - ball.Height;
                ball.Left = player.Left + (player.Width / 2) - (ball.Width / 2);
            }
        }
    }
}