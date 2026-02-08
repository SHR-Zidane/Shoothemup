using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGame.Model
{
    internal class Banana
    {
        private int _x;
        private int _y;
        public bool IsStolen { get; set; }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public Rectangle Hitbox { get; set; }

        public Banana(int x, int y)
        {
            _x = x;
            _y = y;
            IsStolen = false;
            Hitbox = new Rectangle(x, y, 32, 32); // Taille arbitraire pour la hitbox
        }
    }
}
