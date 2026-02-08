using MonkeyGame.Model;

namespace MonkeyGame
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Création des éléments du jeu
            List<player> group= new List<player>();
            List<Palm_Tree> tree= new List<Palm_Tree>();
            List<Gorilla> gorillas = new List<Gorilla>();

            group.Add(new player(Beach.WIDTH / 2, 0, 50, 50));
            int space = 100;
            tree.Add(new Palm_Tree(100, GlobalHelpers.alea.Next(0, 2)));
            for (int i = 0; i < 4; i++)
            {
                space = space + GlobalHelpers.alea.Next(120 , 300);
                tree.Add(new Palm_Tree(100 + space, GlobalHelpers.alea.Next(0, 2)));
            }
            space = 100;
            gorillas.Add(new Gorilla(50, GlobalHelpers.alea.Next(Beach.HEIGHT - 300, Beach.HEIGHT - 200), GlobalHelpers.alea.Next(50, 60), GlobalHelpers.alea.Next(50, 60)));
            for (int i = 0; i < 5; i++)
            {
                space += GlobalHelpers.alea.Next(120, 300);
                gorillas.Add(new Gorilla(50 + space, GlobalHelpers.alea.Next(Beach.HEIGHT - 300, Beach.HEIGHT - 200), GlobalHelpers.alea.Next(50, 60), GlobalHelpers.alea.Next(50, 60)));
            }

            // Démarrage
            Application.Run(new Beach(group, tree, gorillas));
        }
    }
}