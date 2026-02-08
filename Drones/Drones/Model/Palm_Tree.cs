using MonkeyGame.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;

namespace MonkeyGame
{
    public partial class Palm_Tree
    {
        private int x;
        private int y = 150;
        private int width = 250;
        private int height = 250;

        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int WIDTH { get { return width; } }
        public int Height { get { return height; } }
        public Rectangle Hitbox { get; set; }
        public int Direction;
        

        public Palm_Tree(int x, int direction)
        {
            this.x = x;
            Direction = direction;
            Hitbox = new Rectangle(x+50, y+50, width-100, 10);
        }
    }
}
