using System;
using System.Collections.Generic;

namespace DungeonExplorer.Player // Defines namespace in order to organize the related classes
{
    public class Player // Defining the "Player" class
    {
        // Private fields to store the player’s stats
        private string name;
        private int health;
        private List<string> inventory; // List to store multiple items

        // Constructor initializes player attributes
        public Player(string name, int health)
        {
            this.name = name; // Assigns name parameter
            this.health = health; // Assigns health value
            this.inventory = new List<string>(); // Initializes inventory as an empty list
        }

        // Method for picking up an item within a room
        public void PickUpItem(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                inventory.Add(item); // Adds item to inventory instead of replacing previous ones
            }
        }

        // Method: GetStatus()
        // Returns a formatted string showing the player's current status
        public string GetStatus()
        {
            string inventoryList = inventory.Count > 0 ? string.Join(", ", inventory) : "Empty";
            return $"Player: {name}, Health: {health}, Inventory: {inventoryList}";
        }
    }
}

