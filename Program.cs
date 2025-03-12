namespace DungeonExplorer.Program //defines namespace for this class (program)
{
    class Program //defines the entry point
    {
        //main method as entry point for the application
        static void Main()
        {
            Game.Game game = new Game.Game();
            game.Start();
        }
    }
}

