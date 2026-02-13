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
            }
            else
            {
                drawingSpace.Graphics.DrawImage(Resources.Tree_2, X, Y, WIDTH, Height);
                drawingSpace.Graphics.DrawRectangle(Pens.Red, LeafHitbox);
            }
        }
    }
}
