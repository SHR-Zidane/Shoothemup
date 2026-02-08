using MonkeyGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGame
{
    public partial class Banana
    {
        private int _x;
        private int _y;
        private int _width;
        private int _height;
        public bool IsStolen { get; set; }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public Rectangle Hitbox { get; set; }

        public Banana(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            IsStolen = false;
            Hitbox = new Rectangle(x, y, width, height); // Taille arbitraire pour la hitbox
            _width = width;
            _height = height;
        }
    }
}
