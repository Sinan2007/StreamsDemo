public class Player : IPlayer
{
    public string Name { get; private set; }
    public string Position { get; private set; }

    public Player(string name, string position)
    {
        Name = name;
        Position = position;
    }

    
}
