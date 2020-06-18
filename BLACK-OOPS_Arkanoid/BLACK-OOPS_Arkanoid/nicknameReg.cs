using System;
using System.Windows.Forms;

namespace BLACK_OOPS_Arkanoid
{
    public partial class nicknameReg : Form
    {
        public nicknameReg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            new Form1().Show();
        }
    }
}