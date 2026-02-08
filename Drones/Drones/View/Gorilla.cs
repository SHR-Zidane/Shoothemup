using MonkeyGame.Helpers;
using MonkeyGame.Properties;
using System.Resources;

namespace MonkeyGame
{
    public partial class Gorilla
    {
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.gorilla, X, Y, Width, Height);
            drawingSpace.Graphics.DrawRectangle(Pens.Red, Hitbox);
        }
    }
}
