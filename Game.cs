using System;

namespace DungeonExplorer.Game
{
    public class Game
    {
        // fields here store the player and room objects for the game to handle
        private Player.Player player;
        private Room room;

        // constructors job here is to initialize the player ( Dragon born ) and the starting room
        public Game()
        {
            //characters name and starting health points are set
            player = new Player.Player("Dragon Born", 100);
            room = new Room("A dark, mysterious Draugr burial room", "Draugr Relic");
        }
        // function will start the game and manage interactions made with the room and items within
        public void Start()
        {
            Console.WriteLine("Welcome to Skyrim Draugr Hunter!");
            //displays the room name within the dungeon along with any items within the explored room
            Console.WriteLine($"You have entered: {room.GetDescription()}");
            Console.WriteLine($"Item in the room: {room.Item}");

            // when an item is found within the room player will be asked if they want to pick it up (and add to inv)
            Console.WriteLine("Dovahkiin,looks like theres an item. Do you want to pick it up? (yes/no)");
            string input = Console.ReadLine()?.ToLower();

            //conditional if-statement will add item to inventory if selected
            if (input == "yes")
            {
                // calls the method for picking up the room's item
                player.PickUpItem(room.Item);
                Console.WriteLine("You picked up: " + room.Item);
            }

            //displays the players concluding stats (remaining health points and inventory items)
            Console.WriteLine("Player Status:");
            Console.WriteLine(player.GetStatus());
        }
    }
}
