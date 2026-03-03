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
        private int _x;
        private int _y = 150;
        private int width = 250;
        private int height = 250;
        private int _durability = 4;
        private int _currentDurability = 4;

        public int Durability { get { return _durability; }}
        public int CurrentDurability { get { return _currentDurability; } set { _currentDurability = value; } }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int WIDTH { get { return width; } }
        public int Height { get { return height; } }
        public Rectangle LeafHitbox { get; set; }
        public Rectangle TreeHitbox { get; set; }
        public int Direction;
        

        public Palm_Tree(int x, int direction)
        {
            this._x = x;
            Direction = direction;
            LeafHitbox = new Rectangle(x+50, _y+50, width-100, 10);
            switch (direction)
            {
                case 0:
                    TreeHitbox = new Rectangle(x + 100, 270, 35, 100);
                    break;
                case 1:
                    TreeHitbox = new Rectangle(x + 120, 270, 35, 100);
                    break;
            }
        }
    }
}
