namespace DungeonExplorer
{
    // Entry point 
    class Program
    {
        // Main method: the first method called when the program starts
        static void Main()
        {
            // Creates an instance of the game
            var game = new Game.Game();

            // Start the game loop
            game.Start();
        }
    }
}


