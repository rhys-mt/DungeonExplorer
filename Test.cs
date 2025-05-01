using System;
using DungeonExplorer.Player;
using DungeonExplorer.Game;
using DungeonExplorer.Items;

namespace DungeonExplorer
{
    public static class Test
    {
        public static void RunTests()
        {
            Console.WriteLine("Starting basic test...");

            var player = new Player.Player("TestPlayer", 100);
            player.TakeDamage(20);
            var potion = new Potion("Test Potion", 10);
            potion.Use(player);

            Console.WriteLine("Player health after healing: " + player.Health);
        }
    }
}
