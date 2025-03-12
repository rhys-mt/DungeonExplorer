using System;
using System.Collections.Generic;

namespace DungeonExplorer.Game
{
    public class Game
    {
        // Fields store the player and room objects for the game
        private Player.Player player;
        private Dictionary<string, Room> rooms; // Stores all rooms
        private Room currentRoom; // Tracks the player's current room

        // Constructor initializes the player (Dragon Born) and sets up the dungeon rooms
        public Game()
        {
            // The player starts with the name "Dragon Born" and 100 health points
            player = new Player.Player("Dragon Born", 100);

            // Creates multiple rooms and assigns each room an item
            rooms = new Dictionary<string, Room>
            {
                { "Burial Room", new Room("A dark, mysterious Draugr burial room", "Draugr Relic") },
                { "Dragon Chamber", new Room("A hidden chamber filled with ancient gold and artifacts. Even a skeleton key.", "Gold Claw Skeleton Key") },
                { "Urn Hallway", new Room("A long, eerie hallway leading deeper into the dungeon", "Health Potion") }
            };

            // Defines the connections between rooms (north, south, east, west)
            rooms["Burial Room"].SetExits(rooms["Dragon Chamber"], rooms["Urn Hallway"], null, null);
            rooms["Dragon Chamber"].SetExits(null, rooms["Burial Room"], null, null);
            rooms["Urn Hallway"].SetExits(rooms["Burial Room"], null, null, null);

            // The game starts in the Burial Room
            currentRoom = rooms["Burial Room"];
        }

        // The function that runs the game loop and handles player interactions
        public void Start()
        {
            Console.WriteLine("Welcome to Skyrim Draugr Hunter!");

            while (true)
            {
                Console.WriteLine($"\nYou have entered: {currentRoom.GetDescription()}");
                Console.WriteLine($"Item in the room: {currentRoom.Item}");

                // Displays game menu
                Console.WriteLine("\nOptions: ");
                Console.WriteLine("1. Pick up item");
                Console.WriteLine("2. Move to another room");
                Console.WriteLine("3. Check Dragon Born Health");
                Console.WriteLine("4. Quit Game");

                Console.Write("What do you want to do? ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    player.PickUpItem(currentRoom.Item);
                    Console.WriteLine($"You picked up: {currentRoom.Item}");
                }
                else if (choice == "2")
                {
                    Console.WriteLine("What path shall you take? (north/south/east/west)");
                    string direction = Console.ReadLine()?.ToLower();
                    MoveToRoom(direction);
                }
                else if (choice == "3")
                {
                    Console.WriteLine(player.GetStatus());
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Farewell, Dovahkiin.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        // Handles movement between rooms
        private void MoveToRoom(string direction)
        {
            Room nextRoom = currentRoom.GetExit(direction);
            if (nextRoom != null)
            {
                currentRoom = nextRoom;
                Console.WriteLine($"You move to: {currentRoom.GetDescription()}");
            }
            else
            {
                Console.WriteLine("You can't go that way.");
            }
        }
    }
}

