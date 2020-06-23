using System;
using System.Windows.Forms;
using BLACK_OOPS_Arkanoid.Exceptions;

namespace BLACK_OOPS_Arkanoid
{
    public partial class NicknameReg : Form
    {
        public static string nick;
        public NicknameReg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            

                try
                {
                    switch (textBox1.Text)
                    {
                        case string aux when aux.Length > 15:
                            throw new CharacterLimitReached("The limit of characters of a nickname is 15!");
                        case string aux when aux.Trim().Length == 0:
                            throw new EmptyNicknameException("Recuerde ingresar su nickname!!");
                        default:
                            nick = textBox1.Text;
                            Hide();
                            new GameForm().Show();
                            break;
                    }
                    
                }
                catch (CharacterLimitReached ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (EmptyNicknameException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            

            
        }
    }
}