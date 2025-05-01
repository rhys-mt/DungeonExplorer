using System;
using System.Collections.Generic;
using DungeonExplorer.Entities;
using DungeonExplorer.Interfaces;
using DungeonExplorer.Items;

namespace DungeonExplorer.Player
{
    // Represents the player character (Dovahkiin), inheriting from Creature class
    public class Player : Creature
    {
        private List<ICollectible> inventory; // List of items the player is carrying

        public int Level { get; private set; }       // Player's current level
        public int Experience { get; private set; }  // Total gathered experience points

        // Constructor initializes base Creature with name and health, and sets starting XP and level (default 1)
        public Player(string name, int health) : base(name, health)
        {
            inventory = new List<ICollectible>();
            Level = 1;
            Experience = 0;
        }

        // Adds an item to the players inventory
        public void PickUpItem(ICollectible item)
        {
            if (item != null)
            {
                inventory.Add(item);
                Console.WriteLine($"You added {item.Name} to your inventory.");
            }
        }

        // Displays all items currently in the player's inventory
        public void ViewInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");  // Error handling for an empty inventory
                return;
            }

            Console.WriteLine("Your Inventory:");
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {inventory[i].Name}");
            }
        }

        // Uses the selected item by index, optionally targeting a creature (defaults to self)
        public void UseItem(int index, Creature target = null)
        {
            if (index < 0 || index >= inventory.Count)
            {
                Console.WriteLine("Invalid item number.");
                return;
            }

            var item = inventory[index];
            item.Use(target ?? this); // If no target is given, use item on self (e.g., healing)
        }

        // Increases player's XP and handles leveling up
        public override void GainExperience(int amount)
        {
            Experience += amount;
            Console.WriteLine($"You gained {amount} XP.");

            // Level up if XP threshold reached
            if (Experience >= Level * 100)
            {
                Level++;
                Experience = 0;
                MaxHealth += 10;
                Health = MaxHealth; // Fully heal on level-up same as the real Skyrim, adds balancing to combat
                Console.WriteLine($"Congratulations! You leveled up to Level {Level}!");
                Console.WriteLine($"Health increased to {MaxHealth}.");
            }
        }

        // Gives a summary of the player's status and inventory
        public string GetStatus()
        {
            string inventoryList = inventory.Count > 0
                ? string.Join(", ", inventory.ConvertAll(i => i.Name))
                : "Empty";

            return $"Player: {Name}, Health: {Health}/{MaxHealth}, Level: {Level}, XP: {Experience}, Inventory: {inventoryList}";
        }

        // Basic attack method used in battle (default damage)
        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} with a basic strike!");
            target.TakeDamage(10);
        }
    }
}
