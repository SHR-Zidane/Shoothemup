using MonkeyGame.Helpers;
using MonkeyGame.Properties;
using System.Resources;

namespace MonkeyGame
{

    public partial class player
    {

        public void Render(BufferedGraphics drawingSpace)
        {
            string scoreText = "Score : " + Score.ToString();

            drawingSpace.Graphics.DrawImage(Resources.player, X, Y, Width, Height);
            drawingSpace.Graphics.DrawRectangle(Pens.Red, Hitbox);
            drawingSpace.Graphics.DrawString(scoreText, scoreFont, Brushes.Black, X - 5, Y - 30);
            

            int barWidth = Width;
            int barHeight = 5;
            int posX = X;
            int posY = Y - 10;

            drawingSpace.Graphics.FillRectangle(Brushes.Red, posX, posY, barWidth, barHeight);

            float hpRatio = (float)_currentHp / _hpMax;
            float currentBarWidth = (int)(barWidth * hpRatio);

            if (currentBarWidth > 0)
            {
                drawingSpace.Graphics.FillRectangle(Brushes.Green, posX, posY, currentBarWidth, barHeight);
            }
        }
    }
}
