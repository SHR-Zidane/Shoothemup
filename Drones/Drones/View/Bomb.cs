using MonkeyGame;
using MonkeyGame.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MonkeyGame
{
    public partial class Bomb
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.bomb, X, Y, 20, 20);
            //drawingSpace.Graphics.DrawRectangle(Pens.Red, Hitbox);
        }
    }
}
