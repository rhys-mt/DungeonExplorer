namespace DungeonExplorer.Player // defines namespace in order to organize the related classes
{
    public class Player //definining the "player" class
    {
        // private fields to store the player stats
        private string name;
        private int health;
        private string inventory;

        //constructor used to initialize the players stats when creating an object
        public Player(string name, int health)
        {
            this.name = name; // name parameter
            this.health = health; //health value
            this.inventory = "Empty"; //deafult inventory status
        }
        //method for picking up item within a room
        //allwos the player to pick up the item and adds to the inventory
        public void PickUpItem(string item)
        {
            inventory = item; //updates the inventory with the new item collected
        }

        // method: GetStatus()
        // returns a formatted string showing the player's current status
        public string GetStatus()
        {
            return $"Player: {name}, Health: {health}, Inventory: {inventory}";
        }
    }
}
