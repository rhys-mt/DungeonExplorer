using System;
using DungeonExplorer.Entities;

namespace DungeonExplorer.Game
{
    // Represents an enemy creature that the player can encounter and battle using the battle menu system
    public class Monster : Creature
    {
        public int AttackPower { get; private set; } // The base damage the certain monster deals
        public string Type { get; private set; }     // The monster type (e.g., Dragon, Draugr, Spider) all with different attacks found in differnet rooms 

        // Constructor sets up the monster's name, health, attack power, and type of monster
        public Monster(string name, int health, int attackPower, string type)
            : base(name, health)
        {
            AttackPower = attackPower;
            Type = type;
        }

        // Override of the base creatures Attack method
        // Behavior varies based on monster type examplee of dynamic polymorhpism
        public override void Attack(Creature target)
        {
            switch (Type.ToLower())
            {
                case "dragon":
                    Console.WriteLine($"{Name} the {Type} breathes fire at {target.Name}!");
                    target.TakeDamage(AttackPower + 10); // Dragons are the strongest enemy like Skyrim
                    break;

                case "draugr":
                    Console.WriteLine($"{Name} the {Type} swings its ancient axe!");
                    target.TakeDamage(AttackPower);
                    break;

                case "spider":
                    Console.WriteLine($"{Name} the {Type} spits venom at {target.Name}!");
                    target.TakeDamage(AttackPower - 2); // Slightly weaker, can be a more common enemy
                    break;

                default:
                    Console.WriteLine($"{Name} attacks {target.Name} viciously!");
                    target.TakeDamage(AttackPower);
                    break;
            }
        }
    }
}
