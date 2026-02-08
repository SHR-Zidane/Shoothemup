using MonkeyGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGame
{
    public partial class Gorilla
    {
        private int _x;  // Position en X
        private int _y;  // Position en Y

        private int speedx;
        private int speedy;
        public int GroundY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public Rectangle Hitbox { get; set; }
        public int Direction { get; set; }

        public Gorilla(int X, int Y, int width, int height)
        {
            _x = X;
            _y = Y;
            Width = width;
            Height = height;
            // Initialisation immédiate du hitbox pour éviter null et faciliter l'affichage/collisions
            Hitbox = new Rectangle(_x, _y, Width, Height);
        }
        public void Move(int movex, int movey)
        {
            speedx= movex;
            speedy= movey;
        }

        public void stopmove(bool attacked)
        {
            speedx = 0;
            speedy = 0;
        }
        public void Update(int interval)
        {
            _x += speedx;
            _y += speedy;
            Hitbox = new Rectangle(_x, _y, Width, Height);
        }
        public bool CheckGetBanana()
        {
            return true;
        }
    }
}
