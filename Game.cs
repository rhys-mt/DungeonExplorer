using System;
using System.Collections.Generic;
using DungeonExplorer.Player;
using DungeonExplorer.Items;
using DungeonExplorer.Game;

namespace DungeonExplorer.Game
{
    // Main class that controls the overall flow of the game
    public class Game
    {
        private Player.Player player; // The player's character (Dovahkiin)
        private Dictionary<string, Room> rooms; // A map of all room names to their instances
        private Room currentRoom; // The room the player is currently in

        // Constructor: Initializes the player, all items, monsters, rooms, and room connections
        public Game()
        {
            player = new Player.Player("Dragonborn", 100); // Create the player with default health

            // Skyrim-themed weapons, shouts, and potions
            var ironSword = new Weapon("Iron Sword", 15);
            var dragonbane = new Weapon("Dragonbane", 25);
            var fireShout = new Shout("Yol-Toor-Shul", 30);
            var frostShout = new Shout("Fo-Krah-Di-Neh", 20);
            var healingPotion = new Potion("Minor Healing Potion", 20);
            var ultimatePotion = new Potion("Ultimate Healing Potion", 50);

            // Skyrim-style monsters with unique names, health, attack power, and type
            var draugr = new Monster("Restless Draugr", 40, 10, "Draugr");
            var dragon = new Monster("Ancient Dragon", 120, 20, "Dragon");
            var frostSpider = new Monster("Frostbite Spider", 30, 6, "Spider");

            // Rooms with flavor descriptions, items, and optionally monsters
            rooms = new Dictionary<string, Room>
            {
                { "Burial Room", new Room("An eerie graveyard? A cold tomb with flickering candles and an ancient coffin.", dragonbane, draugr) },
                { "Dragon Lair", new Room("A cavern where bones crunch underfoot. You feel watched.", fireShout, dragon) },
                { "Spider Nest", new Room("A huge spiders nest? Webs hang like curtains. Skittering echoes.", frostShout, frostSpider) },
                { "Shrine of Talos", new Room(" A shrine room? A glowing statue of Talos radiates warmth and power.", ultimatePotion) },
                { "Armory", new Room("A dusty vault? With weapons from forgotten wars.", ironSword) },
                { "Alchemist's Lab", new Room("Some sort of lab? Bubbling potions and dusty tomes cover every surface.", healingPotion) }
            };

            // Manually connect rooms by directions inputted in the game
            rooms["Burial Room"].SetExits(rooms["Dragon Lair"], rooms["Spider Nest"], rooms["Armory"], null);
            rooms["Dragon Lair"].SetExits(null, rooms["Burial Room"], rooms["Shrine of Talos"], null);
            rooms["Spider Nest"].SetExits(rooms["Burial Room"], null, rooms["Alchemist's Lab"], null);
            rooms["Alchemist's Lab"].SetExits(null, null, null, rooms["Spider Nest"]);
            rooms["Armory"].SetExits(null, null, null, rooms["Burial Room"]);
            rooms["Shrine of Talos"].SetExits(null, null, null, rooms["Dragon Lair"]);

            // Set the room the player starts upon beginning the game
            currentRoom = rooms["Burial Room"];
        }

        // Starts the game loop, handles battle, exploration, and player choices
        public void Start()
        {
            Console.WriteLine("Welcome to Skyrim: Draugr Hunter!");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"You are in: {currentRoom.GetDescription()}");

                // Combat system: if there's a monster in the room
                if (currentRoom.Monster != null && currentRoom.Monster.IsAlive)
                {
                    var monster = currentRoom.Monster;
                    Console.WriteLine($"A {monster.Type} named {monster.Name} appears!");

                    // Battle loop while both player and monster are alive and fighting
                    while (monster.IsAlive && player.IsAlive)
                    {
                        Console.WriteLine();
                        Console.WriteLine("--- Battle Controls ---");
                        Console.WriteLine("1. ATTACK!");
                        Console.WriteLine("2. POWER ATTACK!");
                        Console.WriteLine("3. View Dovahkiin Status");

                        Console.Write("Your choice: ");
                        string battleChoice = Console.ReadLine();

                        if (battleChoice == "1")
                        {
                            player.Attack(monster);
                            if (monster.IsAlive)
                            {
                                monster.Attack(player);
                            }
                        }
                        else if (battleChoice == "2")
                        {
                            // Let player pick and use an item (shout, weapon, or potion) item has to be in the inventory
                            player.ViewInventory();
                            Console.Write("Choose item number to use: ");
                            if (int.TryParse(Console.ReadLine(), out int itemIndex))
                            {
                                player.UseItem(itemIndex - 1, monster);
                            }

                            if (monster.IsAlive)
                            {
                                monster.Attack(player);
                            }
                        }
                        else if (battleChoice == "3")
                        {
                            Console.WriteLine(player.GetStatus());
                        }
                        else
                        {
                            Console.WriteLine("Invalid action.");
                        }
                    }

                    // If player died
                    if (!player.IsAlive)
                    {
                        Console.WriteLine("The Dovahkiin legend has ended. Game Over.");
                        return;
                    }

                    // If monster died
                    Console.WriteLine($"You defeated the {monster.Type}!");
                    currentRoom.ClearMonster();
                    player.GainExperience(100); // Levelling up system
                }

                // Show item if it is in the selected room
                if (currentRoom.Item != null)
                {
                    Console.WriteLine($"You see an item: {currentRoom.Item.Name}");
                }

                // Exploration & Inventory menu system
                Console.WriteLine();
                Console.WriteLine("--- Main Menu ---");
                Console.WriteLine("1. Pick up item");
                Console.WriteLine("2. Adventure to another room");
                Console.WriteLine("3. View inventory");
                Console.WriteLine("4. View character status");
                Console.WriteLine("5. Quit");

                Console.Write("What do you want to do? ");
                string choice = Console.ReadLine();

                // Handle menu input made by the player
                if (choice == "1" && currentRoom.Item != null)
                {
                    player.PickUpItem(currentRoom.Item);
                    currentRoom.ClearItem();
                }
                else if (choice == "2")
                {
                    Console.Write("Where do you want to go? (north/south/east/west): ");
                    string direction = Console.ReadLine()?.ToLower();
                    MoveToRoom(direction);
                }
                else if (choice == "3")
                {
                    player.ViewInventory();
                }
                else if (choice == "4")
                {
                    Console.WriteLine(player.GetStatus());
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Farewell, Dovahkiin.");
                    break;
                }
                else
                {
                    Console.WriteLine("That action cannot be performed.");
                }
            }
        }

        // Handles the movement logic based on direction input
        private void MoveToRoom(string direction)
        {
            Room nextRoom = currentRoom.GetExit(direction);
            if (nextRoom != null)
            {
                currentRoom = nextRoom;
                Console.WriteLine($"You move into: {currentRoom.GetDescription()}");
            }
            else
            {
                Console.WriteLine("The ruin seems to come to a dead end. Time to turn around.");
            }
        }
    }
}
