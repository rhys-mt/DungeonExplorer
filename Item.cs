using System;
using DungeonExplorer.Interfaces;
using DungeonExplorer.Entities;

namespace DungeonExplorer.Items
{
    // Abstract base class for all usable items (e.g., Weapons, Shouts, Potions)
    public abstract class Item : ICollectible
    {
        public string Name { get; protected set; }

        // All items must have a name
        public Item(string name)
        {
            Name = name;
        }

        // Abstract Use method that accepts a target creature.
        // This allows items to either heal, damage, or perform some effect.
        public abstract void Use(Creature target = null);

        // Legacy method stub, the method is not used but required for ICollectible interface signature compatibility.
        public void Use()
        {
            throw new NotImplementedException(); // This version shouldn't be called directly
        }
    }

    // A weapon deals damage to an enemy target when used
    public class Weapon : Item
    {
        public int Damage { get; private set; }

        public Weapon(string name, int damage) : base(name)
        {
            Damage = damage;
        }

        // Implements item usage as an attack on the target
        public override void Use(Creature target = null)
        {
            if (target != null)
            {
                Console.WriteLine($"You strike {target.Name} with {Name}, dealing {Damage} damage.");
                target.TakeDamage(Damage);
            }
            else
            {
                Console.WriteLine($"You swing the {Name} in the air. It deals {Damage} damage.");
            }
        }
    }

    // Shout item class which functions the same as any weapon
    public class Shout : Item
    {
        public int Damage { get; private set; }

        public Shout(string name, int damage) : base(name)
        {
            Damage = damage;
        }

        // Shouts behave like weapon attacks targeting enemies
        public override void Use(Creature target = null)
        {
            if (target != null)
            {
                Console.WriteLine($"You unleash the shout '{Name}' at {target.Name}, dealing {Damage} damage!");
                target.TakeDamage(Damage);
            }
            else
            {
                Console.WriteLine($"You shout '{Name}' into the void. It echoes powerfully.");
            }
        }
    }

    // A potion restores health to the user or target
    public class Potion : Item
    {
        public int HealAmount { get; private set; }

        public Potion(string name, int healAmount) : base(name)
        {
            HealAmount = healAmount;
        }

        // Potions restore health to the target when used
        public override void Use(Creature target = null)
        {
            if (target != null)
            {
                Console.WriteLine($"You drink the {Name} and restore {HealAmount} health.");
                target.RestoreHealth(HealAmount);
            }
            else
            {
                Console.WriteLine($"You try to use {Name}, but no target is set.");
            }
        }
    }
}
