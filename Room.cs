using System;
using System.Collections.Generic;
using DungeonExplorer.Game;
using DungeonExplorer.Interfaces;

namespace DungeonExplorer
{
    // Represents a single room within the dungeon
    public class Room
    {
        private string description; // Text description of the room
        public ICollectible Item { get; private set; } // Item available in this room (e.g., weapon, shout, potion)
        private Dictionary<string, Room> exits; // Directional exits from this room to other rooms

        public Monster Monster { get; private set; } // Optional monster that may appear in the room

        // Constructor to initialize room with description, optional item, and optional monster
        public Room(string description, ICollectible item, Monster monster = null)
        {
            this.description = description;
            this.Item = item;
            this.Monster = monster;
            this.exits = new Dictionary<string, Room>();
        }

        // Defines the connections between the rooms 
        public void SetExits(Room north, Room south, Room east, Room west)
        {
            if (north != null) exits["north"] = north;
            if (south != null) exits["south"] = south;
            if (east != null) exits["east"] = east;
            if (west != null) exits["west"] = west;
        }

        // Returns the room in the given direction, or null if there isnt a connection
        public Room GetExit(string direction)
        {
            return exits.ContainsKey(direction) ? exits[direction] : null;
        }

        // Returns the room’s description
        public string GetDescription()
        {
            return description;
        }

        // Removes the monster from the room (used after defeating it)
        public void ClearMonster()
        {
            Monster = null;
        }

        // Removes the item from the room (used after picking it up)
        public void ClearItem()
        {
            Item = null;
        }
    }
}
