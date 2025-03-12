using System;
using System.Collections.Generic;

namespace DungeonExplorer // Namespace for the room class
{
    public class Room // Room class represents locations in the game
    {
        // Private field storing the description for the room
        private string description;

        // Public property for items in the room (can only be set inside the class)
        public string Item { get; private set; }

        // Stores room connections (North, South, East, West)
        private Dictionary<string, Room> exits;

        // Constructor initializes the room with a description and item
        public Room(string description, string item)
        {
            this.description = description;
            this.Item = item;
            this.exits = new Dictionary<string, Room>(); // Initializes an empty dictionary for exits
        }

        // Method to set exits for each room (north, south, east, west)
        public void SetExits(Room north, Room south, Room east, Room west)
        {
            if (north != null) exits["north"] = north;
            if (south != null) exits["south"] = south;
            if (east != null) exits["east"] = east;
            if (west != null) exits["west"] = west;
        }

        // Method to get the next room when moving in a direction
        public Room GetExit(string direction)
        {
            return exits.ContainsKey(direction) ? exits[direction] : null;
        }

        // Method: GetDescription()
        // Returns the room description when called
        public string GetDescription()
        {
            return description;
        }
    }
}

