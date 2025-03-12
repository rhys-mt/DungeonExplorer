namespace DungeonExplorer.Program // Defines namespace for this class (Program)
{
    class Program // Defines the entry point
    {
        // Main method as entry point for the application
        static void Main()
        {
            Game.Game game = new Game.Game();
            game.Start();
        }
    }
}


