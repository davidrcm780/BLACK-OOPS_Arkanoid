using System.Windows.Forms;

namespace BLACK_OOPS_Arkanoid
{
    public partial class scores : Form
    {
        public scores()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            new GameMenu().Show();
        }
    }
}