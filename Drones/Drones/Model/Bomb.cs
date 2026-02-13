using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGame.Model
{
    public partial class Bomb:Projectile
    {
        public Bomb(int x, int y) : base(x, y, 5, 10, 10, 10) { }
    }
}
