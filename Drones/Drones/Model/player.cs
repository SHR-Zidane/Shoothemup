using MonkeyGame.Model;
using System.Threading;
using System.Resources;
using MonkeyGame.Properties;
namespace MonkeyGame
{
    public partial class player
    {
        private int _x;  // Position en X
        private int _y;  // Position en Y

        private int speedx;                                 
        private int speedy;                                 

        private int velocityY = 0;
        public bool isJumping = true;
        public int GroundY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool onPalmTree = false;
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public Rectangle Hitbox { get;set; }


        public player(int X, int Y, int width, int height)
        {
            _x = X;
            _y = Y;
            GroundY = 600;
            Width = width;
            Height = height;
        }


        public void move(int movex, int movey)
        {
            speedx = movex;
            speedy = movey;
            

        }
        public void Jump()
        {
            if (!isJumping) // sauter seulement si on est au sol
            {
                velocityY = -15; // vitesse initiale (vers le haut)
                isJumping = true;
            }
        }
        public void stopmove() 
        {
            speedx = 0;
            speedy = 0;
        }


        // Cette méthode calcule le nouvel état dans lequel le joueur se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            if (Hitbox.Right > Beach.WIDTH)
            {
                _x = Beach.WIDTH - 50;
            }
            else if (Hitbox.Left < 0) 
            {
                _x = 2;
            }
            _x += speedx;
            _y += speedy;
            velocityY += 1;
            _y += velocityY;
            if (_y >= GroundY)
            {
                _y = GroundY;
                velocityY = 0;
                isJumping = false;
            }
            Hitbox = new Rectangle(_x, _y, Width, Height);
        }
        public bool CheckOnpalm_tree(Palm_Tree tree)
        {
            if (Y + Height >= tree.Hitbox.Y )
            {
                return onPalmTree = true;
            }
            else
            {
                return onPalmTree = false;
            }
        }
        public int GetHeight(int newground, Palm_Tree tree) 
        {
            newground = tree.Hitbox.Y - 50;
            return newground; 
        
        }   
    }
}
