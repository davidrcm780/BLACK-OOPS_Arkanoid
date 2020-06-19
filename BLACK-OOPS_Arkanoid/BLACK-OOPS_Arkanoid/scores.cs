using System;
using System.Windows.Forms;

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
            throw new System.NotImplementedException();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            new GameMenu().Show();
        }
    }

}