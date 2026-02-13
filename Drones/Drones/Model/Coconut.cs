using MonkeyGame.Properties;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGame.Model
{
    public partial class Coconut:Projectile
    {
        public Coconut(int x, int y) : base(x, y, -5, 10, 10, 10) { }
    }
}
