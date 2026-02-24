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
    public partial class Projectile
    {
        protected int _x;
        protected int _y;
        protected int _speed;
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public Rectangle Hitbox { get; set; }
        public bool getTaken = true;

        public int dmg { get; set; }

        public Projectile(int x, int y, int speed, int damage, int width, int height)
        {
            _x = x;
            _y = y;
            _speed = speed;
            dmg = damage;
            Hitbox = new Rectangle(_x, _y, width, height);
        }
        public void move(int gorillaX, int gorillaY)
        {
            if (gorillaX > _x)
            {
                _x += _speed;
            }
            else if (gorillaX < _x)
            {
                _x -= _speed;
            }
            if (gorillaY > _y)
            {
                _y += _speed;
            }
            else if (gorillaY < _y)
            {
                _y -= _speed;
            }
            getTaken = true;
            Hitbox = new Rectangle(_x, _y, Hitbox.Width, Hitbox.Height);
        }
        public void attack()
        {
            _y += _speed;
            getTaken = false;
        }
    }
}
