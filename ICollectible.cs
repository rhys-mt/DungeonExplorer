public interface ICollectible
{
    string Name { get; }
    void Use(DungeonExplorer.Entities.Creature creature);
}



