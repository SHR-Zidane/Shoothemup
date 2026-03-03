using MonkeyGame;
namespace MonkeyGame
{
    

    public partial class Beach : Form
    {
        public static readonly int WIDTH = 1536;        
        public static readonly int HEIGHT = 1024;

        
        private List<player> group;
        private List<Palm_Tree> tree;
        private List<Gorilla> gorillas;
        private List<Banana> bananas;
        private List<Coconut> coconuts;
        private List<Bomb> bombs;
        BufferedGraphicsContext currentContext;
        BufferedGraphics beach;
   

        public Beach(List<player> group, List<Palm_Tree> tree, List<Gorilla> gorrilas, List<Banana> bananas, List<Coconut> coconuts, List<Bomb> bombs)
        {
            InitializeComponent();
            ClientSize = new Size(WIDTH, HEIGHT);
            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            
            beach = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this.group = group;
            this.tree = tree;
            this.gorillas = gorrilas;
            this.bananas = bananas;
            this.coconuts = coconuts;
            this.bombs = bombs;
            this.KeyPreview = true; // Ensures the form captures key events before child controls
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
        }
        
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (player monkey in group)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        monkey.move(-10, 0);
                        break;
                    case Keys.D:
                        monkey.move(10, 0);
                        if (monkey.X == 0 || monkey.X == WIDTH)
                        {
                            monkey.stopmove();
                        }
                        break;
                    case Keys.Space:
                        monkey.Jump();
                        break;
                    case Keys.Enter:
                        Bomb newBomb = monkey.ThrowBomb();
                        if (newBomb != null)
                        {
                            bombs.Add(newBomb);
                        }
                        break;
                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs i)
        {
            foreach (player monkey in group)
            {
                switch (i.KeyCode)
                {
                    case Keys.A:
                        monkey.stopmove();
                        break;
                    case Keys.D:
                        monkey.stopmove();
                        break;
                }
            }

        }
        // Affichage de la situation actuelle
        private void Render()
        {

            Image beachImg = Properties.Resources.playa;

            beach.Graphics.DrawImage(beachImg, 0, 0, WIDTH, HEIGHT);


            foreach (Palm_Tree palm_tree in tree)
            {
                palm_tree.Render(beach);
            }
            foreach (Banana banana in bananas)
            {
                banana.Render(beach);
            }

            foreach (player monkey in group)
            {
                monkey.Render(beach);
            }

            foreach (Gorilla gorilla in gorillas)
            {
                gorilla.Render(beach);
            }
            foreach (Coconut coconut in coconuts)
            {
                coconut.Render(beach);
            }
            foreach (Bomb bomb in bombs)
            {
                bomb.Render(beach);
            }
            beach.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            foreach (player monkey in group)
            {
                int newGround = 400;
                monkey.GroundY = newGround;
                foreach (Palm_Tree pTree in tree)
                {
                    if (monkey.Hitbox.IntersectsWith(pTree.LeafHitbox))
                    {
                        if (monkey.CheckOnpalm_tree(pTree))
                        {
                            monkey.GroundY = monkey.GetHeight(newGround, pTree);
                        }
                    }
                }
               /* for (int i = coconuts.Count - 1; i >= 0; i--)
                {
                    if (monkey.Hitbox.IntersectsWith(coconuts[i].Hitbox))
                    {
                        monkey.TakeDamage(1);
                        coconuts.RemoveAt(i);
                    }
                    for (int t = tree.Count - 1; t >= 0; t--)
                    {
                         if (coconuts[i].Hitbox.IntersectsWith(tree[t].))
                    }
                }*/
                monkey.Update(interval);

                for (int i = gorillas.Count - 1; i >= 0; i--)
                {
                    Gorilla gorilla = gorillas[i];
                    // On cherche d'abord la cible
                    int min_distance = 10000;
                    Banana cible = null;
                    foreach (Banana banana in bananas)
                    {
                        if (gorilla.Hitbox.IntersectsWith(banana.Hitbox))
                            banana.IsStolen = gorilla.CheckGetBanana();

                        int distance = gorilla.GetDistance(banana.X, banana.Y);
                        if (min_distance > distance)
                        {
                            min_distance = distance;
                            cible = banana;
                        }
                    }

                    // LE GORILLE BOUGUE UNE SEULE FOIS VERS LA CIBLE
                    if (cible != null)
                    {
                        gorilla.Move(cible);
                    }

                    gorilla.Update(interval); // Met à jour sa position et son timer de tir

                    // On vérifie si le gorille est prêt à attaquer
                    if (gorilla.ReadyToAttack())
                    {

                        Coconut newCoco = gorilla.HaveCoconut();
                        if (newCoco != null)
                        {
                            coconuts.Add(newCoco);
                        }
                    }
                    for (int j = bombs.Count - 1; j >= 0; j--)
                    {
                        if (bombs[j].Hitbox.IntersectsWith(gorilla.Hitbox))
                        {
                            gorilla.CurrentHp -= 1;
                            bombs.RemoveAt(j);
                            if (gorilla.CurrentHp <= 0)
                            {
                                gorillas.RemoveAt(i);
                            }
                        }
                    }
                }

                foreach (Bomb bomb in bombs)
                {
                    bomb.attack();
                }
                foreach (Coconut coco in coconuts)
                {
                    coco.attack();
                }

                foreach (Bomb bomb in bombs) bomb.attack();

                foreach (Coconut coco in coconuts) coco.attack();

                for (int i = bananas.Count - 1; i >= 0; i--)
                {
                    if (bananas[i].IsStolen)
                    {
                        bananas.RemoveAt(i);
                    }
                }
            }
        }
        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }
    }
}