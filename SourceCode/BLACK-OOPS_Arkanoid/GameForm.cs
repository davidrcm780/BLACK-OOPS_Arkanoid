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
using BLACK_OOPS_Arkanoid.Exceptions;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace BLACK_OOPS_Arkanoid
{
    public partial class GameForm : Form
    {
        //BALL SPEED
        public int speedX = 0; 
        public int speedY = 0;
        //POINTS SCORED


        private Panel hud;
        private PictureBox heart, heart2, heart3;
        private int remainingPb = 0;
        private Label text, score;
        
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
            player.Top = playground.Bottom - (playground.Bottom / 9);    

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!GameData.gameStarted)
                return;

            //BALL MOVEMENT
            ball.Left += speedX;
            ball.Top += speedY;
            
            //COLLISION OF BALL AND PLAYER
            if (ball.Bottom >= player.Top && ball.Bottom <= player.Bottom && ball.Left >= player.Left && ball.Right <= player.Right)
            {
                speedY = -speedY; //DIRECTION CHANGE
            }
            
            //COLLISIONS OF BALL AND PLAYGROUND
            if (ball.Left <= playground.Left)
                speedX = -speedX;
            
            if (ball.Right >= playground.Right)
                speedX = -speedX;
            
            if (ball.Top <= playground.Top)
                speedY = -speedY;
            
            if (ball.Bottom >= playground.Bottom)
            {
                try
                {
                    GameData.lifes--;
                    switch (GameData.lifes)
                    {
                        case 2:
                            heart3.Hide();
                            break;
                        case 1:
                            heart2.Hide();
                            break;
                        case 0:
                            heart.Hide();
                            break;
                    }

                    GameData.gameStarted = false;
                    timer1.Stop(); //BALL IS OUT SO GAME STOPS

                    GameRestart();
                    if (GameData.lifes == 0)
                    {
                        throw new OutOfLifes("");
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
                catch (OutOfLifes ex)
                {
                    timer1.Stop();
                    GameOver();
                }
            }
            
            //WHEN BALL GOES OUT OF BOUNDS
            try
            {
                if (ball.Right > playground.Right+5 || ball.Left < playground.Left-5)
                {
                    GameData.gameStarted = false;
                    speedX = 0;
                    speedY = 0;
                    ball.Top = player.Top - ball.Height;
                    ball.Left = player.Left + (player.Width / 2) - (ball.Width / 2);
                    throw new OutOfBoundsException("Do not release the ball near the edges of the map");
                }
                
            }catch (OutOfBoundsException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            //BLOCK COLLISIONS
            for (int i = 5; i >= 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (cpb[i, j] != null && ball.Bounds.IntersectsWith(cpb[i, j].Bounds))
                    {   
                        
                        cpb[i, j].Hits--;

                        if (cpb[i, j].Hits == 0)
                        {
                            playground.Controls.Remove(cpb[i, j]);
                            cpb[i, j] = null;

                            remainingPb--;
                            switch (i)
                            {
                                case 0:
                                    GameData.score += 50;
                                    break;
                                case 1:
                                    GameData.score += 25;
                                    break;
                                case 2:
                                    GameData.score += 20;
                                    break;
                                case 3:
                                    GameData.score += 15;
                                    break;
                                case 4:
                                    GameData.score += 10;
                                    break;
                                case 5:
                                    GameData.score += 5;
                                    break;
                            }
                            text.Text = "SCORE: " + GameData.score.ToString();
                        }
                        else if(cpb[i, j].Tag.Equals("blinded"))
                            cpb[i, j].BackgroundImage = Image.FromFile("../../Img/11.png");

                        speedY = -speedY;

                        score.Text = GameData.score.ToString();

                        if (remainingPb == 0)
                        {
                            //WINNING GAME
                            MessageBox.Show("YOU WON!");
                            Cursor.Show();
                            GameFinished();
                        }
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (GameData.gameStarted == false)
            {
                try
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        GameData.gameStarted = true;
                        speedX = 5;
                        speedY = -6;
                    }else if (e.KeyCode != Keys.Space)
                    {
                        throw new WrongKeyException("Press 'space' to start the game");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

            if (e.KeyCode == Keys.Escape)
                Close();
            //ESC TO QUIT
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            LoadTiles();
            panel();
        }

        private void LoadTiles()
        {
            int xAxis = 10;
            int yAxis = 6;
            remainingPb = xAxis * yAxis;

            int pbHeight = (int)(playground.Height * 0.3) / yAxis;
            int pbWidth = (playground.Width - xAxis) / xAxis;
            
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
                    
                    playground.Controls.Add(cpb[i,j]);
                    
                }
            }
        }

        private void playground_MouseMove(object sender, MouseEventArgs e)
        {
            player.Left = e.X - (player.Width/2); //CENTERS PLAYER AT THE MIDDLE OF THE CURSOR
            
            if (GameData.gameStarted == false)
            {
                //IF GAME HASNT STARTED BALL FOLLOWS PLAYER
                ball.Top = player.Top - ball.Height;
                ball.Left = player.Left + (player.Width / 2) - (ball.Width / 2);
            }
        }

        private void GameRestart()
        {
            player.Top = playground.Bottom - (playground.Bottom / 9); 
            ball.Top = player.Top - ball.Height;
            ball.Left = player.Left + (player.Width / 2) - (ball.Width / 2);
        }

        private void GameFinished()
        {
            ConnectionDB.ExecuteNonQuery($"INSERT INTO public.users(nickname, bestScore) VALUES('{NicknameReg.nick}', {GameData.score})");
            Hide();
            Cursor.Show();
            int x = 1;
            int p = GameData.score;
            new GameOver(x, p).Show();
        }

        private void GameOver()
        {
            ConnectionDB.ExecuteNonQuery($"INSERT INTO public.users(nickname, bestScore) VALUES('{NicknameReg.nick}', {GameData.score})");
            Hide();
            Cursor.Show();
            int x = 0;
            int s = GameData.score;
            new GameOver(x, s).Show();
        }

        private void panel()
        {
            //INSTANTIATING COMPONENTS
            hud = new Panel();
            heart = new PictureBox();
            heart2 = new PictureBox();
            heart3 = new PictureBox();
            text = new Label();
            score = new Label();
            
            //HUD
            hud.Width = playground.Width;
            hud.Height = (int) (Height * 0.045);
            hud.Top = playground.Bottom - hud.Height;
            hud.Anchor = AnchorStyles.Bottom;
            hud.BackColor = Color.Gray;
            
            //HEART
            heart.Height = hud.Height;
            heart.Width = heart.Height;
            heart.BackgroundImage = Image.FromFile("../../Img/minimized-heart.png");
            heart.BackgroundImageLayout = ImageLayout.Stretch;
            
            //HEART2 
            heart2.Height = hud.Height;
            heart2.Width = heart.Height;
            heart2.BackgroundImage = Image.FromFile("../../Img/minimized-heart.png");
            heart2.BackgroundImageLayout = ImageLayout.Stretch;
            
            //HEART 3
            heart3.Height = hud.Height;
            heart3.Width = heart.Height;
            heart3.BackgroundImage = Image.FromFile("../../Img/minimized-heart.png");
            heart3.BackgroundImageLayout = ImageLayout.Stretch;
            
            //HEART LOCATION
            heart2.Left = heart.Right + 1;
            heart3.Left = heart2.Right + 1;
            
            //SCORE
            text.Text = "SCORE: " + GameData.score.ToString();
            text.Font = new Font("Microsoft YaHei", 24F);
            text.Width = heart.Width * 5;
            text.ForeColor = Color.White;
            text.TextAlign = ContentAlignment.MiddleCenter;
            text.Left = hud.Right - text.Width;
            text.Height = hud.Height;
            
            //ADD
            hud.Controls.Add(heart);
            hud.Controls.Add(heart2);
            hud.Controls.Add(heart3);
            hud.Controls.Add(text);
            playground.Controls.Add(hud);
        }
        
    }
}