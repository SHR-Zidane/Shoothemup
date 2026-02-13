using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGame.Model
{
    public partial class Projectile
    {
        protected int _x;
        protected int _y;
        protected int _speed;
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public Rectangle Hitbox { get; set; }

        public int dmg { get; set; }

        public Projectile(int x, int y, int speed, int damage, int width, int height)
        {
            _x = x;
            _y = y;
            _speed = speed;
            dmg = damage;
            Hitbox = new Rectangle(_x, _y, width, height);
        }
        public void move()
        {
            _y += _speed;
            Hitbox = new Rectangle(_x, _y, Hitbox.Width, Hitbox.Height);
        }
    }
}
