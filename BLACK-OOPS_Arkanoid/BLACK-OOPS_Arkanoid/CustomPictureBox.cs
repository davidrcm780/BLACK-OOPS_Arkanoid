using System.Windows.Forms;

namespace BLACK_OOPS_Arkanoid
{
    public class CustomPictureBox : PictureBox
    {
        public int Golpes { get; set; } 

        public CustomPictureBox() : base() { }
    }
}