using System;
using System.Windows.Forms;

namespace BLACK_OOPS_Arkanoid
{
    public partial class NicknameReg : Form
    {
        public NicknameReg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new GameForm().Show();
        }
    }
}