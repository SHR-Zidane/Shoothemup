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
    public partial class Coconut:Projectile
    {
        public Coconut(int x, int y) : base(x, y, -5, 10, 20, 20) { }
    }
}
