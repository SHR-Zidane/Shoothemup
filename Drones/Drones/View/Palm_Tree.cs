using MonkeyGame.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Drawing.Text;

namespace MonkeyGame
{
    public partial class Palm_Tree
    {

        public void Render(BufferedGraphics drawingSpace)
        {
            if (Direction == 0)
            {
                drawingSpace.Graphics.DrawImage(Resources.tree, X, Y, WIDTH, Height);
                drawingSpace.Graphics.DrawRectangle(Pens.Red, LeafHitbox);
                drawingSpace.Graphics.DrawRectangle(Pens.Blue, TreeHitbox);

            }
            else
            {
                drawingSpace.Graphics.DrawImage(Resources.Tree_2, X, Y, WIDTH, Height);
                drawingSpace.Graphics.DrawRectangle(Pens.Red, LeafHitbox);
                drawingSpace.Graphics.DrawRectangle(Pens.Blue, TreeHitbox);
            }

            int bWidth = 60;
            int bHeight = 8;
            // On centre la barre au dessus du palmier
            int xBar = X + (WIDTH / 2) - (bWidth / 2);
            int yBar = Y - 15;

            float ratio = (float)_currentDurability / _durability;

            drawingSpace.Graphics.FillRectangle(Brushes.DimGray, xBar, yBar, bWidth, bHeight);

            if (ratio > 0)
            {
                drawingSpace.Graphics.FillRectangle(Brushes.Gold, xBar, yBar, (int)(bWidth * ratio), bHeight);
            }
        }
    }
}
