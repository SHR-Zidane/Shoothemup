using MonkeyGame.Model;
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

        BufferedGraphicsContext currentContext;
        BufferedGraphics beach;
   

        public Beach(List<player> group, List<Palm_Tree> tree, List<Gorilla> gorrilas, List<Banana> bananas)
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

            // draw Trees
            foreach (Palm_Tree palm_tree in tree)
            {
                palm_tree.Render(beach);
            }
            foreach (Banana banana in bananas)
            {
                banana.Render(beach);
            }
            // draw Monkeys
            foreach (player monkey in group)
            {
                monkey.Render(beach);
            }

            foreach (Gorilla gorilla in gorillas)
            {
                gorilla.Render(beach);
            }
            beach.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            foreach (player monkey in group)
            {
                int newGround = 400;
                if (monkey.isJumping)
                {
                    monkey.GroundY = newGround;
                }
                //monkey.Update(interval);
                monkey.GroundY = newGround;
                foreach (Palm_Tree tree in tree)
                {
                    if (monkey.Hitbox.IntersectsWith(tree.LeafHitbox))
                    {
                        if (monkey.CheckOnpalm_tree(tree))
                        {
                            monkey.GroundY = monkey.GetHeight(newGround, tree);
                            //monkey.Update(interval);
                        }
                    }
                }
                monkey.Update(interval);
            }
            foreach (Gorilla gorilla in gorillas)
            {
                int min_distance = 10000;
                Banana cible = null;
                foreach (Banana banana in bananas)
                {
                    // Défini si gorille capture une banane en touchant sa hitbox
                    if (gorilla.Hitbox.IntersectsWith(banana.Hitbox))
                    {
                        banana.IsStolen = gorilla.CheckGetBanana();
                    }
                    // Calcule la distance entre le gorille et les bananes et trouve la banane la plus proche du gorille 
                    int distance = gorilla.GetDistance(banana.X, banana.Y);
                    if (min_distance > distance)
                    {
                        min_distance = distance;
                        cible = banana;
                    }

                    if (cible != null)
                    {
                        gorilla.Move(gorilla.Direction, 0, cible);
                    }
                    gorilla.Update(interval);

                }
                // Vérifie si une banane a été capturée
                // On part de la fin vers le début
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