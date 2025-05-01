using DungeonExplorer.Interfaces;

namespace DungeonExplorer.Entities
{
    // Abstract base class for any living entity that can engage in combat (to define this essentially anything with a health value)
    public abstract class Creature : IDamageable
    {
        public string Name { get; protected set; }     // The creatures name
        public int Health { get; protected set; }       // Current health point amount
        public int MaxHealth { get; protected set; }    // Maximum health pointt amount

        // Property to determine if the entity is still alive or dead
        public bool IsAlive => Health > 0;

        // Constructor used here will set name and starting health point
        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
        }

        // Reduces the creatures health by a inflicted amount of damage 
        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }

        // Restores health points up to the maximum health limit
        public void RestoreHealth(int amount)
        {
            Health += amount;
            if (Health > MaxHealth) Health = MaxHealth;
        }

        // Virtual method to handle experience gain (only applting for Player)
        //  overridden in Player class
        public virtual void GainExperience(int amount)
        {
            // overridden by Player
        }

        // Abstract attack method to be implemented by Player and Monster classes
        public abstract void Attack(Creature target);
    }
}
