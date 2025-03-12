namespace DungeonExplorer //namespace for the room class with generalised naming
{
    public class Room // room class respresents the location in the game
    {
        //pricate field storing the description for the room
        private string description;

        // allows external classes to access 'item' but prevents changes
        public string Item { get; private set; }

        // constructor initializes the room with a description and item
        public Room(string description, string item)
        {
            this.description = description;
            this.Item = item;
        }

        // method "getdescription"
        // returns the room description when called
        public string GetDescription()
        {
            return description;
        }
    }
}
