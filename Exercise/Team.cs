using Exercise;
public class Team : ITeam
{
    public string Name { get; private set; }
    private List<IPlayer> _players = new List<IPlayer>();
    public IReadOnlyList<IPlayer> Players => _players.AsReadOnly();
    public List<string> History { get; private set; }

    public Team(string name)
    {
        Name = name;
        History = new List<string> { $"Team {name} created at {DateTime.Now}" };
    }

    public void AddPlayer(IPlayer player)
    {
        _players.Add(player);
        AddToHistory($"Player {player.Name} joined {Name} at {DateTime.Now}");
    }

    public void RemovePlayer(string playerName)
    {
        var player = _players.FirstOrDefault(p => p.Name == playerName);
        if (player != null)
        {
            _players.Remove(player);
            AddToHistory($"Player {playerName} left {Name} at {DateTime.Now}");
        }
    }

    public void AddToHistory(string message)
    {
        History.Add(message);
    }
}
