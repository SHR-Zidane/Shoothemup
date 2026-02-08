using MonkeyGame.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGame
{
    public partial class Banana
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.Banana, X, Y, 40, 40);
            drawingSpace.Graphics.DrawRectangle(Pens.Red, Hitbox);
        }
    }
}
