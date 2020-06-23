using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Label = System.Reflection.Emit.Label;

namespace BLACK_OOPS_Arkanoid
{
    public partial class scores : Form
    {
        public scores()
        {
            InitializeComponent();
            
        }

       


        private void scores_Load(object sender, EventArgs e)
        {
            List<string> players = new List<string>(10);
            List<string> scores = new List<string>(10);
            //CONSULTA DE NICKNAMES Y SCORES
            var sq = ConnectionDB.ExecuteQuery($"SELECT nickname FROM public.users ORDER BY bestScore DESC LIMIT 10");
            var sql = ConnectionDB.ExecuteQuery($"SELECT bestScore FROM public.users ORDER BY bestScore DESC LIMIT 10");

            foreach (DataRow dr in sq.Rows)
            {
                players.Add(dr[0].ToString());
            }

            foreach (DataRow dr in sql.Rows)
            {
                scores.Add(dr[0].ToString());
            }

            int size = players.Count;
            //Se determina si alguna de las dos listas esta vacia y se llenan
            if (size != 10)
            {
                for (int i = size; i <= 10; i++)
                {
                    players.Insert(i, "empty");
                    scores.Insert(i, "-");
                }
            }

            //Se llama a la funcion que llena los labels
                Labels_Filler(players, scores);
        }

        public void Labels_Filler(List<string> players, List<string> scores)
        {
            label12.Text = players[0];
            label13.Text = players[1];
            label14.Text = players[2];
            label15.Text = players[3];
            label16.Text = players[4];
            label17.Text = players[5];
            label18.Text = players[6];
            label19.Text = players[7];
            label20.Text = players[8];
            label21.Text = players[9];
            label22.Text = scores[0];
            label23.Text = scores[1];
            label24.Text = scores[2];
            label25.Text = scores[3];
            label26.Text = scores[4];
            label27.Text = scores[5];
            label28.Text = scores[6];
            label29.Text = scores[7];
            label30.Text = scores[8];
            label31.Text = scores[9];
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Se vuelve al menu principal
            Hide();
            new GameMenu().Show();
        }
    }

}